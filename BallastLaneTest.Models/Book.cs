using System.Text.Json.Serialization;

namespace BallastLaneTest.Models
{
    public class Book
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
