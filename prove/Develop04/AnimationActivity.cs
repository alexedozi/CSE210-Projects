using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Animation Activity!");
        Console.WriteLine("This activity will display a simple animation for your enjoyment.");

        int duration = GetDurationFromUser();

        Console.WriteLine("Starting animation activity...");

        PlayAnimation(duration);

        Console.WriteLine("Animation activity completed!");

        // Standard finishing message for all activities
        Console.WriteLine("Thank you for participating. Have a great day!");
        Console.ReadLine();
    }

    static int GetDurationFromUser()
    {
        int duration;
        while (true)
        {
            Console.Write("Enter the duration in seconds: ");
            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
            {
                return duration;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer value.");
            }
        }
    }

    static void PlayAnimation(int duration)
    {
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Clear();
            Console.WriteLine("Playing animation...");

            // Replace this with your desired animation code
            Console.WriteLine("▁");
            Thread.Sleep(500);

            Console.Clear();
            Console.WriteLine("Playing animation...");

            // Replace this with your desired animation code
            Console.WriteLine("▃");
            Thread.Sleep(500);
        }

        Console.Clear();
    }
}
