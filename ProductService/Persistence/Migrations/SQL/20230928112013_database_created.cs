using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductService.Persistence.Migrations.SQL
{
    /// <inheritdoc />
    public partial class database_created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(3997), false, "Mutfak" },
                    { 2, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(4008), false, "Mobilya" },
                    { 3, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(4009), false, "Market" },
                    { 4, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(4010), false, "Aydınlatma" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedOn", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(6568), false, "Gardırop", 3000m },
                    { 2, 2, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(6574), false, "Fırın", 4000m },
                    { 3, 3, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(6576), false, "Fıstık Ezmesi", 85m },
                    { 4, 4, "System User", new DateTime(2023, 9, 28, 14, 20, 13, 888, DateTimeKind.Local).AddTicks(6651), false, "ModeLight Işıl 3'lü Avize", 4000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
