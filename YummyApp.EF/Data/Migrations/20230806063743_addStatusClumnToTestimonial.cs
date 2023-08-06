using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStatusClumnToTestimonial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55d01ffa-11ba-425b-ac0b-7d90a1a3daba", "AQAAAAIAAYagAAAAEML3+v3Soc/gMEfepUFmK/LhJ0NM6E1OF2zb2MWd/3jqYUxzlg7Gioe/uwh4vWA8Cw==", "106217ce-4055-4268-8108-d45b5bdb260b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Testimonials");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9de09b91-b8f7-44ab-9656-df8afb91fed3", "AQAAAAIAAYagAAAAEGflWMQo3X0TfxWVawAmLth6TwfyRZFw0K0nW5VycCsvob0jqGocTRjgPyCTdGvREA==", "050fcb02-f104-46b1-bd47-81d402ecf307" });
        }
    }
}
