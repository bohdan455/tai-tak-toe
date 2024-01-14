using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class WinnerType
{
    public int Id { get; set; }
    
    public string Name { get; set; } = default!;
}