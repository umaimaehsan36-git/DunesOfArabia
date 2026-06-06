// PackingItem.cs
// This is the CORRECT model configuration that works with the DbContext fix

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DunesOfArabia.Models
{
    public class PackingItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public bool IsPacked { get; set; } = false;

        // Foreign Key - MUST BE NAMED EXACTLY THIS
        [ForeignKey(nameof(Itinerary))]
        public int ItineraryId { get; set; }

        // Navigation Property - MUST EXIST
        public Itinerary Itinerary { get; set; } = null!;
    }
}