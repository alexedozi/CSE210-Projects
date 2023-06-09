public abstract class Activity
{
    protected string name;
    protected string description;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start()
    {
        int duration = GetDuration();
        Console.WriteLine($"{name}: {description}");
        PrepareToBegin();
        DoActivity(duration);
        ConcludeActivity(duration);
    }

    protected int GetDuration()
    {
        while (true)
        {
            Console.Write("Enter the duration in seconds: ");
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
            {
                return duration;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    protected void ConcludeActivity(int duration)
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Thread.Sleep(2000);
        Console.WriteLine($"You have spent {duration} seconds on this activity.");
        Thread.Sleep(3000);
    }

    protected abstract void DoActivity(int duration);
}