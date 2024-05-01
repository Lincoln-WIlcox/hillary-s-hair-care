using System.ComponentModel.DataAnnotations;

namespace Hillary.Models;

public class Appointment
{
    public int Id { get; set; }

    [Required]
    public int StylistId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public DateTime ScheduledDate { get; set; }
    public Stylist? Stylist { get; set; }
    public Customer? Customer { get; set; }
    public List<AppointmentService>? AppointmentServices { get; set; }
}
