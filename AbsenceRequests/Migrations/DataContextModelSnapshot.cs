﻿// <auto-generated />
using System;
using AbsenceRequests.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AbsenceRequests.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AbsenceRequests.Models.AbsenceRequest", b =>
                {
                    b.Property<int>("AbsenceRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbsenceRequestID"), 1L, 1);

                    b.Property<int>("AbsenceTypeID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AbsenceRequestID");

                    b.HasIndex("AbsenceTypeID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("AbsenceRequests");

                    b.HasData(
                        new
                        {
                            AbsenceRequestID = 1,
                            AbsenceTypeID = 1,
                            EmployeeID = 1,
                            EndDate = new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AbsenceRequests.Models.AbsenceType", b =>
                {
                    b.Property<int>("AbsenceTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbsenceTypeID"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AbsenceTypeID");

                    b.ToTable("AbsenceTypes");

                    b.HasData(
                        new
                        {
                            AbsenceTypeID = 1,
                            Title = "Vacation"
                        },
                        new
                        {
                            AbsenceTypeID = 2,
                            Title = "Family"
                        },
                        new
                        {
                            AbsenceTypeID = 3,
                            Title = "Medical"
                        },
                        new
                        {
                            AbsenceTypeID = 4,
                            Title = "Personal"
                        },
                        new
                        {
                            AbsenceTypeID = 5,
                            Title = "Military"
                        });
                });

            modelBuilder.Entity("AbsenceRequests.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            Email = "simon.johansson@mail.com",
                            Name = "Simon",
                            PhoneNumber = "123 456 78 91",
                            Surname = "Johansson"
                        },
                        new
                        {
                            EmployeeID = 2,
                            Email = "elon.musk@mail.com",
                            Name = "Elon",
                            PhoneNumber = "123 456 78 92",
                            Surname = "Musk"
                        },
                        new
                        {
                            EmployeeID = 3,
                            Email = "jeff.bezos@mail.com",
                            Name = "Jeff",
                            PhoneNumber = "123 456 78 93",
                            Surname = "Bezos"
                        },
                        new
                        {
                            EmployeeID = 4,
                            Email = "steve.jobs@mail.com",
                            Name = "Steve",
                            PhoneNumber = "123 456 78 94",
                            Surname = "Jobs"
                        });
                });

            modelBuilder.Entity("AbsenceRequests.Models.AbsenceRequest", b =>
                {
                    b.HasOne("AbsenceRequests.Models.AbsenceType", "AbsenceType")
                        .WithMany()
                        .HasForeignKey("AbsenceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbsenceRequests.Models.Employee", "Employee")
                        .WithMany("AbsenceRequests")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbsenceType");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AbsenceRequests.Models.Employee", b =>
                {
                    b.Navigation("AbsenceRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
