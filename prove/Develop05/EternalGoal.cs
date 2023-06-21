// Eternal goal that gives points every time it is recorded
public class EternalGoal : Goal
{
    private int points;

    public EternalGoal(string name, int points) : base(name)
    {
        this.points = points;
    }

    public override int CalculatePoints()
    {
        return points;
    }

    public override string GetProgress()
    {
        return $"Completed {points} time(s)";
    }
}