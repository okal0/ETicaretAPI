﻿// <auto-generated />
using System;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    [DbContext(typeof(ETicaretAPIDbContext))]
    [Migration("20241105115416_mig_2")]
    partial class mig_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("orderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("orderId");

                    b.ToTable("Baskets_k");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.BasketItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers_k");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files_k");

                    b.HasDiscriminator<string>("Discriminator").HasValue("File");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders_k");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products_k");
                });

            modelBuilder.Entity("ProductProductImageFile", b =>
                {
                    b.Property<Guid>("ProductImageFilesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductImageFilesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("ProductProductImageFile");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.ProductImageFile", b =>
                {
                    b.HasBaseType("ETicaretAPI.Domain.Entities.File");

                    b.Property<bool>("Showcase")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("ProductImageFile");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Basket", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.Order", "order")
                        .WithMany()
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.BasketItem", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.Domain.Entities.Product", "Product")
                        .WithMany("BasketItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Order", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Product", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("ProductProductImageFile", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.ProductImageFile", null)
                        .WithMany()
                        .HasForeignKey("ProductImageFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Product", b =>
                {
                    b.Navigation("BasketItems");
                });
#pragma warning restore 612, 618
        }
    }
}
