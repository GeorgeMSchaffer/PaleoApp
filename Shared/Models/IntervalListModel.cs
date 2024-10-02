using Shared.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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