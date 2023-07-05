public class HangmanScorer
{
    private const int Game1LetterScore = 1;
    private const int Game1PartScore = 3;
    private const int Game2LetterScore = 3;
    private const int Game2PartScore = 5;
    private const int Level2Bonus = 5;
    private const int Level3Bonus = 15;

    public int CalculateScore(int incorrectGuesses, int numberOfLetters, bool isGame1, bool isCategoryEnabled, string selectedCategory)
    {
        int score = 0;
        if (isGame1)
        {
            score += (numberOfLetters * Game1LetterScore) - (incorrectGuesses * Game1PartScore);
        }
        else
        {
            score += (numberOfLetters * Game2LetterScore) - (incorrectGuesses * Game2PartScore);
        }

        if (isCategoryEnabled)
        {
            score += Level2Bonus;
        }

        if (numberOfLetters >= 5 && incorrectGuesses <= 5)
        {
            score += Level3Bonus;
        }

        return score;
    }
}