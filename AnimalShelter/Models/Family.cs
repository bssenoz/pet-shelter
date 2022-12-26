using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Family
    {
        [Key]
        public int FamilyId { get; set; }
        [Required]
        public string FamilyaName { get; set; }

    }
}
