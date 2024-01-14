using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class PlayerType
{
    public int Id { get; set; }
    
    public string Name { get; set; } = default!;
}