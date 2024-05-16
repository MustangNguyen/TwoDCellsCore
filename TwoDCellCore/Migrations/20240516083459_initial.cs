using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwoDCellCore.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "user_mutation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "user_gun",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_user_gun_AspNetUsers",
                table: "user_gun",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_mutation_AspNetUsers",
                table: "user_mutation",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_gun_AspNetUsers",
                table: "user_gun");

            migrationBuilder.DropForeignKey(
                name: "FK_user_mutation_AspNetUsers",
                table: "user_mutation");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "users",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "user_mutation",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "user_gun",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
