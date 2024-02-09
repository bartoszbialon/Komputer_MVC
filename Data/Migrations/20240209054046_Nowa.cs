using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Nowa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    OriginCountry = table.Column<string>(type: "TEXT", maxLength: 58, nullable: false),
                    FoundationYear = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "computers",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwakomputera = table.Column<string>(name: "Nazwa komputera", type: "TEXT", maxLength: 150, nullable: false),
                    Procesor = table.Column<string>(type: "TEXT", maxLength: 90, nullable: false),
                    PamięćRAM = table.Column<string>(name: "Pamięć RAM", type: "TEXT", maxLength: 90, nullable: false),
                    Dysktwardy = table.Column<string>(name: "Dysk twardy", type: "TEXT", maxLength: 120, nullable: false),
                    Kartagraficzna = table.Column<string>(name: "Karta graficzna", type: "TEXT", maxLength: 90, nullable: false),
                    Dataprodukcji = table.Column<DateTime>(name: "Data produkcji", type: "TEXT", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProducerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computers", x => x.ComputerId);
                    table.ForeignKey(
                        name: "FK_computers_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "ProducerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_computers_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "888df2a7-a91e-48df-a5f2-6dd0904d36d8", "888df2a7-a91e-48df-a5f2-6dd0904d36d8", "admin", "ADMIN" },
                    { "d4fc2d68-e656-4e9b-8576-6b99dc0b2ed0", "d4fc2d68-e656-4e9b-8576-6b99dc0b2ed0", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1663d74f-4122-4b4d-a27b-5962b66d0c94", 0, "0c9e9a4c-1934-4fbe-87de-899de5930c69", "jan@microsoft.wsei.edu.pl", true, false, null, "JAN@MICROSOFT.WSEI.EDU.PL", "JAN", "AQAAAAIAAYagAAAAEPh6oH7YkOgqvLVeekgrAToEaf9UfEIXglFkdc5PPWEqq6fyLXbyQDxpEEtImdv00w==", null, false, "c2c2dc84-c1aa-4556-a5da-88d67769aab5", false, "jan" },
                    { "a1c6e223-d17b-4245-b115-b6c32be19943", 0, "670d9b04-375a-40ee-ad0c-d7137da782d6", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAIAAYagAAAAEOtygr8OfL0KbrmRQSazazLINuQqlordvHVcxn/SGliMjjOthbC6LZzlFa1yCGhqfQ==", null, false, "ca9c5950-c545-488f-af53-e84f653ce32f", false, "adam" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "ProducerId", "City", "Description", "FoundationYear", "Name", "OriginCountry", "PostalCode", "Region", "Street" },
                values: new object[,]
                {
                    { 1, "Round Rock", "Dell Inc. to amerykańska firma zajmująca się produkcją komputerów, w tym laptopów.", new DateTime(1984, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dell", "USA", "78682", "Texas", "One Dell Way" },
                    { 2, "Palo Alto", "HP Inc. to amerykańska firma zajmująca się produkcją sprzętu komputerowego, w tym komputerów stacjonarnych.", new DateTime(1939, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HP", "USA", "94304", "California", "1501 Page Mill Road" },
                    { 3, "Round Rock", "Alienware to marka komputerów do gier i akcesoriów, należąca do Dell Inc.", new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alienware", "USA", "78682", "Texas", "One Dell Way" },
                    { 4, "Mountain View", "Google LLC to globalna firma technologiczna, znana m.in. z systemu operacyjnego Chrome OS, który jest używany w Chromebookach.", new DateTime(1998, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Google", "USA", "94043", "California", "1600 Amphitheatre Parkway" },
                    { 5, "Beitou District", "AsusTek Computer Inc. to tajwańska firma zajmująca się produkcją sprzętu komputerowego, w tym Ultrabooków.", new DateTime(1989, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asus", "Taiwan", "112", "Taipei", "No. 15, Li-Te Road" },
                    { 6, "Cupertino", "Apple Inc. to amerykańska firma technologiczna, która produkuje m.in. komputery All-In-One, takie jak iMac.", new DateTime(1976, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple", "USA", "95014", "California", "1 Apple Park Way" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "Laptop" },
                    { 2, "Komputer stacjonarny" },
                    { 3, "Komputer do gier" },
                    { 4, "Chromebook" },
                    { 5, "Ultrabook" },
                    { 6, "All-In-One" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d4fc2d68-e656-4e9b-8576-6b99dc0b2ed0", "1663d74f-4122-4b4d-a27b-5962b66d0c94" },
                    { "888df2a7-a91e-48df-a5f2-6dd0904d36d8", "a1c6e223-d17b-4245-b115-b6c32be19943" }
                });

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "ComputerId", "Karta graficzna", "Dysk twardy", "Pamięć RAM", "Nazwa komputera", "Procesor", "ProducerId", "Data produkcji", "TypeId" },
                values: new object[,]
                {
                    { 1, "Intel Iris Xe Graphics", "512 GB SSD", "16 GB DDR4", "Dell XPS 13", "Intel Core i7", 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "NVIDIA GeForce RTX 3060", "1 TB SSD", "32 GB DDR4", "HP Pavilion Desktop", "AMD Ryzen 7", 2, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "NVIDIA GeForce RTX 3080", "2 TB NVMe SSD", "64 GB DDR4", "Alienware Aurora R12", "Intel Core i9", 3, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "Intel UHD Graphics 615", "128 GB SSD", "8 GB RAM", "Google Pixelbook Go", "Intel Core i5", 4, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, "Intel Iris Xe Graphics", "1 TB PCIe SSD", "16 GB LPDDR4X", "Asus ZenBook 14", "Intel Core i7", 5, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, "Apple M1 GPU", "512 GB SSD", "16 GB unified memory", "Apple iMac 27-inch", "Apple M1", 6, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_computers_ProducerId",
                table: "computers",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_computers_TypeId",
                table: "computers",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "computers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
