namespace CleanCodeLaborationCore.Games.Tests
{
    [TestClass()]
    public class MastermindTests
    {
        private Mastermind? _mastermind;

        [TestInitialize()]
        public void Setup()
        {
            _mastermind = new Mastermind();
        }

        [TestMethod]
        public void GetGuessResponse_GuessIsCorrect()
        {
            string goal = "BRYPO";
            string guess = "BRYPO";

            string response = _mastermind.GetGuessResponse(guess, goal);

            Assert.AreEqual("WWWWW", response);
        }

        [TestMethod]
        public void GetGuessResponse_GuessHasWhitesAndOranges()
        {
            string goal = "BRYPO";
            string guess = "BRPYO";

            string response = _mastermind.GetGuessResponse(guess, goal);

            Assert.AreEqual("WWOOW", response);
        }

        [TestMethod]
        public void GetGuessResponse_GuessHasOnlyOranges()
        {
            string goal = "BRYPO";
            string guess = "OYBRP";

            string response = _mastermind.GetGuessResponse(guess, goal);

            Assert.AreEqual("OOOOO", response);
        }

        [TestMethod]
        public void GetGuessResponse_GuessHasNoMatches()
        {
            string goal = "BRYPO";
            string guess = "MMMMM";

            string response = _mastermind.GetGuessResponse(guess, goal);

            Assert.AreEqual("-----", response);
        }
    }
}