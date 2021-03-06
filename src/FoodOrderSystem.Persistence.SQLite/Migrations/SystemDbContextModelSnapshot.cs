﻿// <auto-generated />
using System;
using FoodOrderSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodOrderSystem.Persistence.SQLite.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    partial class SystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("FoodOrderSystem.Persistence.CuisineRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cuisine");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DeliveryTimeRow", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndTime")
                        .HasColumnType("INTEGER");

                    b.HasKey("RestaurantId", "DayOfWeek", "StartTime");

                    b.ToTable("DeliveryTime");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishCategoryRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("DishCategory");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductInfo")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishVariantExtraRow", b =>
                {
                    b.Property<Guid>("DishId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VariantId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExtraId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("ProductInfo")
                        .HasColumnType("TEXT");

                    b.HasKey("DishId", "VariantId", "ExtraId");

                    b.ToTable("DishVariantExtra");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishVariantRow", b =>
                {
                    b.Property<Guid>("DishId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VariantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("DishId", "VariantId");

                    b.ToTable("DishVariant");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.PaymentMethodRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.RestaurantCuisineRow", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CuisineId")
                        .HasColumnType("TEXT");

                    b.HasKey("RestaurantId", "CuisineId");

                    b.HasIndex("CuisineId");

                    b.ToTable("RestaurantCuisine");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.RestaurantPaymentMethodRow", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("TEXT");

                    b.HasKey("RestaurantId", "PaymentMethodId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("RestaurantPaymentMethod");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.RestaurantRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressStreet")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressZipCode")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DeliveryCosts")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("Imprint")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MinimumOrderValue")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderEmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.RestaurantUserRow", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("RestaurantId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RestaurantUser");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.UserRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DeliveryTimeRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.RestaurantRow", "Restaurant")
                        .WithMany("DeliveryTimes")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishCategoryRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.RestaurantRow", "Restaurant")
                        .WithMany("Categories")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.DishCategoryRow", "Category")
                        .WithMany("Dishes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderSystem.Persistence.RestaurantRow", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishVariantExtraRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.DishRow", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderSystem.Persistence.DishVariantRow", "Variant")
                        .WithMany("Extras")
                        .HasForeignKey("DishId", "VariantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.DishVariantRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.DishRow", "Dish")
                        .WithMany("Variants")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.RestaurantCuisineRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.CuisineRow", "Cuisine")
                        .WithMany("RestaurantCuisines")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderSystem.Persistence.RestaurantRow", "Restaurant")
                        .WithMany("RestaurantCuisines")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.RestaurantPaymentMethodRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.PaymentMethodRow", "PaymentMethod")
                        .WithMany("RestaurantPaymentMethods")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderSystem.Persistence.RestaurantRow", "Restaurant")
                        .WithMany("RestaurantPaymentMethods")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystem.Persistence.RestaurantUserRow", b =>
                {
                    b.HasOne("FoodOrderSystem.Persistence.RestaurantRow", "Restaurant")
                        .WithMany("RestaurantUsers")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderSystem.Persistence.UserRow", "User")
                        .WithMany("RestaurantUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
