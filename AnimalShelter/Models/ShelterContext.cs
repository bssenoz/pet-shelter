using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AnimalShelter.Models
{
    public class ShelterContext:DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }
        public object Configuration { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QUPCTV5; Database=AnimalShelter;Trusted_Connection=True;");
        }
    }
}
