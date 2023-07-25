using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Services;
using TrainGame.Domain.Models;


namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public Game CreateGame()
    {
        return _gameService.CreateGame();
    }

    [HttpGet("Answer")]
    public bool Game(string gameId, string answer)
    {
        return _gameService.CheckAnswer(gameId, answer);
    }
}