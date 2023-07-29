using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class ulterAdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b572c1f-4f44-4108-acf4-b2367a017b7c", "AQAAAAIAAYagAAAAEGC5UUo8mz5Tv1hmITMQ/zZRMZVwwAZ9OjKGBv5BviWaXpl+rVp46+ZY2F1N+eJmeA==", "1a66e63b-508c-45b1-8ccb-abcee0147579" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e212d486-2908-4554-9460-f342f7b84d5e", "AQAAAAIAAYagAAAAEFs4WzF0KmEbXcYCuUn/OYPACiNBXfHnjq+LF11hMKB9n8drOEA/iQVujK843BLO0A==", "9267529c-9d60-4f06-ab56-bb4975d2e413" });
        }
    }
}
