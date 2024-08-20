using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationInfrastructure.Data;

public class RepositoryTxt : IRepository
{
    private const string PathString = "-result.txt";

    public async Task AddPlayerScore(string line, string gameName)
    {
        var writer = new StreamWriter(gameName + PathString, append: true);
        await writer.WriteLineAsync(line);
        writer.Close();
    }

    public async Task<List<string>> GetAllPlayerScores(string gameName)
    {
        var reader = new StreamReader(gameName + PathString);
        var result = new List<string>();
        string? line;
        while ((line = await reader.ReadLineAsync()) != null) result.Add(line);
        reader.Close();
        return result;
    }
}
