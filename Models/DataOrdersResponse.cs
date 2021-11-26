namespace Web_API_Client.Models
{
    public class DataOrdersResponse
    {
        public int id { get; set; }
        public string? userEmail { get; set; }
        public string? name { get; set; }
        public int? price { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        
    }
}
