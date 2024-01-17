using DataAccess.Models;

namespace BLL.Dto;

public class BoardDto
{
    public BoardDto(Room room)
    {
        Winner = room.Winner?.Name;
        Cells = room.Values.Select(x => new BoardCellDto
        {
            ColumnIndex = x.ColumnIndex,
            RowIndex = x.RowIndex,
            Value = x.Value,
        });
    }
    
    public string? Winner { get; set; }

    public IEnumerable<BoardCellDto> Cells { get; set; }
}