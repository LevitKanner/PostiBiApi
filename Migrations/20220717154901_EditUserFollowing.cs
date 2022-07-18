using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class EditUserFollowing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "091f0d38-989a-48b7-8762-29b951d905c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "84f76a24-b183-4a3c-8e59-93883a764c0d");

            migrationBuilder.RenameColumn(
                name: "user_following_id",
                table: "user_followings",
                newName: "user_id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "8858e0c4-adbc-4a03-8ea4-8a737f39989f", "d648d0f2-cd40-4980-b850-fe47628c63b5", "User", "USER" },
                    { "fc74760a-c8fb-441f-8197-b4edc21ded92", "16b3fd7d-e3b4-4730-9de4-0fb7d4e838d2", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "8858e0c4-adbc-4a03-8ea4-8a737f39989f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "fc74760a-c8fb-441f-8197-b4edc21ded92");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_followings",
                newName: "user_following_id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "091f0d38-989a-48b7-8762-29b951d905c2", "d82df737-cefa-477f-b667-2bec71d39e96", "Admin", "ADMIN" },
                    { "84f76a24-b183-4a3c-8e59-93883a764c0d", "9d6bf33e-f6ca-4388-8964-487c614c8335", "User", "USER" }
                });
        }
    }
}
