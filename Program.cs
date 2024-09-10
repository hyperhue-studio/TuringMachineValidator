using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("TURING MACHINE");
        Console.WriteLine("Available alphabet: 0, 1.");

        // Prompt for required prefix and minimum length
        Console.Write("Enter the required prefix (e.g., '0001'): ");
        string requiredPrefix = Console.ReadLine();

        Console.WriteLine("----------------------------------------------------------------------");
        Console.Write("Enter the minimum length of the word: ");
        int minLength;
        while (!int.TryParse(Console.ReadLine(), out minLength) || minLength < requiredPrefix.Length)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"ERROR - Minimum length must be an integer and at least {requiredPrefix.Length}. TRY AGAIN.");
            Console.Write("Enter the minimum length of the word: ");
        }

        int attempts = 0;
        bool validWord = false;

        while (!validWord)
        {
            Console.WriteLine("----------------------------------------------------------------------");

            attempts++;
            Console.WriteLine("Attempt #" + attempts);

            Console.Write("Enter a word (RegEx): ");
            string word = Console.ReadLine();

            // Validate minimum length
            if (word.Length < minLength)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($"ERROR - The word must be at least {minLength} characters long. TRY AGAIN WITH A DIFFERENT WORD");
                continue;
            }

            // Check if the word starts with the required prefix
            bool startsWithPrefix = true;
            for (int i = 0; i < requiredPrefix.Length; i++)
            {
                if (i >= word.Length || word[i] != requiredPrefix[i])
                {
                    startsWithPrefix = false;
                    break;
                }
            }

            if (!startsWithPrefix)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($"ERROR - The word must start with '{requiredPrefix}'. TRY AGAIN WITH A DIFFERENT WORD");
                continue;
            }

            // Validate the remaining characters
            bool validRest = true;
            for (int i = requiredPrefix.Length; i < word.Length; i++)
            {
                if (word[i] != '0')
                {
                    validRest = false;
                    break;
                }
            }

            // If the word meets all conditions
            if (validRest)
            {
                validWord = true;
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("ERROR - The word does NOT meet the specified format. TRY AGAIN WITH A DIFFERENT WORD");
            }
        }

        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("The word DOES meet the specified format.");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
