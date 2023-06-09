using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ')
                    .Select(word => new Word(word))
                    .ToList();
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetText(bool hideWords)
    {
        if (!hideWords)
            return string.Join(" ", words.Select(word => word.GetWordText()));

        return string.Join(" ", words.Select(word => word.IsHidden() ? "__" : word.GetWordText()));
    }

    public bool HideNextWord()
    {
        List<Word> unhiddenWords = words.Where(word => !word.IsHidden()).ToList();
        if (unhiddenWords.Count == 0)
            return false;

        Random random = new Random();
        int randomIndex = random.Next(0, unhiddenWords.Count);
        unhiddenWords[randomIndex].Hide();
        return true;
    }

    public bool AreAllWordsHidden()
    {
        return words.All(word => word.IsHidden());
    }
}