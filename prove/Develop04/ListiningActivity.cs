public class ListingActivity : Activity
{
    private static readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void DoActivity(int duration)
    {
        Console.WriteLine("Let's begin the listing activity.");
        Thread.Sleep(2000);

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine("\n" + prompt);
        Thread.Sleep(5000);

        DateTime startTime = DateTime.Now;
        List<string> items = ListItems(duration);

        DisplayItemCount(items);
    }

    private List<string> ListItems(int duration)
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Write("Enter an item (or 'done' to finish): ");
            string item = Console.ReadLine();

            if (item.ToLower() == "done")
                break;

            items.Add(item);
        }

        return items;
    }

    private void DisplayItemCount(List<string> items)
    {
        Console.WriteLine($"\nYou listed {items.Count} items.");
    }
}