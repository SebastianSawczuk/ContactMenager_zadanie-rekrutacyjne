using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactMenager.API.Migrations
{
    /// <inheritdoc />
    public partial class addOtherField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_AspNetUsers_ApplicationUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_ApplicationUserId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Other",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Contact",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ApplicationUserId",
                table: "Contact",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_AspNetUsers_ApplicationUserId",
                table: "Contact",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
