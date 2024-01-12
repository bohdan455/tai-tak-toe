using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Player
{
    [Key] 
    public string Id { get; set; } = default!;
    
    [Required] 
    public PlayerType PlayerType { get; set; }
    
    
}