﻿using CleanCodeLaborationCore.Classes;
using CleanCodeLaborationCore.Interfaces;
using System.Data;

namespace CleanCodeLaborationCore.Services;

public class ScoreService
{

    private readonly IIO _io;
    private readonly IRepository _repo;
    private readonly IGame _game;

    private const string SeparationString = "#&#";

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
            string line = player + SeparationString + guesses;
            await _repo.AddPlayerScore(line, _game.GameName);
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
        catch(FormatException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch
        {
            throw new ArgumentException("Couldn't parse player data table");
        }
    }

    private async Task<List<Player>> ParseScoreTable()
    {
        var rawScores = await _repo.GetAllPlayerScores(_game.GameName);

        var players = rawScores
            .Select(playerData => playerData.Split(SeparationString))
            .GroupBy(splitPlayerData => splitPlayerData[0])
            .Select(playerDataGroup =>
            {
                var newPlayer = new Player(playerDataGroup.Key, 0);
                foreach (var entry in playerDataGroup) newPlayer.Update(int.Parse(entry[1]));
                return newPlayer;
            }).ToList();

        players.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        return players;
    }
}
