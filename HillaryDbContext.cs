using Hillary.Models;
using Microsoft.EntityFrameworkCore;

public class HillaryDbContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Stylist> Stylists { get; set; }

    public HillaryDbContext(DbContextOptions<HillaryDbContext> context)
        : base(context) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder
            .Entity<Appointment>()
            .HasData(
                new Appointment[]
                {
                    new Appointment
                    {
                        Id = 1,
                        StylistId = 1,
                        CustomerId = 1,
                        ScheduledDate = new DateTime(2025, 2, 3)
                    },
                    new Appointment
                    {
                        Id = 2,
                        StylistId = 2,
                        CustomerId = 1,
                        ScheduledDate = new DateTime(2026, 3, 4)
                    },
                    new Appointment
                    {
                        Id = 3,
                        StylistId = 3,
                        CustomerId = 2,
                        ScheduledDate = new DateTime(2027, 4, 5)
                    },
                    new Appointment
                    {
                        Id = 4,
                        StylistId = 1,
                        CustomerId = 3,
                        ScheduledDate = new DateTime(2028, 5, 6)
                    }
                }
            );

        modelBuilder
            .Entity<AppointmentService>()
            .HasData(
                new AppointmentService[]
                {
                    new AppointmentService
                    {
                        Id = 1,
                        AppointmentId = 1,
                        ServiceId = 1
                    },
                    new AppointmentService
                    {
                        Id = 2,
                        AppointmentId = 1,
                        ServiceId = 2
                    },
                    new AppointmentService
                    {
                        Id = 3,
                        AppointmentId = 2,
                        ServiceId = 3
                    },
                    new AppointmentService
                    {
                        Id = 4,
                        AppointmentId = 2,
                        ServiceId = 4
                    },
                    new AppointmentService
                    {
                        Id = 5,
                        AppointmentId = 3,
                        ServiceId = 1
                    },
                    new AppointmentService
                    {
                        Id = 6,
                        AppointmentId = 3,
                        ServiceId = 2
                    },
                    new AppointmentService
                    {
                        Id = 7,
                        AppointmentId = 4,
                        ServiceId = 3
                    },
                    new AppointmentService
                    {
                        Id = 8,
                        AppointmentId = 4,
                        ServiceId = 4
                    },
                }
            );

        modelBuilder
            .Entity<Customer>()
            .HasData(
                new Customer[]
                {
                    new Customer { Id = 1, Name = "Customer 1" },
                    new Customer { Id = 2, Name = "Customer 2" },
                    new Customer { Id = 3, Name = "Customer 3" },
                    new Customer { Id = 4, Name = "Customer 4" },
                }
            );

        modelBuilder
            .Entity<Service>()
            .HasData(
                new Service[]
                {
                    new Service
                    {
                        Id = 1,
                        Name = "Customer 1",
                        Price = 12.99M
                    },
                    new Service
                    {
                        Id = 2,
                        Name = "Customer 2",
                        Price = 13.99M
                    },
                    new Service
                    {
                        Id = 3,
                        Name = "Customer 3",
                        Price = 14.99M
                    },
                    new Service
                    {
                        Id = 4,
                        Name = "Customer 4",
                        Price = 15.99M
                    },
                }
            );

        modelBuilder
            .Entity<Stylist>()
            .HasData(
                new Stylist[]
                {
                    new Stylist { Id = 1, Name = "Customer 1", },
                    new Stylist { Id = 2, Name = "Customer 2", },
                    new Stylist { Id = 3, Name = "Customer 3", },
                }
            );
    }
}
