﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hillary.Migrations
{
    [DbContext(typeof(HillaryDbContext))]
    partial class HillaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Hillary.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ScheduledDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            ScheduledDate = new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            ScheduledDate = new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2,
                            ScheduledDate = new DateTime(2027, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 3
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 3,
                            ScheduledDate = new DateTime(2028, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 1
                        });
                });

            modelBuilder.Entity("Hillary.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 2,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 2,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 5,
                            AppointmentId = 3,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 6,
                            AppointmentId = 3,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 7,
                            AppointmentId = 4,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 8,
                            AppointmentId = 4,
                            ServiceId = 4
                        });
                });

            modelBuilder.Entity("Hillary.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customer 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Customer 4"
                        });
                });

            modelBuilder.Entity("Hillary.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customer 1",
                            Price = 12.99m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer 2",
                            Price = 13.99m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer 3",
                            Price = 14.99m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Customer 4",
                            Price = 15.99m
                        });
                });

            modelBuilder.Entity("Hillary.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customer 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer 3"
                        });
                });

            modelBuilder.Entity("Hillary.Models.Appointment", b =>
                {
                    b.HasOne("Hillary.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hillary.Models.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("Hillary.Models.AppointmentService", b =>
                {
                    b.HasOne("Hillary.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hillary.Models.Service", "service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("service");
                });
#pragma warning restore 612, 618
        }
    }
}
