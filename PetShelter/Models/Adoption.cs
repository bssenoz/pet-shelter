using System.ComponentModel.DataAnnotations;

namespace PetShelter.Models
{
    public class Adoption
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public int PetId { get; set; }
        public string Adress { get; set; }
        public string BeforePet { get; set; }
        public string HomePet { get; set; }
        public bool Situation { get; set; }
    }
}
