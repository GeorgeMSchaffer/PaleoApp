using System.Data.Entity;
using Backend.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;

namespace Backend.Models;

public partial class IntervalListModel : PageModel
{
    private readonly AppDBContext _context;

    public IntervalListModel(AppDBContext context)
    {
        _context = context;
    }

    public List<Shared.Models.Interval> Intervals { get;set; }

    public async Task OnGetAsync()
    {
        Intervals = await _context.Intervals.ToListAsync();
    }
}