using System.Data.Entity;
using Backend.Data;
using Backend.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;

namespace Backend.Models;

public partial class OccurrenceListModel : PageModel
{
    private readonly AppDBContext _context;

    public OccurrenceListModel(AppDBContext context)
    {
        _context = context;
    }

    public List<Shared.Models.Occurrence> occurrence { get;set; }

    public async Task OnGetAsync()
    {
        await _context.Intervals.ToListAsync();
    }
}