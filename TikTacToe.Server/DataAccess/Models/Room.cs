﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enum;

namespace DataAccess.Models;

public class Room
{
    public Room()
    {
    }
    
    public Room(string firstPlayerId, int boardSize)
    {
        Id = Guid.NewGuid();
        FirstPlayer = new(Id, firstPlayerId);
        Values = GetEmptyBoard(boardSize);
    }
    
    public Room(string firstPlayerId, int firstPlayerColorId, int boardSize)
    {
        Id = Guid.NewGuid();
        FirstPlayer = new(Id ,firstPlayerId, firstPlayerColorId);
        Values = GetEmptyBoard(boardSize);
    }
    
    public Guid Id { get; set; }
    
    public Player FirstPlayer { get; set; }

    public ICollection<Player> Players { get; set; } = new List<Player>();

    public Player NextPlayerMove { get; set; }
    
    public string? NextPlayerMoveId { get; set; }
    
    public WinnerType? Winner { get; set; }
    
    public int? WinnerId { get; set; }

    public ICollection<BoardCellValue> Values { get; set; }
    
    private static ICollection<BoardCellValue> GetEmptyBoard(int boardSize)
    {
        var values = new List<BoardCellValue>();
        for (var i = 0; i < boardSize; i++)
        {
            for (var j = 0; j < boardSize; j++)
            {
                values.Add(new BoardCellValue(i, j, CellTypes.Empty));
            }
        }
        
        return values;
    }
}