﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phramd.Models;

namespace Phramd.Migrations
{
    [DbContext(typeof(PhramdContext))]
    [Migration("20190307140152_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Phramd.Models.CalendarModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.Property<string>("apple")
                        .HasMaxLength(100);

                    b.Property<DateTime>("emailadded");

                    b.Property<DateTime>("emailremoved");

                    b.Property<string>("gmail")
                        .HasMaxLength(100);

                    b.Property<string>("microsoft")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("CalendarModel");
                });

            modelBuilder.Entity("Phramd.Models.DTFormatsDB", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date");

                    b.Property<string>("Day");

                    b.Property<string>("Hour");

                    b.Property<string>("Minute");

                    b.Property<string>("Month");

                    b.Property<string>("Seconds");

                    b.Property<string>("Time");

                    b.Property<int>("UserID");

                    b.Property<string>("Year");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("DTFormatsDB");
                });

            modelBuilder.Entity("Phramd.Models.Layout", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.Property<decimal>("calH");

                    b.Property<decimal>("calW");

                    b.Property<decimal>("calX");

                    b.Property<decimal>("calY");

                    b.Property<decimal>("dateH");

                    b.Property<decimal>("dateW");

                    b.Property<decimal>("dateX");

                    b.Property<decimal>("dateY");

                    b.Property<DateTime>("layoutadded");

                    b.Property<DateTime>("layoutremoved");

                    b.Property<decimal>("newsH");

                    b.Property<decimal>("newsW");

                    b.Property<decimal>("newsX");

                    b.Property<decimal>("newsY");

                    b.Property<decimal>("timeH");

                    b.Property<decimal>("timeW");

                    b.Property<decimal>("timeX");

                    b.Property<decimal>("timeY");

                    b.Property<decimal>("weathH");

                    b.Property<decimal>("weathW");

                    b.Property<decimal>("weathX");

                    b.Property<decimal>("weathY");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("Layout");
                });

            modelBuilder.Entity("Phramd.Models.NewsDB", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("articles")
                        .IsRequired();

                    b.Property<string>("country")
                        .IsRequired();

                    b.Property<string>("status")
                        .IsRequired();

                    b.Property<string>("time")
                        .IsRequired();

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Phramd.Models.PhotoAccounts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.Property<string>("apple")
                        .HasMaxLength(100);

                    b.Property<DateTime>("emailadded");

                    b.Property<DateTime>("emailremoved");

                    b.Property<string>("gmail")
                        .HasMaxLength(100);

                    b.Property<string>("microsoft")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("PhotoAccounts");
                });

            modelBuilder.Entity("Phramd.Models.ScreenOptions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.Property<DateTime>("optionsadded");

                    b.Property<DateTime>("optionsremoved");

                    b.Property<string>("screenlayout");

                    b.Property<string>("screensize");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("ScreenOptions");
                });

            modelBuilder.Entity("Phramd.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("canceldate");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("signupdate");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Phramd.Models.WeatherDB", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .IsRequired();

                    b.Property<string>("country")
                        .IsRequired();

                    b.Property<string>("status")
                        .IsRequired();

                    b.Property<string>("unit")
                        .IsRequired();

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("Phramd.Models.CalendarModel", b =>
                {
                    b.HasOne("Phramd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.DTFormatsDB", b =>
                {
                    b.HasOne("Phramd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.Layout", b =>
                {
                    b.HasOne("Phramd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.NewsDB", b =>
                {
                    b.HasOne("Phramd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.PhotoAccounts", b =>
                {
                    b.HasOne("Phramd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.ScreenOptions", b =>
                {
                    b.HasOne("Phramd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.WeatherDB", b =>
                {
                    b.HasOne("Phramd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}