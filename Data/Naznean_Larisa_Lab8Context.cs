using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Naznean_Larisa_Lab8.Models;

namespace Naznean_Larisa_Lab8.Data
{
    public class Naznean_Larisa_Lab8Context : DbContext
    {
        public Naznean_Larisa_Lab8Context (DbContextOptions<Naznean_Larisa_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Naznean_Larisa_Lab8.Models.Book> Book { get; set; }

        public DbSet<Naznean_Larisa_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Naznean_Larisa_Lab8.Models.Category> Category { get; set; }
    }
}
