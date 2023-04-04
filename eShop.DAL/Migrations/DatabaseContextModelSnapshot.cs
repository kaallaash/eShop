﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShop.DAL.Context;

#nullable disable

namespace eShop.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eShop.DAL.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eShop.DAL.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Count = 10,
                            DateCreated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 3, 0, 0, 0)),
                            DateUpdated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "Electric drill =)",
                            Name = "Drill",
                            Price = 49.99m
                        },
                        new
                        {
                            Id = -2,
                            Count = 25,
                            DateCreated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5754), new TimeSpan(0, 3, 0, 0, 0)),
                            DateUpdated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5754), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "The hammer like my grandfather's",
                            Name = "Hammer",
                            Price = 19.99m
                        },
                        new
                        {
                            Id = -3,
                            Count = 1000,
                            DateCreated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 3, 0, 0, 0)),
                            DateUpdated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5757), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "Not aluminum",
                            Name = "Nails",
                            Price = 5.99m
                        });
                });

            modelBuilder.Entity("eShop.DAL.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            DateCreated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 3, 0, 0, 0)),
                            DateUpdated = new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 3, 0, 0, 0)),
                            Email = "adminEmail@eShop.com",
                            Password = "admin",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = 0,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("eShop.DAL.Entities.OrderEntity", b =>
                {
                    b.HasOne("eShop.DAL.Entities.ProductEntity", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.DAL.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eShop.DAL.Entities.ProductEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("eShop.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
