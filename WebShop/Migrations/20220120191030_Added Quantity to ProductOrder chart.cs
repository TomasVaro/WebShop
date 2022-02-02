using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class AddedQuantitytoProductOrderchart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f740d82-ea56-4b61-8448-b92bae853ad8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1b5b9264-cdb7-4677-9fba-091591dd4707", "46df9ea0-0780-40a5-9bf1-3b091df20cc7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46df9ea0-0780-40a5-9bf1-3b091df20cc7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b5b9264-cdb7-4677-9fba-091591dd4707");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8c0c7d4-ef07-4abe-87ae-5460897a3c94", "109c8adb-3e8f-4f5f-9d30-8583042ff067", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d88ee500-3844-4589-b0c7-558b0f05c4e6", "d0e9717d-c8ce-4f73-a645-39b043618d5d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City", "FirstName", "LastName", "Street", "ZipCode" },
                values: new object[] { "9c18847e-edd2-45e4-8f37-059f725f4d73", 0, "e31c2137-ba70-404c-96db-d7f5123bf6da", "ApplicationUser", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMlGmbmhFQNa6sumrXpQM0emloeqf3tbY83kfZDsXhScxpgKmZOXi1sOQx8IyRJaUA==", "070-123 45 67", false, "da00f38e-2776-4800-965c-972a642752fc", false, "admin@admin.com", "Göteborg", "Admin", "Adminsson", "Storgatan 3", "123 45" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "9c18847e-edd2-45e4-8f37-059f725f4d73", "b8c0c7d4-ef07-4abe-87ae-5460897a3c94" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d88ee500-3844-4589-b0c7-558b0f05c4e6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9c18847e-edd2-45e4-8f37-059f725f4d73", "b8c0c7d4-ef07-4abe-87ae-5460897a3c94" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8c0c7d4-ef07-4abe-87ae-5460897a3c94");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c18847e-edd2-45e4-8f37-059f725f4d73");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductOrder");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46df9ea0-0780-40a5-9bf1-3b091df20cc7", "6242b3d8-ca35-4d52-b482-3eab7ce71ef0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f740d82-ea56-4b61-8448-b92bae853ad8", "27ede000-9e02-4a31-bc5d-e5c31930daf7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City", "FirstName", "LastName", "Street", "ZipCode" },
                values: new object[] { "1b5b9264-cdb7-4677-9fba-091591dd4707", 0, "ad22d59f-9502-4b66-98f0-1e0ddf77b5a3", "ApplicationUser", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBaqBWQOd5NJST3OPEk+/WVdSiAU7ELpSlJEOSARA+dZhIqS7HUdDq9+e5aXybJ2yA==", "070-123 45 67", false, "af2d3e79-dc34-42c2-96b9-2cf1df506391", false, "admin@admin.com", "Göteborg", "Admin", "Adminsson", "Storgatan 3", "123 45" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1b5b9264-cdb7-4677-9fba-091591dd4707", "46df9ea0-0780-40a5-9bf1-3b091df20cc7" });
        }
    }
}
