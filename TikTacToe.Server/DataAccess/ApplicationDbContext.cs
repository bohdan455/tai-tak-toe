using DataAccess.Extensions;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Player> Players { get; set; }
    
    public virtual DbSet<PlayerType> PlayerTypes { get; set; }
    
    public virtual DbSet<WinnerType> WinnerTypes { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.PopulateEntities();
    }
}