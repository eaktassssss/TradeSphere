﻿// <auto-generated />
using System;
using CustomerService.Persistence.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerService.Persistence.Migrations.SQL
{
    [DbContext(typeof(CustomerDdContext))]
    [Migration("20230928113222_database_created")]
    partial class database_created
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("CustomerService")
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerService.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers", "CustomerService");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System User",
                            CreatedOn = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4495),
                            FirstName = "EVREN",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4509),
                            LastName = "AKTAŞ"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System User",
                            CreatedOn = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4511),
                            FirstName = "ECE",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4512),
                            LastName = "DAĞDELEN"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "System User",
                            CreatedOn = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4513),
                            FirstName = "İBRAHİM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4515),
                            LastName = "AKIŞIK"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "System User",
                            CreatedOn = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4516),
                            FirstName = "GİZEM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 9, 28, 14, 32, 22, 17, DateTimeKind.Local).AddTicks(4517),
                            LastName = "KURTCUOĞLU"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
