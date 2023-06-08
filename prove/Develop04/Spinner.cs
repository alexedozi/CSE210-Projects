using System;
using System.Threading;

public class Spinner
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
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(100);
            Console.Write("\b");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Spinner spinner = new Spinner();
        spinner.Start();

        // Simulating some work
        Thread.Sleep(3000);

        spinner.Stop();

        Console.WriteLine("Spinner stopped.");
        Console.ReadLine();
    }
}
