using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class Player
{
    public Player()
    {
    }
    
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
    
    public string Id { get; set; }
    
    public PlayerType? PlayerType { get; set; }
    
    public int PlayerTypeId { get; set; }
    
    public Room? Room { get; set; }
    
    public Guid RoomId { get; set; }
}