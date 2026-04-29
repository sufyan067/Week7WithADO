namespace Week7WithADO.Models.Doctor
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Specialization { get; set; } = null!;
    }
}
