using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class EditUserFollowingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_followings_users_application_user_id",
                table: "user_followings");

            migrationBuilder.DropIndex(
                name: "ix_user_followings_application_user_id",
                table: "user_followings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "8858e0c4-adbc-4a03-8ea4-8a737f39989f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "fc74760a-c8fb-441f-8197-b4edc21ded92");

            migrationBuilder.DropColumn(
                name: "application_user_id",
                table: "user_followings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "24016f84-c2d9-48a4-8b99-8a51e515f37f", "d4214daf-611b-45d8-af6b-97bfc9588786", "Admin", "ADMIN" },
                    { "24d612bd-089f-494a-814a-f9f8c029fcff", "ec1aafe0-c374-4bb8-9619-2f6bc7086258", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_followings_user_id",
                table: "user_followings",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_followings_users_user_id",
                table: "user_followings",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_followings_users_user_id",
                table: "user_followings");

            migrationBuilder.DropIndex(
                name: "ix_user_followings_user_id",
                table: "user_followings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "24016f84-c2d9-48a4-8b99-8a51e515f37f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "24d612bd-089f-494a-814a-f9f8c029fcff");

            migrationBuilder.AddColumn<string>(
                name: "application_user_id",
                table: "user_followings",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "8858e0c4-adbc-4a03-8ea4-8a737f39989f", "d648d0f2-cd40-4980-b850-fe47628c63b5", "User", "USER" },
                    { "fc74760a-c8fb-441f-8197-b4edc21ded92", "16b3fd7d-e3b4-4730-9de4-0fb7d4e838d2", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_followings_application_user_id",
                table: "user_followings",
                column: "application_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_followings_users_application_user_id",
                table: "user_followings",
                column: "application_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }
    }
}
