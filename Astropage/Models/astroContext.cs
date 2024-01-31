using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Astropage.Models
{

    public class astroContext : DbContext
    {
        public DbSet<astro> Astro { get; set; }
        public astroContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Datasource = horoscope.db");
        }
    }

}

