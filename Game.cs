using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameZone.Models
{
    public class Game : BaseEntity
    {
        [MaxLength(2500)]
        public string? Description { get; set; }
        public string Cover { get; set; } = string.Empty;
        
        public int CategoryId { get; set; }
        public Category category { get; set; } = default!;
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }
}
