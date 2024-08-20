using CleanCodeLaborationApp.UserInterface;
using CleanCodeLaborationCore.Games;
using CleanCodeLaborationCore.Services;
using CleanCodeLaborationTest.Utils;

namespace CleanCodeLaborationTest.Services;

[TestClass()]
public class GameEngineTests
{
    [TestMethod()]
    public void SetTargetGoal_MooGameTargetIsCorrect()
    {
        //Moo game target options range from index 0-8
        var mockValue = "0178";
        var game = new Moo();
        var gameEngine = new GameEngine(game, new ConsoleIO(), new MockGoalGenerator(mockValue));

        var response = gameEngine.SetTargetGoal();

        Assert.AreEqual(response, "1289");
    }
}
