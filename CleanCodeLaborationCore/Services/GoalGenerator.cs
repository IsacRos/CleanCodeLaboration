using CleanCodeLaborationCore.Interfaces;

namespace CleanCodeLaborationCore.Services;

public class GoalGenerator : IGoalGenerator
{
    private Random Random = new Random();
    public int Next(int maxValue) => Random.Next(maxValue);
}
