using System.Text.Json.Serialization;

namespace GLAS_Server.DTO
{
    public class UserProfile
    {

        [JsonPropertyName("accountID")]
        public string AccountID { get; set; } = string.Empty;
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; } = string.Empty;


    }
}
