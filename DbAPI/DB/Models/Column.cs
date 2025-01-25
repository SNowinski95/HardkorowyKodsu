#nullable disable
namespace DbAPI.DB.Models
{
    public record Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
