using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentsAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveResultKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Results_Id",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Appointments_AppointmentId",
                table: "Results",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Appointments_AppointmentId",
                table: "Results");

            migrationBuilder.AddColumn<Guid>(
                name: "ResultId",
                table: "Appointments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Results_Id",
                table: "Appointments",
                column: "Id",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
