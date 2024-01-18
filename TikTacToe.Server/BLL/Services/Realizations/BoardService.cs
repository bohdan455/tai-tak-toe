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
        var player = await _context
            .Players
            .Include(p => p.Room)
            .ThenInclude(b => b!.Values)
            .FirstAsync(p => p.Id == playerId);
        
        var cell = player
            .Room!
            .Values
            .FirstOrDefault(c => c.ColumnIndex == columnIndex && c.RowIndex == rowIndex);

        if (cell.Value != CellTypes.Empty)
        {
            return;
        }
            
        
        cell.Value = player.PlayerTypeId;
        _context.BoardCellValues.Update(cell);
        await _context.SaveChangesAsync();
    }

    public async Task<BoardDto> GetBoard(string boardId)
    {
        var board = await _context
            .Rooms
            .Include(r => r.Values)
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
        var player = new Player(firstPlayer.RoomId, playerId, playerColor);;
        
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
    }
}