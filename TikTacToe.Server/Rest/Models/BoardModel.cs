using BLL.Dto;

namespace Rest.Models;

public class BoardModel
{
    public BoardModel()
    {
    }

    public BoardModel(BoardDto dto)
    {
        Winner = dto.Winner;
        Cells = dto.Cells.Select(x => new BoardCellModel(x));
        NextPlayerMove = dto.NextPlayerMove;
    }
    
    public string? Winner { get; set; }
    
    public string? NextPlayerMove { get; set; }
    
    public IEnumerable<BoardCellModel> Cells { get; set; }
}