using CleanCodeLaborationCore.Classes;
using CleanCodeLaborationCore.Creators;
using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationCore.Services;

public class GameEngine
{
    private readonly IGame _game;
    private readonly IIO _io;
    private bool _gameWon;
    private int _nGuesses = 0;

    public GameEngine(IGame game, IIO io)
    {
        _game = game;
        _io = io;
    }

    public Player RunGame()
    {
        try
        {
            string target = SetTargetGoal();
            _io.WriteOutput($"Welcome to {_game.GameName}!");
            _io.WriteOutput("PRACTICE, number is: " + target + "\n");
            _io.WriteOutput("Enter your username: " + "\n");

            string name = _io.ReadInput();
            _io.WriteOutput("New game:\n");

            GameLoop(target);

            _io.WriteOutput(
                _gameWon ?
                "Correct, it took " + _nGuesses + " guesses\n" :
                "Incorrect, it took too many guesses.\n"
                );

            return GameObjectsCreator.PlayerFactory(name, _nGuesses);
        }
        catch { throw; }
    }

    private string SetTargetGoal()
    {
        try
        {
            Random random = new();
            string target = string.Empty;
            while (target.Length < _game.TargetCount)
            {
                int nextOption = random.Next(_game.TargetOptions.Length);
                if (_game.AllowRepeatedCharacters || !target.Contains(_game.TargetOptions[nextOption])) 
                    target += _game.TargetOptions[nextOption];
            }
            return target;
        }
        catch 
        { 
            throw new ArgumentException("Couldn't set target goal"); 
        }
    }

    private void GameLoop(string target)
    {
        try
        {
            string guessInput;
            string guessResponse;
            do
            {
                guessInput = _io.ReadInput().ToUpper();
                var guess = guessInput.Length > _game.TargetCount ?
                    guessInput.Substring(0, _game.TargetCount) :
                    guessInput;

                _io.WriteOutput(guess + "\n");
                guessResponse = _game.GetGuessResponse(guess, target);
                _io.WriteOutput(guessResponse);
                _nGuesses++;
                SetWinCondition(guess, target);
            }
            while (!_gameWon && _nGuesses < _game.AmountMaxGuesses);
        }
        catch
        {
            throw new ArgumentException("Game loop crashed");
        }
    }

    private void SetWinCondition(string guess, string target) => _gameWon = guess.Equals(target);
}
