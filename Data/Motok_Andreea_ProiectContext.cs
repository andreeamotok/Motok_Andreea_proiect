using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Motok_Andreea_Proiect.Models;

namespace Motok_Andreea_Proiect.Data
{
    public class Motok_Andreea_ProiectContext : DbContext
    {
        public Motok_Andreea_ProiectContext (DbContextOptions<Motok_Andreea_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Motok_Andreea_Proiect.Models.Movie> Movie { get; set; }

        public DbSet<Motok_Andreea_Proiect.Models.Cinema> Cinema { get; set; }

        public DbSet<Motok_Andreea_Proiect.Models.Category> Category { get; set; }
    }
}
