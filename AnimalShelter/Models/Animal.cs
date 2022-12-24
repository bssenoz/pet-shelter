using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [Required]
        public string Familya { get; set; }
        [Required]
        public string Species { get; set; }
        public string Image { get; set; }
        [Required]
        public int Age { get; set; }
    }
}