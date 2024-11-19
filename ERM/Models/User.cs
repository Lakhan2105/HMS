using ERM.Enums;
using System.Text.Json.Serialization;

namespace ERM.Models
{
    public class User : Base
    {
        public int UserId {  get; set; }

        public string Email { get; set; }

        public List<RolesEnum> Role { get; set; } = new List<RolesEnum>();

        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }


        public int? ClinicId { get; set; }

        public virtual Clinic? Clinic { get; set; }
                                                        
    }
}
