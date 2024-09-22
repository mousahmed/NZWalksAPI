using NZWalksAPI.CustomAttributesValidations;
using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double LenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        [ValidDifficultyAttribute]
        public Guid DifficultyId { get; set; }
        [Required]
        [ValidRegionAttribute]
        public Guid RegionId { get; set; }

    }
}
