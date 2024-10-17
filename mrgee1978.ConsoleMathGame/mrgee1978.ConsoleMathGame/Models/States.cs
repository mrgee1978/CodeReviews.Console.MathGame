﻿namespace MathGame.Models
{
    internal class Game
    {
        public DateTime Date { get; set; }
        public GameType Type { get; set; }
        public GameDifficulty Difficulty { get; set; }
        public int Score { get; set; }
    }
    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        RandomGame,
    }

    internal enum GameDifficulty
    {
        Easy,
        Medium,
        Hard,
    }
}