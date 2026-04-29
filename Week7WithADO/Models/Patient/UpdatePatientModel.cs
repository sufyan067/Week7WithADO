namespace Week7WithADO.Models
{
    public class UpdatePatientModel
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string? Email { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
