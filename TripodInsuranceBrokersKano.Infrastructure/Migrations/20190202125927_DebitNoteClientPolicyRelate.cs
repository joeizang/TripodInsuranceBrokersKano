using Microsoft.EntityFrameworkCore.Migrations;

namespace TripodInsuranceBrokersKano.Infrastructure.Migrations
{
    public partial class DebitNoteClientPolicyRelate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DebitNotes_DebitNoteId2",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_DebitNotes_DebitNoteId",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Policies_DebitNoteId",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Clients_DebitNoteId2",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DebitNoteId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DebitNoteId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DebitNoteId2",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DebitNoteId",
                table: "Policies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DebitNoteId",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DebitNoteId2",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Policies_DebitNoteId",
                table: "Policies",
                column: "DebitNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DebitNoteId2",
                table: "Clients",
                column: "DebitNoteId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_DebitNotes_DebitNoteId2",
                table: "Clients",
                column: "DebitNoteId2",
                principalTable: "DebitNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_DebitNotes_DebitNoteId",
                table: "Policies",
                column: "DebitNoteId",
                principalTable: "DebitNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
