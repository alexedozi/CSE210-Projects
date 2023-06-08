class Program
{
    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    activity.Run();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    activity.Run();
                    break;
                case 3:
                    activity = new ListingActivity();
                    activity.Run();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
