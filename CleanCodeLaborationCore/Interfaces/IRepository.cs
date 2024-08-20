namespace CleanCodeLaborationCore.Interfaces;

public interface IRepository
{
    Task AddPlayerScore(string line, string gameName);
    Task<List<string>> GetAllPlayerScores(string gameName);
}
