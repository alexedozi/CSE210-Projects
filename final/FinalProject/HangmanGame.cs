using System;
using System.Collections.Generic;
using System.Linq;

public class HangmanGame
{
    private const int MaxIncorrectGuesses = 11;

    private readonly HangmanWord hangmanWord;
    private readonly HangmanAlphabet alphabet;
    private readonly HangmanFigure hangmanFigure;
    private readonly HangmanScorer scorer;
    private readonly Dictionary<string, List<string>> wordDictionary;
    private bool isCategoryEnabled;
    private string selectedCategory;
    private int score;

    public HangmanGame()
    {
        hangmanWord = new HangmanWord();
        alphabet = new HangmanAlphabet();
        hangmanFigure = new HangmanFigure();
        scorer = new HangmanScorer();

        wordDictionary = new Dictionary<string, List<string>>
        {
            { "Animals", new List<string> { "LION", "TIGER", "ELEPHANT", "MONKEY" } },
            { "Music", new List<string> { "GUITAR", "PIANO", "VIOLIN", "DRUMS" } },
            { "Beach", new List<string> { "SUN", "SAND", "WAVES", "SHELLS" } },
            { "Party", new List<string> { "BALLOONS", "CAKE", "MUSIC", "GIFTS" } },
            { "City", new List<string> { "SKYSCRAPER", "TAXI", "BRIDGE", "PARK" } },
            { "School", new List<string> { "TEACHER", "STUDENT", "BOOKS", "PENCIL" } },
            { "Grocery", new List<string> { "FRUITS", "VEGETABLES", "BREAD", "MILK" } },
            { "Sports", new List<string> { "FOOTBALL", "BASKETBALL", "SOCCER", "TENNIS" } },
            { "Leisure", new List<string> { "READING", "COOKING", "PAINTING", "TRAVEL" } },
            { "Wild West", new List<string> { "HORSE", "SALOON", "CACTUS", "SHERIFF" } }
        };
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to Hangman Game!");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select Game:");
            Console.WriteLine("1. Regular Hangman");
            Console.WriteLine("2. Scrambled Words");
            Console.WriteLine("3. Exit");

            int gameChoice = GetNumericChoice(1, 3);

            if (gameChoice == 3)
            {
                Console.WriteLine("Thank you for playing Hangman Game!");
                break;
            }

            isCategoryEnabled = gameChoice == 1;
            selectedCategory = null;

            if (isCategoryEnabled)
            {
                SelectCategory();
            }

            Console.WriteLine("Select Skill Level:");
            Console.WriteLine("1. Beginner");
            Console.WriteLine("2. Intermediate");
            Console.WriteLine("3. Expert");

            int skillLevelChoice = GetNumericChoice(1, 3);

            Console.WriteLine("Select Number of Letters (3-7):");
            int numberOfLetters = GetNumericChoice(3, 7);

            GenerateWord(numberOfLetters);

            PlayGame();

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    private void SelectCategory()
    {
        Console.WriteLine("Select Category:");
        int index = 1;
        foreach (var category in wordDictionary.Keys)
        {
            Console.WriteLine($"{index}. {category}");
            index++;
        }

        int categoryChoice = GetNumericChoice(1, wordDictionary.Count);

        selectedCategory = wordDictionary.Keys.ElementAt(categoryChoice - 1);
    }

    private void GenerateWord(int numberOfLetters)
    {
        var words = isCategoryEnabled ? wordDictionary[selectedCategory] : wordDictionary.Values.SelectMany(x => x).ToList();
        hangmanWord.GenerateWord(words, numberOfLetters);
    }

    private void PlayGame()
    {
        score = 0;
        int incorrectGuesses = 0;
        bool isGameWon = false;

        Console.WriteLine("\nGame Start!\n");

        while (incorrectGuesses < MaxIncorrectGuesses && !isGameWon)
        {
            Console.Clear();
            Console.WriteLine($"Category: {selectedCategory}");
            Console.WriteLine($"Score: {score}");
            hangmanFigure.DisplayHangman(incorrectGuesses);
            Console.WriteLine("Available Letters: " + alphabet.GetAvailableLetters());
            Console.WriteLine("Word: " + hangmanWord.GetVisibleWord());
            Console.Write("Enter a letter: ");
            char letter = char.ToUpper(Console.ReadKey().KeyChar);

            if (!char.IsLetter(letter))
            {
                Console.WriteLine("\nInvalid input! Please enter a letter.");
                Console.ReadKey();
                continue;
            }

            if (!alphabet.IsLetterAvailable(letter))
            {
                Console.WriteLine($"\n'{letter}' has already been guessed. Try another letter.");
                Console.ReadKey();
                continue;
            }

            alphabet.RemoveLetter(letter);

            bool isCorrectGuess = hangmanWord.CheckLetter(letter);
            if (isCorrectGuess)
            {
                Console.WriteLine("\nCorrect guess!");
                if (hangmanWord.IsWordComplete())
                {
                    isGameWon = true;
                    score += scorer.CalculateScore(incorrectGuesses, hangmanWord.NumberOfLetters, true, isCategoryEnabled, selectedCategory);
                    Console.WriteLine("\nCongratulations! You guessed the word correctly!");
                }
            }
            else
            {
                Console.WriteLine("\nIncorrect guess!");
                incorrectGuesses++;
                if (incorrectGuesses == MaxIncorrectGuesses)
                {
                    Console.WriteLine("\nGame Over! You failed to guess the word.");
                }
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    private int GetNumericChoice(int min, int max)
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
            {
                break;
            }
            Console.WriteLine($"Invalid choice! Please enter a number between {min} and {max}.");
        }
        return choice;
    }
}