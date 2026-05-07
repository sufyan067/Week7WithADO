namespace Week7WithADO.Models.Special
{
    public class PatientWithAppointments
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; } = null!;
        public int AppointmentCount { get; set; }
    }
}
