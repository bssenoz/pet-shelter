using Microsoft.EntityFrameworkCore;

namespace PetShelter.Models
{
    public class ShelterContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adoption> Adoption { get; set; }
        public DbSet<Familya> Families { get; set; }
        public object Configuration { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QUPCTV5; Database=PetShelter;Trusted_Connection=True;");
        }
    }
}
