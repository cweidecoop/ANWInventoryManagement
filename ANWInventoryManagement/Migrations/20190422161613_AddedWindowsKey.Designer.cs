﻿// <auto-generated />
using System;
using ANWInventoryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ANWInventoryManagement.Migrations
{
    [DbContext(typeof(InventoryManagementDbContext))]
    [Migration("20190422161613_AddedWindowsKey")]
    partial class AddedWindowsKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ANWInventoryManagement.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ANWInventoryManagement.Models.CheckIn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckInTime");

                    b.Property<string>("Comment");

                    b.Property<string>("DeviceCategory");

                    b.Property<string>("DeviceID");

                    b.Property<string>("DeviceName");

                    b.Property<string>("ForRepair");

                    b.Property<int>("UserID");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("CheckIns");
                });

            modelBuilder.Entity("ANWInventoryManagement.Models.CheckOut", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckOutTime");

                    b.Property<string>("Comment");

                    b.Property<string>("DeviceCategory");

                    b.Property<string>("DeviceID");

                    b.Property<string>("DeviceName");

                    b.Property<int>("UserID");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("CheckOuts");
                });

            modelBuilder.Entity("ANWInventoryManagement.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<int>("CategoryID");

                    b.Property<bool>("CheckedOut");

                    b.Property<int>("CheckedOutToID");

                    b.Property<string>("CheckedOutToName");

                    b.Property<string>("ItemID");

                    b.Property<DateTime>("LastCheckIn");

                    b.Property<DateTime>("LastCheckOut");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<string>("WindowsKey");

                    b.HasKey("ID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ANWInventoryManagement.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
