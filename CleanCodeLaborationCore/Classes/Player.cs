namespace CleanCodeLaborationCore.Classes;

public class Player
{
    public string Name { get; private set; }
    public int NGames { get; private set; }
    public int TotalGuesses { get; private set; }


    public Player(string name, int guesses)
    {
        Name = name;
        TotalGuesses = guesses;
    }

    public void Update(int guesses)
    {
        TotalGuesses += guesses;
        NGames++;
    }

    public double Average()
    {
        return (double)TotalGuesses / NGames;
    }
}
