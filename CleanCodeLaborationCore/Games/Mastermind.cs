using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationCore.Games;

public class Mastermind : IGame
{
    public string GameName { get; set; } = "Mastermind";
    public int TargetCount { get; set; } = 5;
    public char[] TargetOptions { get; set; } = ['B', 'R', 'Y', 'P', 'O', 'M'];
    public string[] ResponseSymbols { get; set; } = ["W", "O"];
    public int AmountMaxGuesses { get; set; } = 12;
    public bool AllowRepeatedCharacters { get; set; } = true;

    public string GetGuessResponse(string guess, string goal)
    {
        var tempChars = string.Empty;
        var responseCharacters = guess
            .Select((guessChar, idx) =>
            {
                var correctCharOccurrances = goal.Count(goalChar => goalChar.Equals(guessChar));
                if (goal[idx].Equals(guessChar))
                {
                    tempChars += guessChar;
                    return ResponseSymbols[0];
                }
                else if (goal.Contains(guessChar))
                {
                    tempChars += guessChar;
                    return correctCharOccurrances >= tempChars.Count(c => c.Equals(guessChar)) ? ResponseSymbols[1] : "-";
                }
                else return "-";
            });
        return string.Concat(responseCharacters);
    }
}
