using CleanCodeLaborationCore.Interfaces;
using System.Reflection;

namespace CleanCodeLaborationApp.UserInterface;

public class ConsoleMenu : IMenu
{
    public IGame SelectGame()
    {
        try
        {
            int currentIndex = 0;
            ConsoleKey key;
            var gameTypes = GetGameTypes();
            do
            {
                Console.WriteLine("Select Game: \n");

                for (int i = 0; i < gameTypes.Length; i++)
                {
                    if (i == currentIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(gameTypes[i].Name);
                    Console.ResetColor();
                }

                key = Console.ReadKey().Key;
                Console.Clear();

                if (key == ConsoleKey.UpArrow && currentIndex > 0) currentIndex--;
                else if (key == ConsoleKey.DownArrow && currentIndex < gameTypes.Length - 1) currentIndex++;
                else if (key == ConsoleKey.Enter) return (IGame)Activator.CreateInstance(gameTypes[currentIndex])!;

            } while (key != ConsoleKey.Escape);
        }
        catch
        {
            throw;
        }
        throw new ArgumentException("Program exited");
        
    }
    private Type[] GetGameTypes()
    {
        try
        {
            Assembly assembly = Assembly.Load("CleanCodeLaborationCore");
            var gameTypes = assembly.GetTypes()
                .Where(t => t.Namespace == "CleanCodeLaborationCore.Games" && !t.Name.StartsWith("<>"))
                .ToArray();
            return gameTypes;
        }
        catch
        {
            throw new ArgumentException("Couldn't load game types from assembly");
        }
    }

    public bool Continue()
    {
        Console.WriteLine("Continue? (y/n)\n");
        var response = Console.ReadLine()?.ToLower()??string.Empty;

        if (response.Equals("y")) return true;
        else if (!response.Equals("n")) Continue();
        return false;
    }
}
