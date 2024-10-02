using System.Data.Entity;
using Shared.Models;
using Backend;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using Shared.Data;
namespace Backend.Services;
using Shared.Models;
public interface ITaxaService
{
    Task<List<Taxa>> GetAll();
    Task<Taxa> Get(int id);
    Task<Taxa> Create(Taxa taxa);
    Task Update(int id, Taxa taxa);
    Task Delete(int id);
}

public class TaxaService : ITaxaService
{
    private readonly AppDBContext _context;
    private readonly ILogger _logger;

    public TaxaService(AppDBContext context, ILogger<TaxaService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Taxa>> GetAll()
    {
        var taxas = await _context.Taxas.ToListAsync();
//        _logger.LogInformation("Returning " + taxas.+ " taxas");
        return taxas;
    }

    public async Task<Taxa> Get(int id)
    {
        var taxa = await _context.Taxas.FindAsync(id);
        if (taxa == null)
        {
            _logger.LogInformation("Taxa with id {Id} not found", id);
        }

        return taxa;
    }

public async Task<Taxa> Create(Taxa taxa)
    {
        _context.Taxas.Add(taxa);
        await _context.SaveChangesAsync();
        return taxa;
    }

    public async Task Update(int id, Taxa taxa)
    {
        _context.Entry(taxa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var taxToBeDeleted = await _context.Taxas.FindAsync(id);
        _context.Taxas.Remove(taxToBeDeleted);
        await _context.SaveChangesAsync();
    }
}