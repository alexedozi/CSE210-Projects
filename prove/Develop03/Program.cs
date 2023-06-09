public class Program
{
    public static void Main()
    {
        ScriptureReference reference = new ScriptureReference("John 3:16");
        Scripture scripture = new Scripture(reference.GetReference(), "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

        Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
        Console.WriteLine();

        bool hideWords = false;
        while (true)
        {
            Console.WriteLine(scripture.GetText(hideWords));

            string input = Console.ReadLine();
            if (input == "quit")
                break;

            hideWords = scripture.HideNextWord();
            Console.Clear();
        }
    }
}