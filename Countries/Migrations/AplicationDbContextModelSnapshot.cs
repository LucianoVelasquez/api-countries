﻿// <auto-generated />
using Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Countries.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Countries.Entidades.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dificultad")
                        .HasColumnType("int");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<string>("Temporada")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Countries.Entidades.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Capitals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Continents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<string>("SubRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
