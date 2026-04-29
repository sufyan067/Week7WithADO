namespace Week7WithADO.Models.Appointment
{
    public class CreateAppointmentModel
    {
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = null!;
        public string VisitType { get; set; } = null!;

        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
    }
}
