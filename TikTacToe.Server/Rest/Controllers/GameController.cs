using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> StartGame(string playerId)
    {
        var boardId = await _boardService.StartGame(playerId);
        return Ok(new {playerId, boardId});
    }

    [HttpPost]
    [Route("join")]
    public async Task<IActionResult> JoinGame([FromBody] JoinGameRequest request)
    {
        await _boardService.AddSecondPlayerToGame(request.PlayerId, request.BoardId);
        return Ok();
    }

    [HttpPost]
    [Route("move")]
    public async Task<IActionResult> MakeMove([FromBody] MakeMoveRequest request)
    {
        await _boardService.MakeMove(request.X, request.Y, request.PlayerId, request.BoardId);
        return Ok();
    }

    [HttpGet]
    [Route("board")]
    public async Task<IActionResult> GetBoard([FromQuery] string boardId)
    {
        var board = await _boardService.GetBoard(boardId);
        return Ok(board);
    }
}