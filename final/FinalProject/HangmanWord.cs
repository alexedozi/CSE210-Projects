public class HangmanWord
{
    private string mysteryWord;
    private string visibleWord;

    public int NumberOfLetters { get; private set; }

    public void GenerateWord(List<string> words, int numberOfLetters)
    {
        Random random = new Random();
        List<string> filteredWords = words.Where(w => w.Length == numberOfLetters).ToList();
        if (filteredWords.Count == 0)
        {
            Console.WriteLine($"No word available with {numberOfLetters} letters in the selected category.");
            return;
        }

        mysteryWord = filteredWords[random.Next(0, filteredWords.Count)];
        visibleWord = new string('_', numberOfLetters);
        NumberOfLetters = numberOfLetters;
    }

    public string GetVisibleWord()
    {
        return visibleWord;
    }

    public bool CheckLetter(char letterGuess)
    {
        bool isCorrectGuess = false;
        for (int i = 0; i < mysteryWord.Length; i++)
        {
            if (mysteryWord[i] == letterGuess)
            {
                visibleWord = visibleWord.Remove(i, 1).Insert(i, letterGuess.ToString());
                isCorrectGuess = true;
            }
        }
        return isCorrectGuess;
    }

    public bool IsWordComplete()
    {
        return visibleWord == mysteryWord;
    }
}