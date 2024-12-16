using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDEExellence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role" },
                values: new object[] { 1, "admin@example.com", "$2a$11$VgnqtCwJc0guFHQn16JBoOkkbCIbBJtUxeDDC3IIoF.m7c49L0jQC", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
