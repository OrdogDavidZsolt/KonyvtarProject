﻿// <auto-generated />
using System;
using KonyvtarAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KonyvtarAPI.Migrations
{
    [DbContext(typeof(KonyvtarDBContext))]
    [Migration("20250415154140_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("KonyvtarAPI.Kolcsonzes", b =>
                {
                    b.Property<int>("OlvasoSzam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KolcsonzesIdeje")
                        .HasColumnType("TEXT");

                    b.Property<int>("LeltariSzam")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VisszahozasHatarido")
                        .HasColumnType("TEXT");

                    b.HasKey("OlvasoSzam");

                    b.ToTable("Kolcsonzesek");
                });

            modelBuilder.Entity("KonyvtarAPI.Konyvek", b =>
                {
                    b.Property<int>("LeltariSzam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KiadasEve")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kiado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Szerzo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LeltariSzam");

                    b.ToTable("Konyvek");
                });

            modelBuilder.Entity("KonyvtarAPI.Olvasok", b =>
                {
                    b.Property<int>("OlvasoSzam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lakcim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OlvasoNev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SzuletesiDatum")
                        .HasColumnType("TEXT");

                    b.HasKey("OlvasoSzam");

                    b.ToTable("Olvasok");
                });
#pragma warning restore 612, 618
        }
    }
}
