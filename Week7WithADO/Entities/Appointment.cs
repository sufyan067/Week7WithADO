namespace Week7WithADO.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } = null!;
        public string VisitType { get; set; } = null!;

        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
    }
}
