﻿// <auto-generated />
using System;
using LibraryDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryDataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220730105626_KitapDetayIdNullableOlsun")]
    partial class KitapDetayIdNullableOlsun
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryModel.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KategoriAd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("LibraryModel.Models.Kitap", b =>
                {
                    b.Property<int>("KitapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("KitapAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KitapDetayId")
                        .HasColumnType("int");

                    b.Property<int>("YayinEviId")
                        .HasColumnType("int");

                    b.HasKey("KitapId");

                    b.HasIndex("KitapDetayId")
                        .IsUnique()
                        .HasFilter("[KitapDetayId] IS NOT NULL");

                    b.HasIndex("YayinEviId");

                    b.ToTable("Kitap");
                });

            modelBuilder.Entity("LibraryModel.Models.KitapDetayi", b =>
                {
                    b.Property<int>("KitapDetayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BolumSayisi")
                        .HasColumnType("int");

                    b.Property<int>("KitapSayfaSayisi")
                        .HasColumnType("int");

                    b.Property<double>("agirlik")
                        .HasColumnType("float");

                    b.HasKey("KitapDetayId");

                    b.ToTable("KitapDetaylari");
                });

            modelBuilder.Entity("LibraryModel.Models.KitapYazar", b =>
                {
                    b.Property<int>("YazarId")
                        .HasColumnType("int");

                    b.Property<int>("KitapId")
                        .HasColumnType("int");

                    b.HasKey("YazarId", "KitapId");

                    b.HasIndex("KitapId");

                    b.ToTable("KitapYazarlar");
                });

            modelBuilder.Entity("LibraryModel.Models.Tur", b =>
                {
                    b.Property<int>("TurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TurAd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurId");

                    b.ToTable("Turler");
                });

            modelBuilder.Entity("LibraryModel.Models.YayinEvi", b =>
                {
                    b.Property<int>("YayinEviId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BasimYeri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YayinEviAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YayinEviId");

                    b.ToTable("YayinEvi");
                });

            modelBuilder.Entity("LibraryModel.Models.Yazar", b =>
                {
                    b.Property<int>("YazarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lokasyon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YazarAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YazarSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dogumTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("YazarId");

                    b.ToTable("Yazar");
                });

            modelBuilder.Entity("LibraryModel.Models.Kitap", b =>
                {
                    b.HasOne("LibraryModel.Models.KitapDetayi", "KitapDetayi")
                        .WithOne("Kitap")
                        .HasForeignKey("LibraryModel.Models.Kitap", "KitapDetayId");

                    b.HasOne("LibraryModel.Models.YayinEvi", "YayinEvleri")
                        .WithMany("Kitap")
                        .HasForeignKey("YayinEviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KitapDetayi");

                    b.Navigation("YayinEvleri");
                });

            modelBuilder.Entity("LibraryModel.Models.KitapYazar", b =>
                {
                    b.HasOne("LibraryModel.Models.Kitap", "Kitap")
                        .WithMany("KitapYazarlar")
                        .HasForeignKey("KitapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryModel.Models.Yazar", "Yazar")
                        .WithMany("KitapYazarlar")
                        .HasForeignKey("YazarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kitap");

                    b.Navigation("Yazar");
                });

            modelBuilder.Entity("LibraryModel.Models.Kitap", b =>
                {
                    b.Navigation("KitapYazarlar");
                });

            modelBuilder.Entity("LibraryModel.Models.KitapDetayi", b =>
                {
                    b.Navigation("Kitap");
                });

            modelBuilder.Entity("LibraryModel.Models.YayinEvi", b =>
                {
                    b.Navigation("Kitap");
                });

            modelBuilder.Entity("LibraryModel.Models.Yazar", b =>
                {
                    b.Navigation("KitapYazarlar");
                });
#pragma warning restore 612, 618
        }
    }
}
