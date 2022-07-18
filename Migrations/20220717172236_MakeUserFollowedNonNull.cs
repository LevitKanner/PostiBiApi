using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class MakeUserFollowedNonNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "9f7df6f4-6e0e-4f55-82d8-04b83a3394fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "cb95635c-318d-4481-8fc2-2e928790d6f3");

            migrationBuilder.AlterColumn<string>(
                name: "user_followed_id",
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
                    { "42dc1419-f607-4132-80c3-b1dbe47f48f4", "b809f30f-df95-400d-90d2-17d8f3e865d6", "Admin", "ADMIN" },
                    { "86c39fd5-74f6-4f53-bce7-b9b7e733ebb6", "aa3b2a52-4941-469c-8472-04c654151934", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "42dc1419-f607-4132-80c3-b1dbe47f48f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "86c39fd5-74f6-4f53-bce7-b9b7e733ebb6");

            migrationBuilder.AlterColumn<string>(
                name: "user_followed_id",
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
                    { "9f7df6f4-6e0e-4f55-82d8-04b83a3394fc", "eb4a235c-b67e-4eae-8701-694b201f8cac", "User", "USER" },
                    { "cb95635c-318d-4481-8fc2-2e928790d6f3", "e94bcd1a-cefb-43ca-a5af-689ef03d08e5", "Admin", "ADMIN" }
                });
        }
    }
}
