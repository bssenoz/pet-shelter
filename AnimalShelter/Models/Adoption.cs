using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Adoption
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public int PetId { get; set; }
        public bool Situation { get; set; }
    }
}
