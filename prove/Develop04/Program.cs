using System;
using System.Threading;

class MindfulnessActivity
{
    static void Main()
    {
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.Write("Enter your choice (1-3): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                BreathingActivity();
                break;
            case "2":
                ReflectingActivity();
                break;
            case "3":
                ListingActivity();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void BreathingActivity()
    {
        Console.WriteLine("Breathing Activity:");
        Console.WriteLine("Sit in a comfortable position and close your eyes.");
        Console.WriteLine("Take a deep breath in through your nose, hold it for a few seconds, and exhale through your mouth.");
        Console.WriteLine("Focus your attention on your breath and the sensation of it entering and leaving your body.");
        Console.WriteLine("Continue this deep breathing for several minutes, being fully present in the moment.");
    }

    static void ReflectingActivity()
    {
        Console.WriteLine("Reflecting Activity:");
        Console.WriteLine("Find a quiet place where you can be alone.");
        Console.WriteLine("Close your eyes and take a few deep breaths to center yourself.");
        Console.WriteLine("Think about your day or a specific event that happened recently.");
        Console.WriteLine("Reflect on your thoughts, feelings, and actions during that time.");
        Console.WriteLine("Notice any patterns or insights that emerge without judgment.");
        Console.WriteLine("Continue this reflection for a few minutes, staying open and curious about your experience.");
    }

    static void ListingActivity()
    {
        Console.WriteLine("Listing Activity:");
        Console.WriteLine("Take a pen and a piece of paper, or use a digital device.");
        Console.WriteLine("Write down a list of things you are grateful for or things that bring you joy.");
        Console.WriteLine("Focus on both big and small things, and try to be as specific as possible.");
        Console.WriteLine("Take your time to create the list, letting your mind wander and explore different areas of your life.");
        Console.WriteLine("Once you're done, take a moment to appreciate the positive aspects of your life.");
    }
}
