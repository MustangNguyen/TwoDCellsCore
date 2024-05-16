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
            migrationBuilder.DropForeignKey(
                name: "FK_user_gun_users",
                table: "user_gun");

            migrationBuilder.DropForeignKey(
                name: "FK_user_mutation_users",
                table: "user_mutation");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mutation_upgrade_config",
                table: "mutation_upgrade_config");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gun_upgrade_config",
                table: "gun_upgrade_config");

            migrationBuilder.RenameColumn(
                name: "MutationID",
                table: "user_mutation",
                newName: "mutationID");

            migrationBuilder.RenameColumn(
                name: "mutationiXp",
                table: "user_mutation",
                newName: "mutationXp");

            migrationBuilder.RenameIndex(
                name: "IX_user_mutation_MutationID",
                table: "user_mutation",
                newName: "IX_user_mutation_mutationID");

            migrationBuilder.AlterColumn<int>(
                name: "xpRequire",
                table: "mutation_upgrade_config",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "mutationLv",
                table: "mutation_upgrade_config",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "xpRequire",
                table: "gun_upgrade_config",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "mutationLv",
                table: "gun_upgrade_config",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__mutation__3133F259C7CDCB68",
                table: "mutation_upgrade_config",
                column: "mutationLv");

            migrationBuilder.AddPrimaryKey(
                name: "PK__gun_upgr__3133F2595884267F",
                table: "gun_upgrade_config",
                column: "mutationLv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__mutation__3133F259C7CDCB68",
                table: "mutation_upgrade_config");

            migrationBuilder.DropPrimaryKey(
                name: "PK__gun_upgr__3133F2595884267F",
                table: "gun_upgrade_config");

            migrationBuilder.RenameColumn(
                name: "mutationID",
                table: "user_mutation",
                newName: "MutationID");

            migrationBuilder.RenameColumn(
                name: "mutationXp",
                table: "user_mutation",
                newName: "mutationiXp");

            migrationBuilder.RenameIndex(
                name: "IX_user_mutation_mutationID",
                table: "user_mutation",
                newName: "IX_user_mutation_MutationID");

            migrationBuilder.AlterColumn<int>(
                name: "xpRequire",
                table: "mutation_upgrade_config",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "mutationLv",
                table: "mutation_upgrade_config",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "xpRequire",
                table: "gun_upgrade_config",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "mutationLv",
                table: "gun_upgrade_config",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mutation_upgrade_config",
                table: "mutation_upgrade_config",
                column: "mutationLv");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gun_upgrade_config",
                table: "gun_upgrade_config",
                column: "mutationLv");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    credit = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "nchar(18)", fixedLength: true, maxLength: 18, nullable: false),
                    userName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_user_gun_users",
                table: "user_gun",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_user_mutation_users",
                table: "user_mutation",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID");
        }
    }
}
