using System.Globalization;

namespace Hillary.Models.DTOs;

public class GetAppointmentsDTO
{
    public int Id { get; set; }
    public int StylistId { get; set; }
    public int CustomerId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public Stylist Stylist { get; set; }
    public Customer Customer { get; set; }
    public List<GetAppointmentsAppointmentServicesDTO> AppointmentServices { get; set; }
    public decimal totalPrice
    {
        get
        {
            return AppointmentServices.Sum(appointmentService => appointmentService.Service.Price);
        }
    }
    public string ScheduledDateText
    {
        get { return ScheduledDate.ToString(); }
    }
}
