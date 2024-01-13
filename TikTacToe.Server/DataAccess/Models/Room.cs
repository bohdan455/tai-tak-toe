using System.ComponentModel.DataAnnotations;
using DataAccess.Enum;

namespace DataAccess.Models;

public class Room
{
    public Room(string firstPlayerId, int boardSize)
    {
        Id = new Guid();
        FirstPlayer = new(firstPlayerId);
        Board = new List<List<int>>();
        FillBoardWithEmptyCells(Board, boardSize);
    }
    
    public Room(string firstPlayerId, int firstPlayerColorId, int boardSize)
    {
        Id = new Guid();
        FirstPlayer = new(firstPlayerId, firstPlayerColorId);
        Board = new List<List<int>>();
        FillBoardWithEmptyCells(Board, boardSize);
    }
    
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Player FirstPlayer { get; set; }
    
    [Required]
    public string FirstPlayerId { get; set; } = default!;
    
    public Player? SecondPlayer { get; set; }
    
    public string? SecondPlayerId { get; set; }

    public Player? NextMove { get; set; }
    
    public string? NextMoveId { get; set; }
    
    public WinnerType? Winner { get; set; }

    [Required]
    public List<List<int>> Board { get; set; }
    
    private static void FillBoardWithEmptyCells(ICollection<List<int>> board, int boardSize)
    {
        for (var i = 0; i < boardSize; i++)
        {
            var row = new List<int>();
            for (var j = 0; j < boardSize; j++)
            {
                row.Add(CellTypes.Empty);
            }

            board.Add(row);
        }
    }
}