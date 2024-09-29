using Microsoft.EntityFrameworkCore.Metadata;
using Shared.Entities;

namespace Backend.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;


public class AppDBContext : DbContext
{
    public AppDBContext(
        DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public DbSet<Interval> Intervals => Set<Interval>();
    public DbSet<Occurrence> Occurrences => Set<Occurrence>();
    public DbSet<Species> Species => Set<Species>();
    public DbSet<Taxa> Taxas => Set<Taxa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating();
        modelBuilder.Entity<Occurrence>()
            .HasMany<Species>(navigationExpression: o => o.Species)
            .WithOne(navigationExpression: s => s.Occurrence)
            .HasForeignKey(foreignKeyExpression: s => s.AcceptedNo);

        modelBuilder.Entity<Occurrence>()
            .HasOne<Interval>(navigationExpression: o => o.Interval)
            .WithMany(navigationExpression: i => i.Occurrences)
            .HasForeignKey(foreignKeyExpression: o => o.EarlyInterval);

        // modelBuilder.Entity<Species>()
        //     .HasMany(s => s.OccurrenceNo)
    }
}
