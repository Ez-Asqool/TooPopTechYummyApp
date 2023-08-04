using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba360cbe-5de6-4629-bcd6-be86881a10ca", "AQAAAAIAAYagAAAAEEOehry4FrY2/0Smbcl8fU+Yd2VNVGF7g1/ndDrtgN1Tylh0w2DwvaeTs/uwPJQn5Q==", "ba04c81e-d3dd-413d-b882-7f6936a11216" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd10720b-33e1-4092-b7b8-d2d983562552", "AQAAAAIAAYagAAAAEHaFpShQUTeDyqR8Q+MsQRWOboVFdw9+1tPogzdcxxqhZpXOR81qEbA8OLzUMZd22g==", "e9ff40e2-2519-44b9-aab6-1ecfc6ea9e49" });
        }
    }
}
