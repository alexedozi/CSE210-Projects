using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            string input;

            do
            {
                Console.WriteLine("Journal App");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("Enter your choice: ");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        journal.WriteNewEntry();
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        journal.SaveJournalToFile();
                        break;
                    case "4":
                        journal.LoadJournalFromFile();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            } while (input != "5");
        }
    }

    class Journal
    {
        private List<Entry> entries;
        private List<string> prompts;

        public Journal()
        {
            entries = new List<Entry>();
            prompts = new List<string> {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }

        public void WriteNewEntry()
        {
            Console.Clear();
            Console.WriteLine("New Entry");
            Console.WriteLine();

            // select a random prompt
            Random random = new Random();
            int index = random.Next(prompts.Count);
            string prompt = prompts[index];

            Console.WriteLine(prompt);
            Console.Write("Response: ");
            string response = Console.ReadLine();

            // create a new entry and add it to the list of entries
            Entry entry = new Entry(prompt, response, DateTime.Now.ToString());
            entries.Add(entry);

            Console.WriteLine();
            Console.WriteLine("Entry added.");
        }

        public void DisplayJournal()
        {
            Console.Clear();
            Console.WriteLine("Journal");
            Console.WriteLine();

            // iterate through all entries and display them
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry.Prompt);
                Console.WriteLine(entry.Response);
                Console.WriteLine(entry.Date);
                Console.WriteLine();
            }
        }

        public void SaveJournalToFile()
        {
            Console.Clear();
            Console.WriteLine("Save Journal");
            Console.WriteLine();

            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();

            try
            {
                // create a new file and write each entry to a line in the file
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Entry entry in entries)
                    {
                        writer.WriteLine($"{entry.Prompt},{entry.Response},{entry.Date}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Journal saved.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($"Error saving journal: {e.Message}");
            }
        }

        public void LoadJournalFromFile()
        {
            Console.Clear();
            Console.WriteLine("Load Journal");
            Console.WriteLine();

            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();

            try
            {
                // clear the current list of entries
                entries.Clear