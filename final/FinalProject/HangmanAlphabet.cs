public class HangmanAlphabet
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private readonly HashSet<char> availableLetters;

    public HangmanAlphabet()
    {
        availableLetters = new HashSet<char>(Alphabet);
    }

    public string GetAvailableLetters()
    {
        return string.Join(" ", availableLetters);
    }

    public bool IsLetterAvailable(char letter)
    {
        return availableLetters.Contains(letter);
    }

    public void RemoveLetter(char letter)
    {
        availableLetters.Remove(letter);
    }
}