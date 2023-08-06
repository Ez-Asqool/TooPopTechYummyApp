using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addImageNameClumnToTestimonial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Testimonials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Testimonials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9de09b91-b8f7-44ab-9656-df8afb91fed3", "AQAAAAIAAYagAAAAEGflWMQo3X0TfxWVawAmLth6TwfyRZFw0K0nW5VycCsvob0jqGocTRjgPyCTdGvREA==", "050fcb02-f104-46b1-bd47-81d402ecf307" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Testimonials");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Testimonials",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Testimonials",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46e1aa4d-a1d5-4fdc-9cf8-4ff1bbb99a6e", "AQAAAAIAAYagAAAAEEEWo4ogmjvMFZ0gwcI8YVDJj53GtUo2u62OrwpvUJ2/WQiaUMTv6LbFdENbL2gOTw==", "dd3e6ba3-028a-4fcc-85a1-6e12ef48638d" });
        }
    }
}
