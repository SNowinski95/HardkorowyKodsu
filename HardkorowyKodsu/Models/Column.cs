#nullable disable
namespace HardkorowyKodsu.Models
{
    public record Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Type}";
        }
    }
}
