using Shared.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;

public partial class OccurrenceListModel : PageModel
{
    private readonly AppDBContext _context;

    public OccurrenceListModel(AppDBContext context)
    {
        _context = context;
    }

    public Occurrence Occurrence { get; set; }
    public List<Shared.Models.Occurrence> Occurrences { get;set; }

    public async Task OnGetAsync()
    {
        await _context.Occurrences.ToListAsync();
    }
}