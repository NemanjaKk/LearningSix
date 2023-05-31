using LearningSix.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LearningSix.Dto
{
    public class CharacterDto
    {
        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; }
        public int UserId { get; set; }
    }
}
