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
    public class IndexModel : PageModel
    {
        private readonly Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext _context;

        public IndexModel(Motok_Andreea_Proiect.Data.Motok_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Cinema> Cinema { get;set; }

        public async Task OnGetAsync()
        {
            Cinema = await _context.Cinema.ToListAsync();
        }
    }
}
