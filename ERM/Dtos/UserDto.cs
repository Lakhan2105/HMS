using ERM.Enums;
using System.Text.Json.Serialization;

namespace ERM.Dtos
{
    public class UserDto
    {
        
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("role")]
        public List<RolesEnum> Role { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        
        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }

    }
}
