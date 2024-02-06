using Microsoft.AspNetCore.SignalR;

namespace Rest.Hubs;

public class GameHub : Hub
{
    public async Task RefreshBoard(string boardId)
    {
        await Clients.Group(boardId).SendAsync("RefreshBoard");
    }
    
    public async Task AddPlayer(string boardId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, boardId);
    }
}