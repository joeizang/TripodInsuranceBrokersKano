﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TripodInsuranceBrokersKano.Infrastructure.Context;

namespace TripodInsuranceBrokersKano.Infrastructure.Migrations
{
    [DbContext(typeof(TripodContext))]
    [Migration("20190316042443_UpdatesToModel")]
    partial class UpdatesToModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("Insured");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<double?>("PolicyPercentage");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.CreditNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreditNoteNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<bool>("Deleted");

                    b.Property<decimal>("GrossPremium");

                    b.Property<int>("InsuredId");

                    b.Property<decimal>("NetPremium");

                    b.Property<DateTimeOffset>("PolicyEffectiveEndDate");

                    b.Property<DateTimeOffset>("PolicyEffectiveStartDate");

                    b.Property<byte[]>("Signed");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("InsuredId")
                        .IsUnique();

                    b.ToTable("CreditNotes");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.DebitNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<int>("ClientId");

                    b.Property<decimal>("Commission");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("DebitNoteNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<bool>("Deleted");

                    b.Property<int>("PolicyId");

                    b.Property<int>("PremiumType");

                    b.Property<byte[]>("Signature");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("PolicyId")
                        .IsUnique();

                    b.ToTable("DebitNotes");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Insurer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int?>("CreditNoteId");

                    b.Property<int?>("DebitNoteId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("InsurerName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("PolicyId");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreditNoteId");

                    b.HasIndex("DebitNoteId");

                    b.HasIndex("InsurerName")
                        .IsUnique();

                    b.HasIndex("PolicyId");

                    b.ToTable("Insurers");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int?>("CreditNoteId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<decimal>("GrossPolicyValuation");

                    b.Property<int>("IndemnityPeriod");

                    b.Property<int>("InsuredId");

                    b.Property<string>("InsurerPolicyNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("InternalPolicyNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<bool>("MultiInsurerPolicy");

                    b.Property<decimal>("NetPolicyValuation");

                    b.Property<DateTimeOffset>("PolicyEffectiveEndDate");

                    b.Property<DateTimeOffset>("PolicyEffectiveStartDate");

                    b.Property<string>("PolicyTermDocument")
                        .HasMaxLength(4000);

                    b.Property<int>("PolicyTypeId");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreditNoteId");

                    b.HasIndex("InsuredId");

                    b.HasIndex("InsurerPolicyNumber");

                    b.HasIndex("InternalPolicyNumber");

                    b.HasIndex("PolicyTypeId")
                        .IsUnique();

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.PolicyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<double>("Commission");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("PolicyTypes");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<decimal>("Amount");

                    b.Property<string>("ChequeOrDraftNumber")
                        .HasMaxLength(25);

                    b.Property<int>("ClientId");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<int>("PaymentType");

                    b.Property<int>("PolicyId");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("PolicyId")
                        .IsUnique();

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanApprove");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Designation");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("Permissions");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Designation");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.Infrastructure.IdentityModels.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Client", b =>
                {
                    b.OwnsOne("TripodInsuranceBrokersKano.DomainModels.Entities.Address", "ClientAddress", b1 =>
                        {
                            b1.Property<int>("ClientId");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Client")
                                .WithOne("ClientAddress")
                                .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.Address", "ClientId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TripodInsuranceBrokersKano.DomainModels.Entities.Address", "OtherAddress", b1 =>
                        {
                            b1.Property<int>("ClientId");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Client")
                                .WithOne("OtherAddress")
                                .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.Address", "ClientId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.CreditNote", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Client", "Insured")
                        .WithOne()
                        .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.CreditNote", "InsuredId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.DebitNote", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Client", "Client")
                        .WithOne()
                        .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.DebitNote", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Policy", "Policy")
                        .WithOne()
                        .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.DebitNote", "PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Insurer", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.CreditNote")
                        .WithMany("Insurers")
                        .HasForeignKey("CreditNoteId");

                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.DebitNote")
                        .WithMany("Insurers")
                        .HasForeignKey("DebitNoteId");

                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Policy")
                        .WithMany("Insurers")
                        .HasForeignKey("PolicyId");

                    b.OwnsOne("TripodInsuranceBrokersKano.DomainModels.Entities.PhoneNumbers", "PhoneNumbers", b1 =>
                        {
                            b1.Property<int>("InsurerId");

                            b1.Property<string>("FifthNumber");

                            b1.Property<string>("ForthNumber");

                            b1.Property<string>("SecondTelephoneNumber");

                            b1.Property<string>("TelephoneNumber");

                            b1.Property<string>("ThirdNumber");

                            b1.HasKey("InsurerId");

                            b1.ToTable("Insurers");

                            b1.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Insurer")
                                .WithOne("PhoneNumbers")
                                .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.PhoneNumbers", "InsurerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TripodInsuranceBrokersKano.DomainModels.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("InsurerId");

                            b1.HasKey("InsurerId");

                            b1.ToTable("Insurers");

                            b1.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Insurer")
                                .WithOne("Address")
                                .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.Address", "InsurerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Policy", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.CreditNote")
                        .WithMany("Policies")
                        .HasForeignKey("CreditNoteId");

                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Client", "Insured")
                        .WithMany("Policies")
                        .HasForeignKey("InsuredId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.PolicyType", "PolicyType")
                        .WithOne()
                        .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.Policy", "PolicyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripodInsuranceBrokersKano.DomainModels.Entities.Receipt", b =>
                {
                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Client", "Payer")
                        .WithOne()
                        .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.Receipt", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripodInsuranceBrokersKano.DomainModels.Entities.Policy", "Policy")
                        .WithOne()
                        .HasForeignKey("TripodInsuranceBrokersKano.DomainModels.Entities.Receipt", "PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
