using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    public partial class UserFollowingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "7c0ed45d-0e33-48bb-8e44-74f7c8a72a43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "b167bf87-0a59-47c5-94a3-c4e05982fd7a");

            migrationBuilder.CreateTable(
                name: "user_followings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_following_id = table.Column<string>(type: "text", nullable: true),
                    user_followed_id = table.Column<string>(type: "text", nullable: true),
                    follow_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    application_user_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_followings", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_followings_users_application_user_id",
                        column: x => x.application_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "091f0d38-989a-48b7-8762-29b951d905c2", "d82df737-cefa-477f-b667-2bec71d39e96", "Admin", "ADMIN" },
                    { "84f76a24-b183-4a3c-8e59-93883a764c0d", "9d6bf33e-f6ca-4388-8964-487c614c8335", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_followings_application_user_id",
                table: "user_followings",
                column: "application_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_followings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "091f0d38-989a-48b7-8762-29b951d905c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "84f76a24-b183-4a3c-8e59-93883a764c0d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "7c0ed45d-0e33-48bb-8e44-74f7c8a72a43", "c1cf0aa2-f5ee-4ce4-96e0-63cc0ab451c4", "Admin", "ADMIN" },
                    { "b167bf87-0a59-47c5-94a3-c4e05982fd7a", "9dc5102a-c83f-41a7-8b15-dbaeaac6d852", "User", "USER" }
                });
        }
    }
}
