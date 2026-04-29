namespace Week7WithADO.Models.Doctor
{
    public class UpdateDoctorModel
    {
        public int DoctorId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public decimal ConsultationFee { get; set; }
        public bool IsAvailable { get; set; }
    }
}
