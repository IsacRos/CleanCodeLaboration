using CleanCodeLaborationCore.Interfaces;
using CleanCodeLaborationCore.Services;
using Microsoft.Extensions.Logging;

namespace CleanCodeLaborationInfrastructure.Controllers;

public class GameController
{
    private readonly IIO _io;
    private readonly IMenu _menu;
    private readonly IRepository _repo;
    private readonly ILogger<GameController> _logger;

    public GameController(IIO io, IMenu menu, IRepository repo, ILogger<GameController> logger)
    {
        _io = io;
        _menu = menu;
        _repo = repo;
        _logger = logger;
    }

    public void Start()
    {
        try 
        { 
            var game = _menu.SelectGame();

            ScoreService scoreService = new(game, _io, _repo);
            GameEngine gameEngine = new(game, _io);

            var player = gameEngine.RunGame(); 
            scoreService.AddPlayerAndScore(player.Name, player.TotalGuesses.ToString()).Wait();

            if(_menu.Continue()) Start();

            _io.WriteOutput("High score: \n");
            scoreService.DisplayScoreTable().Wait();
        }
        catch(Exception ex) 
        {
            _logger.LogError(ex.Message);
            Environment.Exit(0);
        }
    }
}
