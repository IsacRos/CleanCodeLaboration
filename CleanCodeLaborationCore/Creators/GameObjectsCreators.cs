using CleanCodeLaborationCore.Classes;

namespace CleanCodeLaborationCore.Creators;

public class GameObjectsCreators
{
    public static Player PlayerFactory(string name, int guesses) => new Player(name, guesses);
}
