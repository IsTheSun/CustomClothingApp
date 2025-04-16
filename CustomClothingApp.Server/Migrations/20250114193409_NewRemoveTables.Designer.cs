﻿// <auto-generated />
using System;
using CustomClothingApp.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomClothingApp.Server.Migrations
{
    [DbContext(typeof(CustomClothingDbContext))]
    [Migration("20250114193409_NewRemoveTables")]
    partial class NewRemoveTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CustomClothingApp.Server.Models.Clothingmodel", b =>
                {
                    b.Property<int>("Modelid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("modelid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Modelid"));

                    b.Property<decimal?>("Baseprice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("baseprice");

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Createddate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createddate")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Modeldescription")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("modeldescription");

                    b.Property<string>("Modelname")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("modelname");

                    b.HasKey("Modelid")
                        .HasName("clothingmodels_pkey");

                    b.ToTable("clothingmodels", (string)null);
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.Measurement", b =>
                {
                    b.Property<int>("Measurementsid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("measurementsid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Measurementsid"));

                    b.Property<decimal?>("Chest")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("chest");

                    b.Property<DateTime?>("Createddate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createddate")
                        .HasDefaultValueSql("now()");

                    b.Property<decimal?>("Height")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("height");

                    b.Property<decimal?>("Hip")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("hip");

                    b.Property<string>("Othermeasurements")
                        .HasColumnType("text")
                        .HasColumnName("othermeasurements");

                    b.Property<int?>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.Property<decimal?>("Waist")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("waist");

                    b.HasKey("Measurementsid")
                        .HasName("measurements_pkey");

                    b.HasIndex("Userid");

                    b.ToTable("measurements", (string)null);
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.Order", b =>
                {
                    b.Property<int>("Orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("orderid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Orderid"));

                    b.Property<DateTime?>("Createddate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createddate")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Currentstage")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("currentstage");

                    b.Property<string>("Escrowstatus")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("escrowstatus")
                        .HasDefaultValueSql("'Reserved'::character varying");

                    b.Property<int?>("Measurementsid")
                        .HasColumnType("integer")
                        .HasColumnName("measurementsid");

                    b.Property<int?>("Modelid")
                        .HasColumnType("integer")
                        .HasColumnName("modelid");

                    b.Property<string>("Stagedescription")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("stagedescription");

                    b.Property<int?>("Statusid")
                        .HasColumnType("integer")
                        .HasColumnName("statusid");

                    b.Property<DateTime?>("Updateddate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updateddate");

                    b.Property<int?>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Orderid")
                        .HasName("orders_pkey");

                    b.HasIndex("Measurementsid");

                    b.HasIndex("Modelid");

                    b.HasIndex("Userid");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Userid"));

                    b.Property<DateTime?>("Createddate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createddate")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("username");

                    b.Property<string>("Userrole")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("userrole");

                    b.HasKey("Userid")
                        .HasName("users_pkey");

                    b.HasIndex(new[] { "Email" }, "users_email_key")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.Measurement", b =>
                {
                    b.HasOne("CustomClothingApp.Server.Models.User", "User")
                        .WithMany("Measurements")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_user_measurements");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.Order", b =>
                {
                    b.HasOne("CustomClothingApp.Server.Models.Measurement", "Measurements")
                        .WithMany("Orders")
                        .HasForeignKey("Measurementsid")
                        .HasConstraintName("fk_measurements_orders");

                    b.HasOne("CustomClothingApp.Server.Models.Clothingmodel", "Model")
                        .WithMany("Orders")
                        .HasForeignKey("Modelid")
                        .HasConstraintName("fk_model_orders");

                    b.HasOne("CustomClothingApp.Server.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_user_orders");

                    b.Navigation("Measurements");

                    b.Navigation("Model");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.Clothingmodel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.Measurement", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CustomClothingApp.Server.Models.User", b =>
                {
                    b.Navigation("Measurements");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
