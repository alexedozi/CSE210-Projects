using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            string menuOption;

            do
            {
                Console.WriteLine("\nWelcome to your journal!");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");

                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        myJournal.AddEntry();
                        break;
                    case "2":
                        myJournal.DisplayEntries();
                        break;
                    case "3":
                        myJournal.SaveToFile();
                        break;
                    case "4":
                        myJournal.LoadFromFile();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (menuOption != "5");
        }
    }

    class Journal
    {
        private List<Entry> entries;

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void AddEntry()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine("Prompt: " + prompt);
            Console.Write("Response: ");
            string response = Console.ReadLine();
            DateTime date = DateTime.Now;

            Entry newEntry = new Entry(prompt, response, date);
            entries.Add(newEntry);
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Your journal is empty.");
            }
            else
            {
                Console.WriteLine("Your journal entries:");
                foreach (Entry entry in entries)
                {
                    Console.WriteLine("Date: " + entry.Date);
                    Console.WriteLine("Prompt: " + entry.Prompt);
                    Console.WriteLine("Response: " + entry.Response);
                    Console.WriteLine();
                }
            }
        }

        public void SaveToFile()
        {
            Console.Write("Enter a filename: ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Entry entry in entries)
                    {
                        writer.WriteLine(entry.Date);
                        writer.WriteLine(entry.Prompt);
                        writer.WriteLine(entry.Response);
                    }
                }
                Console.WriteLine("Journal saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving journal to file: " + ex.Message);
            }
        }

        public void LoadFromFile()
        {
            Console.Write("Enter a filename: ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    entries.Clear();

                    while (!reader.EndOfStream)
                    {
                        DateTime date = DateTime.Parse(reader.ReadLine());
                        string prompt = reader.ReadLine();
                        string response = reader.ReadLine();

                        Entry newEntry = new Entry(prompt, response, date);
                        entries.Add(newEntry);
                    }
                }
                Console.WriteLine("Journal loaded from file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading journal from file: " + ex.Message);
            }
        }

        private string GetRandomPrompt()
        {
            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
