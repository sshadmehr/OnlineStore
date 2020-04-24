﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.DataAccess;

namespace OnlineStore.Migrations
{
    [DbContext(typeof(OnlineStoreContext))]
    [Migration("20200424175301_removing_hirerachyField_lackOfTime")]
    partial class removing_hirerachyField_lackOfTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineStore.Domain.Models.DeliveryGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryGroups");
                });

            modelBuilder.Entity("OnlineStore.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("ProductGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineStore.Domain.Models.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("OnlineStore.Domain.Models.ProductsDeliveryGroups", b =>
                {
                    b.Property<int>("DeliveryGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DeliveryGroupId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsDeliveryGroups");
                });

            modelBuilder.Entity("OnlineStore.Domain.Models.Tariff", b =>
                {
                    b.Property<int>("DeliveryGroupId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("DeliveryGroupId", "DeliveryType", "EffectiveDate");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("OnlineStore.Domain.Models.Product", b =>
                {
                    b.HasOne("OnlineStore.Domain.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineStore.Domain.Models.ProductsDeliveryGroups", b =>
                {
                    b.HasOne("OnlineStore.Domain.Models.DeliveryGroup", "DeliveryGroup")
                        .WithMany("ProductsDeliveryGroups")
                        .HasForeignKey("DeliveryGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Domain.Models.Product", "Product")
                        .WithMany("ProductsDeliveryGroups")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineStore.Domain.Models.Tariff", b =>
                {
                    b.HasOne("OnlineStore.Domain.Models.DeliveryGroup", "DeliveryGroup")
                        .WithMany()
                        .HasForeignKey("DeliveryGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
