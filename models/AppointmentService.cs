using System.ComponentModel.DataAnnotations;

namespace Hillary.Models;

public class AppointmentService
{
    public int Id { get; set; }

    [Required]
    public int AppointmentId { get; set; }

    [Required]
    public int ServiceId { get; set; }
    public Appointment? Appointment { get; set; }
    public Service? Service { get; set; }
}
