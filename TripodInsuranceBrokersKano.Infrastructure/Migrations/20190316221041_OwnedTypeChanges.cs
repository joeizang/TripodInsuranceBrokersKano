using Microsoft.EntityFrameworkCore.Migrations;

namespace TripodInsuranceBrokersKano.Infrastructure.Migrations
{
    public partial class OwnedTypeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_BuildingNumber",
                table: "Insurers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_CloseLandMarks",
                table: "Insurers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_StreetName",
                table: "Insurers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientAddress_BuildingNumber",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientAddress_CloseLandMarks",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientAddress_StreetName",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAddress_BuildingNumber",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAddress_CloseLandMarks",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAddress_StreetName",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_BuildingNumber",
                table: "Insurers");

            migrationBuilder.DropColumn(
                name: "Address_CloseLandMarks",
                table: "Insurers");

            migrationBuilder.DropColumn(
                name: "Address_StreetName",
                table: "Insurers");

            migrationBuilder.DropColumn(
                name: "ClientAddress_BuildingNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientAddress_CloseLandMarks",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientAddress_StreetName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OtherAddress_BuildingNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OtherAddress_CloseLandMarks",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OtherAddress_StreetName",
                table: "Clients");
        }
    }
}
