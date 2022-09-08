using System;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace Infrastructure.Data
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

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }

    }
}

