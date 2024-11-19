using System.Text.Json.Serialization;

namespace ERM.Dtos
{
    public class LocationDto
    {
        [JsonPropertyName("locationId")]
        public int LocationId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }
    }
}
