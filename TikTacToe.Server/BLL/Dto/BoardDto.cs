using DataAccess.Models;

namespace BLL.Dto;

public class BoardDto
{
    public BoardDto(Room room)
    {
        Winner = room.Winner?.Name;
        Board = room.Board;
    }
    
    public string? Winner { get; set; }

    public IEnumerable<IEnumerable<int>> Board { get; set; }
}