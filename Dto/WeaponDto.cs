using LearningSix.Models;
using System.Text.Json.Serialization;

namespace LearningSix.Dto
{
    public class WeaponDto
    {
        public string WeaponName { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;
        public int CharacterId { get; set; }
    }
}
