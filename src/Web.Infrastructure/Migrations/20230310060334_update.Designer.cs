// <auto-generated />
using System;
using AppMVC.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppMVC.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230310060334_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppMVC.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 74.090000000000003,
                            Quantity = 55,
                            Title = "HDD 1TB",
                            TotalPrice = 4889.9400000000005
                        },
                        new
                        {
                            Id = 2,
                            Price = 190.99000000000001,
                            Quantity = 102,
                            Title = "HDD SSD 512GB",
                            TotalPrice = 23377.175999999999
                        },
                        new
                        {
                            Id = 3,
                            Price = 80.319999999999993,
                            Quantity = 47,
                            Title = "RAM DDR4 16GB",
                            TotalPrice = 4530.0479999999989
                        });
                });

            modelBuilder.Entity("AppMVC.Domain.Entities.ProductAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductAudits");
                });

            modelBuilder.Entity("AppMVC.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "admin1",
                            Salt = "ef300c2c-72d3-4b95-af2f-42de72402807",
                            UserName = "admin",
                            UserRole = 0
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "user1",
                            Salt = "38cba94a-f7ed-42ba-a63f-ebde75001a65",
                            UserName = "user",
                            UserRole = 1
                        });
                });

            modelBuilder.Entity("AppMVC.Domain.Entities.ProductAudit", b =>
                {
                    b.HasOne("AppMVC.Domain.Entities.Product", "Product")
                        .WithMany("ProductAudits")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppMVC.Domain.Entities.User", "User")
                        .WithMany("ProductAudits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppMVC.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductAudits");
                });

            modelBuilder.Entity("AppMVC.Domain.Entities.User", b =>
                {
                    b.Navigation("ProductAudits");
                });
#pragma warning restore 612, 618
        }
    }
}
