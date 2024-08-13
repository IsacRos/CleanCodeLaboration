using CleanCodeLaborationCore.Interfaces;
using System.Text;

namespace CleanCodeLaborationCore.Games;
public class Moo : IGame
{
    public string GameName { get; set; } = "MooGame";
    public int TargetCount { get; set; } = 4;
    public char[] TargetOptions { get; set; } = ['1','2','3','4','5','6','7','8','9'];
    public string[] ResponseArray { get; set; } = ["B", "C"];
    public bool AllowRepeatedCharacters { get; set; } = false;
    public int AmountMaxGuesses { get; set; } = 4;

    public string GetGuessResponse(string guess, string goal)
    {
        int cows = 0, bulls = 0;
        guess += "    ";     
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }
}
