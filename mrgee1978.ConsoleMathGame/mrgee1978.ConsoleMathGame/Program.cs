using System;
using MathGame.Models;

namespace MathGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name = Helpers.GetValidName();
            Console.WriteLine("Please press any key to continue: ");
            Console.ReadLine();
            Console.Clear();
            Menu.InitialMessage(name);
            GameEngine gameEngine = new GameEngine();
            List<Game> games = new List<Game>();
            GameDifficulty gameDifficulty;
            string choice = string.Empty;
            bool isPlayGame = true;

            do
            {
                Menu.GameMenu();
                choice = Console.ReadLine();
                choice = choice.Trim().ToUpper();


                switch (choice)
                {
                    case "A":
                        gameDifficulty = Menu.DifficultyMenu();
                        Console.Clear();
                        gameEngine.PlayMathGame(GameType.Addition, gameDifficulty);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "S":
                        gameDifficulty = Menu.DifficultyMenu();
                        Console.Clear();
                        gameEngine.PlayMathGame(GameType.Subtraction, gameDifficulty);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "M":
                        gameDifficulty = Menu.DifficultyMenu();
                        Console.Clear();
                        gameEngine.PlayMathGame(GameType.Multiplication, gameDifficulty);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "D":
                        gameDifficulty = Menu.DifficultyMenu();
                        Console.Clear();
                        gameEngine.PlayMathGame(GameType.Division, gameDifficulty);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "R":
                        gameDifficulty = Menu.DifficultyMenu();
                        Console.Clear();
                        gameEngine.PlayMathGame(GameType.RandomGame, gameDifficulty);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "V":
                        games = gameEngine.GetGames();
                        Helpers.DisplayGames(games);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "Q":
                        Console.WriteLine("Good bye!");
                        isPlayGame = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                }

            } while (isPlayGame);


        }
    }
}

