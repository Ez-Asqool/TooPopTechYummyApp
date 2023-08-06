using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTestimonialsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", nullable: false),
                    Stars = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Blocked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46e1aa4d-a1d5-4fdc-9cf8-4ff1bbb99a6e", "AQAAAAIAAYagAAAAEEEWo4ogmjvMFZ0gwcI8YVDJj53GtUo2u62OrwpvUJ2/WQiaUMTv6LbFdENbL2gOTw==", "dd3e6ba3-028a-4fcc-85a1-6e12ef48638d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba360cbe-5de6-4629-bcd6-be86881a10ca", "AQAAAAIAAYagAAAAEEOehry4FrY2/0Smbcl8fU+Yd2VNVGF7g1/ndDrtgN1Tylh0w2DwvaeTs/uwPJQn5Q==", "ba04c81e-d3dd-413d-b882-7f6936a11216" });
        }
    }
}
