namespace GameZone.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        [MaxLength(250)]
        public string? Name { get; set; }
    }
}
