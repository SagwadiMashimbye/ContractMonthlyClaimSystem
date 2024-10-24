using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractMonthlyClaimSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialUPdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicManagers_Users_UserId",
                table: "AcademicManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeCoordinators_Users_UserId",
                table: "ProgrammeCoordinators");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProgrammeCoordinators",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AcademicManagers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicManagers_Users_UserId",
                table: "AcademicManagers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeCoordinators_Users_UserId",
                table: "ProgrammeCoordinators",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicManagers_Users_UserId",
                table: "AcademicManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeCoordinators_Users_UserId",
                table: "ProgrammeCoordinators");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProgrammeCoordinators",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AcademicManagers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicManagers_Users_UserId",
                table: "AcademicManagers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeCoordinators_Users_UserId",
                table: "ProgrammeCoordinators",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
