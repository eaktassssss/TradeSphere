using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerService.Persistence.Migrations.SQL
{
    /// <inheritdoc />
    public partial class database_created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerService");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "CustomerService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "CustomerService",
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "FirstName", "IsDeleted", "JoiningDate", "LastName" },
                values: new object[,]
                {
                    { 1, "System User", new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4495), "EVREN", false, new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4509), "AKTAŞ" },
                    { 2, "System User", new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4511), "ECE", false, new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4512), "DAĞDELEN" },
                    { 3, "System User", new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4513), "İBRAHİM", false, new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4515), "AKIŞIK" },
                    { 4, "System User", new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4516), "GİZEM", false, new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4517), "KURTCUOĞLU" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "CustomerService");
        }
    }
}
