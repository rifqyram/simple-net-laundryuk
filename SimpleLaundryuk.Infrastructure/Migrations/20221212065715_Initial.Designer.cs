﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SimpleLaundryuk.Infrastructure.Repositories;

#nullable disable

namespace SimpleLaundryuk.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221212065715_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("trans_date");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("customer_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("customer_id");

                    b.ToTable("t_bill");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("Weight")
                        .HasColumnType("integer")
                        .HasColumnName("weight");

                    b.Property<Guid>("bill_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("product_price_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("bill_id");

                    b.HasIndex("product_price_id");

                    b.ToTable("t_bill_detail");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mobile_phone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("m_customer");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("m_product");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.ProductPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("product_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.ToTable("m_product_price");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.Bill", b =>
                {
                    b.HasOne("SimpleLaundryuk.Entity.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.BillDetail", b =>
                {
                    b.HasOne("SimpleLaundryuk.Entity.Entities.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("bill_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleLaundryuk.Entity.Entities.ProductPrice", "ProductPrice")
                        .WithMany()
                        .HasForeignKey("product_price_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("ProductPrice");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.ProductPrice", b =>
                {
                    b.HasOne("SimpleLaundryuk.Entity.Entities.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("SimpleLaundryuk.Entity.Entities.Product", b =>
                {
                    b.Navigation("ProductPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
