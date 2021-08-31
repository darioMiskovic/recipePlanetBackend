using Microsoft.EntityFrameworkCore.Migrations;

namespace recipe_planet.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adf96b5b-dce5-441d-a825-94e92e30dd19", "1953ecb5-49a8-4778-b950-d8e392f307f5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cae8c1a-dad3-4e83-8914-0e66e08fdb37", "af9fd32c-2e8f-4fea-a4a7-4e54d2cd3c50", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cae8c1a-dad3-4e83-8914-0e66e08fdb37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf96b5b-dce5-441d-a825-94e92e30dd19");
        }
    }
}
