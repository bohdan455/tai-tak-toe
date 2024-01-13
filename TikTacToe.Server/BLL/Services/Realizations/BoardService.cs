using System.Collections.ObjectModel;
using BLL.Dto;
using BLL.Services.Interfaces;
using DataAccess;
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
    
    public async Task MakeMove(int x, int y, string playerId, string boardId)
    {
        var room = await _context
            .Rooms
            .Include(r => r.Board)
            .FirstAsync(r => r.Id.ToString() == boardId);
        
        var color = _context
            .Players
            .First(p => p.Id == playerId)
            .PlayerTypeId;
        
        room.Board[x][y] = color;
        
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task<BoardDto> GetBoard(string boardId)
    {
        var board = await _context
            .Rooms
            .Include(r => r.Board)
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
        var room = await _context
            .Rooms
            .Include(r => r.FirstPlayer)
            .FirstAsync(r => r.Id.ToString() == boardId);
        
        var playerColor = room.FirstPlayer.PlayerTypeId == 1 ? 2 : 1;
        room.SecondPlayer = new(playerId, playerColor);
        
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }
}