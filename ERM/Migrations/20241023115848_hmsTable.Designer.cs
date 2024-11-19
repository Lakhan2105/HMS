﻿// <auto-generated />
using System;
using ERM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241023115848_hmsTable")]
    partial class hmsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ERM.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("PractitionerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("LocationId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PractitionerId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ERM.Models.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinicId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("ERM.Models.ClinicAdmin", b =>
                {
                    b.Property<int>("ClinicAdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicAdminId"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClinicAdminId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("ClinicAdmins");
                });

            modelBuilder.Entity("ERM.Models.GlobalType", b =>
                {
                    b.Property<int>("GlobalTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GlobalTypeId"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GlobalTypeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GlobalTypeId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("GlobalTypeCategoryId");

                    b.ToTable("GlobalTypes");
                });

            modelBuilder.Entity("ERM.Models.GlobalTypeCategory", b =>
                {
                    b.Property<int>("GlobalTypeCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GlobalTypeCategoryId"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GlobalTypeCategoryId");

                    b.HasIndex("ClinicId");

                    b.ToTable("GlobalTypeCategories");
                });

            modelBuilder.Entity("ERM.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("ClinicId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ERM.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DateofBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int?>("PractitionerId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PractitionerId");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ERM.Models.Practitioner", b =>
                {
                    b.Property<int>("PractitionerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PractitionerId"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PractitionerId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("Practitioners");
                });

            modelBuilder.Entity("ERM.Models.Token", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenId"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AccessTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TokenId");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("ERM.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("ClinicId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ERM.Models.Appointment", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("ERM.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("ERM.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("ERM.Models.Practitioner", "Practitioner")
                        .WithMany()
                        .HasForeignKey("PractitionerId");

                    b.Navigation("Clinic");

                    b.Navigation("Location");

                    b.Navigation("Patient");

                    b.Navigation("Practitioner");
                });

            modelBuilder.Entity("ERM.Models.ClinicAdmin", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("ERM.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Clinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ERM.Models.GlobalType", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("ERM.Models.GlobalTypeCategory", "GlobalTypeCategory")
                        .WithMany()
                        .HasForeignKey("GlobalTypeCategoryId");

                    b.Navigation("Clinic");

                    b.Navigation("GlobalTypeCategory");
                });

            modelBuilder.Entity("ERM.Models.GlobalTypeCategory", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("ERM.Models.Location", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("ERM.Models.Patient", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("ERM.Models.Practitioner", "Practitioner")
                        .WithMany()
                        .HasForeignKey("PractitionerId");

                    b.HasOne("ERM.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Clinic");

                    b.Navigation("Practitioner");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ERM.Models.Practitioner", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("ERM.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Clinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ERM.Models.Token", b =>
                {
                    b.HasOne("ERM.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ERM.Models.User", b =>
                {
                    b.HasOne("ERM.Models.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.Navigation("Clinic");
                });
#pragma warning restore 612, 618
        }
    }
}
