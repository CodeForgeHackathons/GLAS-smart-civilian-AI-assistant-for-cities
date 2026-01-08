using System;
using System.Text.Json.Serialization;

namespace GLAS_Server.DTO
{
    public class UserProfileDto
    {

        public string Username { get; set; } = string.Empty;
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; } = string.Empty;

    }
}
