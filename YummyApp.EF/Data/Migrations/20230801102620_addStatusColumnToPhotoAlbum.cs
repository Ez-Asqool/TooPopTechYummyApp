using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStatusColumnToPhotoAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PhotoAlbums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd10720b-33e1-4092-b7b8-d2d983562552", "AQAAAAIAAYagAAAAEHaFpShQUTeDyqR8Q+MsQRWOboVFdw9+1tPogzdcxxqhZpXOR81qEbA8OLzUMZd22g==", "e9ff40e2-2519-44b9-aab6-1ecfc6ea9e49" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PhotoAlbums");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b572c1f-4f44-4108-acf4-b2367a017b7c", "AQAAAAIAAYagAAAAEGC5UUo8mz5Tv1hmITMQ/zZRMZVwwAZ9OjKGBv5BviWaXpl+rVp46+ZY2F1N+eJmeA==", "1a66e63b-508c-45b1-8ccb-abcee0147579" });
        }
    }
}
