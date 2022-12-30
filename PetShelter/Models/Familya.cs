using System.ComponentModel.DataAnnotations;

namespace PetShelter.Models
{
    public class Familya
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Count { get; set; }

    }
}
