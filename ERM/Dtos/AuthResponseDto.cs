using ERM.Enums;
using System.Text.Json.Serialization;

namespace ERM.Dtos
{
    public class AuthResponseDto
    {
        public TokenAuthDto Token { get; set; }

        public UserAuthDto User { get; set; }
    }

    public class TokenAuthDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class UserAuthDto
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("role")]
        public List<RolesEnum> Role { get; set; }
    }

}
