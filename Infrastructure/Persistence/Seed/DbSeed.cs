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
                        new Role{RoleId=1, Name="Root", Description= "Root", IsActive=true },
                        new Role{RoleId=2, Name="Admin", Description= "Administrador", IsActive=true },
                        new Role{RoleId=3, Name="User", Description= "Usuario", IsActive=true },
                    };
        }
        public static List<Permission> SeedPermissions()
        {
            return new List<Permission>()
                    {
                        new Permission{PermissionId=1, Name="access", DisplayText= "Access", CssClass="", Description= "", Grouping=false, DisplayOrder=1, IsVisible= false, IsActive=true },
                        new Permission{PermissionId=2, Name="create", DisplayText= "Nuevo", CssClass="fa-solid fa-circle-plus", Description= "Crear nuevo", Grouping=false, DisplayOrder=2, IsVisible= true, IsActive=true },
                        new Permission{PermissionId=3, Name="update", DisplayText= "Actualizar", CssClass= "fa-solid fa-pen-to-square", Description= "Actualizar", Grouping=false, DisplayOrder=3, IsVisible= true, IsActive=true },
                        new Permission{PermissionId=4, Name="delete", DisplayText= "Eliminar", CssClass= "fa-solid fa-eraser", Description= "Eliminar", Grouping=false, DisplayOrder=4, IsVisible= true, IsActive=true },
                        new Permission{PermissionId=5, Name="export", DisplayText= "Exportar", CssClass= "fa-solid fa-file-export", Description= "Exportar", Grouping=true, DisplayOrder=5, IsVisible= true, IsActive=true},

                        new Permission{PermissionId=6, Name="excel", DisplayText= "Excel", CssClass= "fa-solid fa-file-excel", Description= "Exportar a Excel", Grouping=false, DisplayOrder=1, IsVisible= true, IsActive=true, ParentId = 5 },
                        new Permission{PermissionId=7, Name="pdf", DisplayText= "PDF", CssClass="fa-solid fa-file-pdf", Description= "Exportar a PDF", Grouping=false, DisplayOrder=2, IsVisible= true, IsActive=true , ParentId = 5},
                        new Permission{PermissionId=8, Name="csv", DisplayText= "CSV", CssClass="fa-solid fa-file-csv", Description= "Exportar a CSV", Grouping=false, DisplayOrder=3, IsVisible= true, IsActive=true , ParentId = 5},
                        new Permission{PermissionId=9, Name="authorize", DisplayText= "Autorizar", CssClass="fa-solid fa-key", Description= "Asigna roles y permisos", Grouping=false, DisplayOrder=6, IsVisible= true, IsActive=true}
                    };
        }
        public static List<User> SeedUsers()
        {
            //Password: tokey
            return new List<User>()
                    {
                        new User{UserId=1, Name="ielizalde@swplus.com.mx", Password="AQAAAAEAACcQAAAAEAvkiEeQxy1Hy8UyXthH/+YaySd3JjAaRoqZ74PMA/Svv9M0sY25C0qmBLLOToJh2A==", Email="ielizalde@swplus.com.mx", RoleId=1, EmailConfirmed=  true, IsActive=true, IsTemporaryPassword =false, CreatedAt = DateTime.Now },
                    };
        }
        public static List<Module> SeedModules()
        {

            return new List<Module>()
            {
                new Module {ModuleId=1, Name = "Home",      Title = "Inicio",           Subtitle = "Inicio",                CssClass = "fa-solid fa-house",        Description = "",   DisplayOrder =1,   IsVisible = false, IsActive = true, CreatedBy= 1, CreatedAt = DateTime.Now },
                new Module {ModuleId=2, Name = "Settings",  Title = "Configuración",    Subtitle = "Configuracion general", CssClass = "fa-solid fa-gear",         Description = "",   DisplayOrder =2,   IsVisible = false, IsActive = true, CreatedBy= 1, CreatedAt = DateTime.Now },
                new Module {ModuleId=3, Name = "Reports",   Title = "Reportes",         Subtitle = "Reportes del sistema",  CssClass = "fa-solid fa-file-lines",   Description = "",   DisplayOrder =3,   IsVisible = false, IsActive = true, CreatedBy= 1, CreatedAt = DateTime.Now },

                new Module {ModuleId=4, Name = "Dashboard", Title = "Dashboard", Subtitle = "Panel principal", Route = "/site/dashboard", CssClass = "fa-solid fa-square-poll-vertical", Description = "", DisplayOrder =1, IsVisible = true, IsActive = true, ParentId = 1, CreatedBy= 1, CreatedAt = DateTime.Now },

                new Module {ModuleId=5, Name = "Users", Title = "Usuarios", Subtitle = "Administracion de usuarios", Route = "/site/config/users", CssClass = "fa-solid fa-users", Description = "",DisplayOrder =1,IsVisible = true, IsActive = true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},
                new Module {ModuleId=6, Name = "Modules", Title = "Módulos", Subtitle = "Administracion de módulos",  Route = "/site/config/modules", CssClass = "fa-solid fa-cubes", Description = "",DisplayOrder =2,IsVisible = true, IsActive = true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},
                new Module {ModuleId=7, Name = "Roles", Title = "Roles", Subtitle = "Administracion de roles",  Route = "/site/config/roles", CssClass = "fa-solid fa-id-badge", Description = "",   DisplayOrder =3,IsVisible = true, IsActive = true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},
                new Module {ModuleId=8, Name = "Permissions", Title = "Permisos", Subtitle = "Administracion de permisos",  Route = "/site/config/permissions", CssClass = "fa-solid fa-user-shield", Description = "",DisplayOrder =4,IsVisible = true, IsActive = true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},
                new Module {ModuleId=9, Name = "Catalogues",Title = "Catálogos",        Subtitle = "Administracion de catálogos", CssClass = "fa-solid fa-rectangle-list", Description = "",   DisplayOrder =5,   IsVisible = true, IsActive = true, ParentId = 2, CreatedBy= 1, CreatedAt = DateTime.Now},

                new Module {ModuleId=10, Name = "MailTemplate", Title = "Plantillas de correo", Subtitle = "Administración de plantillas", Route = "/site/config/catalogues/mail-templates", CssClass = "fa-solid fa-envelope-open-text", Description = "",   DisplayOrder =1,   IsVisible = true, IsActive = true, ParentId = 9, CreatedBy= 1, CreatedAt = DateTime.Now},
 
                new Module {ModuleId=11, Name = "Activity", Title = "Actividad", Subtitle = "Reporte de actividad por usuario del sistema", Route = "/site/reports/activity", CssClass = "fa-solid fa-wave-square", Description = "",   DisplayOrder =1,   IsVisible = true, IsActive = true, ParentId = 3, CreatedBy= 1, CreatedAt = DateTime.Now }

            };
        }
        public static List<ModulePermission> SeedModulesPermissions()
        {

            return new List<ModulePermission>()
                {
                        new ModulePermission {ModuleId=1, PermissionId = 1 },
                        new ModulePermission {ModuleId=2, PermissionId = 1 },
                        new ModulePermission {ModuleId=3, PermissionId = 1 },

                        new ModulePermission {ModuleId=4, PermissionId = 1 },

                        new ModulePermission {ModuleId=5, PermissionId = 1 },
                        new ModulePermission {ModuleId=5, PermissionId = 2 },
                        new ModulePermission {ModuleId=5, PermissionId = 3 },
                        new ModulePermission {ModuleId=5, PermissionId = 4 },
                        new ModulePermission {ModuleId=6, PermissionId = 1 },
                        new ModulePermission {ModuleId=6, PermissionId = 2 },
                        new ModulePermission {ModuleId=6, PermissionId = 3 },
                        new ModulePermission {ModuleId=6, PermissionId = 4 },
                        new ModulePermission {ModuleId=6, PermissionId = 9 },
                        new ModulePermission {ModuleId=7, PermissionId = 1 },
                        new ModulePermission {ModuleId=7, PermissionId = 2 },
                        new ModulePermission {ModuleId=7, PermissionId = 3 },
                        new ModulePermission {ModuleId=7, PermissionId = 4 },
                        new ModulePermission {ModuleId=8, PermissionId = 1 },
                        new ModulePermission {ModuleId=8, PermissionId = 2 },
                        new ModulePermission {ModuleId=8, PermissionId = 3 },
                        new ModulePermission {ModuleId=8, PermissionId = 4 },
                        new ModulePermission {ModuleId=9, PermissionId = 1 },


                        new ModulePermission {ModuleId=10, PermissionId = 1 },
                        new ModulePermission {ModuleId=10, PermissionId = 2 },
                        new ModulePermission {ModuleId=10, PermissionId = 3 },
                        new ModulePermission {ModuleId=10, PermissionId = 4 },

                        new ModulePermission {ModuleId=11, PermissionId = 1 },
                        new ModulePermission {ModuleId=11, PermissionId = 5 },
                        new ModulePermission {ModuleId=11, PermissionId = 6 },
                        new ModulePermission {ModuleId=11, PermissionId = 7 },
                        new ModulePermission {ModuleId=11, PermissionId = 8 }


                };
        }
        public static List<ModuleRole> SeedModulesRole()
        {

            return new List<ModuleRole>()
                {
                        new ModuleRole {RoleId= 1, ModuleId=1, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=2, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=3, PermissionId = 1 },

                        new ModuleRole {RoleId= 1, ModuleId=4, PermissionId = 1 },

                        new ModuleRole {RoleId= 1, ModuleId=5, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=5, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=5, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=5, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=6, PermissionId = 9 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=7, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=8, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=8, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=8, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=8, PermissionId = 4 },
                        new ModuleRole {RoleId= 1, ModuleId=9, PermissionId = 1 },


                        new ModuleRole {RoleId= 1, ModuleId=10, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=10, PermissionId = 2 },
                        new ModuleRole {RoleId= 1, ModuleId=10, PermissionId = 3 },
                        new ModuleRole {RoleId= 1, ModuleId=10, PermissionId = 4 },

                        new ModuleRole {RoleId= 1, ModuleId=11, PermissionId = 1 },
                        new ModuleRole {RoleId= 1, ModuleId=11, PermissionId = 5 },
                        new ModuleRole {RoleId= 1, ModuleId=11, PermissionId = 6 },
                        new ModuleRole {RoleId= 1, ModuleId=11, PermissionId = 7 },
                        new ModuleRole {RoleId= 1, ModuleId=11, PermissionId = 8 }

                };
        }
        public static List<ModuleUser> SeedModulesUser()
        {

            return new List<ModuleUser>()
                {
                        new ModuleUser {UserId= 1, ModuleId=1, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=2, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=3, PermissionId = 1 },

                        new ModuleUser {UserId= 1, ModuleId=4, PermissionId = 1 },

                        new ModuleUser {UserId= 1, ModuleId=5, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=5, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=5, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=5, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=6, PermissionId = 9 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=7, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=8, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=8, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=8, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=8, PermissionId = 4 },
                        new ModuleUser {UserId= 1, ModuleId=9, PermissionId = 1 },


                        new ModuleUser {UserId= 1, ModuleId=10, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=10, PermissionId = 2 },
                        new ModuleUser {UserId= 1, ModuleId=10, PermissionId = 3 },
                        new ModuleUser {UserId= 1, ModuleId=10, PermissionId = 4 },

                        new ModuleUser {UserId= 1, ModuleId=11, PermissionId = 1 },
                        new ModuleUser {UserId= 1, ModuleId=11, PermissionId = 5 },
                        new ModuleUser {UserId= 1, ModuleId=11, PermissionId = 6 },
                        new ModuleUser {UserId= 1, ModuleId=11, PermissionId = 7 },
                        new ModuleUser {UserId= 1, ModuleId=11, PermissionId = 8 }


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
        public static List<Relationship> SeedRelationship()
        {

            return new List<Relationship>()
                    {
                        new Relationship{Id=1, Name="Hijo", Code="H", Description= "", IsActive=true },
                        new Relationship{Id=2, Name="Esposo(a)", Code="E",  Description= "", IsActive=true },
                        new Relationship{Id=3, Name="Padre", Code="P", Description= "", IsActive=true },
                        new Relationship{Id=4, Name="Madre", Code="M", Description= "", IsActive=true },
                        new Relationship{Id=5, Name="Abuelo(a)", Code="M", Description= "", IsActive=true },
                        new Relationship{Id=6, Name="Tutor", Code="M", Description= "", IsActive=true }
                    };
        }

        public static List<Address> SeedAddresses()
        {

            return new List<Address>()
            {
                new Address{ AddressId=1, Type="Domicilio particular", Country="México", State="CDMX", Municipality="Benito Juárez", City="CDMX", Settlement="Portales Norte", Street="Dr. Jose Maria Vertiz", InteriorNumber="202", ExteriorNumber="1400", Reference="Junto al LuckySushi", PostalCode="03303" },
                new Address{ AddressId=2, Type="Domicilio particular", Country="México", State="CDMX", Municipality="Benito Juárez", City="CDMX", Settlement="Portales Norte", Street="Dr. Jose Maria Vertiz", InteriorNumber="202", ExteriorNumber="1400", Reference="Junto al LuckySushi", PostalCode="03303" }

            };
        }


        public static List<Person> SeedPersons()
        {
            return new List<Person>()
            {
                new Person{PersonId=1, Name="Ivan",LastName="Elizalde", MiddleName="Hernandez", GenderId=1, AddressId=1, MaritalStatusId=1, Birthdate= new DateTime(1983,11,11), Title="Ing",  Email="ielizalde@swplus.com.mx", HomePhone="", MobilePhone="5514735111", OfficePhone="", Rfc="EIHI831111", Curp="", Photo="https://gestordoc.blob.core.windows.net/swplus-20220927/assets/avatar.png",  CreatedAt = DateTime.Now },
                new Person{PersonId=2, Name="Ivan Jr",LastName="Elizalde", MiddleName="", GenderId=1, AddressId=2, MaritalStatusId=1, Birthdate= new DateTime(2020,11,11), Title="",  Email="ielizaldejr@swplus.com.mx", HomePhone="", MobilePhone="5514735111", OfficePhone="", Rfc="EIHI831111", Curp="", Photo="https://gestordoc.blob.core.windows.net/swplus-20220927/assets/avatar.png",  CreatedAt = DateTime.Now },
            };
        }
        public static List<PersonUser> SeedPersonUsers()
        {
            return new List<PersonUser>()
            {
                new PersonUser{PersonId=1, UserId=1, Principal = true },
                new PersonUser{PersonId=2, UserId=1, Principal = false, RelationshipId = 1 }
            };
        }


        #endregion

        #region Mail

        public static List<Template> SeedMailTemplates()
        {

            return new List<Template>()
                {
                    new Template{TemplateId=1, Name="activation_account", Subject="Activa tu cuenta", Url="https://gestordoc.blob.core.windows.net/swplus-20220927/email-templates/activate-account.html", Content= "", IsHtml=true, IsCustom=true },
                    new Template{TemplateId=2, Name="forgot_password", Subject="¿Olvidaste tu contraseña?", Url="https://gestordoc.blob.core.windows.net/swplus-20220927/email-templates/new-password-request.html", Content= "", IsHtml=true, IsCustom=true },
                    new Template{TemplateId=3, Name="welcome", Subject="Bienvenido", Url="https://gestordoc.blob.core.windows.net/swplus-20220927/email-templates/welcome.html", Content= "", IsHtml=true, IsCustom=true }

                };
        }
        #endregion

    }
}

