using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Player
{
    public Player(string playerId)
    {
        Id = playerId;
        PlayerTypeId = Random.Shared.Next(1, 3);
    }
    
    public Player(string playerId, int playerTypeId)
    {
        Id = playerId;
        PlayerTypeId = playerTypeId;
    }
    
    [Key] 
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required] 
    public PlayerType? PlayerType { get; set; }
    
    [Required]
    public int PlayerTypeId { get; set; }
}