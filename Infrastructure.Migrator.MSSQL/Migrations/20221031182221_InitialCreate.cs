using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrator.MSSQL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mail");

            migrationBuilder.EnsureSchema(
                name: "person");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "address",
                schema: "person",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    country = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    municipality = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    city = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    settlement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    exterior_number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    interior_number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "audit",
                schema: "dbo",
                columns: table => new
                {
                    audit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    user_agent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    table_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    old_values = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    new_values = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    affected_columns = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    primary_key = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit", x => x.audit_id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                schema: "person",
                columns: table => new
                {
                    gender_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.gender_id);
                });

            migrationBuilder.CreateTable(
                name: "marital_status",
                schema: "person",
                columns: table => new
                {
                    marital_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marital_status", x => x.marital_status_id);
                });

            migrationBuilder.CreateTable(
                name: "module",
                schema: "auth",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    subtitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    css_class = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    route = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    display_order = table.Column<int>(type: "int", nullable: true),
                    is_visible = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.module_id);
                    table.ForeignKey(
                        name: "FK_module_module_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "auth",
                        principalTable: "module",
                        principalColumn: "module_id");
                });

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "auth",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    display_text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    css_class = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    grouping = table.Column<bool>(type: "bit", maxLength: 200, nullable: true),
                    display_order = table.Column<int>(type: "int", nullable: true),
                    is_visible = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    parent_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.permission_id);
                    table.ForeignKey(
                        name: "FK_permission_permission_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "auth",
                        principalTable: "permission",
                        principalColumn: "permission_id");
                });

            migrationBuilder.CreateTable(
                name: "relationship",
                schema: "person",
                columns: table => new
                {
                    relationship_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relationship", x => x.relationship_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "auth",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "template",
                schema: "mail",
                columns: table => new
                {
                    template_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    content = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    is_html = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_template", x => x.template_id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                schema: "person",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    middlename = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    gender_id = table.Column<int>(type: "int", nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    marital_status_id = table.Column<int>(type: "int", nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    home_phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    mobile_phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    office_phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    rfc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    curp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    photo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.person_id);
                    table.ForeignKey(
                        name: "FK_person_address_address_id",
                        column: x => x.address_id,
                        principalSchema: "person",
                        principalTable: "address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK_person_gender_gender_id",
                        column: x => x.gender_id,
                        principalSchema: "person",
                        principalTable: "gender",
                        principalColumn: "gender_id");
                    table.ForeignKey(
                        name: "FK_person_marital_status_marital_status_id",
                        column: x => x.marital_status_id,
                        principalSchema: "person",
                        principalTable: "marital_status",
                        principalColumn: "marital_status_id");
                });

            migrationBuilder.CreateTable(
                name: "module_permission",
                schema: "auth",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_permission", x => new { x.module_id, x.permission_id });
                    table.ForeignKey(
                        name: "FK_module_permission_module_module_id",
                        column: x => x.module_id,
                        principalSchema: "auth",
                        principalTable: "module",
                        principalColumn: "module_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_module_permission_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "auth",
                        principalTable: "permission",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "module_role",
                schema: "auth",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_role", x => new { x.module_id, x.role_id, x.permission_id });
                    table.ForeignKey(
                        name: "FK_module_role_module_module_id",
                        column: x => x.module_id,
                        principalSchema: "auth",
                        principalTable: "module",
                        principalColumn: "module_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_module_role_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "auth",
                        principalTable: "permission",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_module_role_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "auth",
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "auth",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_temporary_password = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "auth",
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activation",
                schema: "mail",
                columns: table => new
                {
                    activation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activation", x => x.activation_id);
                    table.ForeignKey(
                        name: "FK_activation_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "auth",
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "module_user",
                schema: "auth",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_user", x => new { x.module_id, x.user_id, x.permission_id });
                    table.ForeignKey(
                        name: "FK_module_user_module_module_id",
                        column: x => x.module_id,
                        principalSchema: "auth",
                        principalTable: "module",
                        principalColumn: "module_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_module_user_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "auth",
                        principalTable: "permission",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_module_user_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "auth",
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_user",
                schema: "person",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    relationship_id = table.Column<int>(type: "int", nullable: true),
                    principal = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_user", x => new { x.person_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_person_user_person_person_id",
                        column: x => x.person_id,
                        principalSchema: "person",
                        principalTable: "person",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_user_relationship_relationship_id",
                        column: x => x.relationship_id,
                        principalSchema: "person",
                        principalTable: "relationship",
                        principalColumn: "relationship_id");
                    table.ForeignKey(
                        name: "FK_person_user_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "auth",
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "person",
                table: "address",
                columns: new[] { "address_id", "city", "country", "created_at", "created_by", "exterior_number", "interior_number", "latitude", "longitude", "modified_at", "modified_by", "municipality", "postal_code", "reference", "settlement", "state", "street", "type" },
                values: new object[,]
                {
                    { 1, "CDMX", "México", null, null, "1400", "202", 0.0, 0.0, null, null, "Benito Juárez", "03303", "Junto al LuckySushi", "Portales Norte", "CDMX", "Dr. Jose Maria Vertiz", "Domicilio particular" },
                    { 2, "CDMX", "México", null, null, "1400", "202", 0.0, 0.0, null, null, "Benito Juárez", "03303", "Junto al LuckySushi", "Portales Norte", "CDMX", "Dr. Jose Maria Vertiz", "Domicilio particular" }
                });

            migrationBuilder.InsertData(
                schema: "person",
                table: "gender",
                columns: new[] { "gender_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "M", "", true, "Masculino" },
                    { 2, "F", "", true, "Femenino" },
                    { 3, "-", "", true, "No-binario" }
                });

            migrationBuilder.InsertData(
                schema: "person",
                table: "marital_status",
                columns: new[] { "marital_status_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "S", "", true, "Soltero" },
                    { 2, "C", "", true, "Casado" },
                    { 3, "V", "", true, "Viudo" },
                    { 4, "D", "", true, "Divorciado" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module",
                columns: new[] { "module_id", "created_at", "created_by", "css_class", "description", "display_order", "is_active", "is_visible", "modified_at", "modified_by", "name", "parent_id", "route", "subtitle", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4040), 1, "mdi mdi-home", "", 1, true, false, null, null, "Home", null, "/", "Inicio", "Inicio" },
                    { 2, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4070), 1, "mdi mdi-settings", "", 2, true, false, null, null, "Settings", null, "/config", "Configuracion general", "Configuración" },
                    { 8, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4090), 1, "mdi mdi-reports", "", 2, true, false, null, null, "Reports", null, "/reports", "Reportes del sistema", "Reportes" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "permission",
                columns: new[] { "permission_id", "css_class", "description", "display_order", "display_text", "grouping", "is_active", "is_visible", "name", "parent_id" },
                values: new object[,]
                {
                    { 1, "", "", 1, "Access", false, true, false, "access", null },
                    { 2, "mdi mdi-plus-circle", "Crear nuevo", 2, "Nuevo", false, true, true, "create", null },
                    { 3, "mdi mdi-pencil", "Actualizar", 3, "Actualizar", false, true, true, "update", null },
                    { 4, "mdi mdi-delete", "Eliminar", 4, "Eliminar", false, true, true, "delete", null },
                    { 5, "mdi mdi-export", "Exportar", 5, "Exportar", true, true, true, "export", null }
                });

            migrationBuilder.InsertData(
                schema: "person",
                table: "relationship",
                columns: new[] { "relationship_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "H", "", true, "Hijo" },
                    { 2, "E", "", true, "Esposo(a)" },
                    { 3, "P", "", true, "Padre" },
                    { 4, "M", "", true, "Madre" },
                    { 5, "M", "", true, "Abuelo(a)" },
                    { 6, "M", "", true, "Tutor" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "role",
                columns: new[] { "role_id", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "", true, "Root" },
                    { 2, "", true, "Admin" },
                    { 3, "", true, "User" }
                });

            migrationBuilder.InsertData(
                schema: "mail",
                table: "template",
                columns: new[] { "template_id", "content", "is_active", "is_html", "name", "url" },
                values: new object[,]
                {
                    { 1, "", true, true, "Activa tu cuenta", "https://gestordoc.blob.core.windows.net/swplus-20220927/email-templates/activate-account.html" },
                    { 2, "", true, true, "¿Olvidaste tu contraseña?", "https://gestordoc.blob.core.windows.net/swplus-20220927/email-templates/new-password-request.html" },
                    { 3, "", true, true, "Bienvenido", "https://gestordoc.blob.core.windows.net/swplus-20220927/email-templates/welcome.html" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module",
                columns: new[] { "module_id", "created_at", "created_by", "css_class", "description", "display_order", "is_active", "is_visible", "modified_at", "modified_by", "name", "parent_id", "route", "subtitle", "title" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4070), 1, "mdi mdi-user", "", 1, true, false, null, null, "Users", 2, "/config/users", "Administracion de usuarios", "Usuarios" },
                    { 4, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4070), 1, "mdi mdi-mod", "", 2, true, false, null, null, "Modules", 2, "/config/modules", "Administracion de módulos", "Módulos" },
                    { 5, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4080), 1, "mdi mdi-cat", "", 3, true, false, null, null, "Catalogues", 2, "/config/cats", "Administracion de catálogos", "Catálogos" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_permission",
                columns: new[] { "module_id", "permission_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 8, 1 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_role",
                columns: new[] { "module_id", "permission_id", "role_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 8, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "permission",
                columns: new[] { "permission_id", "css_class", "description", "display_order", "display_text", "grouping", "is_active", "is_visible", "name", "parent_id" },
                values: new object[,]
                {
                    { 6, "mdi mdi-file-excel-box", "Exportar a Excel", 1, "Excel", false, true, true, "excel", 5 },
                    { 7, "mdi mdi-file-pdf-box", "Exportar a PDF", 2, "PDF", false, true, true, "pdf", 5 },
                    { 8, "mdi mdi-file-delimited", "Exportar a SCV", 3, "CSV", false, true, true, "csv", 5 }
                });

            migrationBuilder.InsertData(
                schema: "person",
                table: "person",
                columns: new[] { "person_id", "address_id", "birthdate", "created_at", "created_by", "curp", "email", "gender_id", "home_phone", "lastname", "marital_status_id", "middlename", "mobile_phone", "modified_at", "modified_by", "name", "office_phone", "photo", "rfc", "title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1983, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 31, 12, 22, 21, 48, DateTimeKind.Local).AddTicks(160), null, "", "ielizalde@swplus.com.mx", 1, "", "Elizalde", 1, "Hernandez", "5514735111", null, null, "Ivan", "", "https://gestordoc.blob.core.windows.net/swplus-20220927/assets/avatar.png", "EIHI831111", "Ing" },
                    { 2, 2, new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 31, 12, 22, 21, 48, DateTimeKind.Local).AddTicks(170), null, "", "ielizaldejr@swplus.com.mx", 1, "", "Elizalde", 1, "", "5514735111", null, null, "Ivan Jr", "", "https://gestordoc.blob.core.windows.net/swplus-20220927/assets/avatar.png", "EIHI831111", "" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "user",
                columns: new[] { "user_id", "created_at", "created_by", "email", "email_confirmed", "is_active", "is_temporary_password", "modified_at", "modified_by", "name", "password", "role_id" },
                values: new object[] { 1, new DateTime(2022, 10, 31, 12, 22, 21, 48, DateTimeKind.Local).AddTicks(8950), null, "ielizalde@swplus.com.mx", true, true, false, null, null, "ielizalde@swplus.com.mx", "AQAAAAEAACcQAAAAEAvkiEeQxy1Hy8UyXthH/+YaySd3JjAaRoqZ74PMA/Svv9M0sY25C0qmBLLOToJh2A==", 1 });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module",
                columns: new[] { "module_id", "created_at", "created_by", "css_class", "description", "display_order", "is_active", "is_visible", "modified_at", "modified_by", "name", "parent_id", "route", "subtitle", "title" },
                values: new object[,]
                {
                    { 6, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4080), 1, "mdi mdi-cat", "", 1, true, false, null, null, "Género", 5, "/config/sex", "Catálogo de géneros", "Generos" },
                    { 7, new DateTime(2022, 10, 31, 12, 22, 21, 46, DateTimeKind.Local).AddTicks(4080), 1, "mdi mdi-cat", "", 2, true, false, null, null, "País", 5, "/config/country", "Catálogo de paises", "Paises" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_permission",
                columns: new[] { "module_id", "permission_id" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_role",
                columns: new[] { "module_id", "permission_id", "role_id" },
                values: new object[,]
                {
                    { 3, 1, 1 },
                    { 3, 2, 1 },
                    { 3, 3, 1 },
                    { 3, 4, 1 },
                    { 4, 1, 1 },
                    { 4, 2, 1 },
                    { 4, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_user",
                columns: new[] { "module_id", "permission_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 3, 1, 1 },
                    { 3, 2, 1 },
                    { 3, 3, 1 },
                    { 3, 4, 1 },
                    { 4, 1, 1 },
                    { 4, 2, 1 },
                    { 4, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 1, 1 },
                    { 8, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "person",
                table: "person_user",
                columns: new[] { "person_id", "user_id", "principal", "relationship_id" },
                values: new object[,]
                {
                    { 1, 1, true, null },
                    { 2, 1, false, 1 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_permission",
                columns: new[] { "module_id", "permission_id" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_role",
                columns: new[] { "module_id", "permission_id", "role_id" },
                values: new object[,]
                {
                    { 6, 1, 1 },
                    { 6, 2, 1 },
                    { 6, 3, 1 },
                    { 6, 4, 1 },
                    { 7, 1, 1 },
                    { 7, 2, 1 },
                    { 7, 3, 1 },
                    { 7, 4, 1 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module_user",
                columns: new[] { "module_id", "permission_id", "user_id" },
                values: new object[,]
                {
                    { 6, 1, 1 },
                    { 6, 2, 1 },
                    { 6, 3, 1 },
                    { 6, 4, 1 },
                    { 7, 1, 1 },
                    { 7, 2, 1 },
                    { 7, 3, 1 },
                    { 7, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_activation_user_id",
                schema: "mail",
                table: "activation",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_module_parent_id",
                schema: "auth",
                table: "module",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_module_permission_permission_id",
                schema: "auth",
                table: "module_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_module_role_permission_id",
                schema: "auth",
                table: "module_role",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_module_role_role_id",
                schema: "auth",
                table: "module_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_module_user_permission_id",
                schema: "auth",
                table: "module_user",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_module_user_user_id",
                schema: "auth",
                table: "module_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_permission_parent_id",
                schema: "auth",
                table: "permission",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_address_id",
                schema: "person",
                table: "person",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_gender_id",
                schema: "person",
                table: "person",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_marital_status_id",
                schema: "person",
                table: "person",
                column: "marital_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_user_relationship_id",
                schema: "person",
                table: "person_user",
                column: "relationship_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_user_user_id",
                schema: "person",
                table: "person_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                schema: "auth",
                table: "user",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activation",
                schema: "mail");

            migrationBuilder.DropTable(
                name: "audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "module_permission",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "module_role",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "module_user",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "person_user",
                schema: "person");

            migrationBuilder.DropTable(
                name: "template",
                schema: "mail");

            migrationBuilder.DropTable(
                name: "module",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "person",
                schema: "person");

            migrationBuilder.DropTable(
                name: "relationship",
                schema: "person");

            migrationBuilder.DropTable(
                name: "user",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "address",
                schema: "person");

            migrationBuilder.DropTable(
                name: "gender",
                schema: "person");

            migrationBuilder.DropTable(
                name: "marital_status",
                schema: "person");

            migrationBuilder.DropTable(
                name: "role",
                schema: "auth");
        }
    }
}
