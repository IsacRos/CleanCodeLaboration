namespace CleanCodeLaborationCore.Interfaces;

public interface IGame
{
    public string GameName { get; set; }
    public int TargetCount { get; set; }
    public char[] TargetOptions { get; set; }
    public string[] ResponseArray { get; set; }
    public int AmountMaxGuesses { get; set; }
    public bool AllowRepeatedCharacters { get; set; }
    string GetGuessResponse(string guess, string goal);

}
