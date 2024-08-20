using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationTest.Utils;

public class MockGoalGenerator : IGoalGenerator
{
    private readonly string _mockGoal;
    private int _counter;

    public MockGoalGenerator(string mockGoal)
    {
        _mockGoal = mockGoal;
    }

    public int Next(int maxValue)
    {
        int number = _mockGoal[_counter] - '0';
        _counter++;
        return number;
    }
}
