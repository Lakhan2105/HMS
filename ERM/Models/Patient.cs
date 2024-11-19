using System.ComponentModel.DataAnnotations;

namespace ERM.Models
{
    public class Patient : Base
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }
        
        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Phone { get; set; }
        
        public string Email { get; set; }


        public int? ClinicId { get; set; }
        public int? PractitionerId { get; set; }
        public int? UserId { get; set; }


        public virtual Clinic? Clinic { get; set; }
        public virtual Practitioner? Practitioner { get; set; }
        public virtual User? User { get; set; }
    }
}
