using CleanCodeLaborationCore.Classes;

namespace CleanCodeLaborationCore.Creators;

public class GameObjectsCreator
{
    public static Player PlayerFactory(string name, int guesses) => new Player(name, guesses);
}
