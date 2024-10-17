using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {
        static List<Game> games = new List<Game>();
        internal void PlayMathGame(GameType type, GameDifficulty difficulty)
        {
            int count = 0;
            int correctAnswer = 0;
            int[] operands = new int[2];
            string strAnswer = string.Empty;
            int userAnswer = 0;
            bool isCorrect = false;
            GameType gameType = type;
            Game game = new Game()
            {
                Date = DateTime.Now,
                Type = type,
                Score = count,
                Difficulty = difficulty,
            };


            for (int i = 0; i < 5; i++)
            {
                if (type == GameType.RandomGame)
                {
                    Random random = new Random();
                    int randomTypeNumber = random.Next(0, 3);
                    gameType = (GameType)randomTypeNumber;
                }
                if (gameType == GameType.Division)
                {
                    operands = Helpers.GetDivisionOperands(difficulty);
                }
                else
                {
                    operands = Helpers.GetOperandsByDifficulty(difficulty);
                }
                switch (gameType)
                {
                    case GameType.Addition:
                        correctAnswer = operands[0] + operands[1];
                        break;
                    case GameType.Subtraction:
                        correctAnswer = operands[0] - operands[1];
                        break;
                    case GameType.Multiplication:
                        correctAnswer = operands[0] * operands[1];
                        break;
                    case GameType.Division:
                        correctAnswer = operands[0] / operands[1];
                        break;
                }
                Helpers.DisplayMathQuestion(gameType, operands[0], operands[1]);
                strAnswer = Console.ReadLine();
                userAnswer = Helpers.GetValidAnswer(strAnswer);
                isCorrect = IsAnswerCorrect(userAnswer, correctAnswer);
                count += DisplayCorrectOrNot(isCorrect);
                Console.WriteLine("Press any key to continue: ");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Game over! Correct: {count}");
            game.Score = count;
            games.Add(game);
        }
        internal Boolean IsAnswerCorrect(int userAnswer, int correctAnswer)
        {
            return userAnswer == correctAnswer;
        }

        internal int DisplayCorrectOrNot(bool gotCorrect)
        {
            if (gotCorrect)
            {
                Console.WriteLine("Correct!");
                return 1;
            }
            else
            {
                Console.WriteLine("Incorrect!");
                return 0;
            }
        }

        internal List<Game> GetGames()
        {
            return games;
        }
    }
}
