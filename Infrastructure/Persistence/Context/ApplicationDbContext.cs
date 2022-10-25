
using Core.Domain.Entities.Mail;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : AuditableIdentityContext
    {

        public ApplicationDbContext(DbContextOptions options, ICurrentUser currentUser) : base(options, currentUser) {}

        public DbSet<Gender> Gender { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Template> MailTemplates { get; set; }
        public DbSet<Activation> MailActivations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }

    }
}

