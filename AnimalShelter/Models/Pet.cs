using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [Required]
        public int FamilyaId { get; set; }
        [Required]
        public string Species { get; set; }
        public string Image { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
