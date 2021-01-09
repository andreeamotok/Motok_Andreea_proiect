using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Motok_Andreea_Proiect.Data;
using Motok_Andreea_Proiect.Models;

namespace Motok_Andreea_Proiect.Pages.Cinemas
{
    public class DeleteModel : PageModel
    {
        private readonly Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext _context;

        public DeleteModel(Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cinema Cinema { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cinema = await _context.Cinema.FirstOrDefaultAsync(m => m.ID == id);

            if (Cinema == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cinema = await _context.Cinema.FindAsync(id);

            if (Cinema != null)
            {
                _context.Cinema.Remove(Cinema);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
