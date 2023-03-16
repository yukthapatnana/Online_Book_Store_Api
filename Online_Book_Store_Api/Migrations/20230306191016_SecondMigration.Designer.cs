﻿// <auto-generated />
using System;
using Book_Store_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Online_Book_Store_Api.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230306191016_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Book_Store_Api.Models.Book", b =>
                {
                    b.Property<int>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookCategoryCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN");

                    b.HasIndex("BookCategoryCategoryId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Book_Store_Api.Models.BookCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Login", b =>
                {
                    b.Property<int>("Log_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegistrationId")
                        .HasColumnType("int");

                    b.HasKey("Log_Id");

                    b.HasIndex("RegistrationId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Book_Store_Api.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BooksISBN")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RegistrationId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("BooksISBN");

                    b.HasIndex("RegistrationId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("OrderDetailOrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderDetailOrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("RegistrationId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Book", b =>
                {
                    b.HasOne("Book_Store_Api.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("BookCategoryCategoryId");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Login", b =>
                {
                    b.HasOne("Book_Store_Api.Models.Registration", "Registration")
                        .WithMany("Logins")
                        .HasForeignKey("RegistrationId");

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("Book_Store_Api.Models.OrderDetail", b =>
                {
                    b.HasOne("Book_Store_Api.Models.Book", "Books")
                        .WithMany("OrderDetails")
                        .HasForeignKey("BooksISBN");

                    b.HasOne("Book_Store_Api.Models.Registration", "Registration")
                        .WithMany("OrderDetails")
                        .HasForeignKey("RegistrationId");

                    b.Navigation("Books");

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Payment", b =>
                {
                    b.HasOne("Book_Store_Api.Models.OrderDetail", "OrderDetail")
                        .WithMany("Payments")
                        .HasForeignKey("OrderDetailOrderId");

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Book", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Book_Store_Api.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Book_Store_Api.Models.OrderDetail", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Book_Store_Api.Models.Registration", b =>
                {
                    b.Navigation("Logins");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
