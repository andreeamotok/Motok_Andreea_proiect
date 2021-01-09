using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Motok_Andreea_Proiect.Data;
using Motok_Andreea_Proiect.Models;

namespace Motok_Andreea_Proiect.Pages.Movies
{
    public class CreateModel : MovieCategoriesPageModel

    {
        private readonly Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext _context;

        public CreateModel(Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CinemaID"] = new SelectList(_context.Set<Cinema>(), "ID", "CinemaName");
            var Movie = new Movie();
            Movie.MovieCategories = new List<MovieCategory>();
            PopulateAssignedCategoryData(_context, Movie);
            return Page();

        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMovie = new Movie();
            if (selectedCategories != null)
            {
                newMovie.MovieCategories = new List<MovieCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MovieCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMovie.MovieCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Movie>(
            newMovie,
            "Movie",
            i => i.Title, i => i.Director,
            i => i.Price, i => i.PublishingDate, i => i.CinemaID))
            {
                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMovie);
            return Page();
        }
    }
}