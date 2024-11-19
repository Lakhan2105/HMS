using System.Text.Json.Serialization;

namespace ERM.Dtos
{
    public class ClinicAdminDto
    {
        [JsonPropertyName("clinicAdminId")]
        public int ClinicAdminId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
            
        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }
        
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        
        [JsonPropertyName("phone")]
        public int Phone { get; set; }

        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }
        
        [JsonPropertyName("userId")]
        public int? UserId { get; set; }
    }
}
