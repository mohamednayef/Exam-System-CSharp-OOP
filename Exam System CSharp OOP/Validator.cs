using System.Reflection.Metadata.Ecma335;

namespace Exam_System_CSharp_OOP;

public static class Validator
{
    // 1. validate string
    public static string GetValidString(string message, int min, int max)
    {
        while (true)
        {
            Console.WriteLine(message);
        
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be null or empty. Please try again.");
                continue;
            }

            if (input.Length < min || input.Length > max)
            {
                Console.WriteLine($"Input must be between {min} and {max}. Please try again.");
                continue;
            }
            return input;
        }
    }
    
    // 2. validate integer
    public static int GetValidInt(string message, int min, int max)
    {
        while (true)
        {
            Console.WriteLine(message);
        
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be null or empty. Please try again.");
                continue;
            }

            if (int.TryParse(input, out int result) == false)
            {
                Console.WriteLine("Input must be valid integer. Please try again.");
                continue;
            }

            if (result < min || result > max)
            {
                Console.WriteLine($"Input must be between {min} and {max}. Please try again.");
                continue;
            }
            return result;
        }
    }
}