using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetLar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamePetOwnerToOng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_OwnerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Pets",
                newName: "OngId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                newName: "IX_Pets_OngId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_OngId",
                table: "Pets",
                column: "OngId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_OngId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "OngId",
                table: "Pets",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_OngId",
                table: "Pets",
                newName: "IX_Pets_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
