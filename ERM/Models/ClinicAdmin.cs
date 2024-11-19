using System.ComponentModel.DataAnnotations;

namespace ERM.Models
{
    public class ClinicAdmin : Base
    {
        public int ClinicAdminId { get; set; }

        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        public int Phone { get; set; }


        public int? ClinicId { get; set; }

        public virtual Clinic? Clinic { get; set; }
        
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
