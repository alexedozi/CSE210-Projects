// Simple goal that can be marked complete
public class SimpleGoal : Goal
{
    private int points;

    public SimpleGoal(string name, int points) : base(name)
    {
        this.points = points;
    }

    public override int CalculatePoints()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return points;
        }
        return 0;
    }

    public override string GetProgress()
    {
        return IsComplete ? "[X]" : "[ ]";
    }
}
