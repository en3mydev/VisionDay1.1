#nullable disable
using System.ComponentModel.DataAnnotations;

namespace VisionDay1.Models
{
    public class Cat
    {
        [Required]
        public int Id { get; set; }
        [StringLength(10, MinimumLength = 1)]
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
