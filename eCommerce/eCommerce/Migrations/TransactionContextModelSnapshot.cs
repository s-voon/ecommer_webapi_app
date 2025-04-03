﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerce.DbContexts;

#nullable disable

namespace eCommerce.Migrations
{
    [DbContext(typeof(TransactionContext))]
    partial class TransactionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eCommerce.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerEmail = "john@example.com",
                            CustomerName = "John Doe"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerEmail = "jane@example.com",
                            CustomerName = "Jane Smith"
                        });
                });

            modelBuilder.Entity("eCommerce.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceId = 1,
                            CustomerId = 1,
                            InvoiceStatus = "Paid",
                            TotalAmount = 100.5
                        },
                        new
                        {
                            InvoiceId = 2,
                            CustomerId = 2,
                            InvoiceStatus = "Pending",
                            TotalAmount = 200.75
                        });
                });

            modelBuilder.Entity("eCommerce.Entities.InvoiceDetail", b =>
                {
                    b.Property<int>("InvoiceDetailId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InvoiceDetailId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceDetails");

                    b.HasData(
                        new
                        {
                            InvoiceDetailId = 1,
                            InvoiceId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            InvoiceDetailId = 2,
                            InvoiceId = 1,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            InvoiceDetailId = 3,
                            InvoiceId = 2,
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            InvoiceDetailId = 4,
                            InvoiceId = 2,
                            ProductId = 4,
                            Quantity = 3
                        });
                });

            modelBuilder.Entity("eCommerce.Entities.Product", b =>
                {
                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            productId = 1,
                            price = 12.0,
                            productDescription = "Pink cup",
                            productName = "Cup"
                        },
                        new
                        {
                            productId = 2,
                            price = 25.989999999999998,
                            productDescription = "Snoppy Tumbler",
                            productName = "Tumbler"
                        });
                });

            modelBuilder.Entity("eCommerce.Entities.InvoiceDetail", b =>
                {
                    b.HasOne("eCommerce.Entities.Invoice", null)
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eCommerce.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
