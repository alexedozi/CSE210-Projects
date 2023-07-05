/*+------------------------+
|       HangmanGame      |
+------------------------+
| - selectedCategory: string  |
| - isCategoryEnabled: bool   |
| - hangmanWord: HangmanWord |
| - alphabet: HangmanAlphabet |
| - hangmanFigure: HangmanFigure |
| - scorer: HangmanScorer |
| - score: int |
+------------------------+
| + StartGame() |
| - GenerateWord(int) |
| - SelectCategory() |
| - PlayGame() |
| - GetNumericChoice(int, int) |
+------------------------+

+------------------------+
|      HangmanWord       |
+------------------------+
| - mysteryWord: string |
| - visibleWord: char[] |
+------------------------+
| + SetMysteryWord(string) |
| + GetNumberOfLetters(): int |
| + GenerateVisibleWord() |
| + GetMysteryWord(): string |
| + GetVisibleWord(): string |
| + CheckLetterGuess(char): bool |
| + IsWordComplete(): bool |
| + SetNumberOfLetters(int) |
+------------------------+

+------------------------+
|    HangmanAlphabet     |
+------------------------+
| - availableLetters: List<char> |
+------------------------+
| + GetAvailableLetters(): string |
| + IsLetterAvailable(char): bool |
| + RemoveLetter(char) |
+------------------------+

+------------------------+
|    HangmanFigure       |
+------------------------+
| - hangmanParts: string[] |
+------------------------+
| + DisplayHangman(int) |
+------------------------+

+------------------------+
|    HangmanScorer       |
+------------------------+
+------------------------+
| + CalculateScore(int, int, bool, bool, string): int |
+------------------------+
*/