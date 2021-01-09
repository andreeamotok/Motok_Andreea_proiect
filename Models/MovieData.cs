using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motok_Andreea_Proiect.Models
{
    public class MovieData
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MovieCategory> MovieCategories { get; set; }

    }
}
