using BLL.Dto;

namespace Rest.Models;

public class BoardCellModel
{
    public BoardCellModel()
    {
    }

    public BoardCellModel(BoardCellDto dto)
    {
        Column = dto.ColumnIndex;
        Row = dto.RowIndex;
        Value = dto.Value;
    }
    
    public int Column { get; set; }
    
    public int Row { get; set; }

    public int Value { get; set; }
}