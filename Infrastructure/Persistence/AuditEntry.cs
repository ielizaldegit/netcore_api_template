using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;


namespace Infrastructure.Persistence
{

    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }
        public int UserId { get; set; }
        public string TableName { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public AuditType AuditType { get; set; }
        public List<string> ChangedColumns { get; } = new List<string>();

        public List<PropertyEntry> TemporaryProperties { get; } = new();
        public bool HasTemporaryProperties => TemporaryProperties.Count > 0;


        public Audit ToAudit()
        {
            var audit = new Audit();
            audit.UserId = UserId;
            audit.Type = AuditType.ToString();
            audit.TableName = TableName;
            audit.IpAddress = IpAddress;
            audit.UserAgent = UserAgent;
            audit.DateTime = DateTime.UtcNow;
            audit.PrimaryKey = JsonSerializer.Serialize(KeyValues);
            audit.OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues);
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonSerializer.Serialize(ChangedColumns);
            return audit;
        }
    }
}

