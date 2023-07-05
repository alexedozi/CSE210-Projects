public class WordGenerator
    {
        private Dictionary<string, List<string>> wordDictionary;

        public WordGenerator()
        {
            wordDictionary = new Dictionary<string, List<string>>
            {
                { "Animals", new List<string> { "DOG", "CAT", "BIRD", "LION", "TIGER" } },
                { "Music", new List<string> { "PIANO", "GUITAR", "VIOLIN", "TRUMPET", "DRUMS" } },
                { "Beach", new List<string> { "SAND", "WAVES", "SHELLS", "SUNSET", "CRAB" } },
                { "Party", new List<string> { "BALLOONS", "CAKE", "MUSIC", "GAMES", "PRESENTS" } },
                { "City", new List<string> { "SKYSCRAPER", "TAXI", "PARK", "SUBWAY", "BRIDGE" } },
                { "School", new List<string> { "TEACHER", "STUDENT", "BOOKS", "DESK", "PENCIL" } },
                { "Grocery", new List<string> { "APPLE", "BANANA", "ORANGE", "BREAD", "MILK" } },
                { "Sports", new List<string> { "SOCCER", "BASKETBALL", "TENNIS", "SWIMMING", "GOLF" } },
                { "Leisure", new List<string> { "READING", "MOVIES", "GARDENING", "PAINTING", "COOKING" } },
                { "Wild West", new List<string> { "COWBOY", "HORSE", "SALOON", "SHERIFF", "GOLD" } }
            };
        }

        public string GenerateWord(string category, int numberOfLetters)
        {
            if (category != null && wordDictionary.ContainsKey(category))
            {
                List<string> words = wordDictionary[category];
                List<string> filteredWords = FilterWordsByLength(words, numberOfLetters);
                return GetRandomWord(filteredWords);
            }
            else
            {
                List<string> allWords = GetAllWords();
                List<string> filteredWords = FilterWordsByLength(allWords, numberOfLetters);
                return GetRandomWord(filteredWords);
            }
        }

        private List<string> FilterWordsByLength(List<string> words, int length)
        {
            List<string> filteredWords = new List<string>();
            foreach (string word in words)
            {
                if (word.Length == length)
                {
                    filteredWords.Add(word);
                }
            }
            return filteredWords;
        }

        private string GetRandomWord(List<string> words)
        {
            Random random = new Random();
            int index = random.Next(words.Count);
            return words[index];
        }

        private List<string> GetAllWords()
        {
            List<string> allWords = new List<string>();
            foreach (List<string> words in wordDictionary.Values)
            {
                allWords.AddRange(words);
            }
            return allWords;
        }
    }