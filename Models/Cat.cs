#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionDay1.Models
{
    [Table("Cats")]
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
