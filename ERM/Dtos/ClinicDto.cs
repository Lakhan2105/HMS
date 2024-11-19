using System.Text.Json.Serialization;

namespace ERM.Dtos
{
    public class ClinicDto
    {
        [JsonPropertyName("clinicId")]
        public int ClinicId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("address")]
        public string Address { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }

       
    }
}
