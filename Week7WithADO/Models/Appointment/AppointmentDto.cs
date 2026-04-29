namespace Week7WithADO.Models.Appointment
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = null!;
    }
}
