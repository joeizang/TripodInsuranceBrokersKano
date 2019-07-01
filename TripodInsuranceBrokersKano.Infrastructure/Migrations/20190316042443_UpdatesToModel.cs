using Microsoft.EntityFrameworkCore.Migrations;

namespace TripodInsuranceBrokersKano.Infrastructure.Migrations
{
    public partial class UpdatesToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "Receipts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "PolicyTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "Policies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "Insurers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "DebitNotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "CreditNotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Insurers_InsurerName",
                table: "Insurers",
                column: "InsurerName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Insurers_InsurerName",
                table: "Insurers");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "PolicyTypes");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "Insurers");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "DebitNotes");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "CreditNotes");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "Clients");
        }
    }
}
