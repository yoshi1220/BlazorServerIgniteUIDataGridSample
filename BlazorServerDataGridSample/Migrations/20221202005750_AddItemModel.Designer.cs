﻿// <auto-generated />
using BlazorServerDataGridSample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServerDataGridSample.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20221202005750_AddItemModel")]
    partial class AddItemModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorServerDataGridSample.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Items", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemCode = "S001",
                            ItemName = "商品1",
                            UnitPrice = 330m
                        });
                });

            modelBuilder.Entity("BlazorServerDataGridSample.Data.Models.SalesDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("SalesTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SlipNumber")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("SalesDetails", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 990m,
                            ItemCode = "S001",
                            ItemName = "商品1",
                            Quantity = 3m,
                            RowNumber = 1,
                            SalesTax = 99m,
                            SlipNumber = 10001,
                            UnitPrice = 330m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
