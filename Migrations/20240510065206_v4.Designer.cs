﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace kt_web_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240510065206_v4")]
    partial class v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.ProductDetail", b =>
                {
                    b.Property<int>("ProductDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailId"));

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasMaxLength(53)
                        .HasColumnType("real");

                    b.Property<string>("ProductDetailName")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("ShellPrice")
                        .HasMaxLength(53)
                        .HasColumnType("real");

                    b.HasKey("ProductDetailId");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("Models.ProductDetailPropertyDetail", b =>
                {
                    b.Property<int>("ProductDetailPropertyDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailPropertyDetailId"));

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyDetailId")
                        .HasColumnType("int");

                    b.HasKey("ProductDetailPropertyDetailId");

                    b.HasIndex("ProductDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyDetailId");

                    b.ToTable("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("Models.Propertie", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("PropertySort")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Models.PropertyDetail", b =>
                {
                    b.Property<int>("PropertyDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyDetailId"));

                    b.Property<int?>("PropertiePropertyId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyDetailCode")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("PropertyDetailDetail")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("PropertyDetailId");

                    b.HasIndex("PropertiePropertyId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("Models.ProductDetail", b =>
                {
                    b.HasOne("Models.ProductDetail", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Models.ProductDetailPropertyDetail", b =>
                {
                    b.HasOne("Models.ProductDetail", "ProductDetail")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Product", "Product")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.PropertyDetail", "PropertyDetail")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("PropertyDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductDetail");

                    b.Navigation("PropertyDetail");
                });

            modelBuilder.Entity("Models.Propertie", b =>
                {
                    b.HasOne("Models.Product", "Product")
                        .WithMany("Properties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Models.PropertyDetail", b =>
                {
                    b.HasOne("Models.Propertie", "Propertie")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("PropertiePropertyId");

                    b.Navigation("Propertie");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Models.ProductDetail", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("Models.Propertie", b =>
                {
                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("Models.PropertyDetail", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
