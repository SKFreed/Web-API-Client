namespace Web_API_Client.Models
{
    public class DataResponse
    {
        public string? email { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
        public bool enabled { get; set; }
    }
}
