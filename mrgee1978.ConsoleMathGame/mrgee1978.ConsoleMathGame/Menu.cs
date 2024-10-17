using MathGame.Models;

namespace MathGame
{
    internal class Menu
    {
        static string lineSeparator = "=======================================================================";
        static DateTime displayDate = DateTime.Now;

        internal static void InitialMessage(string name)
        {
            Console.WriteLine($"Hello {name}, today is {displayDate.DayOfWeek} Welcome to the Math Game. I hope that you have fun!");
            Console.WriteLine("Press any key to display the main menu");
            Console.ReadKey();
        }

        internal static void GameMenu()
        {
            string menuMessage = $@"What game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random Game
V - View Previous Games
Q - Quit the program";
            Console.Clear();
            Console.WriteLine(lineSeparator);
            Console.WriteLine(menuMessage);
            Console.WriteLine(lineSeparator);
        }

        internal static GameDifficulty DifficultyMenu()
        {
            string message = $@"These are the levels of difficulty:
1 - Easy
2 - Medium
3 - Hard

Please choose the level of difficulty
";
            Console.WriteLine(message);
            string answer = Console.ReadLine();
            int choice = Helpers.GetValidAnswer(answer);

            while (choice < 1 || choice > 3)
            {
                Console.WriteLine(message);
                answer = Console.ReadLine();
                choice = Helpers.GetValidAnswer(answer);
            }

            if (choice == 1)
            {
                return GameDifficulty.Easy;
            }
            else if (choice == 2)
            {
                return GameDifficulty.Medium;
            }
            else
            {
                return GameDifficulty.Hard;
            }

        }
    }
}
