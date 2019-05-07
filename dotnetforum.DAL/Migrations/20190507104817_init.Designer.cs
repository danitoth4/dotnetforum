﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnetforum.DAL;

namespace dotnetforum.DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190507104817_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dotnetforum.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int>("ReviewId");

                    b.Property<int?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("dotnetforum.DAL.Entities.Creation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Creation");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Creation");
                });

            modelBuilder.Entity("dotnetforum.DAL.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int>("CreationId");

                    b.Property<int>("Rating");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("WritenAt");

                    b.HasKey("Id");

                    b.HasIndex("CreationId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("dotnetforum.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("dotnetforum.DAL.Entities.Book", b =>
                {
                    b.HasBaseType("dotnetforum.DAL.Entities.Creation");

                    b.Property<string>("Author");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("dotnetforum.DAL.Entities.Movie", b =>
                {
                    b.HasBaseType("dotnetforum.DAL.Entities.Creation");

                    b.Property<string>("Director");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("dotnetforum.DAL.Entities.Comment", b =>
                {
                    b.HasOne("dotnetforum.DAL.Entities.Review", "Review")
                        .WithMany("Comments")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dotnetforum.DAL.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("dotnetforum.DAL.Entities.Review", b =>
                {
                    b.HasOne("dotnetforum.DAL.Entities.Creation", "Creation")
                        .WithMany("Reviews")
                        .HasForeignKey("CreationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dotnetforum.DAL.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
