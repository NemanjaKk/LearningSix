using System.Text.Json.Serialization;

namespace LearningSix.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? RpgClass { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Skill> Skills { get; set; }
        public string? DeletedAt { get; set; }
    }
}
