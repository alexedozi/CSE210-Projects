public class HangmanFigure
{
    private readonly List<string> hangmanParts;
    private int currentPartIndex;

    public HangmanFigure()
    {
        hangmanParts = new List<string>
        {
            "  _______  ",
            "  |     |  ",
            "  |     O  ",
            "  |    /|\\",
            "  |    / \\",
            " _|_      ",
            "|   |_____|",
            "|_________|"
        };
        currentPartIndex = 0;
    }

    public void DisplayHangman(int incorrectGuesses)
    {
        Console.WriteLine("Hangman Figure:");
        for (int i = 0; i <= Math.Min(incorrectGuesses, hangmanParts.Count - 1); i++)
        {
            Console.WriteLine(hangmanParts[i]);
        }
    }
}