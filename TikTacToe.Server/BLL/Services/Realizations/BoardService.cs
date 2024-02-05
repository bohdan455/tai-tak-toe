using BLL.Dto;
using BLL.Services.Interfaces;
using DataAccess;
using DataAccess.Enum;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Realizations;

public class BoardService : IBoardService
{
    private readonly ApplicationDbContext _context;
    
    public BoardService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task MakeMove(int columnIndex, int rowIndex, string playerId)
    {
        var currentPlayer = await _context
            .Players
            .Include(p => p.Room)
            .ThenInclude(b => b!.Values)
            .FirstAsync(p => p.Id == playerId);
        
        var cell = currentPlayer
            .Room!
            .Values
            .FirstOrDefault(c => c.ColumnIndex == columnIndex && c.RowIndex == rowIndex);

        if (cell.Value != CellTypes.Empty || currentPlayer.Room.NextPlayerMoveId != playerId)
        {
            return;
        }
        
        var nextPlayer = await _context
            .Players
            .FirstAsync(p => p.Id != playerId && p.RoomId == currentPlayer.RoomId);
        
        currentPlayer.Room.NextPlayerMoveId = nextPlayer.Id;
        cell.Value = currentPlayer.PlayerTypeId;
        _context.BoardCellValues.Update(cell);
        _context.Rooms.Update(currentPlayer.Room);
        await _context.SaveChangesAsync();
    }

    public async Task<BoardDto> GetBoard(string boardId)
    {
        var board = await _context
            .Rooms
            .Include(r => r.Values)
            .Include(r => r.NextPlayerMove)
            .ThenInclude(r => r.PlayerType)
            .FirstAsync(r => r.Id.ToString() == boardId);
        return new(board);
    }

    public async Task<string> StartGame(string playerId)
    {
        var room = new Room(playerId, 3);
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room.Id.ToString();
    }

    public async Task AddSecondPlayerToGame(string playerId, string boardId)
    {
        var firstPlayer = await _context
            .Players
            .Include(p => p.Room)
            .SingleAsync(p => p.RoomId == Guid.Parse(boardId));
        
        var playerColor = firstPlayer.PlayerTypeId == 1
            ? 2
            : 1;
        var secondPlayer = new Player(firstPlayer.RoomId, playerId, playerColor);;
        
        _context.Players.Add(secondPlayer);
        await GetRandomNextMove(firstPlayer, secondPlayer);
        await _context.SaveChangesAsync();
    }
    
    private Task GetRandomNextMove(Player firstPlayer, Player secondPlayer)
    {
        var randomPlayer = Random.Shared.Next(1, 3);
        if (randomPlayer == 1)
        {
            firstPlayer.Room!.NextPlayerMoveId = firstPlayer.Id;
            _context.Rooms.Update(firstPlayer.Room);
        }
        else
        {
            secondPlayer.Room!.NextPlayerMoveId = secondPlayer.Id;
            _context.Rooms.Update(secondPlayer.Room);
        }
        
        return Task.CompletedTask;
    }
}