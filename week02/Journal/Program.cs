using System;

// EXCEEDS CORE REQUIREMENTS:
// - Added mood tracking: User is prompted for mood when writing a new journal entry.
// - Mood is saved, loaded, and displayed with each entry.

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string input = "";

        while (input != "5")
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");
            input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveName = Console.ReadLine();
                    journal.SaveToFile(saveName);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadName = Console.ReadLine();
                    journal.LoadFromFile(loadName);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option.\n");
                    break;
            }
        }
    }
}
