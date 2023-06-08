public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity()
    {
        for (int i = 0; i < duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Pause(1);
            Console.WriteLine("Breathe out...");
            Pause(1);
        }
    }
}