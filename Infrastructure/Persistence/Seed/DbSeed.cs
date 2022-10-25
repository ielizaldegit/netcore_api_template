using System;
using Core.Domain.Entities.Mail;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Persistence.Seed
{
    public class DbSeed
    {


        #region Auth Seed
        public static List<Role> SeedRoles()
        {

            return new List<Role>()
                    {
                        new Role{RoleId=1, Name="Root", Description= "", IsActive=true },
                        new Role{RoleId=2, Name="Admin", Description= "", IsActive=true },
                        new Role{RoleId=3, Name="User", Description= "", IsActive=true },
                    };
        }
        public static List<Permission> SeedPermissions()
        {

            return new List<Permission>()
                    {
                        new Permission{PermissionId=1, Name="access", DisplayText= "Access", CssClass="", Description= "", Grouping=false, DisplayOrder=1, IsVisible= false, IsActive=true },
                        new Permission{PermissionId=2, Name="create", DisplayText= "Nuevo", CssClass="mdi mdi-plus-circle", Description= "Crear nuevo", Grouping=false, DisplayOrder=2, IsVisible= true, IsActive=true },
                        new Permission{PermissionId=3, Name="update", DisplayText= "Actualizar", CssClass="mdi mdi-pencil", Description= "Actualizar", Grouping=false, DisplayOrder=3, IsVisible= true, IsActive=true },
                        new Permission{PermissionId=4, Name="delete", DisplayText= "Eliminar", CssClass="mdi mdi-delete", Description= "Eliminar", Grouping=false, DisplayOrder=4, IsVisible= true, IsActive=true },
                        new Permission{PermissionId=5, Name="export", DisplayText= "Exportar", CssClass="mdi mdi-export", Description= "Exportar", Grouping=true, DisplayOrder=5, IsVisible= true, IsActive=true},

                        new Permission{PermissionId=6, Name="excel", DisplayText= "Excel", CssClass="mdi mdi-file-excel-box", Description= "Exportar a Excel", Grouping=false, DisplayOrder=1, IsVisible= true, IsActive=true, ParentId = 5 },
                        new Permission{PermissionId=7, Name="pdf", DisplayText= "PDF", CssClass="mdi mdi-file-pdf-box", Description= "Exportar a PDF", Grouping=false, DisplayOrder=2, IsVisible= true, IsActive=true , ParentId = 5},
                        new Permission{PermissionId=8, Name="csv", DisplayText= "CSV", CssClass="mdi mdi-file-delimited", Description= "Exportar a SCV", Grouping=false, DisplayOrder=3, IsVisible= true, IsActive=true , ParentId = 5}

                    };
        }
        public static List<User> SeedUsers()
        {
            //Password: tokey
            return new List<User>()
                    {
                        new User{UserId=1, Name="ielizalde@swplus.com.mx", Password="AQAAAAEAACcQAAAAEAvkiEeQxy1Hy8UyXthH/+YaySd3JjAaRoqZ74PMA/Svv9M0sY25C0qmBLLOToJh2A==", Email="ielizalde@swplus.com.mx", RoleId=1, EmailConfirmed=  true, IsActive=true, CreatedAt = DateTime.Now },
                    };
        }
        public static List<Module> SeedModules()
        {

            return new List<Module>()
                {
                        new Module {ModuleId=1, Name = "Home",      Title = "Inicio",       Subtitle = "Inicio",                    Route = "/",            CssClass = "mdi mdi-home",      Description = "",   DisplayOrder = 1,   IsVisible = false, IsActive = true, CreatedBy= 1, CreatedAt = DateTime.Now },
                        new Module {ModuleId=2, Name = "Settings",  Title = "Configuración",Subtitle = "Configuracion general",     Route = "/config",      CssClass = "mdi mdi-settings",  Description = "",   DisplayOrder = 2,   IsVisible = false, IsActive = true, CreatedBy= 1, CreatedAt = DateTime.Now },
                        new Module {ModuleId=3, Name = "Users",     Title = "Usuarios",     Subtitle = "Administracion de usuarios",Route ="/config/users", CssClass ="mdi mdi-user",       Description= "",    DisplayOrder=1,     IsVisible= false, IsActive=true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},
                        new Module {ModuleId=4, Name = "Modules",   Title = "Módulos",      Subtitle = "Administracion de módulos", Route ="/config/modules",CssClass="mdi mdi-mod",        Description= "",    DisplayOrder=2,     IsVisible= false, IsActive=true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},
                        new Module {ModuleId=5, Name = "Catalogues",Title = "Catálogos",    Subtitle = "Administracion de catálogos", Route="/config/cats", CssClass ="mdi mdi-cat",        Description= "",    DisplayOrder=3,     IsVisible= false, IsActive=true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},
                        new Module {ModuleId=6, Name = "Género",    Title = "Generos",      Subtitle = "Catálogo de géneros",       Route="/config/sex",    CssClass ="mdi mdi-cat",        Description= "",    DisplayOrder=1,     IsVisible= false, IsActive=true, ParentId = 5, CreatedBy= 1, CreatedAt = DateTime.Now},
                        new Module {ModuleId=7, Name = "País",      Title = "Paises",       Subtitle = "Catálogo de paises",        Route="/config/country", CssClass ="mdi mdi-cat",        Description= "",    DisplayOrder=2,     IsVisible= false, IsActive=true, ParentId = 5, CreatedBy= 1, CreatedAt = DateTime.Now},
                        new Module {ModuleId=8, Name = "Reports",   Title = "Reportes",     Subtitle = "Reportes del sistema",      Route = "/reports",     CssClass = "mdi mdi-reports",   Description = "",   DisplayOrder = 2,   IsVisible = false, IsActive = true, CreatedBy= 1, CreatedAt = DateTime.Now }

                };
        }
        public static List<ModulePermission> SeedModulesPermissions()
        {

            return new List<ModulePermission>()
                {
                        new ModulePermission {ModuleId=1, PermissionId = 1 },
                        new ModulePermission {ModuleId=2, PermissionId = 1 },
                        new ModulePermission {ModuleId=3, PermissionId = 1 },
                        new ModulePermission {ModuleId=3, PermissionId = 2 },
                        new ModulePermission {ModuleId=3, PermissionId = 3 },
                        new ModulePermission {ModuleId=3, PermissionId = 4 },
                        new ModulePermission {ModuleId=4, PermissionId = 1 },
                        new ModulePermission {ModuleId=4, PermissionId = 2 },
                        new ModulePermission {ModuleId=4, PermissionId = 3 },
                        new ModulePermission {ModuleId=4, PermissionId = 4 },
                        new ModulePermission {ModuleId=5, PermissionId = 1 },
                        new ModulePermission {ModuleId=6, PermissionId = 1 },
                        new ModulePermission {ModuleId=6, PermissionId = 2 },
                        new ModulePermission {ModuleId=6, PermissionId = 3 },
                        new ModulePermission {ModuleId=6, PermissionId = 4 },
                        new ModulePermission {ModuleId=7, PermissionId = 1 },
                        new ModulePermission {ModuleId=7, PermissionId = 2 },
                        new ModulePermission {ModuleId=7, PermissionId = 3 },
                        new ModulePermission {ModuleId=7, PermissionId = 4 },
                        new ModulePermission {ModuleId=8, PermissionId = 1 }

                };
        }
        public static List<ModuleRole> SeedModulesRole()
        {

            return new List<ModuleRole>()
                {
                        new ModuleRole {RoleId= 1, ModuleId=1, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=2, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=3, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=3, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=3, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=3, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=4, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=4, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=4, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=4, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=5, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=8, PermissionId = 1 }

                };
        }
        public static List<ModuleUser> SeedModulesUser()
        {

            return new List<ModuleUser>()
                {
                        new ModuleUser {UserId= 1, ModuleId=1, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=2, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=3, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=3, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=3, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=3, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=4, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=4, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=4, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=4, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=5, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=8, PermissionId = 1 }

                };
        }


        #endregion


        #region Persons Seed
        public static List<Gender> SeedGenders()
        {

            return new List<Gender>()
                    {
                        new Gender{Id=1, Name="Masculino", Code="M", Description= "", IsActive=true },
                        new Gender{Id=2, Name="Femenino", Code="F",  Description= "", IsActive=true },
                        new Gender{Id=3, Name="No-binario", Code="-", Description= "", IsActive=true },
                    };
        }
        public static List<MaritalStatus> SeedMaritalStatus()
        {

            return new List<MaritalStatus>()
                    {
                        new MaritalStatus{Id=1, Name="Soltero", Code="S", Description= "", IsActive=true },
                        new MaritalStatus{Id=2, Name="Casado", Code="C",  Description= "", IsActive=true },
                        new MaritalStatus{Id=3, Name="Viudo", Code="V", Description= "", IsActive=true },
                        new MaritalStatus{Id=4, Name="Divorciado", Code="D", Description= "", IsActive=true },
                    };
        }

        public static List<Address> SeedAddresses()
        {

            return new List<Address>()
                    {
                        new Address{ AddressId=1, Type="Domicilio particular", Country="México", State="CDMX", Municipality="Benito Juárez", City="CDMX", Settlement="Portales Norte", Street="Dr. Jose Maria Vertiz", InteriorNumber="202", ExteriorNumber="1400", Reference="Junto al LuckySushi", PostalCode="03303" }
                    };
        }


        public static List<Person> SeedPersons()
        {
            return new List<Person>()
                    {
                        new Person{PersonId=1, Name="Ivan",LastName="Elizalde", MiddleName="Hernandez", GenderId=1, AddressId=1, MaritalStatusId=1, Birthdate= new DateTime(1983,11,11), Title="Ing",  Email="ielizalde@swplus.com.mx", HomePhone="", MobilePhone="5514735111", OfficePhone="", Rfc="EIHI831111", Curp="", Photo="",  CreatedAt = DateTime.Now },
                    };
        }
        public static List<PersonUser> SeedPersonUsers()
        {
            return new List<PersonUser>()
                    {
                        new PersonUser{PersonId=1, UserId=1 },
                    };
        }


        #endregion

        #region Mail

        public static List<Template> SeedMailTemplates()
        {

            return new List<Template>()
                {
                    new Template{TemplateId=1, Name="Activa tu cuenta", Url="https://gestordoc.blob.core.windows.net/swplus-20220927/email-templates/activate-account.html", Content= "", IsHtml=true, IsCustom=true }
                };
        }
        #endregion

    }
}

