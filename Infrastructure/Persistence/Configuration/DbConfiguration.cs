using Core.Domain.Entities.Mail;
using Core.Entities;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configuration;


#region Audit
public class AuditConfiguration : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.ToTable("audit", "dbo").HasKey(s => s.Id);
        builder.Property(p => p.Id).IsRequired().HasColumnName("audit_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.UserId).HasColumnName("user_id").HasColumnType("int").HasColumnOrder(2);
        builder.Property(p => p.Type).HasMaxLength(200).HasColumnName("type").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.IpAddress).HasMaxLength(200).HasColumnName("ip_address").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.UserAgent).HasMaxLength(500).HasColumnName("user_agent").HasColumnType("nvarchar").HasColumnOrder(5);
        builder.Property(p => p.TableName).HasMaxLength(200).HasColumnName("table_name").HasColumnType("nvarchar").HasColumnOrder(6);
        builder.Property(p => p.DateTime).HasColumnName("date").HasColumnType("datetime2").HasColumnOrder(7);
        builder.Property(p => p.OldValues).HasMaxLength(4000).HasColumnName("old_values").HasColumnType("nvarchar").HasColumnOrder(8);
        builder.Property(p => p.NewValues).HasMaxLength(4000).HasColumnName("new_values").HasColumnType("nvarchar").HasColumnOrder(9);
        builder.Property(p => p.AffectedColumns).HasMaxLength(4000).HasColumnName("affected_columns").HasColumnType("nvarchar").HasColumnOrder(10);
        builder.Property(p => p.PrimaryKey).HasMaxLength(4000).HasColumnName("primary_key").HasColumnType("nvarchar").HasColumnOrder(11);

    }
}
#endregion

#region Auth Configuration
public class RoleConfiguration : IEntityTypeConfiguration<Role> {
    public void Configure(EntityTypeBuilder<Role> builder) {
        builder.ToTable("role", "auth").HasKey(s => s.RoleId);
        builder.Property(p => p.RoleId).IsRequired().HasColumnName("role_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Description).HasMaxLength(200).HasColumnName("description").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(4);

        builder.HasMany(a => a.Users).WithOne(b => b.Role);

        builder.HasData(DbSeed.SeedRoles());
    }
}
public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permission", "auth").HasKey(s => s.PermissionId);
        builder.Property(p => p.PermissionId).IsRequired().HasColumnName("permission_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.DisplayText).HasMaxLength(200).HasColumnName("display_text").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.CssClass).HasMaxLength(200).HasColumnName("css_class").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.Description).HasMaxLength(200).HasColumnName("description").HasColumnType("nvarchar").HasColumnOrder(5);
        builder.Property(p => p.Grouping).HasMaxLength(200).HasColumnName("grouping").HasColumnType("bit").HasColumnOrder(6);
        builder.Property(p => p.DisplayOrder).HasColumnName("display_order").HasColumnType("int").HasColumnOrder(7);
        builder.Property(p => p.IsVisible).HasColumnName("is_visible").HasColumnType("bit").HasColumnOrder(8);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(9);
        builder.Property(p => p.ParentId).HasColumnName("parent_id").HasColumnType("int").HasColumnOrder(10);

        builder.HasMany(a => a.Childs).WithOne(b => b.Parent).HasForeignKey(b => b.ParentId);

        builder.HasData(DbSeed.SeedPermissions());

    }
}
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user", "auth").HasKey(s => s.UserId);
        builder.Property(p => p.UserId).IsRequired().HasColumnName("user_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Password).IsRequired().HasMaxLength(200).HasColumnName("password").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(200).HasColumnName("email").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.RoleId).IsRequired().HasColumnName("role_id").HasColumnType("int").HasColumnOrder(5);
        builder.Property(p => p.EmailConfirmed).HasColumnName("email_confirmed").HasColumnType("bit").HasColumnOrder(6);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(7);
        builder.Property(p => p.IsTemporaryPassword).HasColumnName("is_temporary_password").HasColumnType("bit").HasColumnOrder(8);

        builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("int").HasColumnOrder(9);
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime2").HasColumnOrder(10);
        builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("int").HasColumnOrder(11);
        builder.Property(p => p.ModifiedAt).HasColumnName("modified_at").HasColumnType("datetime2").HasColumnOrder(12);



        builder.HasData(DbSeed.SeedUsers());
    }
}
public class ModuleConfiguration : IEntityTypeConfiguration<Module> {
    public void Configure(EntityTypeBuilder<Module> builder) {
        builder.ToTable("module", "auth").HasKey(s => s.ModuleId);
        builder.Property(p => p.ModuleId).IsRequired().HasColumnName("module_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Title).HasMaxLength(200).HasColumnName("title").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.Subtitle).HasMaxLength(200).HasColumnName("subtitle").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.Description).HasMaxLength(200).HasColumnName("description").HasColumnType("nvarchar").HasColumnOrder(5);
        builder.Property(p => p.CssClass).HasMaxLength(200).HasColumnName("css_class").HasColumnType("nvarchar").HasColumnOrder(6);
        builder.Property(p => p.Route).HasMaxLength(200).HasColumnName("route").HasColumnType("nvarchar").HasColumnOrder(7);
        builder.Property(p => p.DisplayOrder).HasColumnName("display_order").HasColumnType("int").HasColumnOrder(8);
        builder.Property(p => p.IsVisible).HasColumnName("is_visible").HasColumnType("bit").HasColumnOrder(9);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(10);
        builder.Property(p => p.ParentId).HasColumnName("parent_id").HasColumnType("int").HasColumnOrder(11);

        builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("int").HasColumnOrder(12);
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime2").HasColumnOrder(13);
        builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("int").HasColumnOrder(14);
        builder.Property(p => p.ModifiedAt).HasColumnName("modified_at").HasColumnType("datetime2").HasColumnOrder(15);


        builder.HasMany(a => a.Children).WithOne(b => b.Parent).HasForeignKey(b=> b.ParentId);

        builder.HasData(DbSeed.SeedModules());
    }
}
public class ModulePermissionConfiguration : IEntityTypeConfiguration<ModulePermission>
{
    public void Configure(EntityTypeBuilder<ModulePermission> builder)
    {
        builder.ToTable("module_permission", "auth").HasKey(s => new { s.ModuleId, s.PermissionId });
        builder.Property(p => p.ModuleId).IsRequired().HasColumnName("module_id").HasColumnType("int").HasColumnOrder(1);
        builder.Property(p => p.PermissionId).IsRequired().HasColumnName("permission_id").HasColumnType("int").HasColumnOrder(2);
       
        builder.HasOne<Permission>(p => p.Permission).WithMany(p => p.ModulePermissions).HasForeignKey(p=> p.PermissionId);
        builder.HasOne<Module>(m => m.Module) .WithMany(m => m.ModulePermissions).HasForeignKey(m=> m.ModuleId);

        builder.HasData(DbSeed.SeedModulesPermissions());
    }
}
public class ModuleUserConfiguration : IEntityTypeConfiguration<ModuleUser>
{
    public void Configure(EntityTypeBuilder<ModuleUser> builder)
    {
        builder.ToTable("module_user", "auth").HasKey(mu => new { mu.ModuleId, mu.UserId, mu.PermissionId });
        builder.Property(mu => mu.ModuleId).IsRequired().HasColumnName("module_id").HasColumnType("int").HasColumnOrder(1);
        builder.Property(mu => mu.UserId).IsRequired().HasColumnName("user_id").HasColumnType("int").HasColumnOrder(2);
        builder.Property(mu => mu.PermissionId).IsRequired().HasColumnName("permission_id").HasColumnType("int").HasColumnOrder(3);

        builder.HasOne<Module>(m => m.Module).WithMany(m => m.ModuleUsers).HasForeignKey(m => m.ModuleId);
        builder.HasOne<User>(u => u.User).WithMany(u => u.ModuleUsers).HasForeignKey(u => u.UserId);
        builder.HasOne<Permission>(p => p.Permission).WithMany(p => p.ModuleUsers).HasForeignKey(p => p.PermissionId);

        builder.HasData(DbSeed.SeedModulesUser());
    }
}
public class ModuleRoleConfiguration : IEntityTypeConfiguration<ModuleRole>
{
    public void Configure(EntityTypeBuilder<ModuleRole> builder)
    {
        builder.ToTable("module_role", "auth").HasKey(mr => new { mr.ModuleId, mr.RoleId, mr.PermissionId });
        builder.Property(mr => mr.ModuleId).IsRequired().HasColumnName("module_id").HasColumnType("int").HasColumnOrder(1);
        builder.Property(mr => mr.RoleId).IsRequired().HasColumnName("role_id").HasColumnType("int").HasColumnOrder(2);
        builder.Property(mr => mr.PermissionId).IsRequired().HasColumnName("permission_id").HasColumnType("int").HasColumnOrder(3);

        builder.HasOne<Module>(m => m.Module).WithMany(m => m.ModuleRoles).HasForeignKey(m => m.ModuleId);
        builder.HasOne<Role>(r => r.Role).WithMany(r => r.ModuleRoles).HasForeignKey(r => r.RoleId);
        builder.HasOne<Permission>(p => p.Permission).WithMany(p => p.ModuleRoles).HasForeignKey(p => p.PermissionId);

        builder.HasData(DbSeed.SeedModulesRole());
    }
}
#endregion

#region Persons Configuration
public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("gender", "person").HasKey(s => s.Id);
        builder.Property(p => p.Id).IsRequired().HasColumnName("gender_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Description).HasMaxLength(200).HasColumnName("description").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.Code).HasMaxLength(200).HasColumnName("code").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(5);

        builder.HasMany(a => a.Persons).WithOne(b => b.Gender);
        builder.HasData(DbSeed.SeedGenders());
    }
}
public class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
{
    public void Configure(EntityTypeBuilder<MaritalStatus> builder)
    {
        builder.ToTable("marital_status", "person").HasKey(s => s.Id);
        builder.Property(p => p.Id).IsRequired().HasColumnName("marital_status_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Description).HasMaxLength(200).HasColumnName("description").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.Code).HasMaxLength(200).HasColumnName("code").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(5);

        builder.HasMany(a => a.Persons).WithOne(b => b.MaritalStatus);
        builder.HasData(DbSeed.SeedMaritalStatus());
    }
}
public class RelationshipConfiguration : IEntityTypeConfiguration<Relationship>
{
    public void Configure(EntityTypeBuilder<Relationship> builder)
    {
        builder.ToTable("relationship", "person").HasKey(s => s.Id);
        builder.Property(p => p.Id).IsRequired().HasColumnName("relationship_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Description).HasMaxLength(200).HasColumnName("description").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.Code).HasMaxLength(200).HasColumnName("code").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(5);

        builder.HasMany(a => a.PersonUsers).WithOne(b => b.Relationship);
        builder.HasData(DbSeed.SeedRelationship());
    }
}

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address", "person").HasKey(s => s.AddressId);
        builder.Property(p => p.AddressId).IsRequired().HasColumnName("address_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Type).HasMaxLength(200).HasColumnName("type").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Country).HasMaxLength(200).HasColumnName("country").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.State).HasMaxLength(200).HasColumnName("state").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.Municipality).HasMaxLength(200).HasColumnName("municipality").HasColumnType("nvarchar").HasColumnOrder(5);
        builder.Property(p => p.City).HasMaxLength(200).HasColumnName("city").HasColumnType("nvarchar").HasColumnOrder(6);
        builder.Property(p => p.Settlement).HasMaxLength(200).HasColumnName("settlement").HasColumnType("nvarchar").HasColumnOrder(7);
        builder.Property(p => p.Street).HasMaxLength(200).HasColumnName("street").HasColumnType("nvarchar").HasColumnOrder(8);
        builder.Property(p => p.ExteriorNumber).HasMaxLength(200).HasColumnName("exterior_number").HasColumnType("nvarchar").HasColumnOrder(9);
        builder.Property(p => p.InteriorNumber).HasMaxLength(200).HasColumnName("interior_number").HasColumnType("nvarchar").HasColumnOrder(10);
        builder.Property(p => p.Reference).HasMaxLength(200).HasColumnName("reference").HasColumnType("nvarchar").HasColumnOrder(11);
        builder.Property(p => p.PostalCode).HasMaxLength(10).HasColumnName("postal_code").HasColumnType("nvarchar").HasColumnOrder(12);
        builder.Property(p => p.Latitude).HasColumnName("latitude").HasColumnType("float").HasColumnOrder(13);
        builder.Property(p => p.Longitude).HasColumnName("longitude").HasColumnType("float").HasColumnOrder(14);

        builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("int").HasColumnOrder(15);
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime2").HasColumnOrder(16);
        builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("int").HasColumnOrder(17);
        builder.Property(p => p.ModifiedAt).HasColumnName("modified_at").HasColumnType("datetime2").HasColumnOrder(18);

        builder.HasMany(a => a.Persons).WithOne(b => b.Address);

        builder.HasData(DbSeed.SeedAddresses());
    }
}
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person", "person").HasKey(s => s.PersonId);
        builder.Property(p => p.PersonId).IsRequired().HasColumnName("person_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(200).HasColumnName("lastname").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.MiddleName).HasMaxLength(200).HasColumnName("middlename").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.GenderId).IsRequired(false).HasColumnName("gender_id").HasColumnType("int").HasColumnOrder(5);
        builder.Property(p => p.AddressId).IsRequired(false).HasColumnName("address_id").HasColumnType("int").HasColumnOrder(6);
        builder.Property(p => p.MaritalStatusId).IsRequired(false).HasColumnName("marital_status_id").HasColumnType("int").HasColumnOrder(7);
        builder.Property(p => p.Birthdate).IsRequired(false).HasColumnName("birthdate").HasColumnType("datetime2").HasColumnOrder(8);
        builder.Property(p => p.Title).HasMaxLength(200).HasColumnName("title").HasColumnType("nvarchar").HasColumnOrder(9);
        builder.Property(p => p.Email).HasMaxLength(200).HasColumnName("email").HasColumnType("nvarchar").HasColumnOrder(10);
        builder.Property(p => p.HomePhone).HasMaxLength(200).HasColumnName("home_phone").HasColumnType("nvarchar").HasColumnOrder(11);
        builder.Property(p => p.MobilePhone).HasMaxLength(200).HasColumnName("mobile_phone").HasColumnType("nvarchar").HasColumnOrder(12);
        builder.Property(p => p.OfficePhone).HasMaxLength(200).HasColumnName("office_phone").HasColumnType("nvarchar").HasColumnOrder(13);
        builder.Property(p => p.Rfc).HasMaxLength(200).HasColumnName("rfc").HasColumnType("nvarchar").HasColumnOrder(14);
        builder.Property(p => p.Curp).HasMaxLength(200).HasColumnName("curp").HasColumnType("nvarchar").HasColumnOrder(15);
        builder.Property(p => p.Photo).HasMaxLength(200).HasColumnName("photo").HasColumnType("nvarchar").HasColumnOrder(16);

        builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("int").HasColumnOrder(17);
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime2").HasColumnOrder(18);
        builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("int").HasColumnOrder(19);
        builder.Property(p => p.ModifiedAt).HasColumnName("modified_at").HasColumnType("datetime2").HasColumnOrder(20);



        builder.HasData(DbSeed.SeedPersons());
    }
}
public class PersonUserConfiguration : IEntityTypeConfiguration<PersonUser>
{
    public void Configure(EntityTypeBuilder<PersonUser> builder)
    {
        builder.ToTable("person_user", "person").HasKey(pu => new { pu.PersonId, pu.UserId });
        builder.Property(pu => pu.PersonId).IsRequired().HasColumnName("person_id").HasColumnType("int").HasColumnOrder(1);
        builder.Property(pu => pu.UserId).IsRequired().HasColumnName("user_id").HasColumnType("int").HasColumnOrder(2);
        builder.Property(pu => pu.RelationshipId).IsRequired(false).HasColumnName("relationship_id").HasColumnType("int").HasColumnOrder(3);
        builder.Property(pu => pu.Principal).IsRequired(false).HasColumnName("principal").HasColumnType("bit").HasColumnOrder(4);
       

        builder.HasOne<Person>(m => m.Person).WithMany(m => m.PersonUsers).HasForeignKey(m => m.PersonId);
        builder.HasOne<User>(r => r.User).WithMany(r => r.PersonUsers).HasForeignKey(r => r.UserId);
        builder.HasOne<Relationship>(r => r.Relationship).WithMany(r => r.PersonUsers).HasForeignKey(r => r.RelationshipId);


        builder.HasData(DbSeed.SeedPersonUsers());
    }
}
#endregion


#region Mail
public class MailTemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable("template", "mail").HasKey(s => s.TemplateId);
        builder.Property(p => p.TemplateId).IsRequired().HasColumnName("template_id").HasColumnType("int").HasColumnOrder(1).UseIdentityColumn();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(250).HasColumnName("name").HasColumnType("nvarchar").HasColumnOrder(2);
        builder.Property(p => p.Subject).IsRequired().HasMaxLength(250).HasColumnName("subject").HasColumnType("nvarchar").HasColumnOrder(3);
        builder.Property(p => p.Url).IsRequired().HasMaxLength(250).HasColumnName("url").HasColumnType("nvarchar").HasColumnOrder(4);
        builder.Property(p => p.Content).HasColumnName("content").HasColumnType("nvarchar(MAX)").HasColumnOrder(5);
        builder.Property(p => p.IsHtml).HasColumnName("is_html").HasColumnType("bit").HasColumnOrder(6);
        builder.Property(p => p.IsCustom).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(7);

        builder.HasData(DbSeed.SeedMailTemplates());
    }
}
public class MailActivationConfiguration : IEntityTypeConfiguration<Activation>
{
    public void Configure(EntityTypeBuilder<Activation> builder)
    {
        builder.ToTable("activation", "mail").HasKey(s => s.ActivationId);
        builder.Property(p => p.ActivationId).IsRequired().HasColumnName("activation_id").HasColumnType("uniqueidentifier").HasColumnOrder(1).HasDefaultValueSql("NEWID()");
        builder.Property(p => p.UserId).IsRequired().HasColumnName("user_id").HasColumnType("int").HasColumnOrder(2);
        builder.Property(p => p.Expiration).IsRequired().HasColumnName("expiration").HasColumnType("datetime2").HasColumnOrder(3);
        builder.Property(p => p.IsActive).HasColumnName("is_active").HasColumnType("bit").HasColumnOrder(4);


        builder.HasOne<User>(u => u.User).WithMany(u => u.Activations).HasForeignKey(u => u.UserId);

    }
}
#endregion


