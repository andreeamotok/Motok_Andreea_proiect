using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Motok_Andreea_Proiect.Data;
using Motok_Andreea_Proiect.Models;

namespace Motok_Andreea_Proiect.Pages.Movies
{
    public class EditModel : MovieCategoriesPageModel
    {
        private readonly Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext _context;

        public EditModel(Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie
  .Include(b => b.Cinema)
  .Include(b => b.MovieCategories).ThenInclude(b => b.Category)
  .AsNoTracking()
  .FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Movie);

            ViewData["CinemaID"] = new SelectList(_context.Set<Cinema>(), "ID", "CinemaName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var MovieToUpdate = await _context.Movie
            .Include(i => i.Cinema)
            .Include(i => i.MovieCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (MovieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(
            MovieToUpdate,
            "Movie",
            i => i.Title, i => i.Director,
            i => i.Price, i => i.PublishingDate, i => i.Cinema))
            {
                UpdateMovieCategories(_context, selectedCategories, MovieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateMovieCategories pentru a aplica informatiile din checkboxuri la entitatea Movies care
            //este editata
            UpdateMovieCategories(_context, selectedCategories, MovieToUpdate);
            PopulateAssignedCategoryData(_context, MovieToUpdate);
            return Page();
        }
    }
}

