namespace DataAccess.Models;

public class BoardCellValue
{
    public BoardCellValue()
    {
    }

    public BoardCellValue(int rowIndex, int columnIndex, int value)
    {
        RowIndex = rowIndex;
        ColumnIndex = columnIndex;
        Value = value;
    }
    
    public int Id { get; set; }

    public int ColumnIndex { get; set; }
    
    public int RowIndex { get; set; }

    public int Value { get; set; }

    public Room? Room { get; set; }

    public Guid RoomId { get; set; }
}