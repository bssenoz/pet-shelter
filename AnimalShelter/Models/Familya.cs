using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
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
