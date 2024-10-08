﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoApiRendaFixa.Infrastructure.Database;

#nullable disable

namespace ProjetoApiRendaFixa.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ProjetoApiRendaFixa.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ProjetoApiRendaFixa.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BondAsset")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IssuerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Tax")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProjetoApiRendaFixa.Models.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ProductId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("ProjetoApiRendaFixa.Models.Purchase", b =>
                {
                    b.HasOne("ProjetoApiRendaFixa.Models.Account", "Account")
                        .WithMany("Purchases")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoApiRendaFixa.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjetoApiRendaFixa.Models.Account", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
