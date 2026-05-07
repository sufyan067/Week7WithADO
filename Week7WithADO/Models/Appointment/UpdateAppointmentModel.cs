namespace Week7WithADO.Models.Appointment
{
    public class UpdateAppointmentModel
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = null!;
        public string VisitType { get; set; } = null!;

        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
    }
}
