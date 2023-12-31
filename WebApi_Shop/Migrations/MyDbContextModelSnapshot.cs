﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_Shop.Data;

namespace WebApi_Shop.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi_Shop.Data.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Bithday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Usename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryOfOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ShopId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShipperId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipperMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("ShipperId");

                    b.HasIndex("ShipperMethodId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApi_Shop.Data.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PriceCurrent")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("orderDetail");
                });

            modelBuilder.Entity("WebApi_Shop.Data.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Shipper", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Bithday")
                        .HasColumnType("datetime2");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ShipperImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipperName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("WebApi_Shop.Data.ShipperMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ShipperPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ShipperMethod");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ShopLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Item", b =>
                {
                    b.HasOne("WebApi_Shop.Data.Category", "category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Shop.Data.Shop", "shop")
                        .WithMany("Items")
                        .HasForeignKey("ShopId")
                        .HasConstraintName("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("shop");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Order", b =>
                {
                    b.HasOne("WebApi_Shop.Data.Customer", "Customer")
                        .WithMany("orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Shop.Data.PaymentMethod", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodId")
                        .HasConstraintName("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Shop.Data.Shipper", "Shipper")
                        .WithMany("Orders")
                        .HasForeignKey("ShipperId")
                        .HasConstraintName("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Shop.Data.ShipperMethod", "ShipperMethod")
                        .WithMany("Orders")
                        .HasForeignKey("ShipperMethodId")
                        .HasConstraintName("ShipperMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Shipper");

                    b.Navigation("ShipperMethod");
                });

            modelBuilder.Entity("WebApi_Shop.Data.OrderDetail", b =>
                {
                    b.HasOne("WebApi_Shop.Data.Item", "item")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Shop.Data.Order", "order")
                        .WithMany("oderdetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("order");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Customer", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Item", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Order", b =>
                {
                    b.Navigation("oderdetails");
                });

            modelBuilder.Entity("WebApi_Shop.Data.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Shipper", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebApi_Shop.Data.ShipperMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebApi_Shop.Data.Shop", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
