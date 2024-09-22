using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.Domain
{
    public class Difficulty
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
