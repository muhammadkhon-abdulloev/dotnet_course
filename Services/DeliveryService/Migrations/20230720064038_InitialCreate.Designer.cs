﻿// <auto-generated />
using System;
using Delivery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Delivery.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230720064038_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Delivery.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("CargoWeight")
                        .HasColumnType("numeric")
                        .HasColumnName("cargo_weight");

                    b.Property<DateOnly>("PickupDate")
                        .HasColumnType("date")
                        .HasColumnName("pickup_date");

                    b.Property<string>("ReceiverAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("receiver_address");

                    b.Property<string>("ReceiverCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("receiver_city");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_address");

                    b.Property<string>("SenderCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_city");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("OrderIdIndex");

                    b.ToTable("order");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargoWeight = 1.3500000000000001,
                            PickupDate = new DateOnly(2023, 7, 23),
                            ReceiverAddress = "Malaya Ordynka, 9",
                            ReceiverCity = "Moscow",
                            SenderAddress = "Raheem Jalil, 12",
                            SenderCity = "Khujand"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
