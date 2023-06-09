public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void DoActivity(int duration)
    {
        Console.WriteLine("Let's begin the breathing activity.");
        Thread.Sleep(2000);

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            BreatheIn();
            BreatheOut();
        }
    }

    private void BreatheIn()
    {
        Console.WriteLine("Breathe in...");
        Thread.Sleep(3000);
    }

    private void BreatheOut()
    {
        Console.WriteLine("Breathe out...");
        Thread.Sleep(3000);
    }
}