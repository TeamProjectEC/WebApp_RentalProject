﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBase.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201205131829_new_model")]
    partial class new_model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataBase.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Birthday")
                        .HasColumnType("int");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DataBase.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("DataBase.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Rent_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MovieId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("DataBase.Rental", b =>
                {
                    b.HasOne("DataBase.Customer", "Customer")
                        .WithMany("Rental")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DataBase.Movie", "Movie")
                        .WithMany("Rental")
                        .HasForeignKey("MovieId");

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("DataBase.Customer", b =>
                {
                    b.Navigation("Rental");
                });

            modelBuilder.Entity("DataBase.Movie", b =>
                {
                    b.Navigation("Rental");
                });
#pragma warning restore 612, 618
        }
    }
}