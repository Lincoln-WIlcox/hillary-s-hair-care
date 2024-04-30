using System.Text.Json.Serialization;
using Hillary.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
}

app.MapGet(
    "/appointments/scheduled",
    (HillaryDbContext db) =>
    {
        List<Appointment> returnAppointments = db
            .Appointments.Include(a => a.Stylist)
            .Include(a => a.Customer)
            .Where(appointment => appointment.ScheduledDate > DateTime.Now)
            .ToList();

        return;
    }
);

app.UseHttpsRedirection();

app.Run();
