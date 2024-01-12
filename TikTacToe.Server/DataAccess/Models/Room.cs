using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Room
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Player FirstPlayer { get; set; } = default!;
    
    [Required]
    public string FirstPlayerId { get; set; } = default!;
    
    public Player? SecondPlayer { get; set; }
    
    public string? SecondPlayerId { get; set; }

    public Player? NextMove { get; set; }
    
    public string? NextMoveId { get; set; }
    
    public WinnerType? Winner { get; set; }
}