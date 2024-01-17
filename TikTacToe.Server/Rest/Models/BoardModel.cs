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
    }
    
    public string? Winner { get; set; }
    
    public IEnumerable<BoardCellModel> Cells { get; set; }
}