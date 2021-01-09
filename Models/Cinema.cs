using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motok_Andreea_Proiect.Models
{
    public class Cinema
    {
        public int ID { get; set; }
        public string CinemaName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
