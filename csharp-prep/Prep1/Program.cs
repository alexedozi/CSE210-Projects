using System;
using System.Collections.Generic;

public class HangmanGame
{
    private const int MaxIncorrectGuesses = 7;
    private const int Game1PartScore = 3;
    private const int Game2PartScore = 5;
    private const int Level2Bonus = 5;
    private const int Level3Bonus = 15;

    private HangmanAlphabet alphabet;
    private HangmanFigure hangmanFigure;
    private HangmanScorer scorer;
    private List<string> categories;
    private Random random;
    private string selectedCategory;
    private string mysteryWord;
    private List<char> guessedLetters;
    private int incorrectGuesses;
    private int score;

    public HangmanGame()
    {
        alphabet = new HangmanAlphabet();
        hangmanFigure = new HangmanFigure();
        scorer = new HangmanScorer(Game1PartScore, Game2PartScore, Level2Bonus, Level3Bonus);
        categories = new List<string>
        {
            "Animals", "Music", "Beach", "Party", "City", "School", "Grocery", "Sports", "Leisure", "West"
        };
        random = new Random();
    }

    public void PlayGame()
    {
        DisplayWelcomeMessage();
        while (true)
        {
            ResetGame();
            DisplayGameMenu();
            int gameOption = GetMenuOption();
            switch (gameOption)
            {
                case 1:
                    PlayGame1();
                    break;
                case 2:
                    PlayGame2();
                    break;
                case 3:
                    PlayGame3();
                    break;
                case 4:
                    PlayGame4();
                    break;
                default:
                    return;
            }
        }
    }

    private void ResetGame()
    {
        alphabet.Reset();
        guessedLetters = new List<char>();
        incorrectGuesses = 0;
        score = 0;
    }

    private void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to Hangman Game!");
    }

    private void DisplayGameMenu()
    {
        Console.WriteLine("Select a game:");
        Console.WriteLine("1. Game 1");
        Console.WriteLine("2. Game 2");
        Console.WriteLine("3. Game 3");
        Console.WriteLine("4. Game 4");
        Console.WriteLine("5. Exit");
    }

    private int GetMenuOption()
    {
        int option;
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 5)
            {
                return option;
            }
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        }
    }

    private void PlayGame1()
    {
        Console.WriteLine("Playing Game 1");
        SelectCategory();
        SelectNumberOfLetters();
        GenerateMysteryWord();
        PlayHangmanGame(true);
    }

    private void PlayGame2()
    {
        Console.WriteLine("Playing Game 2");
        SelectNumberOfLetters();
        GenerateMysteryWord();
        PlayHangmanGame(false);
    }

    private void PlayGame3()
    {
        Console.WriteLine("Playing Game 3");
        SelectNumberOfLetters();
        GenerateRandomMysteryWord();
        PlayHangmanGame(false);
    }

    private void PlayGame4()
    {
        Console.WriteLine("Playing Game 4");
        Calculation calculation = new Calculation();
        int result = calculation.Add(10, 20);
        Console.WriteLine("Addition Result: " + result);

        Eternity eternity = new Eternity();
        string eternityString = eternity.GetEternity();
        Console.WriteLine("Eternity: " + eternityString);

        Scores scores = new Scores();
        scores.DisplayScore(100);
    }

    private void SelectCategory()
    {
        Console.WriteLine("Select a category:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i]}");
        }
        int categoryOption = GetMenuOption();
        selectedCategory = categories[categoryOption - 1];
    }

    private void SelectNumberOfLetters()
    {
        Console.WriteLine("Select the number of letters (3-7):");
        int numberOfLetters = GetMenuOption() + 2;
        alphabet.SetNumberOfLetters(numberOfLetters);
    }

    private void GenerateMysteryWord()
    {
        mysteryWord = "test"; // Replace with actual word generation logic
        Console.WriteLine($"Mystery Word: {mysteryWord}");
    }

    private void GenerateRandomMysteryWord()
    {
        string[] wordList = { "apple", "banana", "carrot", "dog", "elephant" }; // Replace with actual word list
        mysteryWord = wordList[random.Next(wordList.Length)];
        Console.WriteLine($"Mystery Word: {mysteryWord}");
    }

    private void PlayHangmanGame(bool isCategoryEnabled)
    {
        Console.WriteLine("Let the game begin!");

        while (incorrectGuesses < MaxIncorrectGuesses)
        {
            Console.WriteLine();
            DisplayHangmanFigure();
            DisplayMysteryWord();

            char letter = GetLetterGuess();

            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine("You have already guessed that letter. Try again.");
                continue;
            }

            guessedLetters.Add(letter);

            if (mysteryWord.Contains(letter))
            {
                Console.WriteLine("Correct guess!");
                UpdateMysteryWord(letter);
                if (IsWordComplete())
                {
                    Console.WriteLine("Congratulations! You guessed the word.");
                    score += scorer.GetScore(0, isCategoryEnabled, selectedCategory, alphabet.GetNumberOfLetters());
                    break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect guess!");
                incorrectGuesses++;
                hangmanFigure.UpdateFigure(incorrectGuesses, hangmanFigure.GetFigureParts());
                if (incorrectGuesses == MaxIncorrectGuesses)
                {
                    Console.WriteLine("Hangman figure is complete. Game over!");
                    score -= scorer.GetHangmanPenalty();
                    break;
                }
            }
        }

        DisplayHangmanFigure();
        Console.WriteLine($"Game over. The word was {mysteryWord}.");
        scorer.DisplayScore(score);
    }

    private void DisplayHangmanFigure()
    {
        Console.WriteLine("Hangman Figure:");
        hangmanFigure.DisplayFigure(incorrectGuesses);
    }

    private void DisplayMysteryWord()
    {
        Console.WriteLine("Mystery Word:");
        string displayWord = GetDisplayWord();
        Console.WriteLine(displayWord);
    }

    private string GetDisplayWord()
    {
        string displayWord = "";
        foreach (char letter in mysteryWord)
        {
            if (guessedLetters.Contains(letter))
            {
                displayWord += letter;
            }
            else
            {
                displayWord += "_";
            }
            displayWord += " ";
        }
        return displayWord.Trim();
    }

    private char GetLetterGuess()
    {
        Console.WriteLine("Guess a letter:");
        char letter;
        while (true)
        {
            string input = Console.ReadLine().ToUpper();
            if (input.Length == 1 && char.IsLetter(input[0]))
            {
                letter = input[0];
                if (!alphabet.IsValidGuess(letter))
                {
                    Console.WriteLine("Invalid guess. Please enter a valid letter.");
                    continue;
                }
                break;
            }
            Console.WriteLine("Invalid input. Please enter a single letter.");
        }
        return letter;
    }

    private void UpdateMysteryWord(char letter)
    {
        for (int i = 0; i < mysteryWord.Length; i++)
        {
            if (mysteryWord[i] == letter)
            {
                alphabet.RemoveLetter(letter);
            }
        }
    }

    private bool IsWordComplete()
    {
        foreach (char letter in mysteryWord)
        {
            if (!guessedLetters.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }
}

public class HangmanAlphabet
{
    private List<char> alphabet;
    private int numberOfLetters;

    public HangmanAlphabet()
    {
        alphabet = new List<char>();
        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            alphabet.Add(letter);
        }
    }

    public void Reset()
    {
        alphabet.Clear();
        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            alphabet.Add(letter);
        }
    }

    public void SetNumberOfLetters(int numberOfLetters)
    {
        this.numberOfLetters = numberOfLetters;
    }

    public int GetNumberOfLetters()
    {
        return numberOfLetters;
    }

    public bool IsValidGuess(char letter)
    {
        return alphabet.Contains(letter);
    }

    public void RemoveLetter(char letter)
    {
        alphabet.Remove(letter);
    }
}

public class HangmanFigure
{
    private string[] figureParts;

    public HangmanFigure()
    {
        figureParts = new string[]
        {
            " _______",
            "|       |",
            "|       O",
            "|      /|\\",
            "|      / \\",
            "|",
            "|",
            "|",
            "|",
            "|",
            "|"
        };
    }

    public string[] GetFigureParts()
    {
        return figureParts;
    }

    public void UpdateFigure(int incorrectGuesses, string[] figureParts)
    {
        for (int i = 0; i <= incorrectGuesses; i++)
        {
            figureParts[i + 1] = figureParts[i + 1].Substring(0, 7) + "X" + figureParts[i + 1].Substring(8);
        }
    }

    public void DisplayFigure(int incorrectGuesses)
    {
        for (int i = 0; i <= incorrectGuesses + 1; i++)
        {
            Console.WriteLine(figureParts[i]);
        }
    }
}

public class HangmanScorer
{
    private int game1PartScore;
    private int game2PartScore;
    private int level2Bonus;
    private int level3Bonus;

    public HangmanScorer(int game1PartScore, int game2PartScore, int level2Bonus, int level3Bonus)
    {
        this.game1PartScore = game1PartScore;
        this.game2PartScore = game2PartScore;
        this.level2Bonus = level2Bonus;
        this.level3Bonus = level3Bonus;
    }

    public int GetScore(int incorrectGuesses, bool isCategoryEnabled, string category, int numberOfLetters)
    {
        int score = 0;
        if (isCategoryEnabled)
        {
            score += GetCategoryScore(category);
        }
        score += GetPartScore(incorrectGuesses, numberOfLetters);
        return score;
    }

    public int GetHangmanPenalty()
    {
        return game2PartScore * 11;
    }

    private int GetCategoryScore(string category)
    {
        return category.Length;
    }

    private int GetPartScore(int incorrectGuesses, int numberOfLetters)
    {
        int partScore = 0;
        if (incorrectGuesses < 11)
        {
            partScore = game1PartScore;
        }
        else if (incorrectGuesses == 11)
        {
            partScore = game2PartScore;
        }
        else if (incorrectGuesses == 12)
        {
            partScore = game2PartScore + level2Bonus;
        }
        else if (incorrectGuesses == 13)
        {
            partScore = game2PartScore + level3Bonus;
        }
        partScore *= numberOfLetters;
        return partScore;
    }

    public void DisplayScore(int score)
    {
        Console.WriteLine($"Your score: {score}");
    }
}

public class Calculation
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}

public class Eternity
{
    public string GetEternity()
    {
        return "Infinity";
    }
}

public class Scores
{
    public void DisplayScore(int score)
    {
        Console.WriteLine($"Score: {score}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        HangmanGame hangmanGame = new HangmanGame();
        hangmanGame.PlayGame();
    }
}
