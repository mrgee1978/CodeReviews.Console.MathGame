using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        internal static string GetValidName()
        {
            string name = string.Empty;
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Please enter a valid name: ");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static int GetValidAnswer(string strAnswer)
        {
            int answer = 0;

            while (!int.TryParse(strAnswer, out answer))
            {
                Console.WriteLine("Answer is invalid! Try again: ");
                strAnswer = Console.ReadLine();
            }

            return answer;
        }

        internal static int[] GetDivisionOperands(GameDifficulty difficulty)
        {
            int starting;
            int ending;

            if (difficulty == GameDifficulty.Easy)
            {
                starting = 1;
                ending = 10;
            }
            else if (difficulty == GameDifficulty.Medium)
            {
                starting = 10;
                ending = 100;
            }
            else if (difficulty == GameDifficulty.Hard)
            {
                starting = 100;
                ending = 1000;
            }
            else
            {
                return null;
            }

            Random random = new Random();
            int firstNumber = random.Next(starting, ending);
            int secondNumber = random.Next(starting, ending);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(starting, ending);
                secondNumber = random.Next(starting, ending);
            }

            return new int[] { firstNumber, secondNumber };
        }

        internal static int[] GetOperandsByDifficulty(GameDifficulty difficulty)
        {
            Random random = new Random();
            int starting;
            int ending;

            if (difficulty == GameDifficulty.Easy)
            {
                starting = 1;
                ending = 10;
            }
            else if (difficulty == GameDifficulty.Medium)
            {
                starting = 10;
                ending = 100;
            }
            else if (difficulty == GameDifficulty.Hard)
            {
                starting = 100;
                ending = 1000;
            }
            else
            {
                starting = 0;
                ending = 0;
            }

            return new int[] { random.Next(starting, ending), random.Next(starting, ending) };
        }

        internal static void DisplayMathQuestion(GameType type, int firstNumber, int secondNumber)
        {
            char oper = ' ';
            switch (type)
            {
                case GameType.Addition:
                    oper = '+';
                    break;
                case GameType.Subtraction:
                    oper = '-';
                    break;
                case GameType.Multiplication:
                    oper = '*';
                    break;
                case GameType.Division:
                    oper = '/';
                    break;
            }
            Console.WriteLine($"{firstNumber} {oper} {secondNumber}");
        }

        internal static void DisplayGames(List<Game> games)
        {
            if (games.Count == 0)
            {
                Console.WriteLine("No games have been played yet. Nothing to display.");
            }
            else
            {
                foreach (Game game in games)
                {
                    Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty} - {game.Score} pts");
                }
            }
            Console.WriteLine();
        }
    }
}
