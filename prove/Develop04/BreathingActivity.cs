using System;
using System.Threading;

class BreathingActivity
{
    private int duration;

    public BreathingActivity(int duration)
    {
        this.duration = duration;
    }

    public void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");

        Console.WriteLine($"Starting the breathing activity for {duration} seconds...");
        Thread.Sleep(2000); // Pause for 2 seconds before starting

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown();

            Console.WriteLine("Breathe out...");
            ShowCountdown();
        }

        Console.WriteLine("Breathing activity complete.");
    }

    private void ShowCountdown()
    {
        for (int i = 3; i >= 1; i--)
        {
            Console.Write($"{i}...");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}