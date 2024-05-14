using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static part4_2048.Board;

namespace part4_2048
{
    public static class ConsoleGame
    {
        public static Direction GetDirectionInput()
        {
            PrintDirections();
            string direction = Console.ReadLine();
            Console.WriteLine(direction);
            switch (direction) 
            {
                case "w":
                    return Direction.Up;
                case "s":
                    return Direction.Down;
                case "a":
                    return Direction.Left;
                case "d":
                    return Direction.Right;
                default:
                    Console.WriteLine("Not a valid input, try again");
                    return GetDirectionInput();

            }
        }
        private static void PrintDirections()
        {
            Console.WriteLine("Enter direction: ");
            Console.WriteLine("        w  ");
            Console.WriteLine("      a s d");
        }
        public static void ShowPoints(int Points) 
        {
            Console.WriteLine($"Points: {Points}");
        }
        public static void ShowBoard(int[,] data)
        {
            for (int i = 0; i < data.GetLength(0) * 2; i++)
            {
                for (int j = 0; j < data.GetLength(0) * 2; j++)
                {
                    if(i % 2 == 0) 
                    {
                        if (j % 2 == 0)
                            Console.Write(FillStringToFourChars($"{data[i / 2, j / 2]}"));
                        else
                            Console.Write("|");
                    }
                    else
                    {
                        if (j % 2 == 0)
                            Console.Write("----");
                        else
                            Console.Write("-");
                    }

                }
                Console.WriteLine();

            }
        }
        public static string FillStringToFourChars(string input)
        {
            if (input == "0")
                input = " ";
            while (input.Length < 4) 
            {
                input += " ";
            }
            return input;
        }

        public static bool GameOverOutput(GameStatus gameStatus, int points,
            int highScore)
        {
            switch (gameStatus)
            {
                case GameStatus.Win:
                    Console.WriteLine($"good job! points: {points}");
                    break;
                default:
                    Console.WriteLine($"no more room! you lost!");
                    break;
            }
            Console.WriteLine($"highest score: {highScore}");

            Console.WriteLine($"would youi like to play again? [y/n] ");  
            return Console.ReadLine().ToLower() == "y";
        }
    
    }
}
