﻿// <auto-generated />
using GraphQl_Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQl_Demo.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraphQl_Demo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Appetizer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Main"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Burger"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Pasta"
                        });
                });

            modelBuilder.Entity("GraphQl_Demo.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            Description = "A juicy chicken burger with lettuce and cheese",
                            Name = "Classic Burger",
                            Price = 8.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 5,
                            Description = "Tomato, mozzarella, and basil pizza",
                            Name = "Margherita Pizza",
                            Price = 10.5
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Fresh garden salad with grilled chicken",
                            Name = "Grilled Chicken Salad",
                            Price = 7.9500000000000002
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 6,
                            Description = "Creamy Alfredo sauce with fettuccine pasta",
                            Name = "Pasta Alfredo",
                            Price = 12.75
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Warm chocolate brownie with ice cream and fudge",
                            Name = "Chocolate Brownie Sundae",
                            Price = 6.9900000000000002
                        });
                });

            modelBuilder.Entity("GraphQl_Demo.Models.Menu", b =>
                {
                    b.HasOne("GraphQl_Demo.Models.Category", "Category")
                        .WithMany("Menus")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GraphQl_Demo.Models.Category", b =>
                {
                    b.Navigation("Menus");
                });
#pragma warning restore 612, 618
        }
    }
}
