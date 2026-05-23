using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        // Exceeding requirements:
        // This program uses a library of scriptures and selects one randomly.

        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding in all your ways submit to him and he will make your paths straight."
            ),

            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."
            )
        };

        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(selectedScripture.GetDisplayText());

            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());

        Console.WriteLine("\nProgram ended.");
    }
}
