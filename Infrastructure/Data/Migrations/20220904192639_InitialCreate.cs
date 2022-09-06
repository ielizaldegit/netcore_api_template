using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "person");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "address");

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
                name: "country",
                schema: "address",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.country_id);
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
                name: "postal_code",
                schema: "address",
                columns: table => new
                {
                    postal_code_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    settlement_type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    settlement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    state_id = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    municipality_id = table.Column<int>(type: "int", nullable: false),
                    municipality = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    city = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postal_code", x => x.postal_code_id);
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
                name: "state",
                schema: "address",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.state_id);
                    table.ForeignKey(
                        name: "FK_state_country_country_id",
                        column: x => x.country_id,
                        principalSchema: "address",
                        principalTable: "country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
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
                    gender_id = table.Column<int>(type: "int", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    marital_status_id = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_gender_gender_id",
                        column: x => x.gender_id,
                        principalSchema: "person",
                        principalTable: "gender",
                        principalColumn: "gender_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_marital_status_marital_status_id",
                        column: x => x.marital_status_id,
                        principalSchema: "person",
                        principalTable: "marital_status",
                        principalColumn: "marital_status_id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "municipality",
                schema: "address",
                columns: table => new
                {
                    municipality_id = table.Column<int>(type: "int", nullable: false),
                    state_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipality", x => new { x.municipality_id, x.state_id });
                    table.ForeignKey(
                        name: "FK_municipality_state_state_id",
                        column: x => x.state_id,
                        principalSchema: "address",
                        principalTable: "state",
                        principalColumn: "state_id",
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
                    user_id = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { 1, "CDMX", "México", null, null, "1400", "202", 0.0, 0.0, null, null, "Benito Juárez", "03303", "Junto al LuckySushi", "Portales Norte", "CDMX", "Dr. Jose Maria Vertiz", "Domicilio particular" });

            migrationBuilder.InsertData(
                schema: "address",
                table: "country",
                columns: new[] { "country_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "AF", null, false, "Afganistán" },
                    { 2, "AX", null, false, "Islas Gland" },
                    { 3, "AL", null, false, "Albania" },
                    { 4, "DE", null, false, "Alemania" },
                    { 5, "AD", null, false, "Andorra" },
                    { 6, "AO", null, false, "Angola" },
                    { 7, "AI", null, false, "Anguilla" },
                    { 8, "AQ", null, false, "Antártida" },
                    { 9, "AG", null, false, "Antigua y Barbuda" },
                    { 10, "AN", null, false, "Antillas Holandesas" },
                    { 11, "SA", null, false, "Arabia Saudí" },
                    { 12, "DZ", null, false, "Argelia" },
                    { 13, "AR", null, false, "Argentina" },
                    { 14, "AM", null, false, "Armenia" },
                    { 15, "AW", null, false, "Aruba" },
                    { 16, "AU", null, false, "Australia" },
                    { 17, "AT", null, false, "Austria" },
                    { 18, "AZ", null, false, "Azerbaiyán" },
                    { 19, "BS", null, false, "Bahamas" },
                    { 20, "BH", null, false, "Bahréin" },
                    { 21, "BD", null, false, "Bangladesh" },
                    { 22, "BB", null, false, "Barbados" },
                    { 23, "BY", null, false, "Bielorrusia" },
                    { 24, "BE", null, false, "Bélgica" },
                    { 25, "BZ", null, false, "Belice" },
                    { 26, "BJ", null, false, "Benin" },
                    { 27, "BM", null, false, "Bermudas" },
                    { 28, "BT", null, false, "Bhután" },
                    { 29, "BO", null, false, "Bolivia" },
                    { 30, "BA", null, false, "Bosnia y Herzegovina" },
                    { 31, "BW", null, false, "Botsuana" },
                    { 32, "BV", null, false, "Isla Bouvet" },
                    { 33, "BR", null, false, "Brasil" },
                    { 34, "BN", null, false, "Brunéi" },
                    { 35, "BG", null, false, "Bulgaria" },
                    { 36, "BF", null, false, "Burkina Faso" },
                    { 37, "BI", null, false, "Burundi" },
                    { 38, "CV", null, false, "Cabo Verde" },
                    { 39, "KY", null, false, "Islas Caimán" },
                    { 40, "KH", null, false, "Camboya" },
                    { 41, "CM", null, false, "Camerún" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "country",
                columns: new[] { "country_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 42, "CA", null, false, "Canadá" },
                    { 43, "CF", null, false, "República Centroafricana" },
                    { 44, "TD", null, false, "Chad" },
                    { 45, "CZ", null, false, "República Checa" },
                    { 46, "CL", null, false, "Chile" },
                    { 47, "CN", null, false, "China" },
                    { 48, "CY", null, false, "Chipre" },
                    { 49, "CX", null, false, "Isla de Navidad" },
                    { 50, "VA", null, false, "Ciudad del Vaticano" },
                    { 51, "CC", null, false, "Islas Cocos" },
                    { 52, "CO", null, false, "Colombia" },
                    { 53, "KM", null, false, "Comoras" },
                    { 54, "CD", null, false, "República Democrática del Congo" },
                    { 55, "CG", null, false, "Congo" },
                    { 56, "CK", null, false, "Islas Cook" },
                    { 57, "KP", null, false, "Corea del Norte" },
                    { 58, "KR", null, false, "Corea del Sur" },
                    { 59, "CI", null, false, "Costa de Marfil" },
                    { 60, "CR", null, false, "Costa Rica" },
                    { 61, "HR", null, false, "Croacia" },
                    { 62, "CU", null, false, "Cuba" },
                    { 63, "DK", null, false, "Dinamarca" },
                    { 64, "DM", null, false, "Dominica" },
                    { 65, "DO", null, false, "República Dominicana" },
                    { 66, "EC", null, false, "Ecuador" },
                    { 67, "EG", null, false, "Egipto" },
                    { 68, "SV", null, false, "El Salvador" },
                    { 69, "AE", null, false, "Emiratos Árabes Unidos" },
                    { 70, "ER", null, false, "Eritrea" },
                    { 71, "SK", null, false, "Eslovaquia" },
                    { 72, "SI", null, false, "Eslovenia" },
                    { 73, "ES", null, false, "España" },
                    { 74, "UM", null, false, "Islas ultramarinas de Estados Unidos" },
                    { 75, "US", null, false, "Estados Unidos" },
                    { 76, "EE", null, false, "Estonia" },
                    { 77, "ET", null, false, "Etiopía" },
                    { 78, "FO", null, false, "Islas Feroe" },
                    { 79, "PH", null, false, "Filipinas" },
                    { 80, "FI", null, false, "Finlandia" },
                    { 81, "FJ", null, false, "Fiyi" },
                    { 82, "FR", null, false, "Francia" },
                    { 83, "GA", null, false, "Gabón" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "country",
                columns: new[] { "country_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 84, "GM", null, false, "Gambia" },
                    { 85, "GE", null, false, "Georgia" },
                    { 86, "GS", null, false, "Islas Georgias del Sur y Sandwich del Sur" },
                    { 87, "GH", null, false, "Ghana" },
                    { 88, "GI", null, false, "Gibraltar" },
                    { 89, "GD", null, false, "Granada" },
                    { 90, "GR", null, false, "Grecia" },
                    { 91, "GL", null, false, "Groenlandia" },
                    { 92, "GP", null, false, "Guadalupe" },
                    { 93, "GU", null, false, "Guam" },
                    { 94, "GT", null, false, "Guatemala" },
                    { 95, "GF", null, false, "Guayana Francesa" },
                    { 96, "GN", null, false, "Guinea" },
                    { 97, "GQ", null, false, "Guinea Ecuatorial" },
                    { 98, "GW", null, false, "Guinea-Bissau" },
                    { 99, "GY", null, false, "Guyana" },
                    { 100, "HT", null, false, "Haití" },
                    { 101, "HM", null, false, "Islas Heard y McDonald" },
                    { 102, "HN", null, false, "Honduras" },
                    { 103, "HK", null, false, "Hong Kong" },
                    { 104, "HU", null, false, "Hungría" },
                    { 105, "IN", null, false, "India" },
                    { 106, "ID", null, false, "Indonesia" },
                    { 107, "IR", null, false, "Irán" },
                    { 108, "IQ", null, false, "Iraq" },
                    { 109, "IE", null, false, "Irlanda" },
                    { 110, "IS", null, false, "Islandia" },
                    { 111, "IL", null, false, "Israel" },
                    { 112, "IT", null, false, "Italia" },
                    { 113, "JM", null, false, "Jamaica" },
                    { 114, "JP", null, false, "Japón" },
                    { 115, "JO", null, false, "Jordania" },
                    { 116, "KZ", null, false, "Kazajstán" },
                    { 117, "KE", null, false, "Kenia" },
                    { 118, "KG", null, false, "Kirguistán" },
                    { 119, "KI", null, false, "Kiribati" },
                    { 120, "KW", null, false, "Kuwait" },
                    { 121, "LA", null, false, "Laos" },
                    { 122, "LS", null, false, "Lesotho" },
                    { 123, "LV", null, false, "Letonia" },
                    { 124, "LB", null, false, "Líbano" },
                    { 125, "LR", null, false, "Liberia" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "country",
                columns: new[] { "country_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 126, "LY", null, false, "Libia" },
                    { 127, "LI", null, false, "Liechtenstein" },
                    { 128, "LT", null, false, "Lituania" },
                    { 129, "LU", null, false, "Luxemburgo" },
                    { 130, "MO", null, false, "Macao" },
                    { 131, "MK", null, false, "ARY Macedonia" },
                    { 132, "MG", null, false, "Madagascar" },
                    { 133, "MY", null, false, "Malasia" },
                    { 134, "MW", null, false, "Malawi" },
                    { 135, "MV", null, false, "Maldivas" },
                    { 136, "ML", null, false, "Malí" },
                    { 137, "MT", null, false, "Malta" },
                    { 138, "FK", null, false, "Islas Malvinas" },
                    { 139, "MP", null, false, "Islas Marianas del Norte" },
                    { 140, "MA", null, false, "Marruecos" },
                    { 141, "MH", null, false, "Islas Marshall" },
                    { 142, "MQ", null, false, "Martinica" },
                    { 143, "MU", null, false, "Mauricio" },
                    { 144, "MR", null, false, "Mauritania" },
                    { 145, "YT", null, false, "Mayotte" },
                    { 146, "MX", null, true, "México" },
                    { 147, "FM", null, false, "Micronesia" },
                    { 148, "MD", null, false, "Moldavia" },
                    { 149, "MC", null, false, "Mónaco" },
                    { 150, "MN", null, false, "Mongolia" },
                    { 151, "MS", null, false, "Montserrat" },
                    { 152, "MZ", null, false, "Mozambique" },
                    { 153, "MM", null, false, "Myanmar" },
                    { 154, "NA", null, false, "Namibia" },
                    { 155, "NR", null, false, "Nauru" },
                    { 156, "NP", null, false, "Nepal" },
                    { 157, "NI", null, false, "Nicaragua" },
                    { 158, "NE", null, false, "Níger" },
                    { 159, "NG", null, false, "Nigeria" },
                    { 160, "NU", null, false, "Niue" },
                    { 161, "NF", null, false, "Isla Norfolk" },
                    { 162, "NO", null, false, "Noruega" },
                    { 163, "NC", null, false, "Nueva Caledonia" },
                    { 164, "NZ", null, false, "Nueva Zelanda" },
                    { 165, "OM", null, false, "Omán" },
                    { 166, "NL", null, false, "Países Bajos" },
                    { 167, "PK", null, false, "Pakistán" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "country",
                columns: new[] { "country_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 168, "PW", null, false, "Palau" },
                    { 169, "PS", null, false, "Palestina" },
                    { 170, "PA", null, false, "Panamá" },
                    { 171, "PG", null, false, "Papúa Nueva Guinea" },
                    { 172, "PY", null, false, "Paraguay" },
                    { 173, "PE", null, false, "Perú" },
                    { 174, "PN", null, false, "Islas Pitcairn" },
                    { 175, "PF", null, false, "Polinesia Francesa" },
                    { 176, "PL", null, false, "Polonia" },
                    { 177, "PT", null, false, "Portugal" },
                    { 178, "PR", null, false, "Puerto Rico" },
                    { 179, "QA", null, false, "Qatar" },
                    { 180, "GB", null, false, "Reino Unido" },
                    { 181, "RE", null, false, "Reunión" },
                    { 182, "RW", null, false, "Ruanda" },
                    { 183, "RO", null, false, "Rumania" },
                    { 184, "RU", null, false, "Rusia" },
                    { 185, "EH", null, false, "Sahara Occidental" },
                    { 186, "SB", null, false, "Islas Salomón" },
                    { 187, "WS", null, false, "Samoa" },
                    { 188, "AS", null, false, "Samoa Americana" },
                    { 189, "KN", null, false, "San Cristóbal y Nevis" },
                    { 190, "SM", null, false, "San Marino" },
                    { 191, "PM", null, false, "San Pedro y Miquelón" },
                    { 192, "VC", null, false, "San Vicente y las Granadinas" },
                    { 193, "SH", null, false, "Santa Helena" },
                    { 194, "LC", null, false, "Santa Lucía" },
                    { 195, "ST", null, false, "Santo Tomé y Príncipe" },
                    { 196, "SN", null, false, "Senegal" },
                    { 197, "CS", null, false, "Serbia y Montenegro" },
                    { 198, "SC", null, false, "Seychelles" },
                    { 199, "SL", null, false, "Sierra Leona" },
                    { 200, "SG", null, false, "Singapur" },
                    { 201, "SY", null, false, "Siria" },
                    { 202, "SO", null, false, "Somalia" },
                    { 203, "LK", null, false, "Sri Lanka" },
                    { 204, "SZ", null, false, "Suazilandia" },
                    { 205, "ZA", null, false, "Sudáfrica" },
                    { 206, "SD", null, false, "Sudán" },
                    { 207, "SE", null, false, "Suecia" },
                    { 208, "CH", null, false, "Suiza" },
                    { 209, "SR", null, false, "Surinam" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "country",
                columns: new[] { "country_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 210, "SJ", null, false, "Svalbard y Jan Mayen" },
                    { 211, "TH", null, false, "Tailandia" },
                    { 212, "TW", null, false, "Taiwán" },
                    { 213, "TZ", null, false, "Tanzania" },
                    { 214, "TJ", null, false, "Tayikistán" },
                    { 215, "IO", null, false, "Territorio Británico del Océano Índico" },
                    { 216, "TF", null, false, "Territorios Australes Franceses" },
                    { 217, "TL", null, false, "Timor Oriental" },
                    { 218, "TG", null, false, "Togo" },
                    { 219, "TK", null, false, "Tokelau" },
                    { 220, "TO", null, false, "Tonga" },
                    { 221, "TT", null, false, "Trinidad y Tobago" },
                    { 222, "TN", null, false, "Túnez" },
                    { 223, "TC", null, false, "Islas Turcas y Caicos" },
                    { 224, "TM", null, false, "Turkmenistán" },
                    { 225, "TR", null, false, "Turquía" },
                    { 226, "TV", null, false, "Tuvalu" },
                    { 227, "UA", null, false, "Ucrania" },
                    { 228, "UG", null, false, "Uganda" },
                    { 229, "UY", null, false, "Uruguay" },
                    { 230, "UZ", null, false, "Uzbekistán" },
                    { 231, "VU", null, false, "Vanuatu" },
                    { 232, "VE", null, false, "Venezuela" },
                    { 233, "VN", null, false, "Vietnam" },
                    { 234, "VG", null, false, "Islas Vírgenes Británicas" },
                    { 235, "VI", null, false, "Islas Vírgenes de los Estados Unidos" },
                    { 236, "WF", null, false, "Wallis y Futuna" },
                    { 237, "YE", null, false, "Yemen" },
                    { 238, "DJ", null, false, "Yibuti" },
                    { 239, "ZM", null, false, "Zambia" },
                    { 240, "ZW", null, false, "Zimbabue" }
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
                    { 1, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1670), 1, "mdi mdi-home", "", 1, true, false, null, null, "Home", null, "/", "Inicio", "Inicio" },
                    { 2, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1720), 1, "mdi mdi-settings", "", 2, true, false, null, null, "Settings", null, "/config", "Configuracion general", "Configuración" },
                    { 8, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1740), 1, "mdi mdi-reports", "", 2, true, false, null, null, "Reports", null, "/reports", "Reportes del sistema", "Reportes" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "permission",
                columns: new[] { "permission_id", "css_class", "description", "display_order", "display_text", "grouping", "is_active", "is_visible", "name", "parent_id" },
                values: new object[] { 1, "", "", 1, "Access", false, true, false, "access", null });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "permission",
                columns: new[] { "permission_id", "css_class", "description", "display_order", "display_text", "grouping", "is_active", "is_visible", "name", "parent_id" },
                values: new object[,]
                {
                    { 2, "mdi mdi-plus-circle", "Crear nuevo", 2, "Nuevo", false, true, true, "create", null },
                    { 3, "mdi mdi-pencil", "Actualizar", 3, "Actualizar", false, true, true, "update", null },
                    { 4, "mdi mdi-delete", "Eliminar", 4, "Eliminar", false, true, true, "delete", null },
                    { 5, "mdi mdi-export", "Exportar", 5, "Exportar", true, true, true, "export", null }
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
                schema: "auth",
                table: "module",
                columns: new[] { "module_id", "created_at", "created_by", "css_class", "description", "display_order", "is_active", "is_visible", "modified_at", "modified_by", "name", "parent_id", "route", "subtitle", "title" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1720), 1, "mdi mdi-user", "", 1, true, false, null, null, "Users", 2, "/config/users", "Administracion de usuarios", "Usuarios" },
                    { 4, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1730), 1, "mdi mdi-mod", "", 2, true, false, null, null, "Modules", 2, "/config/modules", "Administracion de módulos", "Módulos" },
                    { 5, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1730), 1, "mdi mdi-cat", "", 3, true, false, null, null, "Catalogues", 2, "/config/cats", "Administracion de catálogos", "Catálogos" }
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
                values: new object[] { 1, 1, new DateTime(1983, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 4, 14, 26, 39, 70, DateTimeKind.Local).AddTicks(6920), null, "", "ielizalde@swplus.com.mx", 1, "", "Elizalde", 1, "Hernandez", "5514735111", null, null, "Ivan", "", "", "EIHI831111", "Ing" });

            migrationBuilder.InsertData(
                schema: "address",
                table: "state",
                columns: new[] { "state_id", "code", "country_id", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "", 146, null, true, "Aguascalientes" },
                    { 2, "", 146, null, true, "Baja California" },
                    { 3, "", 146, null, true, "Baja California Sur" },
                    { 4, "", 146, null, true, "Campeche" },
                    { 5, "", 146, null, true, "Coahuila" },
                    { 6, "", 146, null, true, "Colima" },
                    { 7, "", 146, null, true, "Chiapas" },
                    { 8, "", 146, null, true, "Chihuahua" },
                    { 9, "", 146, null, true, "Ciudad de México" },
                    { 10, "", 146, null, true, "Durango" },
                    { 11, "", 146, null, true, "Guanajuato" },
                    { 12, "", 146, null, true, "Guerrero" },
                    { 13, "", 146, null, true, "Hidalgo" },
                    { 14, "", 146, null, true, "Jalisco" },
                    { 15, "", 146, null, true, "México" },
                    { 16, "", 146, null, true, "Michoacán" },
                    { 17, "", 146, null, true, "Morelos" },
                    { 18, "", 146, null, true, "Nayarit" },
                    { 19, "", 146, null, true, "Nuevo León" },
                    { 20, "", 146, null, true, "Oaxaca" },
                    { 21, "", 146, null, true, "Puebla" },
                    { 22, "", 146, null, true, "Querétaro" },
                    { 23, "", 146, null, true, "Quintana Roo" },
                    { 24, "", 146, null, true, "San Luis Potosí" },
                    { 25, "", 146, null, true, "Sinaloa" },
                    { 26, "", 146, null, true, "Sonora" },
                    { 27, "", 146, null, true, "Tabasco" },
                    { 28, "", 146, null, true, "Tamaulipas" },
                    { 29, "", 146, null, true, "Tlaxcala" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "state",
                columns: new[] { "state_id", "code", "country_id", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 30, "", 146, null, true, "Veracruz" },
                    { 31, "", 146, null, true, "Yucatán" },
                    { 32, "", 146, null, true, "Zacatecas" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "user",
                columns: new[] { "user_id", "created_at", "created_by", "email", "email_confirmed", "is_active", "modified_at", "modified_by", "name", "password", "role_id" },
                values: new object[] { 1, new DateTime(2022, 9, 4, 14, 26, 39, 71, DateTimeKind.Local).AddTicks(6250), null, "ielizalde@swplus.com.mx", true, true, null, null, "ielizalde@swplus.com.mx", "AQAAAAEAACcQAAAAEAvkiEeQxy1Hy8UyXthH/+YaySd3JjAaRoqZ74PMA/Svv9M0sY25C0qmBLLOToJh2A==", 1 });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "module",
                columns: new[] { "module_id", "created_at", "created_by", "css_class", "description", "display_order", "is_active", "is_visible", "modified_at", "modified_by", "name", "parent_id", "route", "subtitle", "title" },
                values: new object[,]
                {
                    { 6, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1730), 1, "mdi mdi-cat", "", 1, true, false, null, null, "Género", 5, "/config/sex", "Catálogo de géneros", "Generos" },
                    { 7, new DateTime(2022, 9, 4, 14, 26, 39, 68, DateTimeKind.Local).AddTicks(1740), 1, "mdi mdi-cat", "", 2, true, false, null, null, "País", 5, "/config/country", "Catálogo de paises", "Paises" }
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
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, 1, "", null, true, "Aguascalientes" },
                    { 1, 2, "", null, true, "Ensenada" },
                    { 1, 3, "", null, true, "Comondú" },
                    { 1, 4, "", null, true, "Calkiní" },
                    { 1, 5, "", null, true, "Abasolo" },
                    { 1, 6, "", null, true, "Armería" },
                    { 1, 7, "", null, true, "Acacoyagua" },
                    { 1, 8, "", null, true, "Ahumada" },
                    { 1, 10, "", null, true, "Canatlán" },
                    { 1, 11, "", null, true, "Abasolo" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 1, 12, "", null, true, "Acapulco de Juárez" },
                    { 1, 13, "", null, true, "Acatlán" },
                    { 1, 14, "", null, true, "Acatic" },
                    { 1, 15, "", null, true, "Acambay de Ruíz Castañeda" },
                    { 1, 16, "", null, true, "Acuitzio" },
                    { 1, 17, "", null, true, "Amacuzac" },
                    { 1, 18, "", null, true, "Acaponeta" },
                    { 1, 19, "", null, true, "Abasolo" },
                    { 1, 20, "", null, true, "Abejones" },
                    { 1, 21, "", null, true, "Acajete" },
                    { 1, 22, "", null, true, "Amealco de Bonfil" },
                    { 1, 23, "", null, true, "Cozumel" },
                    { 1, 24, "", null, true, "Ahualulco" },
                    { 1, 25, "", null, true, "Ahome" },
                    { 1, 26, "", null, true, "Aconchi" },
                    { 1, 27, "", null, true, "Balancán" },
                    { 1, 28, "", null, true, "Abasolo" },
                    { 1, 29, "", null, true, "Amaxac de Guerrero" },
                    { 1, 30, "", null, true, "Acajete" },
                    { 1, 31, "", null, true, "Abalá" },
                    { 1, 32, "", null, true, "Apozol" },
                    { 2, 1, "", null, true, "Asientos" },
                    { 2, 2, "", null, true, "Mexicali" },
                    { 2, 3, "", null, true, "Mulegé" },
                    { 2, 4, "", null, true, "Campeche" },
                    { 2, 5, "", null, true, "Acuña" },
                    { 2, 6, "", null, true, "Colima" },
                    { 2, 7, "", null, true, "Acala" },
                    { 2, 8, "", null, true, "Aldama" },
                    { 2, 9, "", null, true, "Azcapotzalco" },
                    { 2, 10, "", null, true, "Canelas" },
                    { 2, 11, "", null, true, "Acámbaro" },
                    { 2, 12, "", null, true, "Ahuacuotzingo" },
                    { 2, 13, "", null, true, "Acaxochitlán" },
                    { 2, 14, "", null, true, "Acatlán de Juárez" },
                    { 2, 15, "", null, true, "Acolman" },
                    { 2, 16, "", null, true, "Aguililla" },
                    { 2, 17, "", null, true, "Atlatlahucan" },
                    { 2, 18, "", null, true, "Ahuacatlán" },
                    { 2, 19, "", null, true, "Agualeguas" },
                    { 2, 20, "", null, true, "Acatlán de Pérez Figueroa" },
                    { 2, 21, "", null, true, "Acateno" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 2, 22, "", null, true, "Pinal de Amoles" },
                    { 2, 23, "", null, true, "Felipe Carrillo Puerto" },
                    { 2, 24, "", null, true, "Alaquines" },
                    { 2, 25, "", null, true, "Angostura" },
                    { 2, 26, "", null, true, "Agua Prieta" },
                    { 2, 27, "", null, true, "Cárdenas" },
                    { 2, 28, "", null, true, "Aldama" },
                    { 2, 29, "", null, true, "Apetatitlán de Antonio Carvajal" },
                    { 2, 30, "", null, true, "Acatlán" },
                    { 2, 31, "", null, true, "Acanceh" },
                    { 2, 32, "", null, true, "Apulco" },
                    { 3, 1, "", null, true, "Calvillo" },
                    { 3, 2, "", null, true, "Tecate" },
                    { 3, 3, "", null, true, "La Paz" },
                    { 3, 4, "", null, true, "Carmen" },
                    { 3, 5, "", null, true, "Allende" },
                    { 3, 6, "", null, true, "Comala" },
                    { 3, 7, "", null, true, "Acapetahua" },
                    { 3, 8, "", null, true, "Allende" },
                    { 3, 9, "", null, true, "Coyoacán" },
                    { 3, 10, "", null, true, "Coneto de Comonfort" },
                    { 3, 11, "", null, true, "San Miguel de Allende" },
                    { 3, 12, "", null, true, "Ajuchitlán del Progreso" },
                    { 3, 13, "", null, true, "Actopan" },
                    { 3, 14, "", null, true, "Ahualulco de Mercado" },
                    { 3, 15, "", null, true, "Aculco" },
                    { 3, 16, "", null, true, "Álvaro Obregón" },
                    { 3, 17, "", null, true, "Axochiapan" },
                    { 3, 18, "", null, true, "Amatlán de Cañas" },
                    { 3, 19, "", null, true, "Los Aldamas" },
                    { 3, 20, "", null, true, "Asunción Cacalotepec" },
                    { 3, 21, "", null, true, "Acatlán" },
                    { 3, 22, "", null, true, "Arroyo Seco" },
                    { 3, 23, "", null, true, "Isla Mujeres" },
                    { 3, 24, "", null, true, "Aquismón" },
                    { 3, 25, "", null, true, "Badiraguato" },
                    { 3, 26, "", null, true, "Alamos" },
                    { 3, 27, "", null, true, "Centla" },
                    { 3, 28, "", null, true, "Altamira" },
                    { 3, 29, "", null, true, "Atlangatepec" },
                    { 3, 30, "", null, true, "Acayucan" },
                    { 3, 31, "", null, true, "Akil" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 3, 32, "", null, true, "Atolinga" },
                    { 4, 1, "", null, true, "Cosío" },
                    { 4, 2, "", null, true, "Tijuana" },
                    { 4, 4, "", null, true, "Champotón" },
                    { 4, 5, "", null, true, "Arteaga" },
                    { 4, 6, "", null, true, "Coquimatlán" },
                    { 4, 7, "", null, true, "Altamirano" },
                    { 4, 8, "", null, true, "Aquiles Serdán" },
                    { 4, 9, "", null, true, "Cuajimalpa de Morelos" },
                    { 4, 10, "", null, true, "Cuencamé" },
                    { 4, 11, "", null, true, "Apaseo el Alto" },
                    { 4, 12, "", null, true, "Alcozauca de Guerrero" },
                    { 4, 13, "", null, true, "Agua Blanca de Iturbide" },
                    { 4, 14, "", null, true, "Amacueca" },
                    { 4, 15, "", null, true, "Almoloya de Alquisiras" },
                    { 4, 16, "", null, true, "Angamacutiro" },
                    { 4, 17, "", null, true, "Ayala" },
                    { 4, 18, "", null, true, "Compostela" },
                    { 4, 19, "", null, true, "Allende" },
                    { 4, 20, "", null, true, "Asunción Cuyotepeji" },
                    { 4, 21, "", null, true, "Acatzingo" },
                    { 4, 22, "", null, true, "Cadereyta de Montes" },
                    { 4, 23, "", null, true, "Othón P. Blanco" },
                    { 4, 24, "", null, true, "Armadillo de los Infante" },
                    { 4, 25, "", null, true, "Concordia" },
                    { 4, 26, "", null, true, "Altar" },
                    { 4, 27, "", null, true, "Centro" },
                    { 4, 28, "", null, true, "Antiguo Morelos" },
                    { 4, 29, "", null, true, "Atltzayanca" },
                    { 4, 30, "", null, true, "Actopan" },
                    { 4, 31, "", null, true, "Baca" },
                    { 4, 32, "", null, true, "Benito Juárez" },
                    { 5, 1, "", null, true, "Jesús María" },
                    { 5, 2, "", null, true, "Playas de Rosarito" },
                    { 5, 4, "", null, true, "Hecelchakán" },
                    { 5, 5, "", null, true, "Candela" },
                    { 5, 6, "", null, true, "Cuauhtémoc" },
                    { 5, 7, "", null, true, "Amatán" },
                    { 5, 8, "", null, true, "Ascensión" },
                    { 5, 9, "", null, true, "Gustavo A. Madero" },
                    { 5, 10, "", null, true, "Durango" },
                    { 5, 11, "", null, true, "Apaseo el Grande" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 5, 12, "", null, true, "Alpoyeca" },
                    { 5, 13, "", null, true, "Ajacuba" },
                    { 5, 14, "", null, true, "Amatitán" },
                    { 5, 15, "", null, true, "Almoloya de Juárez" },
                    { 5, 16, "", null, true, "Angangueo" },
                    { 5, 17, "", null, true, "Coatlán del Río" },
                    { 5, 18, "", null, true, "Huajicori" },
                    { 5, 19, "", null, true, "Anáhuac" },
                    { 5, 20, "", null, true, "Asunción Ixtaltepec" },
                    { 5, 21, "", null, true, "Acteopan" },
                    { 5, 22, "", null, true, "Colón" },
                    { 5, 23, "", null, true, "Benito Juárez" },
                    { 5, 24, "", null, true, "Cárdenas" },
                    { 5, 25, "", null, true, "Cosalá" },
                    { 5, 26, "", null, true, "Arivechi" },
                    { 5, 27, "", null, true, "Comalcalco" },
                    { 5, 28, "", null, true, "Burgos" },
                    { 5, 29, "", null, true, "Apizaco" },
                    { 5, 30, "", null, true, "Acula" },
                    { 5, 31, "", null, true, "Bokobá" },
                    { 5, 32, "", null, true, "Calera" },
                    { 6, 1, "", null, true, "Pabellón de Arteaga" },
                    { 6, 4, "", null, true, "Hopelchén" },
                    { 6, 5, "", null, true, "Castaños" },
                    { 6, 6, "", null, true, "Ixtlahuacán" },
                    { 6, 7, "", null, true, "Amatenango de la Frontera" },
                    { 6, 8, "", null, true, "Bachíniva" },
                    { 6, 9, "", null, true, "Iztacalco" },
                    { 6, 10, "", null, true, "General Simón Bolívar" },
                    { 6, 11, "", null, true, "Atarjea" },
                    { 6, 12, "", null, true, "Apaxtla" },
                    { 6, 13, "", null, true, "Alfajayucan" },
                    { 6, 14, "", null, true, "Ameca" },
                    { 6, 15, "", null, true, "Almoloya del Río" },
                    { 6, 16, "", null, true, "Apatzingán" },
                    { 6, 17, "", null, true, "Cuautla" },
                    { 6, 18, "", null, true, "Ixtlán del Río" },
                    { 6, 19, "", null, true, "Apodaca" },
                    { 6, 20, "", null, true, "Asunción Nochixtlán" },
                    { 6, 21, "", null, true, "Ahuacatlán" },
                    { 6, 22, "", null, true, "Corregidora" },
                    { 6, 23, "", null, true, "José María Morelos" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 6, 24, "", null, true, "Catorce" },
                    { 6, 25, "", null, true, "Culiacán" },
                    { 6, 26, "", null, true, "Arizpe" },
                    { 6, 27, "", null, true, "Cunduacán" },
                    { 6, 28, "", null, true, "Bustamante" },
                    { 6, 29, "", null, true, "Calpulalpan" },
                    { 6, 30, "", null, true, "Acultzingo" },
                    { 6, 31, "", null, true, "Buctzotz" },
                    { 6, 32, "", null, true, "Cañitas de Felipe Pescador" },
                    { 7, 1, "", null, true, "Rincón de Romos" },
                    { 7, 4, "", null, true, "Palizada" },
                    { 7, 5, "", null, true, "Cuatro Ciénegas" },
                    { 7, 6, "", null, true, "Manzanillo" },
                    { 7, 7, "", null, true, "Amatenango del Valle" },
                    { 7, 8, "", null, true, "Balleza" },
                    { 7, 9, "", null, true, "Iztapalapa" },
                    { 7, 10, "", null, true, "Gómez Palacio" },
                    { 7, 11, "", null, true, "Celaya" },
                    { 7, 12, "", null, true, "Arcelia" },
                    { 7, 13, "", null, true, "Almoloya" },
                    { 7, 14, "", null, true, "San Juanito de Escobedo" },
                    { 7, 15, "", null, true, "Amanalco" },
                    { 7, 16, "", null, true, "Aporo" },
                    { 7, 17, "", null, true, "Cuernavaca" },
                    { 7, 18, "", null, true, "Jala" },
                    { 7, 19, "", null, true, "Aramberri" },
                    { 7, 20, "", null, true, "Asunción Ocotlán" },
                    { 7, 21, "", null, true, "Ahuatlán" },
                    { 7, 22, "", null, true, "Ezequiel Montes" },
                    { 7, 23, "", null, true, "Lázaro Cárdenas" },
                    { 7, 24, "", null, true, "Cedral" },
                    { 7, 25, "", null, true, "Choix" },
                    { 7, 26, "", null, true, "Atil" },
                    { 7, 27, "", null, true, "Emiliano Zapata" },
                    { 7, 28, "", null, true, "Camargo" },
                    { 7, 29, "", null, true, "El Carmen Tequexquitla" },
                    { 7, 30, "", null, true, "Camarón de Tejeda" },
                    { 7, 31, "", null, true, "Cacalchén" },
                    { 7, 32, "", null, true, "Concepción del Oro" },
                    { 8, 1, "", null, true, "San José de Gracia" },
                    { 8, 3, "", null, true, "Los Cabos" },
                    { 8, 4, "", null, true, "Tenabo" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 8, 5, "", null, true, "Escobedo" },
                    { 8, 6, "", null, true, "Minatitlán" },
                    { 8, 7, "", null, true, "Angel Albino Corzo" },
                    { 8, 8, "", null, true, "Batopilas" },
                    { 8, 9, "", null, true, "La Magdalena Contreras" },
                    { 8, 10, "", null, true, "Guadalupe Victoria" },
                    { 8, 11, "", null, true, "Manuel Doblado" },
                    { 8, 12, "", null, true, "Atenango del Río" },
                    { 8, 13, "", null, true, "Apan" },
                    { 8, 14, "", null, true, "Arandas" },
                    { 8, 15, "", null, true, "Amatepec" },
                    { 8, 16, "", null, true, "Aquila" },
                    { 8, 17, "", null, true, "Emiliano Zapata" },
                    { 8, 18, "", null, true, "Xalisco" },
                    { 8, 19, "", null, true, "Bustamante" },
                    { 8, 20, "", null, true, "Asunción Tlacolulita" },
                    { 8, 21, "", null, true, "Ahuazotepec" },
                    { 8, 22, "", null, true, "Huimilpan" },
                    { 8, 23, "", null, true, "Solidaridad" },
                    { 8, 24, "", null, true, "Cerritos" },
                    { 8, 25, "", null, true, "Elota" },
                    { 8, 26, "", null, true, "Bacadéhuachi" },
                    { 8, 27, "", null, true, "Huimanguillo" },
                    { 8, 28, "", null, true, "Casas" },
                    { 8, 29, "", null, true, "Cuapiaxtla" },
                    { 8, 30, "", null, true, "Alpatláhuac" },
                    { 8, 31, "", null, true, "Calotmul" },
                    { 8, 32, "", null, true, "Cuauhtémoc" },
                    { 9, 1, "", null, true, "Tepezalá" },
                    { 9, 3, "", null, true, "Loreto" },
                    { 9, 4, "", null, true, "Escárcega" },
                    { 9, 5, "", null, true, "Francisco I. Madero" },
                    { 9, 6, "", null, true, "Tecomán" },
                    { 9, 7, "", null, true, "Arriaga" },
                    { 9, 8, "", null, true, "Bocoyna" },
                    { 9, 9, "", null, true, "Milpa Alta" },
                    { 9, 10, "", null, true, "Guanaceví" },
                    { 9, 11, "", null, true, "Comonfort" },
                    { 9, 12, "", null, true, "Atlamajalcingo del Monte" },
                    { 9, 13, "", null, true, "El Arenal" },
                    { 9, 14, "", null, true, "El Arenal" },
                    { 9, 15, "", null, true, "Amecameca" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 9, 16, "", null, true, "Ario" },
                    { 9, 17, "", null, true, "Huitzilac" },
                    { 9, 18, "", null, true, "Del Nayar" },
                    { 9, 19, "", null, true, "Cadereyta Jiménez" },
                    { 9, 20, "", null, true, "Ayotzintepec" },
                    { 9, 21, "", null, true, "Ahuehuetitla" },
                    { 9, 22, "", null, true, "Jalpan de Serra" },
                    { 9, 23, "", null, true, "Tulum" },
                    { 9, 24, "", null, true, "Cerro de San Pedro" },
                    { 9, 25, "", null, true, "Escuinapa" },
                    { 9, 26, "", null, true, "Bacanora" },
                    { 9, 27, "", null, true, "Jalapa" },
                    { 9, 28, "", null, true, "Ciudad Madero" },
                    { 9, 29, "", null, true, "Cuaxomulco" },
                    { 9, 30, "", null, true, "Alto Lucero de Gutiérrez Barrios" },
                    { 9, 31, "", null, true, "Cansahcab" },
                    { 9, 32, "", null, true, "Chalchihuites" },
                    { 10, 1, "", null, true, "El Llano" },
                    { 10, 4, "", null, true, "Calakmul" },
                    { 10, 5, "", null, true, "Frontera" },
                    { 10, 6, "", null, true, "Villa de Álvarez" },
                    { 10, 7, "", null, true, "Bejucal de Ocampo" },
                    { 10, 8, "", null, true, "Buenaventura" },
                    { 10, 9, "", null, true, "Álvaro Obregón" },
                    { 10, 10, "", null, true, "Hidalgo" },
                    { 10, 11, "", null, true, "Coroneo" },
                    { 10, 12, "", null, true, "Atlixtac" },
                    { 10, 13, "", null, true, "Atitalaquia" },
                    { 10, 14, "", null, true, "Atemajac de Brizuela" },
                    { 10, 15, "", null, true, "Apaxco" },
                    { 10, 16, "", null, true, "Arteaga" },
                    { 10, 17, "", null, true, "Jantetelco" },
                    { 10, 18, "", null, true, "Rosamorada" },
                    { 10, 19, "", null, true, "El Carmen" },
                    { 10, 20, "", null, true, "El Barrio de la Soledad" },
                    { 10, 21, "", null, true, "Ajalpan" },
                    { 10, 22, "", null, true, "Landa de Matamoros" },
                    { 10, 23, "", null, true, "Bacalar" },
                    { 10, 24, "", null, true, "Ciudad del Maíz" },
                    { 10, 25, "", null, true, "El Fuerte" },
                    { 10, 26, "", null, true, "Bacerac" },
                    { 10, 27, "", null, true, "Jalpa de Méndez" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 10, 28, "", null, true, "Cruillas" },
                    { 10, 29, "", null, true, "Chiautempan" },
                    { 10, 30, "", null, true, "Altotonga" },
                    { 10, 31, "", null, true, "Cantamayec" },
                    { 10, 32, "", null, true, "Fresnillo" },
                    { 11, 1, "", null, true, "San Francisco de los Romo" },
                    { 11, 4, "", null, true, "Candelaria" },
                    { 11, 5, "", null, true, "General Cepeda" },
                    { 11, 7, "", null, true, "Bella Vista" },
                    { 11, 8, "", null, true, "Camargo" },
                    { 11, 9, "", null, true, "Tláhuac" },
                    { 11, 10, "", null, true, "Indé" },
                    { 11, 11, "", null, true, "Cortazar" },
                    { 11, 12, "", null, true, "Atoyac de Álvarez" },
                    { 11, 13, "", null, true, "Atlapexco" },
                    { 11, 14, "", null, true, "Atengo" },
                    { 11, 15, "", null, true, "Atenco" },
                    { 11, 16, "", null, true, "Briseñas" },
                    { 11, 17, "", null, true, "Jiutepec" },
                    { 11, 18, "", null, true, "Ruíz" },
                    { 11, 19, "", null, true, "Cerralvo" },
                    { 11, 20, "", null, true, "Calihualá" },
                    { 11, 21, "", null, true, "Albino Zertuche" },
                    { 11, 22, "", null, true, "El Marqués" },
                    { 11, 23, "", null, true, "Puerto Morelos" },
                    { 11, 24, "", null, true, "Ciudad Fernández" },
                    { 11, 25, "", null, true, "Guasave" },
                    { 11, 26, "", null, true, "Bacoachi" },
                    { 11, 27, "", null, true, "Jonuta" },
                    { 11, 28, "", null, true, "Gómez Farías" },
                    { 11, 29, "", null, true, "Muñoz de Domingo Arenas" },
                    { 11, 30, "", null, true, "Alvarado" },
                    { 11, 31, "", null, true, "Celestún" },
                    { 11, 32, "", null, true, "Trinidad García de la Cadena" },
                    { 12, 5, "", null, true, "Guerrero" },
                    { 12, 7, "", null, true, "Berriozábal" },
                    { 12, 8, "", null, true, "Carichí" },
                    { 12, 9, "", null, true, "Tlalpan" },
                    { 12, 10, "", null, true, "Lerdo" },
                    { 12, 11, "", null, true, "Cuerámaro" },
                    { 12, 12, "", null, true, "Ayutla de los Libres" },
                    { 12, 13, "", null, true, "Atotonilco el Grande" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 12, 14, "", null, true, "Atenguillo" },
                    { 12, 15, "", null, true, "Atizapán" },
                    { 12, 16, "", null, true, "Buenavista" },
                    { 12, 17, "", null, true, "Jojutla" },
                    { 12, 18, "", null, true, "San Blas" },
                    { 12, 19, "", null, true, "Ciénega de Flores" },
                    { 12, 20, "", null, true, "Candelaria Loxicha" },
                    { 12, 21, "", null, true, "Aljojuca" },
                    { 12, 22, "", null, true, "Pedro Escobedo" },
                    { 12, 24, "", null, true, "Tancanhuitz" },
                    { 12, 25, "", null, true, "Mazatlán" },
                    { 12, 26, "", null, true, "Bácum" },
                    { 12, 27, "", null, true, "Macuspana" },
                    { 12, 28, "", null, true, "González" },
                    { 12, 29, "", null, true, "Españita" },
                    { 12, 30, "", null, true, "Amatitlán" },
                    { 12, 31, "", null, true, "Cenotillo" },
                    { 12, 32, "", null, true, "Genaro Codina" },
                    { 13, 5, "", null, true, "Hidalgo" },
                    { 13, 7, "", null, true, "Bochil" },
                    { 13, 8, "", null, true, "Casas Grandes" },
                    { 13, 9, "", null, true, "Xochimilco" },
                    { 13, 10, "", null, true, "Mapimí" },
                    { 13, 11, "", null, true, "Doctor Mora" },
                    { 13, 12, "", null, true, "Azoyú" },
                    { 13, 13, "", null, true, "Atotonilco de Tula" },
                    { 13, 14, "", null, true, "Atotonilco el Alto" },
                    { 13, 15, "", null, true, "Atizapán de Zaragoza" },
                    { 13, 16, "", null, true, "Carácuaro" },
                    { 13, 17, "", null, true, "Jonacatepec" },
                    { 13, 18, "", null, true, "San Pedro Lagunillas" },
                    { 13, 19, "", null, true, "China" },
                    { 13, 20, "", null, true, "Ciénega de Zimatlán" },
                    { 13, 21, "", null, true, "Altepexi" },
                    { 13, 22, "", null, true, "Peñamiller" },
                    { 13, 24, "", null, true, "Ciudad Valles" },
                    { 13, 25, "", null, true, "Mocorito" },
                    { 13, 26, "", null, true, "Banámichi" },
                    { 13, 27, "", null, true, "Nacajuca" },
                    { 13, 28, "", null, true, "Güémez" },
                    { 13, 29, "", null, true, "Huamantla" },
                    { 13, 30, "", null, true, "Naranjos Amatlán" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 13, 31, "", null, true, "Conkal" },
                    { 13, 32, "", null, true, "General Enrique Estrada" },
                    { 14, 5, "", null, true, "Jiménez" },
                    { 14, 7, "", null, true, "El Bosque" },
                    { 14, 8, "", null, true, "Coronado" },
                    { 14, 9, "", null, true, "Benito Juárez" },
                    { 14, 10, "", null, true, "Mezquital" },
                    { 14, 11, "", null, true, "Dolores Hidalgo Cuna de la Independencia Nacional" },
                    { 14, 12, "", null, true, "Benito Juárez" },
                    { 14, 13, "", null, true, "Calnali" },
                    { 14, 14, "", null, true, "Atoyac" },
                    { 14, 15, "", null, true, "Atlacomulco" },
                    { 14, 16, "", null, true, "Coahuayana" },
                    { 14, 17, "", null, true, "Mazatepec" },
                    { 14, 18, "", null, true, "Santa María del Oro" },
                    { 14, 19, "", null, true, "Doctor Arroyo" },
                    { 14, 20, "", null, true, "Ciudad Ixtepec" },
                    { 14, 21, "", null, true, "Amixtlán" },
                    { 14, 22, "", null, true, "Querétaro" },
                    { 14, 24, "", null, true, "Coxcatlán" },
                    { 14, 25, "", null, true, "Rosario" },
                    { 14, 26, "", null, true, "Baviácora" },
                    { 14, 27, "", null, true, "Paraíso" },
                    { 14, 28, "", null, true, "Guerrero" },
                    { 14, 29, "", null, true, "Hueyotlipan" },
                    { 14, 30, "", null, true, "Amatlán de los Reyes" },
                    { 14, 31, "", null, true, "Cuncunul" },
                    { 14, 32, "", null, true, "General Francisco R. Murguía" },
                    { 15, 5, "", null, true, "Juárez" },
                    { 15, 7, "", null, true, "Cacahoatán" },
                    { 15, 8, "", null, true, "Coyame del Sotol" },
                    { 15, 9, "", null, true, "Cuauhtémoc" },
                    { 15, 10, "", null, true, "Nazas" },
                    { 15, 11, "", null, true, "Guanajuato" },
                    { 15, 12, "", null, true, "Buenavista de Cuéllar" },
                    { 15, 13, "", null, true, "Cardonal" },
                    { 15, 14, "", null, true, "Autlán de Navarro" },
                    { 15, 15, "", null, true, "Atlautla" },
                    { 15, 16, "", null, true, "Coalcomán de Vázquez Pallares" },
                    { 15, 17, "", null, true, "Miacatlán" },
                    { 15, 18, "", null, true, "Santiago Ixcuintla" },
                    { 15, 19, "", null, true, "Doctor Coss" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 15, 20, "", null, true, "Coatecas Altas" },
                    { 15, 21, "", null, true, "Amozoc" },
                    { 15, 22, "", null, true, "San Joaquín" },
                    { 15, 24, "", null, true, "Charcas" },
                    { 15, 25, "", null, true, "Salvador Alvarado" },
                    { 15, 26, "", null, true, "Bavispe" },
                    { 15, 27, "", null, true, "Tacotalpa" },
                    { 15, 28, "", null, true, "Gustavo Díaz Ordaz" },
                    { 15, 29, "", null, true, "Ixtacuixtla de Mariano Matamoros" },
                    { 15, 30, "", null, true, "Angel R. Cabada" },
                    { 15, 31, "", null, true, "Cuzamá" },
                    { 15, 32, "", null, true, "El Plateado de Joaquín Amaro" },
                    { 16, 5, "", null, true, "Lamadrid" },
                    { 16, 7, "", null, true, "Catazajá" },
                    { 16, 8, "", null, true, "La Cruz" },
                    { 16, 9, "", null, true, "Miguel Hidalgo" },
                    { 16, 10, "", null, true, "Nombre de Dios" },
                    { 16, 11, "", null, true, "Huanímaro" },
                    { 16, 12, "", null, true, "Coahuayutla de José María Izazaga" },
                    { 16, 13, "", null, true, "Cuautepec de Hinojosa" },
                    { 16, 14, "", null, true, "Ayotlán" },
                    { 16, 15, "", null, true, "Axapusco" },
                    { 16, 16, "", null, true, "Coeneo" },
                    { 16, 17, "", null, true, "Ocuituco" },
                    { 16, 18, "", null, true, "Tecuala" },
                    { 16, 19, "", null, true, "Doctor González" },
                    { 16, 20, "", null, true, "Coicoyán de las Flores" },
                    { 16, 21, "", null, true, "Aquixtla" },
                    { 16, 22, "", null, true, "San Juan del Río" },
                    { 16, 24, "", null, true, "Ebano" },
                    { 16, 25, "", null, true, "San Ignacio" },
                    { 16, 26, "", null, true, "Benjamín Hill" },
                    { 16, 27, "", null, true, "Teapa" },
                    { 16, 28, "", null, true, "Hidalgo" },
                    { 16, 29, "", null, true, "Ixtenco" },
                    { 16, 30, "", null, true, "La Antigua" },
                    { 16, 31, "", null, true, "Chacsinkín" },
                    { 16, 32, "", null, true, "General Pánfilo Natera" },
                    { 17, 5, "", null, true, "Matamoros" },
                    { 17, 7, "", null, true, "Cintalapa" },
                    { 17, 8, "", null, true, "Cuauhtémoc" },
                    { 17, 9, "", null, true, "Venustiano Carranza" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 17, 10, "", null, true, "Ocampo" },
                    { 17, 11, "", null, true, "Irapuato" },
                    { 17, 12, "", null, true, "Cocula" },
                    { 17, 13, "", null, true, "Chapantongo" },
                    { 17, 14, "", null, true, "Ayutla" },
                    { 17, 15, "", null, true, "Ayapango" },
                    { 17, 16, "", null, true, "Contepec" },
                    { 17, 17, "", null, true, "Puente de Ixtla" },
                    { 17, 18, "", null, true, "Tepic" },
                    { 17, 19, "", null, true, "Galeana" },
                    { 17, 20, "", null, true, "La Compañía" },
                    { 17, 21, "", null, true, "Atempan" },
                    { 17, 22, "", null, true, "Tequisquiapan" },
                    { 17, 24, "", null, true, "Guadalcázar" },
                    { 17, 25, "", null, true, "Sinaloa" },
                    { 17, 26, "", null, true, "Caborca" },
                    { 17, 27, "", null, true, "Tenosique" },
                    { 17, 28, "", null, true, "Jaumave" },
                    { 17, 29, "", null, true, "Mazatecochco de José María Morelos" },
                    { 17, 30, "", null, true, "Apazapan" },
                    { 17, 31, "", null, true, "Chankom" },
                    { 17, 32, "", null, true, "Guadalupe" },
                    { 18, 5, "", null, true, "Monclova" },
                    { 18, 7, "", null, true, "Coapilla" },
                    { 18, 8, "", null, true, "Cusihuiriachi" },
                    { 18, 10, "", null, true, "El Oro" },
                    { 18, 11, "", null, true, "Jaral del Progreso" },
                    { 18, 12, "", null, true, "Copala" },
                    { 18, 13, "", null, true, "Chapulhuacán" },
                    { 18, 14, "", null, true, "La Barca" },
                    { 18, 15, "", null, true, "Calimaya" },
                    { 18, 16, "", null, true, "Copándaro" },
                    { 18, 17, "", null, true, "Temixco" },
                    { 18, 18, "", null, true, "Tuxpan" },
                    { 18, 19, "", null, true, "García" },
                    { 18, 20, "", null, true, "Concepción Buenavista" },
                    { 18, 21, "", null, true, "Atexcal" },
                    { 18, 22, "", null, true, "Tolimán" },
                    { 18, 24, "", null, true, "Huehuetlán" },
                    { 18, 25, "", null, true, "Navolato" },
                    { 18, 26, "", null, true, "Cajeme" },
                    { 18, 28, "", null, true, "Jiménez" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 18, 29, "", null, true, "Contla de Juan Cuamatzi" },
                    { 18, 30, "", null, true, "Aquila" },
                    { 18, 31, "", null, true, "Chapab" },
                    { 18, 32, "", null, true, "Huanusco" },
                    { 19, 5, "", null, true, "Morelos" },
                    { 19, 7, "", null, true, "Comitán de Domínguez" },
                    { 19, 8, "", null, true, "Chihuahua" },
                    { 19, 10, "", null, true, "Otáez" },
                    { 19, 11, "", null, true, "Jerécuaro" },
                    { 19, 12, "", null, true, "Copalillo" },
                    { 19, 13, "", null, true, "Chilcuautla" },
                    { 19, 14, "", null, true, "Bolaños" },
                    { 19, 15, "", null, true, "Capulhuac" },
                    { 19, 16, "", null, true, "Cotija" },
                    { 19, 17, "", null, true, "Tepalcingo" },
                    { 19, 18, "", null, true, "La Yesca" },
                    { 19, 19, "", null, true, "San Pedro Garza García" },
                    { 19, 20, "", null, true, "Concepción Pápalo" },
                    { 19, 21, "", null, true, "Atlixco" },
                    { 19, 24, "", null, true, "Lagunillas" },
                    { 19, 26, "", null, true, "Cananea" },
                    { 19, 28, "", null, true, "Llera" },
                    { 19, 29, "", null, true, "Tepetitla de Lardizábal" },
                    { 19, 30, "", null, true, "Astacinga" },
                    { 19, 31, "", null, true, "Chemax" },
                    { 19, 32, "", null, true, "Jalpa" },
                    { 20, 5, "", null, true, "Múzquiz" },
                    { 20, 7, "", null, true, "La Concordia" },
                    { 20, 8, "", null, true, "Chínipas" },
                    { 20, 10, "", null, true, "Pánuco de Coronado" },
                    { 20, 11, "", null, true, "León" },
                    { 20, 12, "", null, true, "Copanatoyac" },
                    { 20, 13, "", null, true, "Eloxochitlán" },
                    { 20, 14, "", null, true, "Cabo Corrientes" },
                    { 20, 15, "", null, true, "Coacalco de Berriozábal" },
                    { 20, 16, "", null, true, "Cuitzeo" },
                    { 20, 17, "", null, true, "Tepoztlán" },
                    { 20, 18, "", null, true, "Bahía de Banderas" },
                    { 20, 19, "", null, true, "General Bravo" },
                    { 20, 20, "", null, true, "Constancia del Rosario" },
                    { 20, 21, "", null, true, "Atoyatempan" },
                    { 20, 24, "", null, true, "Matehuala" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 20, 26, "", null, true, "Carbó" },
                    { 20, 28, "", null, true, "Mainero" },
                    { 20, 29, "", null, true, "Sanctórum de Lázaro Cárdenas" },
                    { 20, 30, "", null, true, "Atlahuilco" },
                    { 20, 31, "", null, true, "Chicxulub Pueblo" },
                    { 20, 32, "", null, true, "Jerez" },
                    { 21, 5, "", null, true, "Nadadores" },
                    { 21, 7, "", null, true, "Copainalá" },
                    { 21, 8, "", null, true, "Delicias" },
                    { 21, 10, "", null, true, "Peñón Blanco" },
                    { 21, 11, "", null, true, "Moroleón" },
                    { 21, 12, "", null, true, "Coyuca de Benítez" },
                    { 21, 13, "", null, true, "Emiliano Zapata" },
                    { 21, 14, "", null, true, "Casimiro Castillo" },
                    { 21, 15, "", null, true, "Coatepec Harinas" },
                    { 21, 16, "", null, true, "Charapan" },
                    { 21, 17, "", null, true, "Tetecala" },
                    { 21, 19, "", null, true, "General Escobedo" },
                    { 21, 20, "", null, true, "Cosolapa" },
                    { 21, 21, "", null, true, "Atzala" },
                    { 21, 24, "", null, true, "Mexquitic de Carmona" },
                    { 21, 26, "", null, true, "La Colorada" },
                    { 21, 28, "", null, true, "El Mante" },
                    { 21, 29, "", null, true, "Nanacamilpa de Mariano Arista" },
                    { 21, 30, "", null, true, "Atoyac" },
                    { 21, 31, "", null, true, "Chichimilá" },
                    { 21, 32, "", null, true, "Jiménez del Teul" },
                    { 22, 5, "", null, true, "Nava" },
                    { 22, 7, "", null, true, "Chalchihuitán" },
                    { 22, 8, "", null, true, "Dr. Belisario Domínguez" },
                    { 22, 10, "", null, true, "Poanas" },
                    { 22, 11, "", null, true, "Ocampo" },
                    { 22, 12, "", null, true, "Coyuca de Catalán" },
                    { 22, 13, "", null, true, "Epazoyucan" },
                    { 22, 14, "", null, true, "Cihuatlán" },
                    { 22, 15, "", null, true, "Cocotitlán" },
                    { 22, 16, "", null, true, "Charo" },
                    { 22, 17, "", null, true, "Tetela del Volcán" },
                    { 22, 19, "", null, true, "General Terán" },
                    { 22, 20, "", null, true, "Cosoltepec" },
                    { 22, 21, "", null, true, "Atzitzihuacán" },
                    { 22, 24, "", null, true, "Moctezuma" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 22, 26, "", null, true, "Cucurpe" },
                    { 22, 28, "", null, true, "Matamoros" },
                    { 22, 29, "", null, true, "Acuamanala de Miguel Hidalgo" },
                    { 22, 30, "", null, true, "Atzacan" },
                    { 22, 31, "", null, true, "Chikindzonot" },
                    { 22, 32, "", null, true, "Juan Aldama" },
                    { 23, 5, "", null, true, "Ocampo" },
                    { 23, 7, "", null, true, "Chamula" },
                    { 23, 8, "", null, true, "Galeana" },
                    { 23, 10, "", null, true, "Pueblo Nuevo" },
                    { 23, 11, "", null, true, "Pénjamo" },
                    { 23, 12, "", null, true, "Cuajinicuilapa" },
                    { 23, 13, "", null, true, "Francisco I. Madero" },
                    { 23, 14, "", null, true, "Zapotlán el Grande" },
                    { 23, 15, "", null, true, "Coyotepec" },
                    { 23, 16, "", null, true, "Chavinda" },
                    { 23, 17, "", null, true, "Tlalnepantla" },
                    { 23, 19, "", null, true, "General Treviño" },
                    { 23, 20, "", null, true, "Cuilápam de Guerrero" },
                    { 23, 21, "", null, true, "Atzitzintla" },
                    { 23, 24, "", null, true, "Rayón" },
                    { 23, 26, "", null, true, "Cumpas" },
                    { 23, 28, "", null, true, "Méndez" },
                    { 23, 29, "", null, true, "Natívitas" },
                    { 23, 30, "", null, true, "Atzalan" },
                    { 23, 31, "", null, true, "Chocholá" },
                    { 23, 32, "", null, true, "Juchipila" },
                    { 24, 5, "", null, true, "Parras" },
                    { 24, 7, "", null, true, "Chanal" },
                    { 24, 8, "", null, true, "Santa Isabel" },
                    { 24, 10, "", null, true, "Rodeo" },
                    { 24, 11, "", null, true, "Pueblo Nuevo" },
                    { 24, 12, "", null, true, "Cualác" },
                    { 24, 13, "", null, true, "Huasca de Ocampo" },
                    { 24, 14, "", null, true, "Cocula" },
                    { 24, 15, "", null, true, "Cuautitlán" },
                    { 24, 16, "", null, true, "Cherán" },
                    { 24, 17, "", null, true, "Tlaltizapán de Zapata" },
                    { 24, 19, "", null, true, "General Zaragoza" },
                    { 24, 20, "", null, true, "Cuyamecalco Villa de Zaragoza" },
                    { 24, 21, "", null, true, "Axutla" },
                    { 24, 24, "", null, true, "Rioverde" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 24, 26, "", null, true, "Divisaderos" },
                    { 24, 28, "", null, true, "Mier" },
                    { 24, 29, "", null, true, "Panotla" },
                    { 24, 30, "", null, true, "Tlaltetela" },
                    { 24, 31, "", null, true, "Chumayel" },
                    { 24, 32, "", null, true, "Loreto" },
                    { 25, 5, "", null, true, "Piedras Negras" },
                    { 25, 7, "", null, true, "Chapultenango" },
                    { 25, 8, "", null, true, "Gómez Farías" },
                    { 25, 10, "", null, true, "San Bernardo" },
                    { 25, 11, "", null, true, "Purísima del Rincón" },
                    { 25, 12, "", null, true, "Cuautepec" },
                    { 25, 13, "", null, true, "Huautla" },
                    { 25, 14, "", null, true, "Colotlán" },
                    { 25, 15, "", null, true, "Chalco" },
                    { 25, 16, "", null, true, "Chilchota" },
                    { 25, 17, "", null, true, "Tlaquiltenango" },
                    { 25, 19, "", null, true, "General Zuazua" },
                    { 25, 20, "", null, true, "Chahuites" },
                    { 25, 21, "", null, true, "Ayotoxco de Guerrero" },
                    { 25, 24, "", null, true, "Salinas" },
                    { 25, 26, "", null, true, "Empalme" },
                    { 25, 28, "", null, true, "Miguel Alemán" },
                    { 25, 29, "", null, true, "San Pablo del Monte" },
                    { 25, 30, "", null, true, "Ayahualulco" },
                    { 25, 31, "", null, true, "Dzán" },
                    { 25, 32, "", null, true, "Luis Moya" },
                    { 26, 5, "", null, true, "Progreso" },
                    { 26, 7, "", null, true, "Chenalhó" },
                    { 26, 8, "", null, true, "Gran Morelos" },
                    { 26, 10, "", null, true, "San Dimas" },
                    { 26, 11, "", null, true, "Romita" },
                    { 26, 12, "", null, true, "Cuetzala del Progreso" },
                    { 26, 13, "", null, true, "Huazalingo" },
                    { 26, 14, "", null, true, "Concepción de Buenos Aires" },
                    { 26, 15, "", null, true, "Chapa de Mota" },
                    { 26, 16, "", null, true, "Chinicuila" },
                    { 26, 17, "", null, true, "Tlayacapan" },
                    { 26, 19, "", null, true, "Guadalupe" },
                    { 26, 20, "", null, true, "Chalcatongo de Hidalgo" },
                    { 26, 21, "", null, true, "Calpan" },
                    { 26, 24, "", null, true, "San Antonio" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 26, 26, "", null, true, "Etchojoa" },
                    { 26, 28, "", null, true, "Miquihuana" },
                    { 26, 29, "", null, true, "Santa Cruz Tlaxcala" },
                    { 26, 30, "", null, true, "Banderilla" },
                    { 26, 31, "", null, true, "Dzemul" },
                    { 26, 32, "", null, true, "Mazapil" },
                    { 27, 5, "", null, true, "Ramos Arizpe" },
                    { 27, 7, "", null, true, "Chiapa de Corzo" },
                    { 27, 8, "", null, true, "Guachochi" },
                    { 27, 10, "", null, true, "San Juan de Guadalupe" },
                    { 27, 11, "", null, true, "Salamanca" },
                    { 27, 12, "", null, true, "Cutzamala de Pinzón" },
                    { 27, 13, "", null, true, "Huehuetla" },
                    { 27, 14, "", null, true, "Cuautitlán de García Barragán" },
                    { 27, 15, "", null, true, "Chapultepec" },
                    { 27, 16, "", null, true, "Chucándiro" },
                    { 27, 17, "", null, true, "Totolapan" },
                    { 27, 19, "", null, true, "Los Herreras" },
                    { 27, 20, "", null, true, "Chiquihuitlán de Benito Juárez" },
                    { 27, 21, "", null, true, "Caltepec" },
                    { 27, 24, "", null, true, "San Ciro de Acosta" },
                    { 27, 26, "", null, true, "Fronteras" },
                    { 27, 28, "", null, true, "Nuevo Laredo" },
                    { 27, 29, "", null, true, "Tenancingo" },
                    { 27, 30, "", null, true, "Benito Juárez" },
                    { 27, 31, "", null, true, "Dzidzantún" },
                    { 27, 32, "", null, true, "Melchor Ocampo" },
                    { 28, 5, "", null, true, "Sabinas" },
                    { 28, 7, "", null, true, "Chiapilla" },
                    { 28, 8, "", null, true, "Guadalupe" },
                    { 28, 10, "", null, true, "San Juan del Río" },
                    { 28, 11, "", null, true, "Salvatierra" },
                    { 28, 12, "", null, true, "Chilapa de Álvarez" },
                    { 28, 13, "", null, true, "Huejutla de Reyes" },
                    { 28, 14, "", null, true, "Cuautla" },
                    { 28, 15, "", null, true, "Chiautla" },
                    { 28, 16, "", null, true, "Churintzio" },
                    { 28, 17, "", null, true, "Xochitepec" },
                    { 28, 19, "", null, true, "Higueras" },
                    { 28, 20, "", null, true, "Heroica Ciudad de Ejutla de Crespo" },
                    { 28, 21, "", null, true, "Camocuautla" },
                    { 28, 24, "", null, true, "San Luis Potosí" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 28, 26, "", null, true, "Granados" },
                    { 28, 28, "", null, true, "Nuevo Morelos" },
                    { 28, 29, "", null, true, "Teolocholco" },
                    { 28, 30, "", null, true, "Boca del Río" },
                    { 28, 31, "", null, true, "Dzilam de Bravo" },
                    { 28, 32, "", null, true, "Mezquital del Oro" },
                    { 29, 5, "", null, true, "Sacramento" },
                    { 29, 7, "", null, true, "Chicoasén" },
                    { 29, 8, "", null, true, "Guadalupe y Calvo" },
                    { 29, 10, "", null, true, "San Luis del Cordero" },
                    { 29, 11, "", null, true, "San Diego de la Unión" },
                    { 29, 12, "", null, true, "Chilpancingo de los Bravo" },
                    { 29, 13, "", null, true, "Huichapan" },
                    { 29, 14, "", null, true, "Cuquío" },
                    { 29, 15, "", null, true, "Chicoloapan" },
                    { 29, 16, "", null, true, "Churumuco" },
                    { 29, 17, "", null, true, "Yautepec" },
                    { 29, 19, "", null, true, "Hualahuises" },
                    { 29, 20, "", null, true, "Eloxochitlán de Flores Magón" },
                    { 29, 21, "", null, true, "Caxhuacan" },
                    { 29, 24, "", null, true, "San Martín Chalchicuautla" },
                    { 29, 26, "", null, true, "Guaymas" },
                    { 29, 28, "", null, true, "Ocampo" },
                    { 29, 29, "", null, true, "Tepeyanco" },
                    { 29, 30, "", null, true, "Calcahualco" },
                    { 29, 31, "", null, true, "Dzilam González" },
                    { 29, 32, "", null, true, "Miguel Auza" },
                    { 30, 5, "", null, true, "Saltillo" },
                    { 30, 7, "", null, true, "Chicomuselo" },
                    { 30, 8, "", null, true, "Guazapares" },
                    { 30, 10, "", null, true, "San Pedro del Gallo" },
                    { 30, 11, "", null, true, "San Felipe" },
                    { 30, 12, "", null, true, "Florencio Villarreal" },
                    { 30, 13, "", null, true, "Ixmiquilpan" },
                    { 30, 14, "", null, true, "Chapala" },
                    { 30, 15, "", null, true, "Chiconcuac" },
                    { 30, 16, "", null, true, "Ecuandureo" },
                    { 30, 17, "", null, true, "Yecapixtla" },
                    { 30, 19, "", null, true, "Iturbide" },
                    { 30, 20, "", null, true, "El Espinal" },
                    { 30, 21, "", null, true, "Coatepec" },
                    { 30, 24, "", null, true, "San Nicolás Tolentino" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 30, 26, "", null, true, "Hermosillo" },
                    { 30, 28, "", null, true, "Padilla" },
                    { 30, 29, "", null, true, "Terrenate" },
                    { 30, 30, "", null, true, "Camerino Z. Mendoza" },
                    { 30, 31, "", null, true, "Dzitás" },
                    { 30, 32, "", null, true, "Momax" },
                    { 31, 5, "", null, true, "San Buenaventura" },
                    { 31, 7, "", null, true, "Chilón" },
                    { 31, 8, "", null, true, "Guerrero" },
                    { 31, 10, "", null, true, "Santa Clara" },
                    { 31, 11, "", null, true, "San Francisco del Rincón" },
                    { 31, 12, "", null, true, "General Canuto A. Neri" },
                    { 31, 13, "", null, true, "Jacala de Ledezma" },
                    { 31, 14, "", null, true, "Chimaltitán" },
                    { 31, 15, "", null, true, "Chimalhuacán" },
                    { 31, 16, "", null, true, "Epitacio Huerta" },
                    { 31, 17, "", null, true, "Zacatepec" },
                    { 31, 19, "", null, true, "Juárez" },
                    { 31, 20, "", null, true, "Tamazulápam del Espíritu Santo" },
                    { 31, 21, "", null, true, "Coatzingo" },
                    { 31, 24, "", null, true, "Santa Catarina" },
                    { 31, 26, "", null, true, "Huachinera" },
                    { 31, 28, "", null, true, "Palmillas" },
                    { 31, 29, "", null, true, "Tetla de la Solidaridad" },
                    { 31, 30, "", null, true, "Carrillo Puerto" },
                    { 31, 31, "", null, true, "Dzoncauich" },
                    { 31, 32, "", null, true, "Monte Escobedo" },
                    { 32, 5, "", null, true, "San Juan de Sabinas" },
                    { 32, 7, "", null, true, "Escuintla" },
                    { 32, 8, "", null, true, "Hidalgo del Parral" },
                    { 32, 10, "", null, true, "Santiago Papasquiaro" },
                    { 32, 11, "", null, true, "San José Iturbide" },
                    { 32, 12, "", null, true, "General Heliodoro Castillo" },
                    { 32, 13, "", null, true, "Jaltocán" },
                    { 32, 14, "", null, true, "Chiquilistlán" },
                    { 32, 15, "", null, true, "Donato Guerra" },
                    { 32, 16, "", null, true, "Erongarícuaro" },
                    { 32, 17, "", null, true, "Zacualpan de Amilpas" },
                    { 32, 19, "", null, true, "Lampazos de Naranjo" },
                    { 32, 20, "", null, true, "Fresnillo de Trujano" },
                    { 32, 21, "", null, true, "Cohetzala" },
                    { 32, 24, "", null, true, "Santa María del Río" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 32, 26, "", null, true, "Huásabas" },
                    { 32, 28, "", null, true, "Reynosa" },
                    { 32, 29, "", null, true, "Tetlatlahuca" },
                    { 32, 30, "", null, true, "Catemaco" },
                    { 32, 31, "", null, true, "Espita" },
                    { 32, 32, "", null, true, "Morelos" },
                    { 33, 5, "", null, true, "San Pedro" },
                    { 33, 7, "", null, true, "Francisco León" },
                    { 33, 8, "", null, true, "Huejotitán" },
                    { 33, 10, "", null, true, "Súchil" },
                    { 33, 11, "", null, true, "San Luis de la Paz" },
                    { 33, 12, "", null, true, "Huamuxtitlán" },
                    { 33, 13, "", null, true, "Juárez Hidalgo" },
                    { 33, 14, "", null, true, "Degollado" },
                    { 33, 15, "", null, true, "Ecatepec de Morelos" },
                    { 33, 16, "", null, true, "Gabriel Zamora" },
                    { 33, 17, "", null, true, "Temoac" },
                    { 33, 19, "", null, true, "Linares" },
                    { 33, 20, "", null, true, "Guadalupe Etla" },
                    { 33, 21, "", null, true, "Cohuecan" },
                    { 33, 24, "", null, true, "Santo Domingo" },
                    { 33, 26, "", null, true, "Huatabampo" },
                    { 33, 28, "", null, true, "Río Bravo" },
                    { 33, 29, "", null, true, "Tlaxcala" },
                    { 33, 30, "", null, true, "Cazones de Herrera" },
                    { 33, 31, "", null, true, "Halachó" },
                    { 33, 32, "", null, true, "Moyahua de Estrada" },
                    { 34, 5, "", null, true, "Sierra Mojada" },
                    { 34, 7, "", null, true, "Frontera Comalapa" },
                    { 34, 8, "", null, true, "Ignacio Zaragoza" },
                    { 34, 10, "", null, true, "Tamazula" },
                    { 34, 11, "", null, true, "Santa Catarina" },
                    { 34, 12, "", null, true, "Huitzuco de los Figueroa" },
                    { 34, 13, "", null, true, "Lolotla" },
                    { 34, 14, "", null, true, "Ejutla" },
                    { 34, 15, "", null, true, "Ecatzingo" },
                    { 34, 16, "", null, true, "Hidalgo" },
                    { 34, 19, "", null, true, "Marín" },
                    { 34, 20, "", null, true, "Guadalupe de Ramírez" },
                    { 34, 21, "", null, true, "Coronango" },
                    { 34, 24, "", null, true, "San Vicente Tancuayalab" },
                    { 34, 26, "", null, true, "Huépac" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 34, 28, "", null, true, "San Carlos" },
                    { 34, 29, "", null, true, "Tlaxco" },
                    { 34, 30, "", null, true, "Cerro Azul" },
                    { 34, 31, "", null, true, "Hocabá" },
                    { 34, 32, "", null, true, "Nochistlán de Mejía" },
                    { 35, 5, "", null, true, "Torreón" },
                    { 35, 7, "", null, true, "Frontera Hidalgo" },
                    { 35, 8, "", null, true, "Janos" },
                    { 35, 10, "", null, true, "Tepehuanes" },
                    { 35, 11, "", null, true, "Santa Cruz de Juventino Rosas" },
                    { 35, 12, "", null, true, "Iguala de la Independencia" },
                    { 35, 13, "", null, true, "Metepec" },
                    { 35, 14, "", null, true, "Encarnación de Díaz" },
                    { 35, 15, "", null, true, "Huehuetoca" },
                    { 35, 16, "", null, true, "La Huacana" },
                    { 35, 19, "", null, true, "Melchor Ocampo" },
                    { 35, 20, "", null, true, "Guelatao de Juárez" },
                    { 35, 21, "", null, true, "Coxcatlán" },
                    { 35, 24, "", null, true, "Soledad de Graciano Sánchez" },
                    { 35, 26, "", null, true, "Imuris" },
                    { 35, 28, "", null, true, "San Fernando" },
                    { 35, 29, "", null, true, "Tocatlán" },
                    { 35, 30, "", null, true, "Citlaltépetl" },
                    { 35, 31, "", null, true, "Hoctún" },
                    { 35, 32, "", null, true, "Noria de Ángeles" },
                    { 36, 5, "", null, true, "Viesca" },
                    { 36, 7, "", null, true, "La Grandeza" },
                    { 36, 8, "", null, true, "Jiménez" },
                    { 36, 10, "", null, true, "Tlahualilo" },
                    { 36, 11, "", null, true, "Santiago Maravatío" },
                    { 36, 12, "", null, true, "Igualapa" },
                    { 36, 13, "", null, true, "San Agustín Metzquititlán" },
                    { 36, 14, "", null, true, "Etzatlán" },
                    { 36, 15, "", null, true, "Hueypoxtla" },
                    { 36, 16, "", null, true, "Huandacareo" },
                    { 36, 19, "", null, true, "Mier y Noriega" },
                    { 36, 20, "", null, true, "Guevea de Humboldt" },
                    { 36, 21, "", null, true, "Coyomeapan" },
                    { 36, 24, "", null, true, "Tamasopo" },
                    { 36, 26, "", null, true, "Magdalena" },
                    { 36, 28, "", null, true, "San Nicolás" },
                    { 36, 29, "", null, true, "Totolac" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 36, 30, "", null, true, "Coacoatzintla" },
                    { 36, 31, "", null, true, "Homún" },
                    { 36, 32, "", null, true, "Ojocaliente" },
                    { 37, 5, "", null, true, "Villa Unión" },
                    { 37, 7, "", null, true, "Huehuetán" },
                    { 37, 8, "", null, true, "Juárez" },
                    { 37, 10, "", null, true, "Topia" },
                    { 37, 11, "", null, true, "Silao de la Victoria" },
                    { 37, 12, "", null, true, "Ixcateopan de Cuauhtémoc" },
                    { 37, 13, "", null, true, "Metztitlán" },
                    { 37, 14, "", null, true, "El Grullo" },
                    { 37, 15, "", null, true, "Huixquilucan" },
                    { 37, 16, "", null, true, "Huaniqueo" },
                    { 37, 19, "", null, true, "Mina" },
                    { 37, 20, "", null, true, "Mesones Hidalgo" },
                    { 37, 21, "", null, true, "Coyotepec" },
                    { 37, 24, "", null, true, "Tamazunchale" },
                    { 37, 26, "", null, true, "Mazatán" },
                    { 37, 28, "", null, true, "Soto la Marina" },
                    { 37, 29, "", null, true, "Ziltlaltépec de Trinidad Sánchez Santos" },
                    { 37, 30, "", null, true, "Coahuitlán" },
                    { 37, 31, "", null, true, "Huhí" },
                    { 37, 32, "", null, true, "Pánuco" },
                    { 38, 5, "", null, true, "Zaragoza" },
                    { 38, 7, "", null, true, "Huixtán" },
                    { 38, 8, "", null, true, "Julimes" },
                    { 38, 10, "", null, true, "Vicente Guerrero" },
                    { 38, 11, "", null, true, "Tarandacuao" },
                    { 38, 12, "", null, true, "Zihuatanejo de Azueta" },
                    { 38, 13, "", null, true, "Mineral del Chico" },
                    { 38, 14, "", null, true, "Guachinango" },
                    { 38, 15, "", null, true, "Isidro Fabela" },
                    { 38, 16, "", null, true, "Huetamo" },
                    { 38, 19, "", null, true, "Montemorelos" },
                    { 38, 20, "", null, true, "Villa Hidalgo" },
                    { 38, 21, "", null, true, "Cuapiaxtla de Madero" },
                    { 38, 24, "", null, true, "Tampacán" },
                    { 38, 26, "", null, true, "Moctezuma" },
                    { 38, 28, "", null, true, "Tampico" },
                    { 38, 29, "", null, true, "Tzompantepec" },
                    { 38, 30, "", null, true, "Coatepec" },
                    { 38, 31, "", null, true, "Hunucmá" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 38, 32, "", null, true, "Pinos" },
                    { 39, 7, "", null, true, "Huitiupán" },
                    { 39, 8, "", null, true, "López" },
                    { 39, 10, "", null, true, "Nuevo Ideal" },
                    { 39, 11, "", null, true, "Tarimoro" },
                    { 39, 12, "", null, true, "Juan R. Escudero" },
                    { 39, 13, "", null, true, "Mineral del Monte" },
                    { 39, 14, "", null, true, "Guadalajara" },
                    { 39, 15, "", null, true, "Ixtapaluca" },
                    { 39, 16, "", null, true, "Huiramba" },
                    { 39, 19, "", null, true, "Monterrey" },
                    { 39, 20, "", null, true, "Heroica Ciudad de Huajuapan de León" },
                    { 39, 21, "", null, true, "Cuautempan" },
                    { 39, 24, "", null, true, "Tampamolón Corona" },
                    { 39, 26, "", null, true, "Naco" },
                    { 39, 28, "", null, true, "Tula" },
                    { 39, 29, "", null, true, "Xaloztoc" },
                    { 39, 30, "", null, true, "Coatzacoalcos" },
                    { 39, 31, "", null, true, "Ixil" },
                    { 39, 32, "", null, true, "Río Grande" },
                    { 40, 7, "", null, true, "Huixtla" },
                    { 40, 8, "", null, true, "Madera" },
                    { 40, 11, "", null, true, "Tierra Blanca" },
                    { 40, 12, "", null, true, "Leonardo Bravo" },
                    { 40, 13, "", null, true, "La Misión" },
                    { 40, 14, "", null, true, "Hostotipaquillo" },
                    { 40, 15, "", null, true, "Ixtapan de la Sal" },
                    { 40, 16, "", null, true, "Indaparapeo" },
                    { 40, 19, "", null, true, "Parás" },
                    { 40, 20, "", null, true, "Huautepec" },
                    { 40, 21, "", null, true, "Cuautinchán" },
                    { 40, 24, "", null, true, "Tamuín" },
                    { 40, 26, "", null, true, "Nácori Chico" },
                    { 40, 28, "", null, true, "Valle Hermoso" },
                    { 40, 29, "", null, true, "Xaltocan" },
                    { 40, 30, "", null, true, "Coatzintla" },
                    { 40, 31, "", null, true, "Izamal" },
                    { 40, 32, "", null, true, "Sain Alto" },
                    { 41, 7, "", null, true, "La Independencia" },
                    { 41, 8, "", null, true, "Maguarichi" },
                    { 41, 11, "", null, true, "Uriangato" },
                    { 41, 12, "", null, true, "Malinaltepec" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 41, 13, "", null, true, "Mixquiahuala de Juárez" },
                    { 41, 14, "", null, true, "Huejúcar" },
                    { 41, 15, "", null, true, "Ixtapan del Oro" },
                    { 41, 16, "", null, true, "Irimbo" },
                    { 41, 19, "", null, true, "Pesquería" },
                    { 41, 20, "", null, true, "Huautla de Jiménez" },
                    { 41, 21, "", null, true, "Cuautlancingo" },
                    { 41, 24, "", null, true, "Tanlajás" },
                    { 41, 26, "", null, true, "Nacozari de García" },
                    { 41, 28, "", null, true, "Victoria" },
                    { 41, 29, "", null, true, "Papalotla de Xicohténcatl" },
                    { 41, 30, "", null, true, "Coetzala" },
                    { 41, 31, "", null, true, "Kanasín" },
                    { 41, 32, "", null, true, "El Salvador" },
                    { 42, 7, "", null, true, "Ixhuatán" },
                    { 42, 8, "", null, true, "Manuel Benavides" },
                    { 42, 11, "", null, true, "Valle de Santiago" },
                    { 42, 12, "", null, true, "Mártir de Cuilapan" },
                    { 42, 13, "", null, true, "Molango de Escamilla" },
                    { 42, 14, "", null, true, "Huejuquilla el Alto" },
                    { 42, 15, "", null, true, "Ixtlahuaca" },
                    { 42, 16, "", null, true, "Ixtlán" },
                    { 42, 19, "", null, true, "Los Ramones" },
                    { 42, 20, "", null, true, "Ixtlán de Juárez" },
                    { 42, 21, "", null, true, "Cuayuca de Andrade" },
                    { 42, 24, "", null, true, "Tanquián de Escobedo" },
                    { 42, 26, "", null, true, "Navojoa" },
                    { 42, 28, "", null, true, "Villagrán" },
                    { 42, 29, "", null, true, "Xicohtzinco" },
                    { 42, 30, "", null, true, "Colipa" },
                    { 42, 31, "", null, true, "Kantunil" },
                    { 42, 32, "", null, true, "Sombrerete" },
                    { 43, 7, "", null, true, "Ixtacomitán" },
                    { 43, 8, "", null, true, "Matachí" },
                    { 43, 11, "", null, true, "Victoria" },
                    { 43, 12, "", null, true, "Metlatónoc" },
                    { 43, 13, "", null, true, "Nicolás Flores" },
                    { 43, 14, "", null, true, "La Huerta" },
                    { 43, 15, "", null, true, "Xalatlaco" },
                    { 43, 16, "", null, true, "Jacona" },
                    { 43, 19, "", null, true, "Rayones" },
                    { 43, 20, "", null, true, "Heroica Ciudad de Juchitán de Zaragoza" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 43, 21, "", null, true, "Cuetzalan del Progreso" },
                    { 43, 24, "", null, true, "Tierra Nueva" },
                    { 43, 26, "", null, true, "Nogales" },
                    { 43, 28, "", null, true, "Xicoténcatl" },
                    { 43, 29, "", null, true, "Yauhquemehcan" },
                    { 43, 30, "", null, true, "Comapa" },
                    { 43, 31, "", null, true, "Kaua" },
                    { 43, 32, "", null, true, "Susticacán" },
                    { 44, 7, "", null, true, "Ixtapa" },
                    { 44, 8, "", null, true, "Matamoros" },
                    { 44, 11, "", null, true, "Villagrán" },
                    { 44, 12, "", null, true, "Mochitlán" },
                    { 44, 13, "", null, true, "Nopala de Villagrán" },
                    { 44, 14, "", null, true, "Ixtlahuacán de los Membrillos" },
                    { 44, 15, "", null, true, "Jaltenco" },
                    { 44, 16, "", null, true, "Jiménez" },
                    { 44, 19, "", null, true, "Sabinas Hidalgo" },
                    { 44, 20, "", null, true, "Loma Bonita" },
                    { 44, 21, "", null, true, "Cuyoaco" },
                    { 44, 24, "", null, true, "Vanegas" },
                    { 44, 26, "", null, true, "Onavas" },
                    { 44, 29, "", null, true, "Zacatelco" },
                    { 44, 30, "", null, true, "Córdoba" },
                    { 44, 31, "", null, true, "Kinchil" },
                    { 44, 32, "", null, true, "Tabasco" },
                    { 45, 7, "", null, true, "Ixtapangajoya" },
                    { 45, 8, "", null, true, "Meoqui" },
                    { 45, 11, "", null, true, "Xichú" },
                    { 45, 12, "", null, true, "Olinalá" },
                    { 45, 13, "", null, true, "Omitlán de Juárez" },
                    { 45, 14, "", null, true, "Ixtlahuacán del Río" },
                    { 45, 15, "", null, true, "Jilotepec" },
                    { 45, 16, "", null, true, "Jiquilpan" },
                    { 45, 19, "", null, true, "Salinas Victoria" },
                    { 45, 20, "", null, true, "Magdalena Apasco" },
                    { 45, 21, "", null, true, "Chalchicomula de Sesma" },
                    { 45, 24, "", null, true, "Venado" },
                    { 45, 26, "", null, true, "Opodepe" },
                    { 45, 29, "", null, true, "Benito Juárez" },
                    { 45, 30, "", null, true, "Cosamaloapan de Carpio" },
                    { 45, 31, "", null, true, "Kopomá" },
                    { 45, 32, "", null, true, "Tepechitlán" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 46, 7, "", null, true, "Jiquipilas" },
                    { 46, 8, "", null, true, "Morelos" },
                    { 46, 11, "", null, true, "Yuriria" },
                    { 46, 12, "", null, true, "Ometepec" },
                    { 46, 13, "", null, true, "San Felipe Orizatlán" },
                    { 46, 14, "", null, true, "Jalostotitlán" },
                    { 46, 15, "", null, true, "Jilotzingo" },
                    { 46, 16, "", null, true, "Juárez" },
                    { 46, 19, "", null, true, "San Nicolás de los Garza" },
                    { 46, 20, "", null, true, "Magdalena Jaltepec" },
                    { 46, 21, "", null, true, "Chapulco" },
                    { 46, 24, "", null, true, "Villa de Arriaga" },
                    { 46, 26, "", null, true, "Oquitoa" },
                    { 46, 29, "", null, true, "Emiliano Zapata" },
                    { 46, 30, "", null, true, "Cosautlán de Carvajal" },
                    { 46, 31, "", null, true, "Mama" },
                    { 46, 32, "", null, true, "Tepetongo" },
                    { 47, 7, "", null, true, "Jitotol" },
                    { 47, 8, "", null, true, "Moris" },
                    { 47, 12, "", null, true, "Pedro Ascencio Alquisiras" },
                    { 47, 13, "", null, true, "Pacula" },
                    { 47, 14, "", null, true, "Jamay" },
                    { 47, 15, "", null, true, "Jiquipilco" },
                    { 47, 16, "", null, true, "Jungapeo" },
                    { 47, 19, "", null, true, "Hidalgo" },
                    { 47, 20, "", null, true, "Santa Magdalena Jicotlán" },
                    { 47, 21, "", null, true, "Chiautla" },
                    { 47, 24, "", null, true, "Villa de Guadalupe" },
                    { 47, 26, "", null, true, "Pitiquito" },
                    { 47, 29, "", null, true, "Lázaro Cárdenas" },
                    { 47, 30, "", null, true, "Coscomatepec" },
                    { 47, 31, "", null, true, "Maní" },
                    { 47, 32, "", null, true, "Teúl de González Ortega" },
                    { 48, 7, "", null, true, "Juárez" },
                    { 48, 8, "", null, true, "Namiquipa" },
                    { 48, 12, "", null, true, "Petatlán" },
                    { 48, 13, "", null, true, "Pachuca de Soto" },
                    { 48, 14, "", null, true, "Jesús María" },
                    { 48, 15, "", null, true, "Jocotitlán" },
                    { 48, 16, "", null, true, "Lagunillas" },
                    { 48, 19, "", null, true, "Santa Catarina" },
                    { 48, 20, "", null, true, "Magdalena Mixtepec" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 48, 21, "", null, true, "Chiautzingo" },
                    { 48, 24, "", null, true, "Villa de la Paz" },
                    { 48, 26, "", null, true, "Puerto Peñasco" },
                    { 48, 29, "", null, true, "La Magdalena Tlaltelulco" },
                    { 48, 30, "", null, true, "Cosoleacaque" },
                    { 48, 31, "", null, true, "Maxcanú" },
                    { 48, 32, "", null, true, "Tlaltenango de Sánchez Román" },
                    { 49, 7, "", null, true, "Larráinzar" },
                    { 49, 8, "", null, true, "Nonoava" },
                    { 49, 12, "", null, true, "Pilcaya" },
                    { 49, 13, "", null, true, "Pisaflores" },
                    { 49, 14, "", null, true, "Jilotlán de los Dolores" },
                    { 49, 15, "", null, true, "Joquicingo" },
                    { 49, 16, "", null, true, "Madero" },
                    { 49, 19, "", null, true, "Santiago" },
                    { 49, 20, "", null, true, "Magdalena Ocotlán" },
                    { 49, 21, "", null, true, "Chiconcuautla" },
                    { 49, 24, "", null, true, "Villa de Ramos" },
                    { 49, 26, "", null, true, "Quiriego" },
                    { 49, 29, "", null, true, "San Damián Texóloc" },
                    { 49, 30, "", null, true, "Cotaxtla" },
                    { 49, 31, "", null, true, "Mayapán" },
                    { 49, 32, "", null, true, "Valparaíso" },
                    { 50, 7, "", null, true, "La Libertad" },
                    { 50, 8, "", null, true, "Nuevo Casas Grandes" },
                    { 50, 12, "", null, true, "Pungarabato" },
                    { 50, 13, "", null, true, "Progreso de Obregón" },
                    { 50, 14, "", null, true, "Jocotepec" },
                    { 50, 15, "", null, true, "Juchitepec" },
                    { 50, 16, "", null, true, "Maravatío" },
                    { 50, 19, "", null, true, "Vallecillo" },
                    { 50, 20, "", null, true, "Magdalena Peñasco" },
                    { 50, 21, "", null, true, "Chichiquila" },
                    { 50, 24, "", null, true, "Villa de Reyes" },
                    { 50, 26, "", null, true, "Rayón" },
                    { 50, 29, "", null, true, "San Francisco Tetlanohcan" },
                    { 50, 30, "", null, true, "Coxquihui" },
                    { 50, 31, "", null, true, "Mérida" },
                    { 50, 32, "", null, true, "Vetagrande" },
                    { 51, 7, "", null, true, "Mapastepec" },
                    { 51, 8, "", null, true, "Ocampo" },
                    { 51, 12, "", null, true, "Quechultenango" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 51, 13, "", null, true, "Mineral de la Reforma" },
                    { 51, 14, "", null, true, "Juanacatlán" },
                    { 51, 15, "", null, true, "Lerma" },
                    { 51, 16, "", null, true, "Marcos Castellanos" },
                    { 51, 19, "", null, true, "Villaldama" },
                    { 51, 20, "", null, true, "Magdalena Teitipac" },
                    { 51, 21, "", null, true, "Chietla" },
                    { 51, 24, "", null, true, "Villa Hidalgo" },
                    { 51, 26, "", null, true, "Rosario" },
                    { 51, 29, "", null, true, "San Jerónimo Zacualpan" },
                    { 51, 30, "", null, true, "Coyutla" },
                    { 51, 31, "", null, true, "Mocochá" },
                    { 51, 32, "", null, true, "Villa de Cos" },
                    { 52, 7, "", null, true, "Las Margaritas" },
                    { 52, 8, "", null, true, "Ojinaga" },
                    { 52, 12, "", null, true, "San Luis Acatlán" },
                    { 52, 13, "", null, true, "San Agustín Tlaxiaca" },
                    { 52, 14, "", null, true, "Juchitlán" },
                    { 52, 15, "", null, true, "Malinalco" },
                    { 52, 16, "", null, true, "Lázaro Cárdenas" },
                    { 52, 20, "", null, true, "Magdalena Tequisistlán" },
                    { 52, 21, "", null, true, "Chigmecatitlán" },
                    { 52, 24, "", null, true, "Villa Juárez" },
                    { 52, 26, "", null, true, "Sahuaripa" },
                    { 52, 29, "", null, true, "San José Teacalco" },
                    { 52, 30, "", null, true, "Cuichapa" },
                    { 52, 31, "", null, true, "Motul" },
                    { 52, 32, "", null, true, "Villa García" },
                    { 53, 7, "", null, true, "Mazapa de Madero" },
                    { 53, 8, "", null, true, "Praxedis G. Guerrero" },
                    { 53, 12, "", null, true, "San Marcos" },
                    { 53, 13, "", null, true, "San Bartolo Tutotepec" },
                    { 53, 14, "", null, true, "Lagos de Moreno" },
                    { 53, 15, "", null, true, "Melchor Ocampo" },
                    { 53, 16, "", null, true, "Morelia" },
                    { 53, 20, "", null, true, "Magdalena Tlacotepec" },
                    { 53, 21, "", null, true, "Chignahuapan" },
                    { 53, 24, "", null, true, "Axtla de Terrazas" },
                    { 53, 26, "", null, true, "San Felipe de Jesús" },
                    { 53, 29, "", null, true, "San Juan Huactzinco" },
                    { 53, 30, "", null, true, "Cuitláhuac" },
                    { 53, 31, "", null, true, "Muna" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 53, 32, "", null, true, "Villa González Ortega" },
                    { 54, 7, "", null, true, "Mazatán" },
                    { 54, 8, "", null, true, "Riva Palacio" },
                    { 54, 12, "", null, true, "San Miguel Totolapan" },
                    { 54, 13, "", null, true, "San Salvador" },
                    { 54, 14, "", null, true, "El Limón" },
                    { 54, 15, "", null, true, "Metepec" },
                    { 54, 16, "", null, true, "Morelos" },
                    { 54, 20, "", null, true, "Magdalena Zahuatlán" },
                    { 54, 21, "", null, true, "Chignautla" },
                    { 54, 24, "", null, true, "Xilitla" },
                    { 54, 26, "", null, true, "San Javier" },
                    { 54, 29, "", null, true, "San Lorenzo Axocomanitla" },
                    { 54, 30, "", null, true, "Chacaltianguis" },
                    { 54, 31, "", null, true, "Muxupip" },
                    { 54, 32, "", null, true, "Villa Hidalgo" },
                    { 55, 7, "", null, true, "Metapa" },
                    { 55, 8, "", null, true, "Rosales" },
                    { 55, 12, "", null, true, "Taxco de Alarcón" },
                    { 55, 13, "", null, true, "Santiago de Anaya" },
                    { 55, 14, "", null, true, "Magdalena" },
                    { 55, 15, "", null, true, "Mexicaltzingo" },
                    { 55, 16, "", null, true, "Múgica" },
                    { 55, 20, "", null, true, "Mariscala de Juárez" },
                    { 55, 21, "", null, true, "Chila" },
                    { 55, 24, "", null, true, "Zaragoza" },
                    { 55, 26, "", null, true, "San Luis Río Colorado" },
                    { 55, 29, "", null, true, "San Lucas Tecopilco" },
                    { 55, 30, "", null, true, "Chalma" },
                    { 55, 31, "", null, true, "Opichén" },
                    { 55, 32, "", null, true, "Villanueva" },
                    { 56, 7, "", null, true, "Mitontic" },
                    { 56, 8, "", null, true, "Rosario" },
                    { 56, 12, "", null, true, "Tecoanapa" },
                    { 56, 13, "", null, true, "Santiago Tulantepec de Lugo Guerrero" },
                    { 56, 14, "", null, true, "Santa María del Oro" },
                    { 56, 15, "", null, true, "Morelos" },
                    { 56, 16, "", null, true, "Nahuatzen" },
                    { 56, 20, "", null, true, "Mártires de Tacubaya" },
                    { 56, 21, "", null, true, "Chila de la Sal" },
                    { 56, 24, "", null, true, "Villa de Arista" },
                    { 56, 26, "", null, true, "San Miguel de Horcasitas" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 56, 29, "", null, true, "Santa Ana Nopalucan" },
                    { 56, 30, "", null, true, "Chiconamel" },
                    { 56, 31, "", null, true, "Oxkutzcab" },
                    { 56, 32, "", null, true, "Zacatecas" },
                    { 57, 7, "", null, true, "Motozintla" },
                    { 57, 8, "", null, true, "San Francisco de Borja" },
                    { 57, 12, "", null, true, "Técpan de Galeana" },
                    { 57, 13, "", null, true, "Singuilucan" },
                    { 57, 14, "", null, true, "La Manzanilla de la Paz" },
                    { 57, 15, "", null, true, "Naucalpan de Juárez" },
                    { 57, 16, "", null, true, "Nocupétaro" },
                    { 57, 20, "", null, true, "Matías Romero Avendaño" },
                    { 57, 21, "", null, true, "Honey" },
                    { 57, 24, "", null, true, "Matlapa" },
                    { 57, 26, "", null, true, "San Pedro de la Cueva" },
                    { 57, 29, "", null, true, "Santa Apolonia Teacalco" },
                    { 57, 30, "", null, true, "Chiconquiaco" },
                    { 57, 31, "", null, true, "Panabá" },
                    { 57, 32, "", null, true, "Trancoso" },
                    { 58, 7, "", null, true, "Nicolás Ruíz" },
                    { 58, 8, "", null, true, "San Francisco de Conchos" },
                    { 58, 12, "", null, true, "Teloloapan" },
                    { 58, 13, "", null, true, "Tasquillo" },
                    { 58, 14, "", null, true, "Mascota" },
                    { 58, 15, "", null, true, "Nezahualcóyotl" },
                    { 58, 16, "", null, true, "Nuevo Parangaricutiro" },
                    { 58, 20, "", null, true, "Mazatlán Villa de Flores" },
                    { 58, 21, "", null, true, "Chilchotla" },
                    { 58, 24, "", null, true, "El Naranjo" },
                    { 58, 26, "", null, true, "Santa Ana" },
                    { 58, 29, "", null, true, "Santa Catarina Ayometla" },
                    { 58, 30, "", null, true, "Chicontepec" },
                    { 58, 31, "", null, true, "Peto" },
                    { 58, 32, "", null, true, "Santa María de la Paz" },
                    { 59, 7, "", null, true, "Ocosingo" },
                    { 59, 8, "", null, true, "San Francisco del Oro" },
                    { 59, 12, "", null, true, "Tepecoacuilco de Trujano" },
                    { 59, 13, "", null, true, "Tecozautla" },
                    { 59, 14, "", null, true, "Mazamitla" },
                    { 59, 15, "", null, true, "Nextlalpan" },
                    { 59, 16, "", null, true, "Nuevo Urecho" },
                    { 59, 20, "", null, true, "Miahuatlán de Porfirio Díaz" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 59, 21, "", null, true, "Chinantla" },
                    { 59, 26, "", null, true, "Santa Cruz" },
                    { 59, 29, "", null, true, "Santa Cruz Quilehtla" },
                    { 59, 30, "", null, true, "Chinameca" },
                    { 59, 31, "", null, true, "Progreso" },
                    { 60, 7, "", null, true, "Ocotepec" },
                    { 60, 8, "", null, true, "Santa Bárbara" },
                    { 60, 12, "", null, true, "Tetipac" },
                    { 60, 13, "", null, true, "Tenango de Doria" },
                    { 60, 14, "", null, true, "Mexticacán" },
                    { 60, 15, "", null, true, "Nicolás Romero" },
                    { 60, 16, "", null, true, "Numarán" },
                    { 60, 20, "", null, true, "Mixistlán de la Reforma" },
                    { 60, 21, "", null, true, "Domingo Arenas" },
                    { 60, 26, "", null, true, "Sáric" },
                    { 60, 29, "", null, true, "Santa Isabel Xiloxoxtla" },
                    { 60, 30, "", null, true, "Chinampa de Gorostiza" },
                    { 60, 31, "", null, true, "Quintana Roo" },
                    { 61, 7, "", null, true, "Ocozocoautla de Espinosa" },
                    { 61, 8, "", null, true, "Satevó" },
                    { 61, 12, "", null, true, "Tixtla de Guerrero" },
                    { 61, 13, "", null, true, "Tepeapulco" },
                    { 61, 14, "", null, true, "Mezquitic" },
                    { 61, 15, "", null, true, "Nopaltepec" },
                    { 61, 16, "", null, true, "Ocampo" },
                    { 61, 20, "", null, true, "Monjas" },
                    { 61, 21, "", null, true, "Eloxochitlán" },
                    { 61, 26, "", null, true, "Soyopa" },
                    { 61, 30, "", null, true, "Las Choapas" },
                    { 61, 31, "", null, true, "Río Lagartos" },
                    { 62, 7, "", null, true, "Ostuacán" },
                    { 62, 8, "", null, true, "Saucillo" },
                    { 62, 12, "", null, true, "Tlacoachistlahuaca" },
                    { 62, 13, "", null, true, "Tepehuacán de Guerrero" },
                    { 62, 14, "", null, true, "Mixtlán" },
                    { 62, 15, "", null, true, "Ocoyoacac" },
                    { 62, 16, "", null, true, "Pajacuarán" },
                    { 62, 20, "", null, true, "Natividad" },
                    { 62, 21, "", null, true, "Epatlán" },
                    { 62, 26, "", null, true, "Suaqui Grande" },
                    { 62, 30, "", null, true, "Chocamán" },
                    { 62, 31, "", null, true, "Sacalum" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 63, 7, "", null, true, "Osumacinta" },
                    { 63, 8, "", null, true, "Temósachic" },
                    { 63, 12, "", null, true, "Tlacoapa" },
                    { 63, 13, "", null, true, "Tepeji del Río de Ocampo" },
                    { 63, 14, "", null, true, "Ocotlán" },
                    { 63, 15, "", null, true, "Ocuilan" },
                    { 63, 16, "", null, true, "Panindícuaro" },
                    { 63, 20, "", null, true, "Nazareno Etla" },
                    { 63, 21, "", null, true, "Esperanza" },
                    { 63, 26, "", null, true, "Tepache" },
                    { 63, 30, "", null, true, "Chontla" },
                    { 63, 31, "", null, true, "Samahil" },
                    { 64, 7, "", null, true, "Oxchuc" },
                    { 64, 8, "", null, true, "El Tule" },
                    { 64, 12, "", null, true, "Tlalchapa" },
                    { 64, 13, "", null, true, "Tepetitlán" },
                    { 64, 14, "", null, true, "Ojuelos de Jalisco" },
                    { 64, 15, "", null, true, "El Oro" },
                    { 64, 16, "", null, true, "Parácuaro" },
                    { 64, 20, "", null, true, "Nejapa de Madero" },
                    { 64, 21, "", null, true, "Francisco Z. Mena" },
                    { 64, 26, "", null, true, "Trincheras" },
                    { 64, 30, "", null, true, "Chumatlán" },
                    { 64, 31, "", null, true, "Sanahcat" },
                    { 65, 7, "", null, true, "Palenque" },
                    { 65, 8, "", null, true, "Urique" },
                    { 65, 12, "", null, true, "Tlalixtaquilla de Maldonado" },
                    { 65, 13, "", null, true, "Tetepango" },
                    { 65, 14, "", null, true, "Pihuamo" },
                    { 65, 15, "", null, true, "Otumba" },
                    { 65, 16, "", null, true, "Paracho" },
                    { 65, 20, "", null, true, "Ixpantepec Nieves" },
                    { 65, 21, "", null, true, "General Felipe Ángeles" },
                    { 65, 26, "", null, true, "Tubutama" },
                    { 65, 30, "", null, true, "Emiliano Zapata" },
                    { 65, 31, "", null, true, "San Felipe" },
                    { 66, 7, "", null, true, "Pantelhó" },
                    { 66, 8, "", null, true, "Uruachi" },
                    { 66, 12, "", null, true, "Tlapa de Comonfort" },
                    { 66, 13, "", null, true, "Villa de Tezontepec" },
                    { 66, 14, "", null, true, "Poncitlán" },
                    { 66, 15, "", null, true, "Otzoloapan" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 66, 16, "", null, true, "Pátzcuaro" },
                    { 66, 20, "", null, true, "Santiago Niltepec" },
                    { 66, 21, "", null, true, "Guadalupe" },
                    { 66, 26, "", null, true, "Ures" },
                    { 66, 30, "", null, true, "Espinal" },
                    { 66, 31, "", null, true, "Santa Elena" },
                    { 67, 7, "", null, true, "Pantepec" },
                    { 67, 8, "", null, true, "Valle de Zaragoza" },
                    { 67, 12, "", null, true, "Tlapehuala" },
                    { 67, 13, "", null, true, "Tezontepec de Aldama" },
                    { 67, 14, "", null, true, "Puerto Vallarta" },
                    { 67, 15, "", null, true, "Otzolotepec" },
                    { 67, 16, "", null, true, "Penjamillo" },
                    { 67, 20, "", null, true, "Oaxaca de Juárez" },
                    { 67, 21, "", null, true, "Guadalupe Victoria" },
                    { 67, 26, "", null, true, "Villa Hidalgo" },
                    { 67, 30, "", null, true, "Filomeno Mata" },
                    { 67, 31, "", null, true, "Seyé" },
                    { 68, 7, "", null, true, "Pichucalco" },
                    { 68, 12, "", null, true, "La Unión de Isidoro Montes de Oca" },
                    { 68, 13, "", null, true, "Tianguistengo" },
                    { 68, 14, "", null, true, "Villa Purificación" },
                    { 68, 15, "", null, true, "Ozumba" },
                    { 68, 16, "", null, true, "Peribán" },
                    { 68, 20, "", null, true, "Ocotlán de Morelos" },
                    { 68, 21, "", null, true, "Hermenegildo Galeana" },
                    { 68, 26, "", null, true, "Villa Pesqueira" },
                    { 68, 30, "", null, true, "Fortín" },
                    { 68, 31, "", null, true, "Sinanché" },
                    { 69, 7, "", null, true, "Pijijiapan" },
                    { 69, 12, "", null, true, "Xalpatláhuac" },
                    { 69, 13, "", null, true, "Tizayuca" },
                    { 69, 14, "", null, true, "Quitupan" },
                    { 69, 15, "", null, true, "Papalotla" },
                    { 69, 16, "", null, true, "La Piedad" },
                    { 69, 20, "", null, true, "La Pe" },
                    { 69, 21, "", null, true, "Huaquechula" },
                    { 69, 26, "", null, true, "Yécora" },
                    { 69, 30, "", null, true, "Gutiérrez Zamora" },
                    { 69, 31, "", null, true, "Sotuta" },
                    { 70, 7, "", null, true, "El Porvenir" },
                    { 70, 12, "", null, true, "Xochihuehuetlán" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 70, 13, "", null, true, "Tlahuelilpan" },
                    { 70, 14, "", null, true, "El Salto" },
                    { 70, 15, "", null, true, "La Paz" },
                    { 70, 16, "", null, true, "Purépero" },
                    { 70, 20, "", null, true, "Pinotepa de Don Luis" },
                    { 70, 21, "", null, true, "Huatlatlauca" },
                    { 70, 26, "", null, true, "General Plutarco Elías Calles" },
                    { 70, 30, "", null, true, "Hidalgotitlán" },
                    { 70, 31, "", null, true, "Sucilá" },
                    { 71, 7, "", null, true, "Villa Comaltitlán" },
                    { 71, 12, "", null, true, "Xochistlahuaca" },
                    { 71, 13, "", null, true, "Tlahuiltepa" },
                    { 71, 14, "", null, true, "San Cristóbal de la Barranca" },
                    { 71, 15, "", null, true, "Polotitlán" },
                    { 71, 16, "", null, true, "Puruándiro" },
                    { 71, 20, "", null, true, "Pluma Hidalgo" },
                    { 71, 21, "", null, true, "Huauchinango" },
                    { 71, 26, "", null, true, "Benito Juárez" },
                    { 71, 30, "", null, true, "Huatusco" },
                    { 71, 31, "", null, true, "Sudzal" },
                    { 72, 7, "", null, true, "Pueblo Nuevo Solistahuacán" },
                    { 72, 12, "", null, true, "Zapotitlán Tablas" },
                    { 72, 13, "", null, true, "Tlanalapa" },
                    { 72, 14, "", null, true, "San Diego de Alejandría" },
                    { 72, 15, "", null, true, "Rayón" },
                    { 72, 16, "", null, true, "Queréndaro" },
                    { 72, 20, "", null, true, "San José del Progreso" },
                    { 72, 21, "", null, true, "Huehuetla" },
                    { 72, 26, "", null, true, "San Ignacio Río Muerto" },
                    { 72, 30, "", null, true, "Huayacocotla" },
                    { 72, 31, "", null, true, "Suma" },
                    { 73, 7, "", null, true, "Rayón" },
                    { 73, 12, "", null, true, "Zirándaro" },
                    { 73, 13, "", null, true, "Tlanchinol" },
                    { 73, 14, "", null, true, "San Juan de los Lagos" },
                    { 73, 15, "", null, true, "San Antonio la Isla" },
                    { 73, 16, "", null, true, "Quiroga" },
                    { 73, 20, "", null, true, "Putla Villa de Guerrero" },
                    { 73, 21, "", null, true, "Huehuetlán el Chico" },
                    { 73, 30, "", null, true, "Hueyapan de Ocampo" },
                    { 73, 31, "", null, true, "Tahdziú" },
                    { 74, 7, "", null, true, "Reforma" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 74, 12, "", null, true, "Zitlala" },
                    { 74, 13, "", null, true, "Tlaxcoapan" },
                    { 74, 14, "", null, true, "San Julián" },
                    { 74, 15, "", null, true, "San Felipe del Progreso" },
                    { 74, 16, "", null, true, "Cojumatlán de Régules" },
                    { 74, 20, "", null, true, "Santa Catarina Quioquitani" },
                    { 74, 21, "", null, true, "Huejotzingo" },
                    { 74, 30, "", null, true, "Huiloapan de Cuauhtémoc" },
                    { 74, 31, "", null, true, "Tahmek" },
                    { 75, 7, "", null, true, "Las Rosas" },
                    { 75, 12, "", null, true, "Eduardo Neri" },
                    { 75, 13, "", null, true, "Tolcayuca" },
                    { 75, 14, "", null, true, "San Marcos" },
                    { 75, 15, "", null, true, "San Martín de las Pirámides" },
                    { 75, 16, "", null, true, "Los Reyes" },
                    { 75, 20, "", null, true, "Reforma de Pineda" },
                    { 75, 21, "", null, true, "Hueyapan" },
                    { 75, 30, "", null, true, "Ignacio de la Llave" },
                    { 75, 31, "", null, true, "Teabo" },
                    { 76, 7, "", null, true, "Sabanilla" },
                    { 76, 12, "", null, true, "Acatepec" },
                    { 76, 13, "", null, true, "Tula de Allende" },
                    { 76, 14, "", null, true, "San Martín de Bolaños" },
                    { 76, 15, "", null, true, "San Mateo Atenco" },
                    { 76, 16, "", null, true, "Sahuayo" },
                    { 76, 20, "", null, true, "La Reforma" },
                    { 76, 21, "", null, true, "Hueytamalco" },
                    { 76, 30, "", null, true, "Ilamatlán" },
                    { 76, 31, "", null, true, "Tecoh" },
                    { 77, 7, "", null, true, "Salto de Agua" },
                    { 77, 12, "", null, true, "Marquelia" },
                    { 77, 13, "", null, true, "Tulancingo de Bravo" },
                    { 77, 14, "", null, true, "San Martín Hidalgo" },
                    { 77, 15, "", null, true, "San Simón de Guerrero" },
                    { 77, 16, "", null, true, "San Lucas" },
                    { 77, 20, "", null, true, "Reyes Etla" },
                    { 77, 21, "", null, true, "Hueytlalpan" },
                    { 77, 30, "", null, true, "Isla" },
                    { 77, 31, "", null, true, "Tekal de Venegas" },
                    { 78, 7, "", null, true, "San Cristóbal de las Casas" },
                    { 78, 12, "", null, true, "Cochoapa el Grande" },
                    { 78, 13, "", null, true, "Xochiatipan" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 78, 14, "", null, true, "San Miguel el Alto" },
                    { 78, 15, "", null, true, "Santo Tomás" },
                    { 78, 16, "", null, true, "Santa Ana Maya" },
                    { 78, 20, "", null, true, "Rojas de Cuauhtémoc" },
                    { 78, 21, "", null, true, "Huitzilan de Serdán" },
                    { 78, 30, "", null, true, "Ixcatepec" },
                    { 78, 31, "", null, true, "Tekantó" },
                    { 79, 7, "", null, true, "San Fernando" },
                    { 79, 12, "", null, true, "José Joaquín de Herrera" },
                    { 79, 13, "", null, true, "Xochicoatlán" },
                    { 79, 14, "", null, true, "Gómez Farías" },
                    { 79, 15, "", null, true, "Soyaniquilpan de Juárez" },
                    { 79, 16, "", null, true, "Salvador Escalante" },
                    { 79, 20, "", null, true, "Salina Cruz" },
                    { 79, 21, "", null, true, "Huitziltepec" },
                    { 79, 30, "", null, true, "Ixhuacán de los Reyes" },
                    { 79, 31, "", null, true, "Tekax" },
                    { 80, 7, "", null, true, "Siltepec" },
                    { 80, 12, "", null, true, "Juchitán" },
                    { 80, 13, "", null, true, "Yahualica" },
                    { 80, 14, "", null, true, "San Sebastián del Oeste" },
                    { 80, 15, "", null, true, "Sultepec" },
                    { 80, 16, "", null, true, "Senguio" },
                    { 80, 20, "", null, true, "San Agustín Amatengo" },
                    { 80, 21, "", null, true, "Atlequizayan" },
                    { 80, 30, "", null, true, "Ixhuatlán del Café" },
                    { 80, 31, "", null, true, "Tekit" },
                    { 81, 7, "", null, true, "Simojovel" },
                    { 81, 12, "", null, true, "Iliatenco" },
                    { 81, 13, "", null, true, "Zacualtipán de Ángeles" },
                    { 81, 14, "", null, true, "Santa María de los Ángeles" },
                    { 81, 15, "", null, true, "Tecámac" },
                    { 81, 16, "", null, true, "Susupuato" },
                    { 81, 20, "", null, true, "San Agustín Atenango" },
                    { 81, 21, "", null, true, "Ixcamilpa de Guerrero" },
                    { 81, 30, "", null, true, "Ixhuatlancillo" },
                    { 81, 31, "", null, true, "Tekom" },
                    { 82, 7, "", null, true, "Sitalá" },
                    { 82, 13, "", null, true, "Zapotlán de Juárez" },
                    { 82, 14, "", null, true, "Sayula" },
                    { 82, 15, "", null, true, "Tejupilco" },
                    { 82, 16, "", null, true, "Tacámbaro" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 82, 20, "", null, true, "San Agustín Chayuco" },
                    { 82, 21, "", null, true, "Ixcaquixtla" },
                    { 82, 30, "", null, true, "Ixhuatlán del Sureste" },
                    { 82, 31, "", null, true, "Telchac Pueblo" },
                    { 83, 7, "", null, true, "Socoltenango" },
                    { 83, 13, "", null, true, "Zempoala" },
                    { 83, 14, "", null, true, "Tala" },
                    { 83, 15, "", null, true, "Temamatla" },
                    { 83, 16, "", null, true, "Tancítaro" },
                    { 83, 20, "", null, true, "San Agustín de las Juntas" },
                    { 83, 21, "", null, true, "Ixtacamaxtitlán" },
                    { 83, 30, "", null, true, "Ixhuatlán de Madero" },
                    { 83, 31, "", null, true, "Telchac Puerto" },
                    { 84, 7, "", null, true, "Solosuchiapa" },
                    { 84, 13, "", null, true, "Zimapán" },
                    { 84, 14, "", null, true, "Talpa de Allende" },
                    { 84, 15, "", null, true, "Temascalapa" },
                    { 84, 16, "", null, true, "Tangamandapio" },
                    { 84, 20, "", null, true, "San Agustín Etla" },
                    { 84, 21, "", null, true, "Ixtepec" },
                    { 84, 30, "", null, true, "Ixmatlahuacan" },
                    { 84, 31, "", null, true, "Temax" },
                    { 85, 7, "", null, true, "Soyaló" },
                    { 85, 14, "", null, true, "Tamazula de Gordiano" },
                    { 85, 15, "", null, true, "Temascalcingo" },
                    { 85, 16, "", null, true, "Tangancícuaro" },
                    { 85, 20, "", null, true, "San Agustín Loxicha" },
                    { 85, 21, "", null, true, "Izúcar de Matamoros" },
                    { 85, 30, "", null, true, "Ixtaczoquitlán" },
                    { 85, 31, "", null, true, "Temozón" },
                    { 86, 7, "", null, true, "Suchiapa" },
                    { 86, 14, "", null, true, "Tapalpa" },
                    { 86, 15, "", null, true, "Temascaltepec" },
                    { 86, 16, "", null, true, "Tanhuato" },
                    { 86, 20, "", null, true, "San Agustín Tlacotepec" },
                    { 86, 21, "", null, true, "Jalpan" },
                    { 86, 30, "", null, true, "Jalacingo" },
                    { 86, 31, "", null, true, "Tepakán" },
                    { 87, 7, "", null, true, "Suchiate" },
                    { 87, 14, "", null, true, "Tecalitlán" },
                    { 87, 15, "", null, true, "Temoaya" },
                    { 87, 16, "", null, true, "Taretan" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 87, 20, "", null, true, "San Agustín Yatareni" },
                    { 87, 21, "", null, true, "Jolalpan" },
                    { 87, 30, "", null, true, "Xalapa" },
                    { 87, 31, "", null, true, "Tetiz" },
                    { 88, 7, "", null, true, "Sunuapa" },
                    { 88, 14, "", null, true, "Tecolotlán" },
                    { 88, 15, "", null, true, "Tenancingo" },
                    { 88, 16, "", null, true, "Tarímbaro" },
                    { 88, 20, "", null, true, "San Andrés Cabecera Nueva" },
                    { 88, 21, "", null, true, "Jonotla" },
                    { 88, 30, "", null, true, "Jalcomulco" },
                    { 88, 31, "", null, true, "Teya" },
                    { 89, 7, "", null, true, "Tapachula" },
                    { 89, 14, "", null, true, "Techaluta de Montenegro" },
                    { 89, 15, "", null, true, "Tenango del Aire" },
                    { 89, 16, "", null, true, "Tepalcatepec" },
                    { 89, 20, "", null, true, "San Andrés Dinicuiti" },
                    { 89, 21, "", null, true, "Jopala" },
                    { 89, 30, "", null, true, "Jáltipan" },
                    { 89, 31, "", null, true, "Ticul" },
                    { 90, 7, "", null, true, "Tapalapa" },
                    { 90, 14, "", null, true, "Tenamaxtlán" },
                    { 90, 15, "", null, true, "Tenango del Valle" },
                    { 90, 16, "", null, true, "Tingambato" },
                    { 90, 20, "", null, true, "San Andrés Huaxpaltepec" },
                    { 90, 21, "", null, true, "Juan C. Bonilla" },
                    { 90, 30, "", null, true, "Jamapa" },
                    { 90, 31, "", null, true, "Timucuy" },
                    { 91, 7, "", null, true, "Tapilula" },
                    { 91, 14, "", null, true, "Teocaltiche" },
                    { 91, 15, "", null, true, "Teoloyucan" },
                    { 91, 16, "", null, true, "Tingüindín" },
                    { 91, 20, "", null, true, "San Andrés Huayápam" },
                    { 91, 21, "", null, true, "Juan Galindo" },
                    { 91, 30, "", null, true, "Jesús Carranza" },
                    { 91, 31, "", null, true, "Tinum" },
                    { 92, 7, "", null, true, "Tecpatán" },
                    { 92, 14, "", null, true, "Teocuitatlán de Corona" },
                    { 92, 15, "", null, true, "Teotihuacán" },
                    { 92, 16, "", null, true, "Tiquicheo de Nicolás Romero" },
                    { 92, 20, "", null, true, "San Andrés Ixtlahuaca" },
                    { 92, 21, "", null, true, "Juan N. Méndez" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 92, 30, "", null, true, "Xico" },
                    { 92, 31, "", null, true, "Tixcacalcupul" },
                    { 93, 7, "", null, true, "Tenejapa" },
                    { 93, 14, "", null, true, "Tepatitlán de Morelos" },
                    { 93, 15, "", null, true, "Tepetlaoxtoc" },
                    { 93, 16, "", null, true, "Tlalpujahua" },
                    { 93, 20, "", null, true, "San Andrés Lagunas" },
                    { 93, 21, "", null, true, "Lafragua" },
                    { 93, 30, "", null, true, "Jilotepec" },
                    { 93, 31, "", null, true, "Tixkokob" },
                    { 94, 7, "", null, true, "Teopisca" },
                    { 94, 14, "", null, true, "Tequila" },
                    { 94, 15, "", null, true, "Tepetlixpa" },
                    { 94, 16, "", null, true, "Tlazazalca" },
                    { 94, 20, "", null, true, "San Andrés Nuxiño" },
                    { 94, 21, "", null, true, "Libres" },
                    { 94, 30, "", null, true, "Juan Rodríguez Clara" },
                    { 94, 31, "", null, true, "Tixmehuac" },
                    { 95, 14, "", null, true, "Teuchitlán" },
                    { 95, 15, "", null, true, "Tepotzotlán" },
                    { 95, 16, "", null, true, "Tocumbo" },
                    { 95, 20, "", null, true, "San Andrés Paxtlán" },
                    { 95, 21, "", null, true, "La Magdalena Tlatlauquitepec" },
                    { 95, 30, "", null, true, "Juchique de Ferrer" },
                    { 95, 31, "", null, true, "Tixpéhual" },
                    { 96, 7, "", null, true, "Tila" },
                    { 96, 14, "", null, true, "Tizapán el Alto" },
                    { 96, 15, "", null, true, "Tequixquiac" },
                    { 96, 16, "", null, true, "Tumbiscatío" },
                    { 96, 20, "", null, true, "San Andrés Sinaxtla" },
                    { 96, 21, "", null, true, "Mazapiltepec de Juárez" },
                    { 96, 30, "", null, true, "Landero y Coss" },
                    { 96, 31, "", null, true, "Tizimín" },
                    { 97, 7, "", null, true, "Tonalá" },
                    { 97, 14, "", null, true, "Tlajomulco de Zúñiga" },
                    { 97, 15, "", null, true, "Texcaltitlán" },
                    { 97, 16, "", null, true, "Turicato" },
                    { 97, 20, "", null, true, "San Andrés Solaga" },
                    { 97, 21, "", null, true, "Mixtla" },
                    { 97, 30, "", null, true, "Lerdo de Tejada" },
                    { 97, 31, "", null, true, "Tunkás" },
                    { 98, 7, "", null, true, "Totolapa" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 98, 14, "", null, true, "San Pedro Tlaquepaque" },
                    { 98, 15, "", null, true, "Texcalyacac" },
                    { 98, 16, "", null, true, "Tuxpan" },
                    { 98, 20, "", null, true, "San Andrés Teotilálpam" },
                    { 98, 21, "", null, true, "Molcaxac" },
                    { 98, 30, "", null, true, "Magdalena" },
                    { 98, 31, "", null, true, "Tzucacab" },
                    { 99, 7, "", null, true, "La Trinitaria" },
                    { 99, 14, "", null, true, "Tolimán" },
                    { 99, 15, "", null, true, "Texcoco" },
                    { 99, 16, "", null, true, "Tuzantla" },
                    { 99, 20, "", null, true, "San Andrés Tepetlapa" },
                    { 99, 21, "", null, true, "Cañada Morelos" },
                    { 99, 30, "", null, true, "Maltrata" },
                    { 99, 31, "", null, true, "Uayma" },
                    { 100, 7, "", null, true, "Tumbalá" },
                    { 100, 14, "", null, true, "Tomatlán" },
                    { 100, 15, "", null, true, "Tezoyuca" },
                    { 100, 16, "", null, true, "Tzintzuntzan" },
                    { 100, 20, "", null, true, "San Andrés Yaá" },
                    { 100, 21, "", null, true, "Naupan" },
                    { 100, 30, "", null, true, "Manlio Fabio Altamirano" },
                    { 100, 31, "", null, true, "Ucú" },
                    { 101, 7, "", null, true, "Tuxtla Gutiérrez" },
                    { 101, 14, "", null, true, "Tonalá" },
                    { 101, 15, "", null, true, "Tianguistenco" },
                    { 101, 16, "", null, true, "Tzitzio" },
                    { 101, 20, "", null, true, "San Andrés Zabache" },
                    { 101, 21, "", null, true, "Nauzontla" },
                    { 101, 30, "", null, true, "Mariano Escobedo" },
                    { 101, 31, "", null, true, "Umán" },
                    { 102, 7, "", null, true, "Tuxtla Chico" },
                    { 102, 14, "", null, true, "Tonaya" },
                    { 102, 15, "", null, true, "Timilpan" },
                    { 102, 16, "", null, true, "Uruapan" },
                    { 102, 20, "", null, true, "San Andrés Zautla" },
                    { 102, 21, "", null, true, "Nealtican" },
                    { 102, 30, "", null, true, "Martínez de la Torre" },
                    { 102, 31, "", null, true, "Valladolid" },
                    { 103, 7, "", null, true, "Tuzantán" },
                    { 103, 14, "", null, true, "Tonila" },
                    { 103, 15, "", null, true, "Tlalmanalco" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 103, 16, "", null, true, "Venustiano Carranza" },
                    { 103, 20, "", null, true, "San Antonino Castillo Velasco" },
                    { 103, 21, "", null, true, "Nicolás Bravo" },
                    { 103, 30, "", null, true, "Mecatlán" },
                    { 103, 31, "", null, true, "Xocchel" },
                    { 104, 7, "", null, true, "Tzimol" },
                    { 104, 14, "", null, true, "Totatiche" },
                    { 104, 15, "", null, true, "Tlalnepantla de Baz" },
                    { 104, 16, "", null, true, "Villamar" },
                    { 104, 20, "", null, true, "San Antonino el Alto" },
                    { 104, 21, "", null, true, "Nopalucan" },
                    { 104, 30, "", null, true, "Mecayapan" },
                    { 104, 31, "", null, true, "Yaxcabá" },
                    { 105, 7, "", null, true, "Unión Juárez" },
                    { 105, 14, "", null, true, "Tototlán" },
                    { 105, 15, "", null, true, "Tlatlaya" },
                    { 105, 16, "", null, true, "Vista Hermosa" },
                    { 105, 20, "", null, true, "San Antonino Monte Verde" },
                    { 105, 21, "", null, true, "Ocotepec" },
                    { 105, 30, "", null, true, "Medellín de Bravo" },
                    { 105, 31, "", null, true, "Yaxkukul" },
                    { 106, 7, "", null, true, "Venustiano Carranza" },
                    { 106, 14, "", null, true, "Tuxcacuesco" },
                    { 106, 15, "", null, true, "Toluca" },
                    { 106, 16, "", null, true, "Yurécuaro" },
                    { 106, 20, "", null, true, "San Antonio Acutla" },
                    { 106, 21, "", null, true, "Ocoyucan" },
                    { 106, 30, "", null, true, "Miahuatlán" },
                    { 106, 31, "", null, true, "Yobaín" },
                    { 107, 7, "", null, true, "Villa Corzo" },
                    { 107, 14, "", null, true, "Tuxcueca" },
                    { 107, 15, "", null, true, "Tonatico" },
                    { 107, 16, "", null, true, "Zacapu" },
                    { 107, 20, "", null, true, "San Antonio de la Cal" },
                    { 107, 21, "", null, true, "Olintla" },
                    { 107, 30, "", null, true, "Las Minas" },
                    { 108, 7, "", null, true, "Villaflores" },
                    { 108, 14, "", null, true, "Tuxpan" },
                    { 108, 15, "", null, true, "Tultepec" },
                    { 108, 16, "", null, true, "Zamora" },
                    { 108, 20, "", null, true, "San Antonio Huitepec" },
                    { 108, 21, "", null, true, "Oriental" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 108, 30, "", null, true, "Minatitlán" },
                    { 109, 7, "", null, true, "Yajalón" },
                    { 109, 14, "", null, true, "Unión de San Antonio" },
                    { 109, 15, "", null, true, "Tultitlán" },
                    { 109, 16, "", null, true, "Zináparo" },
                    { 109, 20, "", null, true, "San Antonio Nanahuatípam" },
                    { 109, 21, "", null, true, "Pahuatlán" },
                    { 109, 30, "", null, true, "Misantla" },
                    { 110, 7, "", null, true, "San Lucas" },
                    { 110, 14, "", null, true, "Unión de Tula" },
                    { 110, 15, "", null, true, "Valle de Bravo" },
                    { 110, 16, "", null, true, "Zinapécuaro" },
                    { 110, 20, "", null, true, "San Antonio Sinicahua" },
                    { 110, 21, "", null, true, "Palmar de Bravo" },
                    { 110, 30, "", null, true, "Mixtla de Altamirano" },
                    { 111, 7, "", null, true, "Zinacantán" },
                    { 111, 14, "", null, true, "Valle de Guadalupe" },
                    { 111, 15, "", null, true, "Villa de Allende" },
                    { 111, 16, "", null, true, "Ziracuaretiro" },
                    { 111, 20, "", null, true, "San Antonio Tepetlapa" },
                    { 111, 21, "", null, true, "Pantepec" },
                    { 111, 30, "", null, true, "Moloacán" },
                    { 112, 7, "", null, true, "San Juan Cancuc" },
                    { 112, 14, "", null, true, "Valle de Juárez" },
                    { 112, 15, "", null, true, "Villa del Carbón" },
                    { 112, 16, "", null, true, "Zitácuaro" },
                    { 112, 20, "", null, true, "San Baltazar Chichicápam" },
                    { 112, 21, "", null, true, "Petlalcingo" },
                    { 112, 30, "", null, true, "Naolinco" },
                    { 113, 7, "", null, true, "Aldama" },
                    { 113, 14, "", null, true, "San Gabriel" },
                    { 113, 15, "", null, true, "Villa Guerrero" },
                    { 113, 16, "", null, true, "José Sixto Verduzco" },
                    { 113, 20, "", null, true, "San Baltazar Loxicha" },
                    { 113, 21, "", null, true, "Piaxtla" },
                    { 113, 30, "", null, true, "Naranjal" },
                    { 114, 7, "", null, true, "Benemérito de las Américas" },
                    { 114, 14, "", null, true, "Villa Corona" },
                    { 114, 15, "", null, true, "Villa Victoria" },
                    { 114, 20, "", null, true, "San Baltazar Yatzachi el Bajo" },
                    { 114, 21, "", null, true, "Puebla" },
                    { 114, 30, "", null, true, "Nautla" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 115, 7, "", null, true, "Maravilla Tenejapa" },
                    { 115, 14, "", null, true, "Villa Guerrero" },
                    { 115, 15, "", null, true, "Xonacatlán" },
                    { 115, 20, "", null, true, "San Bartolo Coyotepec" },
                    { 115, 21, "", null, true, "Quecholac" },
                    { 115, 30, "", null, true, "Nogales" },
                    { 116, 7, "", null, true, "Marqués de Comillas" },
                    { 116, 14, "", null, true, "Villa Hidalgo" },
                    { 116, 15, "", null, true, "Zacazonapan" },
                    { 116, 20, "", null, true, "San Bartolomé Ayautla" },
                    { 116, 21, "", null, true, "Quimixtlán" },
                    { 116, 30, "", null, true, "Oluta" },
                    { 117, 7, "", null, true, "Montecristo de Guerrero" },
                    { 117, 14, "", null, true, "Cañadas de Obregón" },
                    { 117, 15, "", null, true, "Zacualpan" },
                    { 117, 20, "", null, true, "San Bartolomé Loxicha" },
                    { 117, 21, "", null, true, "Rafael Lara Grajales" },
                    { 117, 30, "", null, true, "Omealca" },
                    { 118, 7, "", null, true, "San Andrés Duraznal" },
                    { 118, 14, "", null, true, "Yahualica de González Gallo" },
                    { 118, 15, "", null, true, "Zinacantepec" },
                    { 118, 20, "", null, true, "San Bartolomé Quialana" },
                    { 118, 21, "", null, true, "Los Reyes de Juárez" },
                    { 118, 30, "", null, true, "Orizaba" },
                    { 119, 7, "", null, true, "Santiago el Pinar" },
                    { 119, 14, "", null, true, "Zacoalco de Torres" },
                    { 119, 15, "", null, true, "Zumpahuacán" },
                    { 119, 20, "", null, true, "San Bartolomé Yucuañe" },
                    { 119, 21, "", null, true, "San Andrés Cholula" },
                    { 119, 30, "", null, true, "Otatitlán" },
                    { 120, 14, "", null, true, "Zapopan" },
                    { 120, 15, "", null, true, "Zumpango" },
                    { 120, 20, "", null, true, "San Bartolomé Zoogocho" },
                    { 120, 21, "", null, true, "San Antonio Cañada" },
                    { 120, 30, "", null, true, "Oteapan" },
                    { 121, 14, "", null, true, "Zapotiltic" },
                    { 121, 15, "", null, true, "Cuautitlán Izcalli" },
                    { 121, 20, "", null, true, "San Bartolo Soyaltepec" },
                    { 121, 21, "", null, true, "San Diego la Mesa Tochimiltzingo" },
                    { 121, 30, "", null, true, "Ozuluama de Mascareñas" },
                    { 122, 14, "", null, true, "Zapotitlán de Vadillo" },
                    { 122, 15, "", null, true, "Valle de Chalco Solidaridad" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 122, 20, "", null, true, "San Bartolo Yautepec" },
                    { 122, 21, "", null, true, "San Felipe Teotlalcingo" },
                    { 122, 30, "", null, true, "Pajapan" },
                    { 123, 14, "", null, true, "Zapotlán del Rey" },
                    { 123, 15, "", null, true, "Luvianos" },
                    { 123, 20, "", null, true, "San Bernardo Mixtepec" },
                    { 123, 21, "", null, true, "San Felipe Tepatlán" },
                    { 123, 30, "", null, true, "Pánuco" },
                    { 124, 14, "", null, true, "Zapotlanejo" },
                    { 124, 15, "", null, true, "San José del Rincón" },
                    { 124, 20, "", null, true, "San Blas Atempa" },
                    { 124, 21, "", null, true, "San Gabriel Chilac" },
                    { 124, 30, "", null, true, "Papantla" },
                    { 125, 14, "", null, true, "San Ignacio Cerro Gordo" },
                    { 125, 15, "", null, true, "Tonanitla" },
                    { 125, 20, "", null, true, "San Carlos Yautepec" },
                    { 125, 21, "", null, true, "San Gregorio Atzompa" },
                    { 125, 30, "", null, true, "Paso del Macho" },
                    { 126, 20, "", null, true, "San Cristóbal Amatlán" },
                    { 126, 21, "", null, true, "San Jerónimo Tecuanipan" },
                    { 126, 30, "", null, true, "Paso de Ovejas" },
                    { 127, 20, "", null, true, "San Cristóbal Amoltepec" },
                    { 127, 21, "", null, true, "San Jerónimo Xayacatlán" },
                    { 127, 30, "", null, true, "La Perla" },
                    { 128, 20, "", null, true, "San Cristóbal Lachirioag" },
                    { 128, 21, "", null, true, "San José Chiapa" },
                    { 128, 30, "", null, true, "Perote" },
                    { 129, 20, "", null, true, "San Cristóbal Suchixtlahuaca" },
                    { 129, 21, "", null, true, "San José Miahuatlán" },
                    { 129, 30, "", null, true, "Platón Sánchez" },
                    { 130, 20, "", null, true, "San Dionisio del Mar" },
                    { 130, 21, "", null, true, "San Juan Atenco" },
                    { 130, 30, "", null, true, "Playa Vicente" },
                    { 131, 20, "", null, true, "San Dionisio Ocotepec" },
                    { 131, 21, "", null, true, "San Juan Atzompa" },
                    { 131, 30, "", null, true, "Poza Rica de Hidalgo" },
                    { 132, 20, "", null, true, "San Dionisio Ocotlán" },
                    { 132, 21, "", null, true, "San Martín Texmelucan" },
                    { 132, 30, "", null, true, "Las Vigas de Ramírez" },
                    { 133, 20, "", null, true, "San Esteban Atatlahuca" },
                    { 133, 21, "", null, true, "San Martín Totoltepec" },
                    { 133, 30, "", null, true, "Pueblo Viejo" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 134, 20, "", null, true, "San Felipe Jalapa de Díaz" },
                    { 134, 21, "", null, true, "San Matías Tlalancaleca" },
                    { 134, 30, "", null, true, "Puente Nacional" },
                    { 135, 20, "", null, true, "San Felipe Tejalápam" },
                    { 135, 21, "", null, true, "San Miguel Ixitlán" },
                    { 135, 30, "", null, true, "Rafael Delgado" },
                    { 136, 20, "", null, true, "San Felipe Usila" },
                    { 136, 21, "", null, true, "San Miguel Xoxtla" },
                    { 136, 30, "", null, true, "Rafael Lucio" },
                    { 137, 20, "", null, true, "San Francisco Cahuacuá" },
                    { 137, 21, "", null, true, "San Nicolás Buenos Aires" },
                    { 137, 30, "", null, true, "Los Reyes" },
                    { 138, 20, "", null, true, "San Francisco Cajonos" },
                    { 138, 21, "", null, true, "San Nicolás de los Ranchos" },
                    { 138, 30, "", null, true, "Río Blanco" },
                    { 139, 20, "", null, true, "San Francisco Chapulapa" },
                    { 139, 21, "", null, true, "San Pablo Anicano" },
                    { 139, 30, "", null, true, "Saltabarranca" },
                    { 140, 20, "", null, true, "San Francisco Chindúa" },
                    { 140, 21, "", null, true, "San Pedro Cholula" },
                    { 140, 30, "", null, true, "San Andrés Tenejapan" },
                    { 141, 20, "", null, true, "San Francisco del Mar" },
                    { 141, 21, "", null, true, "San Pedro Yeloixtlahuaca" },
                    { 141, 30, "", null, true, "San Andrés Tuxtla" },
                    { 142, 20, "", null, true, "San Francisco Huehuetlán" },
                    { 142, 21, "", null, true, "San Salvador el Seco" },
                    { 142, 30, "", null, true, "San Juan Evangelista" },
                    { 143, 20, "", null, true, "San Francisco Ixhuatán" },
                    { 143, 21, "", null, true, "San Salvador el Verde" },
                    { 143, 30, "", null, true, "Santiago Tuxtla" },
                    { 144, 20, "", null, true, "San Francisco Jaltepetongo" },
                    { 144, 21, "", null, true, "San Salvador Huixcolotla" },
                    { 144, 30, "", null, true, "Sayula de Alemán" },
                    { 145, 20, "", null, true, "San Francisco Lachigoló" },
                    { 145, 21, "", null, true, "San Sebastián Tlacotepec" },
                    { 145, 30, "", null, true, "Soconusco" },
                    { 146, 20, "", null, true, "San Francisco Logueche" },
                    { 146, 21, "", null, true, "Santa Catarina Tlaltempan" },
                    { 146, 30, "", null, true, "Sochiapa" },
                    { 147, 20, "", null, true, "San Francisco Nuxaño" },
                    { 147, 21, "", null, true, "Santa Inés Ahuatempan" },
                    { 147, 30, "", null, true, "Soledad Atzompa" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 148, 20, "", null, true, "San Francisco Ozolotepec" },
                    { 148, 21, "", null, true, "Santa Isabel Cholula" },
                    { 148, 30, "", null, true, "Soledad de Doblado" },
                    { 149, 20, "", null, true, "San Francisco Sola" },
                    { 149, 21, "", null, true, "Santiago Miahuatlán" },
                    { 149, 30, "", null, true, "Soteapan" },
                    { 150, 20, "", null, true, "San Francisco Telixtlahuaca" },
                    { 150, 21, "", null, true, "Huehuetlán el Grande" },
                    { 150, 30, "", null, true, "Tamalín" },
                    { 151, 20, "", null, true, "San Francisco Teopan" },
                    { 151, 21, "", null, true, "Santo Tomás Hueyotlipan" },
                    { 151, 30, "", null, true, "Tamiahua" },
                    { 152, 20, "", null, true, "San Francisco Tlapancingo" },
                    { 152, 21, "", null, true, "Soltepec" },
                    { 152, 30, "", null, true, "Tampico Alto" },
                    { 153, 20, "", null, true, "San Gabriel Mixtepec" },
                    { 153, 21, "", null, true, "Tecali de Herrera" },
                    { 153, 30, "", null, true, "Tancoco" },
                    { 154, 20, "", null, true, "San Ildefonso Amatlán" },
                    { 154, 21, "", null, true, "Tecamachalco" },
                    { 154, 30, "", null, true, "Tantima" },
                    { 155, 20, "", null, true, "San Ildefonso Sola" },
                    { 155, 21, "", null, true, "Tecomatlán" },
                    { 155, 30, "", null, true, "Tantoyuca" },
                    { 156, 20, "", null, true, "San Ildefonso Villa Alta" },
                    { 156, 21, "", null, true, "Tehuacán" },
                    { 156, 30, "", null, true, "Tatatila" },
                    { 157, 20, "", null, true, "San Jacinto Amilpas" },
                    { 157, 21, "", null, true, "Tehuitzingo" },
                    { 157, 30, "", null, true, "Castillo de Teayo" },
                    { 158, 20, "", null, true, "San Jacinto Tlacotepec" },
                    { 158, 21, "", null, true, "Tenampulco" },
                    { 158, 30, "", null, true, "Tecolutla" },
                    { 159, 20, "", null, true, "San Jerónimo Coatlán" },
                    { 159, 21, "", null, true, "Teopantlán" },
                    { 159, 30, "", null, true, "Tehuipango" },
                    { 160, 20, "", null, true, "San Jerónimo Silacayoapilla" },
                    { 160, 21, "", null, true, "Teotlalco" },
                    { 160, 30, "", null, true, "Álamo Temapache" },
                    { 161, 20, "", null, true, "San Jerónimo Sosola" },
                    { 161, 21, "", null, true, "Tepanco de López" },
                    { 161, 30, "", null, true, "Tempoal" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 162, 20, "", null, true, "San Jerónimo Taviche" },
                    { 162, 21, "", null, true, "Tepango de Rodríguez" },
                    { 162, 30, "", null, true, "Tenampa" },
                    { 163, 20, "", null, true, "San Jerónimo Tecóatl" },
                    { 163, 21, "", null, true, "Tepatlaxco de Hidalgo" },
                    { 163, 30, "", null, true, "Tenochtitlán" },
                    { 164, 20, "", null, true, "San Jorge Nuchita" },
                    { 164, 21, "", null, true, "Tepeaca" },
                    { 164, 30, "", null, true, "Teocelo" },
                    { 165, 20, "", null, true, "San José Ayuquila" },
                    { 165, 21, "", null, true, "Tepemaxalco" },
                    { 165, 30, "", null, true, "Tepatlaxco" },
                    { 166, 20, "", null, true, "San José Chiltepec" },
                    { 166, 21, "", null, true, "Tepeojuma" },
                    { 166, 30, "", null, true, "Tepetlán" },
                    { 167, 20, "", null, true, "San José del Peñasco" },
                    { 167, 21, "", null, true, "Tepetzintla" },
                    { 167, 30, "", null, true, "Tepetzintla" },
                    { 168, 20, "", null, true, "San José Estancia Grande" },
                    { 168, 21, "", null, true, "Tepexco" },
                    { 168, 30, "", null, true, "Tequila" },
                    { 169, 20, "", null, true, "San José Independencia" },
                    { 169, 21, "", null, true, "Tepexi de Rodríguez" },
                    { 169, 30, "", null, true, "José Azueta" },
                    { 170, 20, "", null, true, "San José Lachiguiri" },
                    { 170, 21, "", null, true, "Tepeyahualco" },
                    { 170, 30, "", null, true, "Texcatepec" },
                    { 171, 20, "", null, true, "San José Tenango" },
                    { 171, 21, "", null, true, "Tepeyahualco de Cuauhtémoc" },
                    { 171, 30, "", null, true, "Texhuacán" },
                    { 172, 20, "", null, true, "San Juan Achiutla" },
                    { 172, 21, "", null, true, "Tetela de Ocampo" },
                    { 172, 30, "", null, true, "Texistepec" },
                    { 173, 20, "", null, true, "San Juan Atepec" },
                    { 173, 21, "", null, true, "Teteles de Avila Castillo" },
                    { 173, 30, "", null, true, "Tezonapa" },
                    { 174, 20, "", null, true, "Ánimas Trujano" },
                    { 174, 21, "", null, true, "Teziutlán" },
                    { 174, 30, "", null, true, "Tierra Blanca" },
                    { 175, 20, "", null, true, "San Juan Bautista Atatlahuca" },
                    { 175, 21, "", null, true, "Tianguismanalco" },
                    { 175, 30, "", null, true, "Tihuatlán" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 176, 20, "", null, true, "San Juan Bautista Coixtlahuaca" },
                    { 176, 21, "", null, true, "Tilapa" },
                    { 176, 30, "", null, true, "Tlacojalpan" },
                    { 177, 20, "", null, true, "San Juan Bautista Cuicatlán" },
                    { 177, 21, "", null, true, "Tlacotepec de Benito Juárez" },
                    { 177, 30, "", null, true, "Tlacolulan" },
                    { 178, 20, "", null, true, "San Juan Bautista Guelache" },
                    { 178, 21, "", null, true, "Tlacuilotepec" },
                    { 178, 30, "", null, true, "Tlacotalpan" },
                    { 179, 20, "", null, true, "San Juan Bautista Jayacatlán" },
                    { 179, 21, "", null, true, "Tlachichuca" },
                    { 179, 30, "", null, true, "Tlacotepec de Mejía" },
                    { 180, 20, "", null, true, "San Juan Bautista Lo de Soto" },
                    { 180, 21, "", null, true, "Tlahuapan" },
                    { 180, 30, "", null, true, "Tlachichilco" },
                    { 181, 20, "", null, true, "San Juan Bautista Suchitepec" },
                    { 181, 21, "", null, true, "Tlaltenango" },
                    { 181, 30, "", null, true, "Tlalixcoyan" },
                    { 182, 20, "", null, true, "San Juan Bautista Tlacoatzintepec" },
                    { 182, 21, "", null, true, "Tlanepantla" },
                    { 182, 30, "", null, true, "Tlalnelhuayocan" },
                    { 183, 20, "", null, true, "San Juan Bautista Tlachichilco" },
                    { 183, 21, "", null, true, "Tlaola" },
                    { 183, 30, "", null, true, "Tlapacoyan" },
                    { 184, 20, "", null, true, "San Juan Bautista Tuxtepec" },
                    { 184, 21, "", null, true, "Tlapacoya" },
                    { 184, 30, "", null, true, "Tlaquilpa" },
                    { 185, 20, "", null, true, "San Juan Cacahuatepec" },
                    { 185, 21, "", null, true, "Tlapanalá" },
                    { 185, 30, "", null, true, "Tlilapan" },
                    { 186, 20, "", null, true, "San Juan Cieneguilla" },
                    { 186, 21, "", null, true, "Tlatlauquitepec" },
                    { 186, 30, "", null, true, "Tomatlán" },
                    { 187, 20, "", null, true, "San Juan Coatzóspam" },
                    { 187, 21, "", null, true, "Tlaxco" },
                    { 187, 30, "", null, true, "Tonayán" },
                    { 188, 20, "", null, true, "San Juan Colorado" },
                    { 188, 21, "", null, true, "Tochimilco" },
                    { 188, 30, "", null, true, "Totutla" },
                    { 189, 20, "", null, true, "San Juan Comaltepec" },
                    { 189, 21, "", null, true, "Tochtepec" },
                    { 189, 30, "", null, true, "Tuxpan" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 190, 20, "", null, true, "San Juan Cotzocón" },
                    { 190, 21, "", null, true, "Totoltepec de Guerrero" },
                    { 190, 30, "", null, true, "Tuxtilla" },
                    { 191, 20, "", null, true, "San Juan Chicomezúchil" },
                    { 191, 21, "", null, true, "Tulcingo" },
                    { 191, 30, "", null, true, "Ursulo Galván" },
                    { 192, 20, "", null, true, "San Juan Chilateca" },
                    { 192, 21, "", null, true, "Tuzamapan de Galeana" },
                    { 192, 30, "", null, true, "Vega de Alatorre" },
                    { 193, 20, "", null, true, "San Juan del Estado" },
                    { 193, 21, "", null, true, "Tzicatlacoyan" },
                    { 193, 30, "", null, true, "Veracruz" },
                    { 194, 20, "", null, true, "San Juan del Río" },
                    { 194, 21, "", null, true, "Venustiano Carranza" },
                    { 194, 30, "", null, true, "Villa Aldama" },
                    { 195, 20, "", null, true, "San Juan Diuxi" },
                    { 195, 21, "", null, true, "Vicente Guerrero" },
                    { 195, 30, "", null, true, "Xoxocotla" },
                    { 196, 20, "", null, true, "San Juan Evangelista Analco" },
                    { 196, 21, "", null, true, "Xayacatlán de Bravo" },
                    { 196, 30, "", null, true, "Yanga" },
                    { 197, 20, "", null, true, "San Juan Guelavía" },
                    { 197, 21, "", null, true, "Xicotepec" },
                    { 197, 30, "", null, true, "Yecuatla" },
                    { 198, 20, "", null, true, "San Juan Guichicovi" },
                    { 198, 21, "", null, true, "Xicotlán" },
                    { 198, 30, "", null, true, "Zacualpan" },
                    { 199, 20, "", null, true, "San Juan Ihualtepec" },
                    { 199, 21, "", null, true, "Xiutetelco" },
                    { 199, 30, "", null, true, "Zaragoza" },
                    { 200, 20, "", null, true, "San Juan Juquila Mixes" },
                    { 200, 21, "", null, true, "Xochiapulco" },
                    { 200, 30, "", null, true, "Zentla" },
                    { 201, 20, "", null, true, "San Juan Juquila Vijanos" },
                    { 201, 21, "", null, true, "Xochiltepec" },
                    { 201, 30, "", null, true, "Zongolica" },
                    { 202, 20, "", null, true, "San Juan Lachao" },
                    { 202, 21, "", null, true, "Xochitlán de Vicente Suárez" },
                    { 202, 30, "", null, true, "Zontecomatlán de López y Fuentes" },
                    { 203, 20, "", null, true, "San Juan Lachigalla" },
                    { 203, 21, "", null, true, "Xochitlán Todos Santos" },
                    { 203, 30, "", null, true, "Zozocolco de Hidalgo" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 204, 20, "", null, true, "San Juan Lajarcia" },
                    { 204, 21, "", null, true, "Yaonáhuac" },
                    { 204, 30, "", null, true, "Agua Dulce" },
                    { 205, 20, "", null, true, "San Juan Lalana" },
                    { 205, 21, "", null, true, "Yehualtepec" },
                    { 205, 30, "", null, true, "El Higo" },
                    { 206, 20, "", null, true, "San Juan de los Cués" },
                    { 206, 21, "", null, true, "Zacapala" },
                    { 206, 30, "", null, true, "Nanchital de Lázaro Cárdenas del Río" },
                    { 207, 20, "", null, true, "San Juan Mazatlán" },
                    { 207, 21, "", null, true, "Zacapoaxtla" },
                    { 207, 30, "", null, true, "Tres Valles" },
                    { 208, 20, "", null, true, "San Juan Mixtepec -Dto. 08 -" },
                    { 208, 21, "", null, true, "Zacatlán" },
                    { 208, 30, "", null, true, "Carlos A. Carrillo" },
                    { 209, 20, "", null, true, "San Juan Mixtepec -Dto. 26 -" },
                    { 209, 21, "", null, true, "Zapotitlán" },
                    { 209, 30, "", null, true, "Tatahuicapan de Juárez" },
                    { 210, 20, "", null, true, "San Juan Ñumí" },
                    { 210, 21, "", null, true, "Zapotitlán de Méndez" },
                    { 210, 30, "", null, true, "Uxpanapa" },
                    { 211, 20, "", null, true, "San Juan Ozolotepec" },
                    { 211, 21, "", null, true, "Zaragoza" },
                    { 211, 30, "", null, true, "San Rafael" },
                    { 212, 20, "", null, true, "San Juan Petlapa" },
                    { 212, 21, "", null, true, "Zautla" },
                    { 212, 30, "", null, true, "Santiago Sochiapan" },
                    { 213, 20, "", null, true, "San Juan Quiahije" },
                    { 213, 21, "", null, true, "Zihuateutla" },
                    { 214, 20, "", null, true, "San Juan Quiotepec" },
                    { 214, 21, "", null, true, "Zinacatepec" },
                    { 215, 20, "", null, true, "San Juan Sayultepec" },
                    { 215, 21, "", null, true, "Zongozotla" },
                    { 216, 20, "", null, true, "San Juan Tabaá" },
                    { 216, 21, "", null, true, "Zoquiapan" },
                    { 217, 20, "", null, true, "San Juan Tamazola" },
                    { 217, 21, "", null, true, "Zoquitlán" },
                    { 218, 20, "", null, true, "San Juan Teita" },
                    { 219, 20, "", null, true, "San Juan Teitipac" },
                    { 220, 20, "", null, true, "San Juan Tepeuxila" },
                    { 221, 20, "", null, true, "San Juan Teposcolula" },
                    { 222, 20, "", null, true, "San Juan Yaeé" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 223, 20, "", null, true, "San Juan Yatzona" },
                    { 224, 20, "", null, true, "San Juan Yucuita" },
                    { 225, 20, "", null, true, "San Lorenzo" },
                    { 226, 20, "", null, true, "San Lorenzo Albarradas" },
                    { 227, 20, "", null, true, "San Lorenzo Cacaotepec" },
                    { 228, 20, "", null, true, "San Lorenzo Cuaunecuiltitla" },
                    { 229, 20, "", null, true, "San Lorenzo Texmelúcan" },
                    { 230, 20, "", null, true, "San Lorenzo Victoria" },
                    { 231, 20, "", null, true, "San Lucas Camotlán" },
                    { 232, 20, "", null, true, "San Lucas Ojitlán" },
                    { 233, 20, "", null, true, "San Lucas Quiaviní" },
                    { 234, 20, "", null, true, "San Lucas Zoquiápam" },
                    { 235, 20, "", null, true, "San Luis Amatlán" },
                    { 236, 20, "", null, true, "San Marcial Ozolotepec" },
                    { 237, 20, "", null, true, "San Marcos Arteaga" },
                    { 238, 20, "", null, true, "San Martín de los Cansecos" },
                    { 239, 20, "", null, true, "San Martín Huamelúlpam" },
                    { 240, 20, "", null, true, "San Martín Itunyoso" },
                    { 241, 20, "", null, true, "San Martín Lachilá" },
                    { 242, 20, "", null, true, "San Martín Peras" },
                    { 243, 20, "", null, true, "San Martín Tilcajete" },
                    { 244, 20, "", null, true, "San Martín Toxpalan" },
                    { 245, 20, "", null, true, "San Martín Zacatepec" },
                    { 246, 20, "", null, true, "San Mateo Cajonos" },
                    { 247, 20, "", null, true, "Capulálpam de Méndez" },
                    { 248, 20, "", null, true, "San Mateo del Mar" },
                    { 249, 20, "", null, true, "San Mateo Yoloxochitlán" },
                    { 250, 20, "", null, true, "San Mateo Etlatongo" },
                    { 251, 20, "", null, true, "San Mateo Nejápam" },
                    { 252, 20, "", null, true, "San Mateo Peñasco" },
                    { 253, 20, "", null, true, "San Mateo Piñas" },
                    { 254, 20, "", null, true, "San Mateo Río Hondo" },
                    { 255, 20, "", null, true, "San Mateo Sindihui" },
                    { 256, 20, "", null, true, "San Mateo Tlapiltepec" },
                    { 257, 20, "", null, true, "San Melchor Betaza" },
                    { 258, 20, "", null, true, "San Miguel Achiutla" },
                    { 259, 20, "", null, true, "San Miguel Ahuehuetitlán" },
                    { 260, 20, "", null, true, "San Miguel Aloápam" },
                    { 261, 20, "", null, true, "San Miguel Amatitlán" },
                    { 262, 20, "", null, true, "San Miguel Amatlán" },
                    { 263, 20, "", null, true, "San Miguel Coatlán" },
                    { 264, 20, "", null, true, "San Miguel Chicahua" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 265, 20, "", null, true, "San Miguel Chimalapa" },
                    { 266, 20, "", null, true, "San Miguel del Puerto" },
                    { 267, 20, "", null, true, "San Miguel del Río" },
                    { 268, 20, "", null, true, "San Miguel Ejutla" },
                    { 269, 20, "", null, true, "San Miguel el Grande" },
                    { 270, 20, "", null, true, "San Miguel Huautla" },
                    { 271, 20, "", null, true, "San Miguel Mixtepec" },
                    { 272, 20, "", null, true, "San Miguel Panixtlahuaca" },
                    { 273, 20, "", null, true, "San Miguel Peras" },
                    { 274, 20, "", null, true, "San Miguel Piedras" },
                    { 275, 20, "", null, true, "San Miguel Quetzaltepec" },
                    { 276, 20, "", null, true, "San Miguel Santa Flor" },
                    { 277, 20, "", null, true, "Villa Sola de Vega" },
                    { 278, 20, "", null, true, "San Miguel Soyaltepec" },
                    { 279, 20, "", null, true, "San Miguel Suchixtepec" },
                    { 280, 20, "", null, true, "Villa Talea de Castro" },
                    { 281, 20, "", null, true, "San Miguel Tecomatlán" },
                    { 282, 20, "", null, true, "San Miguel Tenango" },
                    { 283, 20, "", null, true, "San Miguel Tequixtepec" },
                    { 284, 20, "", null, true, "San Miguel Tilquiápam" },
                    { 285, 20, "", null, true, "San Miguel Tlacamama" },
                    { 286, 20, "", null, true, "San Miguel Tlacotepec" },
                    { 287, 20, "", null, true, "San Miguel Tulancingo" },
                    { 288, 20, "", null, true, "San Miguel Yotao" },
                    { 289, 20, "", null, true, "San Nicolás" },
                    { 290, 20, "", null, true, "San Nicolás Hidalgo" },
                    { 291, 20, "", null, true, "San Pablo Coatlán" },
                    { 292, 20, "", null, true, "San Pablo Cuatro Venados" },
                    { 293, 20, "", null, true, "San Pablo Etla" },
                    { 294, 20, "", null, true, "San Pablo Huitzo" },
                    { 295, 20, "", null, true, "San Pablo Huixtepec" },
                    { 296, 20, "", null, true, "San Pablo Macuiltianguis" },
                    { 297, 20, "", null, true, "San Pablo Tijaltepec" },
                    { 298, 20, "", null, true, "San Pablo Villa de Mitla" },
                    { 299, 20, "", null, true, "San Pablo Yaganiza" },
                    { 300, 20, "", null, true, "San Pedro Amuzgos" },
                    { 301, 20, "", null, true, "San Pedro Apóstol" },
                    { 302, 20, "", null, true, "San Pedro Atoyac" },
                    { 303, 20, "", null, true, "San Pedro Cajonos" },
                    { 304, 20, "", null, true, "San Pedro Coxcaltepec Cántaros" },
                    { 305, 20, "", null, true, "San Pedro Comitancillo" },
                    { 306, 20, "", null, true, "San Pedro el Alto" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 307, 20, "", null, true, "San Pedro Huamelula" },
                    { 308, 20, "", null, true, "San Pedro Huilotepec" },
                    { 309, 20, "", null, true, "San Pedro Ixcatlán" },
                    { 310, 20, "", null, true, "San Pedro Ixtlahuaca" },
                    { 311, 20, "", null, true, "San Pedro Jaltepetongo" },
                    { 312, 20, "", null, true, "San Pedro Jicayán" },
                    { 313, 20, "", null, true, "San Pedro Jocotipac" },
                    { 314, 20, "", null, true, "San Pedro Juchatengo" },
                    { 315, 20, "", null, true, "San Pedro Mártir" },
                    { 316, 20, "", null, true, "San Pedro Mártir Quiechapa" },
                    { 317, 20, "", null, true, "San Pedro Mártir Yucuxaco" },
                    { 318, 20, "", null, true, "San Pedro Mixtepec -Dto. 22 -" },
                    { 319, 20, "", null, true, "San Pedro Mixtepec -Dto. 26 -" },
                    { 320, 20, "", null, true, "San Pedro Molinos" },
                    { 321, 20, "", null, true, "San Pedro Nopala" },
                    { 322, 20, "", null, true, "San Pedro Ocopetatillo" },
                    { 323, 20, "", null, true, "San Pedro Ocotepec" },
                    { 324, 20, "", null, true, "San Pedro Pochutla" },
                    { 325, 20, "", null, true, "San Pedro Quiatoni" },
                    { 326, 20, "", null, true, "San Pedro Sochiápam" },
                    { 327, 20, "", null, true, "San Pedro Tapanatepec" },
                    { 328, 20, "", null, true, "San Pedro Taviche" },
                    { 329, 20, "", null, true, "San Pedro Teozacoalco" },
                    { 330, 20, "", null, true, "San Pedro Teutila" },
                    { 331, 20, "", null, true, "San Pedro Tidaá" },
                    { 332, 20, "", null, true, "San Pedro Topiltepec" },
                    { 333, 20, "", null, true, "San Pedro Totolápam" },
                    { 334, 20, "", null, true, "Villa de Tututepec de Melchor Ocampo" },
                    { 335, 20, "", null, true, "San Pedro Yaneri" },
                    { 336, 20, "", null, true, "San Pedro Yólox" },
                    { 337, 20, "", null, true, "San Pedro y San Pablo Ayutla" },
                    { 338, 20, "", null, true, "Villa de Etla" },
                    { 339, 20, "", null, true, "San Pedro y San Pablo Teposcolula" },
                    { 340, 20, "", null, true, "San Pedro y San Pablo Tequixtepec" },
                    { 341, 20, "", null, true, "San Pedro Yucunama" },
                    { 342, 20, "", null, true, "San Raymundo Jalpan" },
                    { 343, 20, "", null, true, "San Sebastián Abasolo" },
                    { 344, 20, "", null, true, "San Sebastián Coatlán" },
                    { 345, 20, "", null, true, "San Sebastián Ixcapa" },
                    { 346, 20, "", null, true, "San Sebastián Nicananduta" },
                    { 347, 20, "", null, true, "San Sebastián Río Hondo" },
                    { 348, 20, "", null, true, "San Sebastián Tecomaxtlahuaca" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 349, 20, "", null, true, "San Sebastián Teitipac" },
                    { 350, 20, "", null, true, "San Sebastián Tutla" },
                    { 351, 20, "", null, true, "San Simón Almolongas" },
                    { 352, 20, "", null, true, "San Simón Zahuatlán" },
                    { 353, 20, "", null, true, "Santa Ana" },
                    { 354, 20, "", null, true, "Santa Ana Ateixtlahuaca" },
                    { 355, 20, "", null, true, "Santa Ana Cuauhtémoc" },
                    { 356, 20, "", null, true, "Santa Ana del Valle" },
                    { 357, 20, "", null, true, "Santa Ana Tavela" },
                    { 358, 20, "", null, true, "Santa Ana Tlapacoyan" },
                    { 359, 20, "", null, true, "Santa Ana Yareni" },
                    { 360, 20, "", null, true, "Santa Ana Zegache" },
                    { 361, 20, "", null, true, "Santa Catalina Quierí" },
                    { 362, 20, "", null, true, "Santa Catarina Cuixtla" },
                    { 363, 20, "", null, true, "Santa Catarina Ixtepeji" },
                    { 364, 20, "", null, true, "Santa Catarina Juquila" },
                    { 365, 20, "", null, true, "Santa Catarina Lachatao" },
                    { 366, 20, "", null, true, "Santa Catarina Loxicha" },
                    { 367, 20, "", null, true, "Santa Catarina Mechoacán" },
                    { 368, 20, "", null, true, "Santa Catarina Minas" },
                    { 369, 20, "", null, true, "Santa Catarina Quiané" },
                    { 370, 20, "", null, true, "Santa Catarina Tayata" },
                    { 371, 20, "", null, true, "Santa Catarina Ticuá" },
                    { 372, 20, "", null, true, "Santa Catarina Yosonotú" },
                    { 373, 20, "", null, true, "Santa Catarina Zapoquila" },
                    { 374, 20, "", null, true, "Santa Cruz Acatepec" },
                    { 375, 20, "", null, true, "Santa Cruz Amilpas" },
                    { 376, 20, "", null, true, "Santa Cruz de Bravo" },
                    { 377, 20, "", null, true, "Santa Cruz Itundujia" },
                    { 378, 20, "", null, true, "Santa Cruz Mixtepec" },
                    { 379, 20, "", null, true, "Santa Cruz Nundaco" },
                    { 380, 20, "", null, true, "Santa Cruz Papalutla" },
                    { 381, 20, "", null, true, "Santa Cruz Tacache de Mina" },
                    { 382, 20, "", null, true, "Santa Cruz Tacahua" },
                    { 383, 20, "", null, true, "Santa Cruz Tayata" },
                    { 384, 20, "", null, true, "Santa Cruz Xitla" },
                    { 385, 20, "", null, true, "Santa Cruz Xoxocotlán" },
                    { 386, 20, "", null, true, "Santa Cruz Zenzontepec" },
                    { 387, 20, "", null, true, "Santa Gertrudis" },
                    { 388, 20, "", null, true, "Santa Inés del Monte" },
                    { 389, 20, "", null, true, "Santa Inés Yatzeche" },
                    { 390, 20, "", null, true, "Santa Lucía del Camino" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 391, 20, "", null, true, "Santa Lucía Miahuatlán" },
                    { 392, 20, "", null, true, "Santa Lucía Monteverde" },
                    { 393, 20, "", null, true, "Santa Lucía Ocotlán" },
                    { 394, 20, "", null, true, "Santa María Alotepec" },
                    { 395, 20, "", null, true, "Santa María Apazco" },
                    { 396, 20, "", null, true, "Santa María la Asunción" },
                    { 397, 20, "", null, true, "Heroica Ciudad de Tlaxiaco" },
                    { 398, 20, "", null, true, "Ayoquezco de Aldama" },
                    { 399, 20, "", null, true, "Santa María Atzompa" },
                    { 400, 20, "", null, true, "Santa María Camotlán" },
                    { 401, 20, "", null, true, "Santa María Colotepec" },
                    { 402, 20, "", null, true, "Santa María Cortijo" },
                    { 403, 20, "", null, true, "Santa María Coyotepec" },
                    { 404, 20, "", null, true, "Santa María Chachoápam" },
                    { 405, 20, "", null, true, "Villa de Chilapa de Díaz" },
                    { 406, 20, "", null, true, "Santa María Chilchotla" },
                    { 407, 20, "", null, true, "Santa María Chimalapa" },
                    { 408, 20, "", null, true, "Santa María del Rosario" },
                    { 409, 20, "", null, true, "Santa María del Tule" },
                    { 410, 20, "", null, true, "Santa María Ecatepec" },
                    { 411, 20, "", null, true, "Santa María Guelacé" },
                    { 412, 20, "", null, true, "Santa María Guienagati" },
                    { 413, 20, "", null, true, "Santa María Huatulco" },
                    { 414, 20, "", null, true, "Santa María Huazolotitlán" },
                    { 415, 20, "", null, true, "Santa María Ipalapa" },
                    { 416, 20, "", null, true, "Santa María Ixcatlán" },
                    { 417, 20, "", null, true, "Santa María Jacatepec" },
                    { 418, 20, "", null, true, "Santa María Jalapa del Marqués" },
                    { 419, 20, "", null, true, "Santa María Jaltianguis" },
                    { 420, 20, "", null, true, "Santa María Lachixío" },
                    { 421, 20, "", null, true, "Santa María Mixtequilla" },
                    { 422, 20, "", null, true, "Santa María Nativitas" },
                    { 423, 20, "", null, true, "Santa María Nduayaco" },
                    { 424, 20, "", null, true, "Santa María Ozolotepec" },
                    { 425, 20, "", null, true, "Santa María Pápalo" },
                    { 426, 20, "", null, true, "Santa María Peñoles" },
                    { 427, 20, "", null, true, "Santa María Petapa" },
                    { 428, 20, "", null, true, "Santa María Quiegolani" },
                    { 429, 20, "", null, true, "Santa María Sola" },
                    { 430, 20, "", null, true, "Santa María Tataltepec" },
                    { 431, 20, "", null, true, "Santa María Tecomavaca" },
                    { 432, 20, "", null, true, "Santa María Temaxcalapa" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 433, 20, "", null, true, "Santa María Temaxcaltepec" },
                    { 434, 20, "", null, true, "Santa María Teopoxco" },
                    { 435, 20, "", null, true, "Santa María Tepantlali" },
                    { 436, 20, "", null, true, "Santa María Texcatitlán" },
                    { 437, 20, "", null, true, "Santa María Tlahuitoltepec" },
                    { 438, 20, "", null, true, "Santa María Tlalixtac" },
                    { 439, 20, "", null, true, "Santa María Tonameca" },
                    { 440, 20, "", null, true, "Santa María Totolapilla" },
                    { 441, 20, "", null, true, "Santa María Xadani" },
                    { 442, 20, "", null, true, "Santa María Yalina" },
                    { 443, 20, "", null, true, "Santa María Yavesía" },
                    { 444, 20, "", null, true, "Santa María Yolotepec" },
                    { 445, 20, "", null, true, "Santa María Yosoyúa" },
                    { 446, 20, "", null, true, "Santa María Yucuhiti" },
                    { 447, 20, "", null, true, "Santa María Zacatepec" },
                    { 448, 20, "", null, true, "Santa María Zaniza" },
                    { 449, 20, "", null, true, "Santa María Zoquitlán" },
                    { 450, 20, "", null, true, "Santiago Amoltepec" },
                    { 451, 20, "", null, true, "Santiago Apoala" },
                    { 452, 20, "", null, true, "Santiago Apóstol" },
                    { 453, 20, "", null, true, "Santiago Astata" },
                    { 454, 20, "", null, true, "Santiago Atitlán" },
                    { 455, 20, "", null, true, "Santiago Ayuquililla" },
                    { 456, 20, "", null, true, "Santiago Cacaloxtepec" },
                    { 457, 20, "", null, true, "Santiago Camotlán" },
                    { 458, 20, "", null, true, "Santiago Comaltepec" },
                    { 459, 20, "", null, true, "Santiago Chazumba" },
                    { 460, 20, "", null, true, "Santiago Choápam" },
                    { 461, 20, "", null, true, "Santiago del Río" },
                    { 462, 20, "", null, true, "Santiago Huajolotitlán" },
                    { 463, 20, "", null, true, "Santiago Huauclilla" },
                    { 464, 20, "", null, true, "Santiago Ihuitlán Plumas" },
                    { 465, 20, "", null, true, "Santiago Ixcuintepec" },
                    { 466, 20, "", null, true, "Santiago Ixtayutla" },
                    { 467, 20, "", null, true, "Santiago Jamiltepec" },
                    { 468, 20, "", null, true, "Santiago Jocotepec" },
                    { 469, 20, "", null, true, "Santiago Juxtlahuaca" },
                    { 470, 20, "", null, true, "Santiago Lachiguiri" },
                    { 471, 20, "", null, true, "Santiago Lalopa" },
                    { 472, 20, "", null, true, "Santiago Laollaga" },
                    { 473, 20, "", null, true, "Santiago Laxopa" },
                    { 474, 20, "", null, true, "Santiago Llano Grande" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 475, 20, "", null, true, "Santiago Matatlán" },
                    { 476, 20, "", null, true, "Santiago Miltepec" },
                    { 477, 20, "", null, true, "Santiago Minas" },
                    { 478, 20, "", null, true, "Santiago Nacaltepec" },
                    { 479, 20, "", null, true, "Santiago Nejapilla" },
                    { 480, 20, "", null, true, "Santiago Nundiche" },
                    { 481, 20, "", null, true, "Santiago Nuyoó" },
                    { 482, 20, "", null, true, "Santiago Pinotepa Nacional" },
                    { 483, 20, "", null, true, "Santiago Suchilquitongo" },
                    { 484, 20, "", null, true, "Santiago Tamazola" },
                    { 485, 20, "", null, true, "Santiago Tapextla" },
                    { 486, 20, "", null, true, "Villa Tejúpam de la Unión" },
                    { 487, 20, "", null, true, "Santiago Tenango" },
                    { 488, 20, "", null, true, "Santiago Tepetlapa" },
                    { 489, 20, "", null, true, "Santiago Tetepec" },
                    { 490, 20, "", null, true, "Santiago Texcalcingo" },
                    { 491, 20, "", null, true, "Santiago Textitlán" },
                    { 492, 20, "", null, true, "Santiago Tilantongo" },
                    { 493, 20, "", null, true, "Santiago Tillo" },
                    { 494, 20, "", null, true, "Santiago Tlazoyaltepec" },
                    { 495, 20, "", null, true, "Santiago Xanica" },
                    { 496, 20, "", null, true, "Santiago Xiacuí" },
                    { 497, 20, "", null, true, "Santiago Yaitepec" },
                    { 498, 20, "", null, true, "Santiago Yaveo" },
                    { 499, 20, "", null, true, "Santiago Yolomécatl" },
                    { 500, 20, "", null, true, "Santiago Yosondúa" },
                    { 501, 20, "", null, true, "Santiago Yucuyachi" },
                    { 502, 20, "", null, true, "Santiago Zacatepec" },
                    { 503, 20, "", null, true, "Santiago Zoochila" },
                    { 504, 20, "", null, true, "Nuevo Zoquiápam" },
                    { 505, 20, "", null, true, "Santo Domingo Ingenio" },
                    { 506, 20, "", null, true, "Santo Domingo Albarradas" },
                    { 507, 20, "", null, true, "Santo Domingo Armenta" },
                    { 508, 20, "", null, true, "Santo Domingo Chihuitán" },
                    { 509, 20, "", null, true, "Santo Domingo de Morelos" },
                    { 510, 20, "", null, true, "Santo Domingo Ixcatlán" },
                    { 511, 20, "", null, true, "Santo Domingo Nuxaá" },
                    { 512, 20, "", null, true, "Santo Domingo Ozolotepec" },
                    { 513, 20, "", null, true, "Santo Domingo Petapa" },
                    { 514, 20, "", null, true, "Santo Domingo Roayaga" },
                    { 515, 20, "", null, true, "Santo Domingo Tehuantepec" },
                    { 516, 20, "", null, true, "Santo Domingo Teojomulco" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 517, 20, "", null, true, "Santo Domingo Tepuxtepec" },
                    { 518, 20, "", null, true, "Santo Domingo Tlatayápam" },
                    { 519, 20, "", null, true, "Santo Domingo Tomaltepec" },
                    { 520, 20, "", null, true, "Santo Domingo Tonalá" },
                    { 521, 20, "", null, true, "Santo Domingo Tonaltepec" },
                    { 522, 20, "", null, true, "Santo Domingo Xagacía" },
                    { 523, 20, "", null, true, "Santo Domingo Yanhuitlán" },
                    { 524, 20, "", null, true, "Santo Domingo Yodohino" },
                    { 525, 20, "", null, true, "Santo Domingo Zanatepec" },
                    { 526, 20, "", null, true, "Santos Reyes Nopala" },
                    { 527, 20, "", null, true, "Santos Reyes Pápalo" },
                    { 528, 20, "", null, true, "Santos Reyes Tepejillo" },
                    { 529, 20, "", null, true, "Santos Reyes Yucuná" },
                    { 530, 20, "", null, true, "Santo Tomás Jalieza" },
                    { 531, 20, "", null, true, "Santo Tomás Mazaltepec" },
                    { 532, 20, "", null, true, "Santo Tomás Ocotepec" },
                    { 533, 20, "", null, true, "Santo Tomás Tamazulapan" },
                    { 534, 20, "", null, true, "San Vicente Coatlán" },
                    { 535, 20, "", null, true, "San Vicente Lachixío" },
                    { 536, 20, "", null, true, "San Vicente Nuñú" },
                    { 537, 20, "", null, true, "Silacayoápam" },
                    { 538, 20, "", null, true, "Sitio de Xitlapehua" },
                    { 539, 20, "", null, true, "Soledad Etla" },
                    { 540, 20, "", null, true, "Villa de Tamazulápam del Progreso" },
                    { 541, 20, "", null, true, "Tanetze de Zaragoza" },
                    { 542, 20, "", null, true, "Taniche" },
                    { 543, 20, "", null, true, "Tataltepec de Valdés" },
                    { 544, 20, "", null, true, "Teococuilco de Marcos Pérez" },
                    { 545, 20, "", null, true, "Teotitlán de Flores Magón" },
                    { 546, 20, "", null, true, "Teotitlán del Valle" },
                    { 547, 20, "", null, true, "Teotongo" },
                    { 548, 20, "", null, true, "Tepelmeme Villa de Morelos" },
                    { 549, 20, "", null, true, "Tezoatlán de Segura y Luna" },
                    { 550, 20, "", null, true, "San Jerónimo Tlacochahuaya" },
                    { 551, 20, "", null, true, "Tlacolula de Matamoros" },
                    { 552, 20, "", null, true, "Tlacotepec Plumas" },
                    { 553, 20, "", null, true, "Tlalixtac de Cabrera" },
                    { 554, 20, "", null, true, "Totontepec Villa de Morelos" },
                    { 555, 20, "", null, true, "Trinidad Zaachila" },
                    { 556, 20, "", null, true, "La Trinidad Vista Hermosa" },
                    { 557, 20, "", null, true, "Unión Hidalgo" },
                    { 558, 20, "", null, true, "Valerio Trujano" }
                });

            migrationBuilder.InsertData(
                schema: "address",
                table: "municipality",
                columns: new[] { "municipality_id", "state_id", "code", "description", "is_active", "name" },
                values: new object[,]
                {
                    { 559, 20, "", null, true, "San Juan Bautista Valle Nacional" },
                    { 560, 20, "", null, true, "Villa Díaz Ordaz" },
                    { 561, 20, "", null, true, "Yaxe" },
                    { 562, 20, "", null, true, "Magdalena Yodocono de Porfirio Díaz" },
                    { 563, 20, "", null, true, "Yogana" },
                    { 564, 20, "", null, true, "Yutanduchi de Guerrero" },
                    { 565, 20, "", null, true, "Villa de Zaachila" },
                    { 566, 20, "", null, true, "San Mateo Yucutindoo" },
                    { 567, 20, "", null, true, "Zapotitlán Lagunas" },
                    { 568, 20, "", null, true, "Zapotitlán Palmas" },
                    { 569, 20, "", null, true, "Santa Inés de Zaragoza" },
                    { 570, 20, "", null, true, "Zimatlán de Álvarez" }
                });

            migrationBuilder.InsertData(
                schema: "person",
                table: "person_user",
                columns: new[] { "person_id", "user_id" },
                values: new object[] { 1, 1 });

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
                name: "IX_municipality_state_id",
                schema: "address",
                table: "municipality",
                column: "state_id");

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
                name: "IX_person_user_user_id",
                schema: "person",
                table: "person_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_state_country_id",
                schema: "address",
                table: "state",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                schema: "auth",
                table: "user",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "municipality",
                schema: "address");

            migrationBuilder.DropTable(
                name: "person_user",
                schema: "person");

            migrationBuilder.DropTable(
                name: "postal_code",
                schema: "address");

            migrationBuilder.DropTable(
                name: "module",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "state",
                schema: "address");

            migrationBuilder.DropTable(
                name: "person",
                schema: "person");

            migrationBuilder.DropTable(
                name: "user",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "country",
                schema: "address");

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
