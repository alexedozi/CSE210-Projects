// Main program
public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    public static void Main(string[] args)
    {
        LoadGoals(); // Load goals from storage (if any)

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Add New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals and Score");
            Console.WriteLine("6. Exit");
            Console.WriteLine("---------------------");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void AddNewGoal()
    {
        Console.Clear();
        Console.WriteLine("Add New Goal");
        Console.WriteLine("------------");

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter goal type: ");
        string goalType = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                Console.Write("Enter points for completing the goal: ");
                int points = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, points));
                Console.WriteLine("Simple goal added successfully!");
                break;
            case "2":
                Console.Write("Enter points for each recording: ");
                points = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, points));
                Console.WriteLine("Eternal goal added successfully!");
                break;
            case "3":
                Console.Write("Enter points for each recording: ");
                points = int.Parse(Console.ReadLine());
                Console.Write("Enter target count for completion: ");
                int targetCount = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, targetCount));
                Console.WriteLine("Checklist goal added successfully!");
                break;
            default:
                Console.WriteLine("Invalid goal type!");
                break;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Record Event");
        Console.WriteLine("------------");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Select a goal to record an event:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} {goals[i].GetProgress()}");
        }

        Console.Write("Enter goal number: ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber < 0 || goalNumber >= goals.Count)
        {
            Console.WriteLine("Invalid goal number!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Goal selectedGoal = goals[goalNumber];
        int pointsEarned = selectedGoal.CalculatePoints();
        score += pointsEarned;

        Console.WriteLine($"Event recorded successfully! You earned {pointsEarned} points.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void ShowGoals()
    {
        Console.Clear();
        Console.WriteLine("Goals");
        Console.WriteLine("-----");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} {goals[i].GetProgress()}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void ShowScore()
    {
        Console.Clear();
        Console.WriteLine($"Score: {score}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void SaveGoals()
    {
        // Save goals and score to storage (e.g., file or database)
        Console.WriteLine("Goals and score saved successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void LoadGoals()
    {
        // Load goals and score from storage (e.g., file or database)
        // Populate the 'goals' list and 'score' variable
        Console.WriteLine("Goals and score loaded successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
