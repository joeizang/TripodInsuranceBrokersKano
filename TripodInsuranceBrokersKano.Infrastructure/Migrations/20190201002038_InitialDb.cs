using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TripodInsuranceBrokersKano.Infrastructure.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Commission = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreditNoteNumber = table.Column<string>(maxLength: 10, nullable: false),
                    InsuredId = table.Column<int>(nullable: false),
                    PolicyEffectiveStartDate = table.Column<DateTimeOffset>(nullable: false),
                    PolicyEffectiveEndDate = table.Column<DateTimeOffset>(nullable: false),
                    GrossPremium = table.Column<decimal>(nullable: false),
                    NetPremium = table.Column<decimal>(nullable: false),
                    Signed = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebitNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DebitNoteNumber = table.Column<string>(maxLength: 10, nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    PolicyId = table.Column<int>(nullable: false),
                    Commission = table.Column<decimal>(nullable: false),
                    Signature = table.Column<byte[]>(nullable: true),
                    PremiumType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    Insured = table.Column<bool>(nullable: false),
                    PolicyPercentage = table.Column<double>(nullable: true),
                    DebitNoteId2 = table.Column<int>(nullable: true),
                    DebitNoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_DebitNotes_DebitNoteId2",
                        column: x => x.DebitNoteId2,
                        principalTable: "DebitNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    InsurerPolicyNumber = table.Column<string>(maxLength: 20, nullable: false),
                    InternalPolicyNumber = table.Column<string>(maxLength: 15, nullable: false),
                    PolicyTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    PolicyTermDocument = table.Column<string>(maxLength: 4000, nullable: true),
                    GrossPolicyValuation = table.Column<decimal>(nullable: false),
                    NetPolicyValuation = table.Column<decimal>(nullable: false),
                    MultiInsurerPolicy = table.Column<bool>(nullable: false),
                    IndemnityPeriod = table.Column<int>(nullable: false),
                    InsuredId = table.Column<int>(nullable: false),
                    PolicyEffectiveStartDate = table.Column<DateTimeOffset>(nullable: false),
                    PolicyEffectiveEndDate = table.Column<DateTimeOffset>(nullable: false),
                    DebitNoteId = table.Column<int>(nullable: false),
                    CreditNoteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policies_DebitNotes_DebitNoteId",
                        column: x => x.DebitNoteId,
                        principalTable: "DebitNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_Clients_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_PolicyTypes_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "PolicyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insurers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    InsurerName = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumbers_TelephoneNumber = table.Column<string>(nullable: true),
                    PhoneNumbers_SecondTelephoneNumber = table.Column<string>(nullable: true),
                    PhoneNumbers_ThirdNumber = table.Column<string>(nullable: true),
                    PhoneNumbers_ForthNumber = table.Column<string>(nullable: true),
                    PhoneNumbers_FifthNumber = table.Column<string>(nullable: true),
                    CreditNoteId = table.Column<int>(nullable: true),
                    DebitNoteId = table.Column<int>(nullable: true),
                    PolicyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurers_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insurers_DebitNotes_DebitNoteId",
                        column: x => x.DebitNoteId,
                        principalTable: "DebitNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insurers_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    PolicyId = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    ChequeOrDraftNumber = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipts_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DebitNoteId2",
                table: "Clients",
                column: "DebitNoteId2");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_InsuredId",
                table: "CreditNotes",
                column: "InsuredId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_ClientId",
                table: "DebitNotes",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_PolicyId",
                table: "DebitNotes",
                column: "PolicyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurers_CreditNoteId",
                table: "Insurers",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurers_DebitNoteId",
                table: "Insurers",
                column: "DebitNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurers_PolicyId",
                table: "Insurers",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_CreditNoteId",
                table: "Policies",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_DebitNoteId",
                table: "Policies",
                column: "DebitNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_InsuredId",
                table: "Policies",
                column: "InsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_InsurerPolicyNumber",
                table: "Policies",
                column: "InsurerPolicyNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_InternalPolicyNumber",
                table: "Policies",
                column: "InternalPolicyNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PolicyTypeId",
                table: "Policies",
                column: "PolicyTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ClientId",
                table: "Receipts",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_PolicyId",
                table: "Receipts",
                column: "PolicyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNotes_Clients_InsuredId",
                table: "CreditNotes",
                column: "InsuredId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_Clients_ClientId",
                table: "DebitNotes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_Policies_PolicyId",
                table: "DebitNotes",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DebitNotes_DebitNoteId2",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_DebitNotes_DebitNoteId",
                table: "Policies");

            migrationBuilder.DropTable(
                name: "Insurers");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "DebitNotes");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "CreditNotes");

            migrationBuilder.DropTable(
                name: "PolicyTypes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
