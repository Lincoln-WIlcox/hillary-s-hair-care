using Hillary.Models.DTOs;

namespace Hillary.Models;

public class GetAppointmentsAppointmentServicesDTO
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int ServiceId { get; set; }
    public GetAppointmentsAppointmentServicesServiceDTO Service { get; set; }
}
