using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Motok_Andreea_Proiect.Data;
using Motok_Andreea_Proiect.Models;

namespace Motok_Andreea_Proiect.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext _context;

        public DetailsModel(Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
