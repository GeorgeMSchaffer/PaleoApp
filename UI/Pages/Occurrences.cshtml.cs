using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;
using Shared.Data;
namespace UI.Pages
{
    public class OccurrencesModel : PageModel
    {
        private readonly AppDBContext _context;

        public OccurrencesModel(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Occurrence Occurrence { get; set; } = default!;
        public List<Occurrence> Occurrences { get; set; } = default!;
        public async Task OnGetAsync()
        {
            await _context.Occurrences.ToListAsync();
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Occurrences.Add(Occurrence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
