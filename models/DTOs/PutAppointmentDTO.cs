namespace Hillary.Models.DTOs;

public class PutAppointmentsDTO
{
    public int StylistId { get; set; }
    public int CustomerId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public List<int> ServiceIds { get; set; }
}
