﻿// <auto-generated />
using System;
using ASPDotNetExam.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASPDotNetExam.Migrations
{
    [DbContext(typeof(userContext))]
    partial class userContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0-preview1.19506.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ASPDotNetExam.DataBase.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("ItemDateID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("PriceID")
                        .HasColumnType("int");

                    b.Property<int?>("PromoID")
                        .HasColumnType("int");

                    b.Property<int?>("StockID")
                        .HasColumnType("int");

                    b.Property<int?>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ItemDateID");

                    b.HasIndex("PriceID");

                    b.HasIndex("PromoID");

                    b.HasIndex("StockID");

                    b.HasIndex("TypeID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.ItemDate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ProduceDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("ItemDates");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.Itemtype", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("Itemtypes");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.Price", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.Promo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Promos");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.Stock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Token")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.UserItem", b =>
                {
                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ItemID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserItems");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.Item", b =>
                {
                    b.HasOne("ASPDotNetExam.DataBase.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("ASPDotNetExam.DataBase.ItemDate", "ItemDate")
                        .WithMany()
                        .HasForeignKey("ItemDateID");

                    b.HasOne("ASPDotNetExam.DataBase.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceID");

                    b.HasOne("ASPDotNetExam.DataBase.Promo", "Promo")
                        .WithMany()
                        .HasForeignKey("PromoID");

                    b.HasOne("ASPDotNetExam.DataBase.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID");

                    b.HasOne("ASPDotNetExam.DataBase.Itemtype", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID");
                });

            modelBuilder.Entity("ASPDotNetExam.DataBase.UserItem", b =>
                {
                    b.HasOne("ASPDotNetExam.DataBase.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPDotNetExam.DataBase.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
