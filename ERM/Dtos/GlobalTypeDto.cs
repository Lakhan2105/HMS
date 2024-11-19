using System.Text.Json.Serialization;

namespace ERM.Dtos
{
    public class GlobalTypeDto
    {
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }


        [JsonPropertyName("categoryId")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("clinicId")]
        public int? ClinicId { get; set; }
    }
}
