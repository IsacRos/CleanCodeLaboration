using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationApp.UserInterface;

public class ConsoleIO : IIO
{
    public string ReadInput()
    {
        return Console.ReadLine()?? throw new ArgumentNullException();
    }

    public void WriteOutput(string output)
    {
        Console.WriteLine(output);
    }
}
