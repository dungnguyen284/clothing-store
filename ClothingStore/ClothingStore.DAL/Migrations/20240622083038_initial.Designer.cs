﻿// <auto-generated />
using System;
using ClothingStore.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClothingStore.DAL.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240622083038_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClothingStore.DAL.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "realvietdung@gmail.com",
                            Password = "admin",
                            PhoneNumber = "0388188526",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bill", (string)null);
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.BillDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("BillDetail", (string)null);
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Áo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Quần"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Giày"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Phụ kiện"
                        });
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("SavePoints")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Áo thun nam",
                            Image = "",
                            IsDeleted = false,
                            Name = "Áo thun nam",
                            Price = 100000.0,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Áo thun nữ",
                            Image = "",
                            IsDeleted = false,
                            Name = "Áo thun nữ",
                            Price = 90000.0,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Quần jean nam",
                            Image = "",
                            IsDeleted = false,
                            Name = "Quần jean nam",
                            Price = 200000.0,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Quần jean nữ",
                            Image = "",
                            IsDeleted = false,
                            Name = "Quần jean nữ",
                            Price = 180000.0,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Giày thể thao nam",
                            Image = "",
                            IsDeleted = false,
                            Name = "Giày thể thao nam",
                            Price = 300000.0,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Giày thể thao nữ",
                            Image = "",
                            IsDeleted = false,
                            Name = "Giày thể thao nữ",
                            Price = 280000.0,
                            Quantity = 100
                        });
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.Bill", b =>
                {
                    b.HasOne("ClothingStore.DAL.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.BillDetail", b =>
                {
                    b.HasOne("ClothingStore.DAL.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingStore.DAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.Product", b =>
                {
                    b.HasOne("ClothingStore.DAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ClothingStore.DAL.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
