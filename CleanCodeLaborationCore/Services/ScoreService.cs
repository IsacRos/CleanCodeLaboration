using CleanCodeLaborationCore.Classes;
using CleanCodeLaborationCore.Interfaces;
using System.Data;
using System.Net.Http.Headers;

namespace CleanCodeLaborationCore.Services;

public class ScoreService
{
    private readonly IIO _io;
    private readonly IRepository _repo;
    private readonly IGame _game;

    public ScoreService(IGame game, IIO io, IRepository repo)
    {
        _io = io;
        _repo = repo;
        _game = game;
    }

    public async Task AddPlayerAndScore(string player, string guesses)
    {
        try
        {
            string line = player + "#&#" + guesses;
            await _repo.AddDataLine(line, _game.GameName);
        }
        catch
        {
            throw new ArgumentException("Couldn't add player score");
        }
    }

    public async Task DisplayScoreTable()
    {
        try
        {
            var players = await ParseScoreTable();
            _io.WriteOutput("Player    Games   Average");
            _io.WriteOutput("-------------------------");
            foreach (var p in players)
            {
                var formattedScore = string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average());
                _io.WriteOutput(formattedScore);
            }
        }
        catch
        {
            throw new ArgumentException("Couldn't parse score table");
        }

    }

    private async Task<List<Player>> ParseScoreTable()
    {
        var scores = await _repo.GetDataTable(_game.GameName);

        var result = scores
            .Select(s => s.Split("#&#"))
            .GroupBy(g => g[0])
            .Select(group =>
            {
                var player = new Player(group.Key, 0);
                foreach (var score in group) player.Update(int.Parse(score[1]));
                return player;
            }).ToList();

        result.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        return result;
    }



}
