using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum_DAL.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17af339e-7ff2-4833-b503-5b2d325affc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2aa7fdd-0d8a-41c0-b5f7-f2c48e812406");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b387bb7b-1dc9-4a91-99d9-984268b66862", "0ed2ce52-83ed-496c-83a7-68a1d084ecb0", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c21d9d0-f511-40d4-80c3-d25095ede3bf", "3dc8a695-03d9-4737-8499-5777c728048b", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c21d9d0-f511-40d4-80c3-d25095ede3bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b387bb7b-1dc9-4a91-99d9-984268b66862");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17af339e-7ff2-4833-b503-5b2d325affc5", "3329a465-2cd0-4e39-9bb5-25ca9603b4cd", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2aa7fdd-0d8a-41c0-b5f7-f2c48e812406", "34651d97-7fe0-4c46-85ea-f81120da191a", "admin", null });
        }
    }
}
