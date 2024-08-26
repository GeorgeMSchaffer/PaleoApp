namespace Backend;
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
        public DbSet<Occurance> Occurances => Set<Occurance>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            // TODO: custom code here
        }
        public DbSet<Interval> Interval { get; set; } = default!;
    }
