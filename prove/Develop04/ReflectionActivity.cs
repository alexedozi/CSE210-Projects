public class ReflectionActivity : Activity
{
    private static readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] questions = {
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

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void DoActivity(int duration)
    {
        Console.WriteLine("Let's begin the reflection activity.");
        Thread.Sleep(2000);

        DateTime startTime = DateTime.Now;
        Random random = new Random();

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            DisplayPrompt(random);
            AskQuestions();
        }
    }

    private void DisplayPrompt(Random random)
    {
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine("\n" + prompt);
        Thread.Sleep(2000);
    }

    private void AskQuestions()
    {
        foreach (string question in questions)
        {
            DisplaySpinner();
            Console.WriteLine(question);
            Thread.Sleep(3000);
        }
    }

    private void DisplaySpinner()
    {
        string[] spinners = { "|", "/", "-", "\\" };
        foreach (string spinner in spinners)
        {
            Console.Write("\r" + spinner);
            Thread.Sleep(200);
        }
    }
}