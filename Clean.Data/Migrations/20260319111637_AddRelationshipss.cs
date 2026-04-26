using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BabyId",
                table: "Appointments",
                column: "BabyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_NurseId",
                table: "Appointments",
                column: "NurseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Babies_BabyId",
                table: "Appointments",
                column: "BabyId",
                principalTable: "Babies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Nurses_NurseId",
                table: "Appointments",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Babies_BabyId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Nurses_NurseId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BabyId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_NurseId",
                table: "Appointments");
        }
    }
}
