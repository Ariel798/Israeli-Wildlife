// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WildlifeProject.Repository;

#nullable disable

namespace WildlifeProject.Migrations
{
    [DbContext(typeof(AdminContext))]
    [Migration("20220814150450_Stam2")]
    partial class Stam2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("WildlifeProject.Model.AdminUser", b =>
                {
                    b.Property<int>("UserKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("UserKey");

                    b.ToTable("AdminUsers");

                    b.HasData(
                        new
                        {
                            UserKey = 1,
                            Password = "ArielJoseph111",
                            UserName = "ArielJoseph111"
                        });
                });

            modelBuilder.Entity("WildlifeProject.Model.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConservationStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureName")
                        .HasColumnType("TEXT");

                    b.HasKey("AnimalId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            CategoryId = 1,
                            ConservationStatus = "Extinct in the wild",
                            Description = "~/Information/honey-badger.txt",
                            Name = "Honey Badger",
                            PictureName = "~/Images/honey-bagder.jpg"
                        });
                });

            modelBuilder.Entity("WildlifeProject.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Mammels"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Birds"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Reptilians"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Amphibian"
                        });
                });

            modelBuilder.Entity("WildlifeProject.Model.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentText")
                        .HasColumnType("TEXT");

                    b.HasKey("CommentId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            AnimalId = 1,
                            CommentText = "beautifull!"
                        });
                });

            modelBuilder.Entity("WildlifeProject.Model.Animal", b =>
                {
                    b.HasOne("WildlifeProject.Model.Category", "Category")
                        .WithMany("Animals")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WildlifeProject.Model.Comment", b =>
                {
                    b.HasOne("WildlifeProject.Model.Animal", "Animal")
                        .WithMany("Comments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("WildlifeProject.Model.Animal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("WildlifeProject.Model.Category", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
