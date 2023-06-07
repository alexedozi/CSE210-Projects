using System;
using System.Threading;

class Spinner
{
    private bool isSpinning;
    private Thread spinnerThread;

    public void Start()
    {
        isSpinning = true;
        spinnerThread = new Thread(Spin);
        spinnerThread.Start();
    }

    public void Stop()
    {
        isSpinning = false;
        spinnerThread.Join();
    }

    private void Spin()
    {
        while (isSpinning)
        {
            Console.Write("/");
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("-");
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("\\");
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("|");
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Spinner Activity!");
        Console.WriteLine("This activity will display a spinning animation using a custom Spinner class.");

        int duration = GetDurationFromUser();

        Console.WriteLine("Starting spinner activity...");

        Spinner spinner = new Spinner();
        spinner.Start();

        Thread.Sleep(duration * 1000); // Convert seconds to milliseconds

        spinner.Stop();

        Console.WriteLine("Spinner activity completed!");

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
}
