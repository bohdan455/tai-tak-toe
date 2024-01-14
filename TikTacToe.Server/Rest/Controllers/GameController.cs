using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Rest.Models;

namespace Rest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IBoardService _boardService;

    public GameController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    [HttpPost]
    [Route("start")]
    public async Task<IActionResult> StartGame()
    {
        var playerId = Guid.NewGuid().ToString();
        var boardId = await _boardService.StartGame(playerId);
        return Ok(new {playerId, boardId});
    }

    [HttpPost]
    [Route("join")]
    public async Task<IActionResult> JoinGame([FromBody] JoinGameRequest request)
    {
        var playerId = Guid.NewGuid().ToString();
        await _boardService.AddSecondPlayerToGame(playerId, request.BoardId);
        return Ok(playerId);
    }

    [HttpPost]
    [Route("move")]
    public async Task<IActionResult> MakeMove([FromBody] MakeMoveRequest request)
    {
        await _boardService.MakeMove(request.X, request.Y, request.PlayerId);
        return Ok();
    }

    [HttpGet]
    [Route("board/{boardId}")]
    public async Task<IActionResult> GetBoard([FromQuery] string boardId)
    {
        var board = await _boardService.GetBoard(boardId);
        return Ok(board);
    }
}