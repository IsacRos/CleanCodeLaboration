using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationInfrastructure.Data;

public class RepositoryTxt : IRepository
{
    public async Task AddDataLine(string line, string gameName)
    {
        var writer = new StreamWriter($"{gameName}-result.txt", append: true);
        await writer.WriteLineAsync(line);
        writer.Close();
    }

    public async Task<List<string>> GetDataTable(string gameName)
    {
        var reader = new StreamReader($"{gameName}-result.txt");
        var result = new List<string>();
        string? line;
        while ((line = await reader.ReadLineAsync()) != null) result.Add(line);
        reader.Close();
        return result;
    }
}
