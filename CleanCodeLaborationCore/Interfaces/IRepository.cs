namespace CleanCodeLaborationCore.Interfaces;

public interface IRepository
{
    Task AddDataLine(string line, string gameName);
    Task<List<string>> GetDataTable(string gameName);
}
