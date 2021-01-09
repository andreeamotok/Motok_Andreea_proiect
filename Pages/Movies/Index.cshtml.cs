using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Motok_Andreea_Proiect.Data;
using Motok_Andreea_Proiect.Models;

namespace Motok_Andreea_Proiect.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext _context;

        public IndexModel(Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        public MovieData MovieD { get; set; }
        public int MovieID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            MovieD = new MovieData();
            MovieD.Movies = await _context.Movie.Include(b => b.Cinema).Include(b => b.MovieCategories).ThenInclude(b => b.Category).AsNoTracking().OrderBy(b => b.Title).ToListAsync();
            if (id != null)
            {
                MovieID = id.Value;
                Movie Movie = MovieD.Movies
                .Where(i => i.ID == id.Value).Single();
                MovieD.Categories = Movie.MovieCategories.Select(s => s.Category);
            }
        }
    }
}
