using System;
using System.Text.Json.Serialization;

namespace GLAS_Server.DTO
{
    public class UserProfile
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; } = string.Empty;


    }
}
