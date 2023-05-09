using System;
using System.Collections.Generic;
using System.Linq;

namespace SimonConsole
{
    class Program
    {
        static List<string> pattern = new List<string>(); // List to store the generated pattern
        static List<string> playerPattern = new List<string>(); // List to store the player's input pattern
        static Random random = new Random(); // Random object for generating random numbers
        static int level = 1; // Variable to keep track of the game level
        static bool gameover = false; // Variable to determine if the game is over

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simon Game!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();

            while (!gameover)
            {
                GeneratePattern(); // Generate a new pattern
                ShowPattern(); // Show the generated pattern to the player
                GetPlayerInput(); // Get input from the player
                CheckPlayerInput(); // Check if the player's input matches the generated pattern
                if (!gameover)
                    level++; // Increase the level if the player's input was correct
            }

            Console.WriteLine($"Game Over! You made it to level: {level}. Press any key to exit...");
            Console.ReadKey();
        }

        static void GeneratePattern()
        {
            int randomNumber = random.Next(0, 4); // Generate a random number between 0 and 4
            string color = "";

            switch (randomNumber)
            {
                case 0:
                    color = "R"; // Assign "R" for red color
                    break;
                case 1:
                    color = "G"; // Assign "G" for green color
                    break;
                case 2:
                    color = "B"; // Assign "B" for blue color
                    break;
                case 3:
                    color = "Y"; // Assign "Y" for yellow color
                    break;
            }

            pattern.Add(color); // Add the generated color to the pattern list
        }

        static void ShowPattern()
        {
            Console.Clear();
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Watch the pattern:");
            Console.WriteLine();

            foreach (var color in pattern)
            {
                switch (color)
                {
                    case "R":
                        Console.BackgroundColor = ConsoleColor.Red;  // Set the background color to red
                        break;
                    case "G":
                        Console.BackgroundColor = ConsoleColor.Green; // Set the background color to green
                        break;
                    case "B":
                        Console.BackgroundColor = ConsoleColor.Blue; // Set the background color to blue
                        break;
                    case "Y":
                        Console.BackgroundColor = ConsoleColor.Yellow; // Set the background color to yellow
                        break;
                }

                Console.Write(" ");
                Console.ResetColor(); // Reset the background color
            }

            Console.WriteLine();
            System.Threading.Thread.Sleep(1000); // Pause for 1 second
            Console.Clear();
        }

        static void GetPlayerInput()
        {
            Console.WriteLine("Enter the pattern (e.g., RGBY): ");
            string input = Console.ReadLine();
            playerPattern = input.Select(c => c.ToString().ToUpper()).ToList(); // Convert player's input to uppercase and store it in the playerPattern list
        }

        static void CheckPlayerInput()
        {
            if (playerPattern.SequenceEqual(pattern)) // Check if the player's input matches the generated pattern
            {
                Console.WriteLine("Correct!");
                System.Threading.Thread.Sleep(1000); // Pause for 1 second
            }
            else
            {
                Console.WriteLine("Wrong!");
                gameover = true; // Set gameover to true if the player's input was incorrect
            }

            playerPattern.Clear();
        }
    }
}