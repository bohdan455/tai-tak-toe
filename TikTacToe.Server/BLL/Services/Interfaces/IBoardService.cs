using BLL.Dto;

namespace BLL.Services.Interfaces;

public interface IBoardService
{
    Task MakeMove(int columnIndex, int rowIndex, string playerId);

    Task<BoardDto> GetBoard(string boardId);

    Task<string> StartGame(string playerId);
    
    Task AddSecondPlayerToGame(string playerId, string boardId);
}