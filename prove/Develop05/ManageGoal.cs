// Manager class for tracking goals and displaying progress
public class GoalManager
{
    private List<Goal> goals;

    public GoalManager()
    {
        goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
        }
    }

    public void MarkGoalComplete(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            Console.WriteLine($"Goal '{goalName}' marked as complete.");
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }
}