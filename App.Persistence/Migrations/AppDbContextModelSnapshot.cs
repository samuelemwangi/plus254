﻿// <auto-generated />
using System;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("App.Domain.Entities.Category", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<short>("Deleted");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LastEditedBy");

                    b.Property<DateTime?>("LastEditedDate");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("App.Domain.Entities.Notification", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<short>("Deleted");

                    b.Property<string>("From")
                        .IsRequired();

                    b.Property<string>("LastEditedBy");

                    b.Property<DateTime?>("LastEditedDate");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("To")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("App.Domain.Entities.Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CategoryID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<short>("Deleted");

                    b.Property<bool>("Discontinued");

                    b.Property<string>("LastEditedBy");

                    b.Property<DateTime?>("LastEditedDate");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("QuantityPerUnit")
                        .HasMaxLength(20);

                    b.Property<short>("ReorderLevel")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((short)0);

                    b.Property<decimal>("UnitPrice")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0m);

                    b.Property<short>("UnitsInStock")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((short)0);

                    b.Property<short>("UnitsOnOrder")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((short)0);

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("App.Domain.Entities.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<short>("Deleted");

                    b.Property<string>("LastEditedBy");

                    b.Property<DateTime?>("LastEditedDate");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.Domain.Entities.Product", b =>
                {
                    b.HasOne("App.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .HasConstraintName("FK_Product_Categories");
                });

            modelBuilder.Entity("App.Domain.Entities.User", b =>
                {
                    b.OwnsOne("App.Domain.ValueObjects.UniqueUserCode", "UniqueUserCode", b1 =>
                        {
                            b1.Property<long>("UserID");

                            b1.Property<string>("Domain");

                            b1.Property<string>("UserName");

                            b1.HasKey("UserID");

                            b1.ToTable("Users");

                            b1.HasOne("App.Domain.Entities.User")
                                .WithOne("UniqueUserCode")
                                .HasForeignKey("App.Domain.ValueObjects.UniqueUserCode", "UserID")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
