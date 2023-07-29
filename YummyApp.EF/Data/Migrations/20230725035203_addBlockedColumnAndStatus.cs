using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addBlockedColumnAndStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "PhotoAlbums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "MenuCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Blocked",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "Blocked", "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { 0, "ebed951d-f277-4fac-ab25-50a4ecc64951", "AQAAAAIAAYagAAAAEJCqFUGsV7ZitfBS/ihQB2kJc35m8YF6GqBdHmyLr9aJ/6ihHEnp1zaErSWVPtA44A==", "7bdd1660-42a1-48d9-904e-27904611a802", 1 });

            migrationBuilder.UpdateData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Blocked",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Blocked",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Blocked",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "PhotoAlbums");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "MenuCategories");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90ab50d0-bb33-4def-bcd6-c73b3dd02896", "AQAAAAIAAYagAAAAENSLPBLYlVYIklELiyku56tdfWaGn/I7jeIylj8eba4FvCjnI/tin5bHEJEdOTs19g==", "f9abfce7-54ed-4ed5-964a-17627fa7c8ce" });
        }
    }
}
