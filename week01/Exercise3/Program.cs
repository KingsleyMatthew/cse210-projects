using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate random magic number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            Console.WriteLine($"What is the magic number? {magicNumber}");
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number!");

            // Loop until user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Display number of guesses
            Console.WriteLine($"You guessed the number in {guessCount} tries.");

            // Ask to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}