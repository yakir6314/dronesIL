﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dronesIL.Data;

namespace dronesIL.Migrations
{
    [DbContext(typeof(dronesILContext))]
    [Migration("20210612163854_changDroneIdName")]
    partial class changDroneIdName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dronesIL.Models.Drone", b =>
                {
                    b.Property<int>("droneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("droneId");

                    b.ToTable("Drone");
                });

            modelBuilder.Entity("dronesIL.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("orderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("orderStatus")
                        .HasColumnType("int");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("streetNum")
                        .HasColumnType("int");

                    b.Property<decimal>("sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("dronesIL.Models.user", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("dronesIL.Models.Order", b =>
                {
                    b.HasOne("dronesIL.Models.user", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });
#pragma warning restore 612, 618
        }
    }
}
