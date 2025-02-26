using System.ComponentModel.DataAnnotations;

namespace PostRedisApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
