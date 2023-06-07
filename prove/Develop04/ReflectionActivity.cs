using System;
using System.Threading;

class ReflectionActivity
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Reflection Activity!");

        // Prompt for duration
        Console.Write("Please enter the duration of this activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        // Description of the activity
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");

        // Array of prompts
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        // Array of questions
        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Random number generator
        Random rand = new Random();

        // Start time
        DateTime startTime = DateTime.Now;

        // Perform reflection activity for the specified duration
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            // Display a random prompt
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine(prompt);

            // Pause for several seconds with spinner animation
            Console.Write("Reflecting");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();

            // Ask random questions
            foreach (string question in questions)
            {
                Console.WriteLine(question);

                // Pause for several seconds with spinner animation
                Console.Write("Reflecting");
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("Reflection activity completed. Thank you!");

        // Wait for user input to exit
        Console.ReadLine();
    }
}