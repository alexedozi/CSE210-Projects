public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        int promptIndex = random.Next(0, prompts.Length);
        int count = 0;

        Console.WriteLine(prompts[promptIndex]);
        Pause(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            count++;
        }

        Console.WriteLine();
        Console.WriteLine("Number of items listed: " + count);
        Pause(3);
        Console.WriteLine();
    }
}
