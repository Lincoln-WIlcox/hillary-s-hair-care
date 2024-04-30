namespace Hillary.Models.DTOs;

public class GetAppointmentsDTO
{
    public int Id { get; set; }
    public int StylistId { get; set; }
    public int CustomerId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public Stylist? Stylist { get; set; }
    public Customer? Customer { get; set; }
    public List<Service> Services { get; set; }
}
