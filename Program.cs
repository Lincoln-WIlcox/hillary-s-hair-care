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

app.MapGet(
    "/api/appointments/{id}/services",
    (HillaryDbContext db, int id) =>
    {
        Appointment? appointment = db.Appointments.SingleOrDefault(app => app.Id == id);

        if (appointment == null)
        {
            return Results.BadRequest();
        }

        return Results.Ok(
            db.AppointmentServices.Include(aps => aps.Service)
                .Where(aps => aps.AppointmentId == id)
                .Select(aps => new GetAppointmentServicesDTO
                {
                    Id = aps.Service.Id,
                    Name = aps.Service.Name,
                    Price = aps.Service.Price
                })
        );
    }
);

app.MapGet(
    "/api/stylists",
    (HillaryDbContext db, bool? active) =>
    {
        List<Stylist> returnStylists = db.Stylists.ToList();

        if (active != null)
        {
            returnStylists = returnStylists.Where(stylist => stylist.Active == active).ToList();
        }

        return Results.Ok(
            returnStylists.Select(stylist => new GetStylistsDTO
            {
                Id = stylist.Id,
                Name = stylist.Name
            })
        );
    }
);

app.MapGet(
    "/api/customers",
    (HillaryDbContext db) =>
    {
        return Results.Ok(
            db.Customers.Select(customer => new GetCustomersDTO
            {
                Id = customer.Id,
                Name = customer.Name
            })
        );
    }
);

app.MapGet(
    "/api/services",
    (HillaryDbContext db) =>
    {
        return Results.Ok(
            db.Services.Select(service => new GetServicesDTO
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price
            })
        );
    }
);

app.MapPost(
    "/api/appointments",
    (HillaryDbContext db, PostAppointmentsDTO postAppointment) =>
    {
        Stylist? stylist = db.Stylists.SingleOrDefault(stylist =>
            stylist.Id == postAppointment.StylistId
        );
        Customer? customer = db.Customers.SingleOrDefault(customer =>
            customer.Id == postAppointment.CustomerId
        );

        if (stylist == null || customer == null)
        {
            return Results.BadRequest();
        }

        Appointment newAppointment = new Appointment
        {
            StylistId = postAppointment.StylistId,
            CustomerId = postAppointment.CustomerId,
            ScheduledDate = postAppointment.ScheduledDate
        };
        db.Appointments.Add(newAppointment);
        db.SaveChanges();

        foreach (int serviceId in postAppointment.ServiceIds)
        {
            Service? service = db.Services.SingleOrDefault(srv => srv.Id == serviceId);
            if (service == null)
            {
                return Results.BadRequest();
            }

            db.AppointmentServices.Add(
                new AppointmentService { AppointmentId = newAppointment.Id, ServiceId = serviceId }
            );
        }
        db.SaveChanges();

        return Results.Created(
            $"/api/appointments/{newAppointment.Id}",
            new PostAppointmentReturnDTO
            {
                Id = newAppointment.Id,
                StylistId = newAppointment.StylistId,
                CustomerId = newAppointment.CustomerId,
                ScheduledDate = newAppointment.ScheduledDate
            }
        );
    }
);

app.MapPost(
    "/api/stylists",
    (HillaryDbContext db, PostStylistDTO postedStylist) =>
    {
        Stylist stylist = new Stylist { Name = postedStylist.Name, Active = true };
        db.Stylists.Add(stylist);
        db.SaveChanges();
        return Results.Ok(
            new PostStylistReturnDTO
            {
                Id = stylist.Id,
                Name = stylist.Name,
                Active = stylist.Active
            }
        );
    }
);

app.MapPost(
    "/api/customers",
    (HillaryDbContext db, PostCustomerDTO postedCustomer) =>
    {
        Customer customer = new Customer { Name = postedCustomer.Name };
        db.Customers.Add(customer);
        db.SaveChanges();
        return Results.Ok(new PostCustomerReturnDTO { Id = customer.Id, Name = customer.Name });
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
            Service? service = db.Services.SingleOrDefault(srv => srv.Id == serviceId);
            if (service == null)
            {
                return Results.BadRequest();
            }

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

app.MapDelete(
    "/api/stylists/{id}",
    (HillaryDbContext db, int id) =>
    {
        Stylist? stylist = db.Stylists.SingleOrDefault(stylist => stylist.Id == id);

        if (stylist == null)
        {
            return Results.BadRequest();
        }

        stylist.Active = false;
        db.SaveChanges();

        return Results.NoContent();
    }
);

app.UseHttpsRedirection();

app.Run();
