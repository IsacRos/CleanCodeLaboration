using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationCore.Games;

public class Mastermind : IGame
{
    public string GameName { get; set; } = "Mastermind";
    public int TargetCount { get; set; } = 5;
    public char[] TargetOptions { get; set; } = ['B', 'R', 'Y', 'P', 'O', 'M'];
    public string[] ResponseArray { get; set; } = ["W", "O"];
    public int AmountMaxGuesses { get; set; } = 12;
    public bool AllowRepeatedCharacters { get; set; } = true;

    public string GetGuessResponse(string guess, string goal)
    {
        var tempString = string.Empty;
        var s = guess.Select((g, idx) =>
        {
            var amountOfGs = goal.Count(c => c.Equals(g));
            if (goal[idx].Equals(g))
            {
                tempString += g;
                return ResponseArray[0];
            }
            else if (goal.Contains(g))
            {
                tempString += g;
                return amountOfGs >= tempString.Count(c => c.Equals(g)) ? ResponseArray[1] : "-";
            }
            else return "-";
        });
        return string.Concat(s);
    }
}
