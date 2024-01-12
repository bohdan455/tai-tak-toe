using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extensions;

public static class ModelBuilderExtensions
{
    public static void PopulateEntities(this ModelBuilder modelBuilder)
    {
        PopulatePlayerTypes(modelBuilder);
        PopulateWinnerTypes(modelBuilder);
    }
    
    private static void PopulatePlayerTypes(ModelBuilder modelBuilder)
    {
        var red = new PlayerType
        {
            Id = 1,
            Name = "Red",
        };
        var blue = new PlayerType
        {
            Id = 2,
            Name = "Blue",
        };
        
        modelBuilder.Entity<PlayerType>().HasData(red, blue);
    }
    
    private static void PopulateWinnerTypes(this ModelBuilder modelBuilder)
    {
        var red = new WinnerType
        {
            Id = 1,
            Name = "Red",
        };
        var blue = new WinnerType
        {
            Id = 2,
            Name = "Blue",
        };
        var draw = new WinnerType
        {
            Id = 3,
            Name = "Draw",
        };
        
        modelBuilder.Entity<WinnerType>().HasData(red, blue, draw);
    }
}