using Hillary.Models;
using Hillary.Models.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

// allows passing datetimes without time zone data
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillaryDbContext>(builder.Configuration["HillaryDbConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
}

app.MapGet(
    "/api/appointments/scheduled",
    (HillaryDbContext db) =>
    {
        List<Appointment> returnAppointments = db
            .Appointments.Include(a => a.Stylist)
            .Include(a => a.Customer)
            .Include(a => a.AppointmentServices)
            .ThenInclude(a => a.Service)
            .Where(appointment => appointment.ScheduledDate > DateTime.Now)
            .ToList();

        return returnAppointments.Select(a => new GetAppointmentsDTO
        {
            Id = a.Id,
            StylistId = a.StylistId,
            CustomerId = a.CustomerId,
            ScheduledDate = a.ScheduledDate,
            Stylist = a.Stylist,
            Customer = a.Customer,
            AppointmentServices = a
                .AppointmentServices.Select(asv => new GetAppointmentsAppointmentServicesDTO
                {
                    Id = asv.Id,
                    AppointmentId = asv.AppointmentId,
                    ServiceId = asv.ServiceId,
                    Service = new GetAppointmentsAppointmentServicesServiceDTO
                    {
                        Id = asv.Service.Id,
                        Name = asv.Service.Name,
                        Price = asv.Service.Price
                    }
                })
                .ToList()
        });
    }
);

app.MapPut(
    "/api/appointments/{id}",
    (HillaryDbContext db, PutAppointmentsDTO putAppointment, int id) =>
    {
        Stylist? stylist = db.Stylists.SingleOrDefault(stylist =>
            stylist.Id == putAppointment.StylistId
        );
        Customer? customer = db.Customers.SingleOrDefault(customer =>
            customer.Id == putAppointment.CustomerId
        );

        if (stylist == null || customer == null)
        {
            return Results.BadRequest();
        }

        Appointment? existingAppointment = db.Appointments.SingleOrDefault(app => app.Id == id);

        if (existingAppointment != null)
        {
            db.Appointments.Remove(existingAppointment);
        }

        db.Appointments.Add(
            new Appointment
            {
                Id = id,
                StylistId = putAppointment.StylistId,
                CustomerId = putAppointment.CustomerId,
                ScheduledDate = putAppointment.ScheduledDate
            }
        );

        foreach (AppointmentService aps in db.AppointmentServices)
        {
            if (aps.AppointmentId == id)
            {
                db.AppointmentServices.Remove(aps);
            }
        }

        foreach (int serviceId in putAppointment.ServiceIds)
        {
            db.AppointmentServices.Add(
                new AppointmentService { AppointmentId = id, ServiceId = serviceId }
            );
        }

        db.SaveChanges();
        return Results.Ok();
    }
);

app.MapDelete(
    "/api/appointments/{id}",
    (HillaryDbContext db, int id) =>
    {
        Appointment? appointment = db.Appointments.SingleOrDefault(app => app.Id == id);

        if (appointment == null)
        {
            return Results.BadRequest();
        }

        db.Appointments.Remove(appointment);
        db.SaveChanges();
        return Results.NoContent();
    }
);

app.UseHttpsRedirection();

app.Run();
