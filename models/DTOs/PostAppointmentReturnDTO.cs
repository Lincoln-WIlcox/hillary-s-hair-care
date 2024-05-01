namespace Hillary.Models.DTOs;

public class PostAppointmentReturnDTO
{
    public int Id { get; set; }
    public int StylistId { get; set; }
    public int CustomerId { get; set; }
    public DateTime ScheduledDate { get; set; }
}
