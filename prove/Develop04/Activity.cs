public abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public void Run()
    {
        Console.WriteLine("Activity: " + name);
        Console.WriteLine(description);
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
        Console.WriteLine();

        RunActivity();

        Console.WriteLine("Good job!");
        Console.WriteLine("You have completed the " + name + " activity.");
        Console.WriteLine("Duration: " + duration + " seconds");
        Pause(3);
        Console.WriteLine();
    }

    protected void SetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void RunActivity();
}
