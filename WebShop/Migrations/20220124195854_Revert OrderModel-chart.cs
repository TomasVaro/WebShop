using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class RevertOrderModelchart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ProductOrder_ProductOrderProductId_ProductOrderOrderId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductOrderProductId_ProductOrderOrderId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7640319-c232-4882-8168-15733ce600fe");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6b351dee-982c-4faa-9d01-da9654201bb5", "cb789e1a-28c1-48b9-81c0-c850e7980a95" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb789e1a-28c1-48b9-81c0-c850e7980a95");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b351dee-982c-4faa-9d01-da9654201bb5");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductOrderOrderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductOrderProductId",
                table: "Order");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66d93b6b-0737-4d1c-b12f-0fda0d265f26", "f967ea47-bf1e-493b-836e-40273990cc40", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbb4278a-e04f-4223-baca-4cd1547947b5", "b2b26e8a-bf2b-486e-94f2-1611e741de5c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "0507d89f-1a09-478a-9f75-1393fd278187", 0, "Göteborg", "f9e700a1-3ca7-4412-9482-8a2e390dda79", null, "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMpKHfEBLv7nAIM1D52EP2BqlpolWzADaZghkQc7vbJO1stqzKukMys70ivy8LhqUQ==", "070-123 45 67", false, "46d9137f-6252-4020-96c7-a7eb64043b90", "Storgatan 3", false, "admin@admin.com", "123 45" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0507d89f-1a09-478a-9f75-1393fd278187", "66d93b6b-0737-4d1c-b12f-0fda0d265f26" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb4278a-e04f-4223-baca-4cd1547947b5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0507d89f-1a09-478a-9f75-1393fd278187", "66d93b6b-0737-4d1c-b12f-0fda0d265f26" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66d93b6b-0737-4d1c-b12f-0fda0d265f26");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0507d89f-1a09-478a-9f75-1393fd278187");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductOrderOrderId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductOrderProductId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb789e1a-28c1-48b9-81c0-c850e7980a95", "89ae85bf-9543-40f9-a133-9f6e666cc34f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7640319-c232-4882-8168-15733ce600fe", "5fd8b037-79dc-428a-85b4-62534b987255", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "6b351dee-982c-4faa-9d01-da9654201bb5", 0, "Göteborg", "909bfadf-29e3-4e71-83e5-91069881b6ae", null, "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPZQVFKSgIJrhckPysg3G69xl9Ie4jI7IpNLWp+KXEVadCLABUspCWgGt9Y6BrjOyw==", "070-123 45 67", false, "e3e1828e-8a70-4c8f-b42e-3ed8e24f79f0", "Storgatan 3", false, "admin@admin.com", "123 45" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "6b351dee-982c-4faa-9d01-da9654201bb5", "cb789e1a-28c1-48b9-81c0-c850e7980a95" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductOrderProductId_ProductOrderOrderId",
                table: "Order",
                columns: new[] { "ProductOrderProductId", "ProductOrderOrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ProductOrder_ProductOrderProductId_ProductOrderOrderId",
                table: "Order",
                columns: new[] { "ProductOrderProductId", "ProductOrderOrderId" },
                principalTable: "ProductOrder",
                principalColumns: new[] { "ProductId", "OrderId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
