using CleanCodeLaborationCore.Classes;
using CleanCodeLaborationCore.Games;
using CleanCodeLaborationCore.Interfaces;
using CleanCodeLaborationCore.Services;
using System.Linq.Expressions;
using System.Numerics;

namespace CleanCodeLaborationApp.Controllers;

public class GameController
{
    private readonly IIO _io;
    private readonly IMenu _menu;
    private readonly IRepository _repo;

    public GameController(IIO io, IMenu menu, IRepository repo)
    {
        _io = io;
        _menu = menu;
        _repo = repo;
    }

    public void Start()
    {
        var game = _menu.SelectGame();

        ScoreService scoreService = new(game, _io, _repo);
        GameEngine gameEngine = new(game, _io);

        try 
        { 
            var player = gameEngine.RunGame(); 
            scoreService.AddPlayerAndScore(player.Name, player.TotalGuesses.ToString()).Wait();
        }
        catch(Exception ex) 
        {
            _io.WriteOutput(ex.ToString());
            Environment.Exit(0);
        }

        if(_menu.Continue()) Start();

        _io.WriteOutput("High score: \n");
        scoreService.DisplayScoreTable().Wait();
        
    }
}
