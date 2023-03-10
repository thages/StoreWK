// <auto-generated />
using System;
using Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.CategoryAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("_createdAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("_description")
                        .HasColumnType("longtext")
                        .HasColumnName("Description");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Catalog.Domain.AggregatesModel.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("_categoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<DateTime>("_createdAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("_description")
                        .HasColumnType("longtext")
                        .HasColumnName("Description");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.Property<decimal>("_price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
