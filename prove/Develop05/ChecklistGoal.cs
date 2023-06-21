// Checklist goal that must be accomplished a certain number of times
public class ChecklistGoal : Goal
{
    private int points;
    private int targetCount;
    private int currentCount;

    public ChecklistGoal(string name, int points, int targetCount) : base(name)
    {
        this.points = points;
        this.targetCount = targetCount;
        currentCount = 0;
    }

    public override int CalculatePoints()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            if (currentCount == targetCount)
            {
                IsComplete = true;
                return points + 500; // Bonus points for achieving the target count
            }
            return points;
        }
        return 0;
    }

    public override string GetProgress()
    {
        return $"Completed {currentCount}/{targetCount} times";
    }
}