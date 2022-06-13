﻿// <auto-generated />
using AllergyMatchMaker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllergyMatchMaker.Migrations
{
    [DbContext(typeof(AllergyInfoContext))]
    [Migration("20220613172012_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AllergyMatchMaker.Models.AllergyInfo", b =>
                {
                    b.Property<int>("AllergyInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Allergy")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Memo")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<string>("Zodiac")
                        .HasColumnType("longtext");

                    b.HasKey("AllergyInfoId");

                    b.ToTable("AllergyInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
