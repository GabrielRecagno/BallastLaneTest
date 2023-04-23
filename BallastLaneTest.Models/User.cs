using System.Text.Json.Serialization;

namespace BallastLaneTest.Models
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
    }
}
