using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements:
        // Added automatic date recording for every entry.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();

                Entry newEntry = new Entry();

                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._date = DateTime.Now.ToShortDateString();

                journal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
           else if (choice == 3)
            {
                try
                {
                    Console.Write("What is the filename? ");
                    string file = Console.ReadLine();

                    journal.LoadFromFile(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading file.");
                    Console.WriteLine(ex.Message);
                }
            }
            else if (choice == 4)
            {
                try
                {
                    Console.Write("What is the filename? ");
                    string file = Console.ReadLine();

                    journal.SaveToFile(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving file.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}