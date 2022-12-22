using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        [Required]
        public string Username { get; set; }
        [StringLength(50)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}