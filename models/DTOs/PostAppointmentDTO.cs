namespace Hillary.Models.DTOs;

public class PostAppointmentsDTO
{
    public int StylistId { get; set; }
    public int CustomerId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public List<int> ServiceIds { get; set; }
}
