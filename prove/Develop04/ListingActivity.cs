using System;
using System.Threading;

class ListingActivity
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Listing Activity!");

        // Prompt for duration
        Console.Write("Please enter the duration of this activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        // Description of the activity
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        // Array of prompts
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        // Random number generator
        Random rand = new Random();

        // Start time
        DateTime startTime = DateTime.Now;

        // Perform listing activity for the specified duration
        int itemCount = 0;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            // Display a random prompt
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine(prompt);

            // Countdown timer
            Console.WriteLine("You have 10 seconds to start listing items...");
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Start listing items now!");

            // Start listing items
            string input;
            do
            {
                input = Console.ReadLine();
                itemCount++;
            } while (!string.IsNullOrEmpty(input));

            itemCount--; // Exclude the empty entry
        }

        Console.WriteLine("You listed a total of " + itemCount + " items.");
        Console.WriteLine("Listing activity completed. Thank you!");

        // Wait for user input to exit
        Console.ReadLine();
    }
}