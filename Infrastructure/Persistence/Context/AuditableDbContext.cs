using System;
using System.Threading;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence.Context
{
    public abstract class AuditableIdentityContext : DbContext
    {

        protected readonly ICurrentUser _currentUser;

        public AuditableIdentityContext(DbContextOptions options, ICurrentUser currentUser) : base(options)
        {
            _currentUser = currentUser;
        }

        public DbSet<Audit> AuditLogs { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try {
                var auditEntries = HandleAuditingBeforeSaveChanges(_currentUser.GetUserId(), _currentUser.GetUserIp(), _currentUser.GetUserAgent());
                int result = await base.SaveChangesAsync();
                await HandleAuditingAfterSaveChangesAsync(auditEntries);

                return result;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }


        private List<AuditEntry> HandleAuditingBeforeSaveChanges(int userId, string ip, string agent)
        {
            foreach (var entry in ChangeTracker.Entries<AuditBaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = userId;
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = DateTime.UtcNow;
                        entry.Entity.ModifiedBy = userId;
                        break;
                    case EntityState.Deleted:
                        break;
                }
            }

            ChangeTracker.DetectChanges();

            var trailEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries<AuditBaseEntity>()
                .Where(e => e.State is EntityState.Added or EntityState.Deleted or EntityState.Modified)
                .ToList())
            {
                var trailEntry = new AuditEntry(entry)
                {
                    TableName = entry.Entity.GetType().Name,
                    UserId = userId,
                    UserAgent = agent,
                    IpAddress = ip
                };
                trailEntries.Add(trailEntry);
                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        trailEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        trailEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            trailEntry.AuditType = AuditType.Create;
                            trailEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            trailEntry.AuditType = AuditType.Delete;
                            trailEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified && property.OriginalValue?.Equals(property.CurrentValue) == false)
                            {
                                trailEntry.ChangedColumns.Add(propertyName);
                                trailEntry.AuditType = AuditType.Update;
                                trailEntry.OldValues[propertyName] = property.OriginalValue;
                                trailEntry.NewValues[propertyName] = property.CurrentValue;
                            }

                            break;
                    }
                }
            }

            foreach (var auditEntry in trailEntries.Where(e => !e.HasTemporaryProperties))
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }

            return trailEntries.Where(e => e.HasTemporaryProperties).ToList();
        }

        private Task HandleAuditingAfterSaveChangesAsync(List<AuditEntry> trailEntries)
        {
            if (trailEntries == null || trailEntries.Count == 0)
            {
                return Task.CompletedTask;
            }

            foreach (var entry in trailEntries)
            {
                foreach (var prop in entry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        entry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        entry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                AuditLogs.Add(entry.ToAudit());
            }

            return SaveChangesAsync();
        }





    }
}

