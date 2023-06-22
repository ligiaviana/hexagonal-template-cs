﻿// <auto-generated />
using HexagonalTemplate.Adapters.SqliteAdapters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HexagonalTemplate.Migrations.AppRepositoryDb
{
    [DbContext(typeof(AppRepositoryDbContext))]
    partial class AppRepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("HexagonalTemplate.Models.Entities.ActiveChannelsEntity", b =>
                {
                    b.Property<int>("ActiveChannelsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Email")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Sms")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WebPush")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActiveChannelsId");

                    b.ToTable("ActiveChannels");
                });

            modelBuilder.Entity("HexagonalTemplate.Models.Entities.AppEntity", b =>
                {
                    b.Property<int>("AppId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AppId");

                    b.ToTable("Apps");
                });
#pragma warning restore 612, 618
        }
    }
}