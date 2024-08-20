namespace CleanCodeLaborationCore.Games.Tests;

[TestClass()]
public class MooTests
{
    private Moo _moo = new();

    [TestInitialize()]
    public void Setup()
    {
        _moo = new Moo();
    }

    [TestMethod()]
    public void GetGuessResponseTest_GuessIsCorrect()
    {
        string guess = "1234";
        string goal = "1234";

        string reponse = _moo.GetGuessResponse(guess, goal);

        Assert.AreEqual("BBBB,", reponse);
    }

    [TestMethod]
    public void GetGuessResponse_GuessHasCowsAndBulls()
    {
        string goal = "1234";
        string guess = "1243";

        string response = _moo.GetGuessResponse(guess, goal);

        Assert.AreEqual("BB,CC", response);
    }

    [TestMethod]
    public void GetGuessResponse_GuessHasOnlyCows()
    {
        string goal = "1234";
        string guess = "4321";

        string response = _moo.GetGuessResponse(guess, goal);

        Assert.AreEqual(",CCCC", response);
    }

    [TestMethod]
    public void GetGuessResponse_GuessHasNoCowsOrBulls()
    {
        string goal = "1234";
        string guess = "5678";

        string response = _moo.GetGuessResponse(guess, goal);

        Assert.AreEqual(",", response);
    }
}