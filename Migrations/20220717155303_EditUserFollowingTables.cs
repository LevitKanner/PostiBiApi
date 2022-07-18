using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class EditUserFollowingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_followings_users_user_id",
                table: "user_followings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "24016f84-c2d9-48a4-8b99-8a51e515f37f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "24d612bd-089f-494a-814a-f9f8c029fcff");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_followings",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "9f7df6f4-6e0e-4f55-82d8-04b83a3394fc", "eb4a235c-b67e-4eae-8701-694b201f8cac", "User", "USER" },
                    { "cb95635c-318d-4481-8fc2-2e928790d6f3", "e94bcd1a-cefb-43ca-a5af-689ef03d08e5", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_user_followings_users_user_id",
                table: "user_followings",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_followings_users_user_id",
                table: "user_followings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "9f7df6f4-6e0e-4f55-82d8-04b83a3394fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "cb95635c-318d-4481-8fc2-2e928790d6f3");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_followings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "24016f84-c2d9-48a4-8b99-8a51e515f37f", "d4214daf-611b-45d8-af6b-97bfc9588786", "Admin", "ADMIN" },
                    { "24d612bd-089f-494a-814a-f9f8c029fcff", "ec1aafe0-c374-4bb8-9619-2f6bc7086258", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_user_followings_users_user_id",
                table: "user_followings",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }
    }
}
