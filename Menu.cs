﻿using System;
using ThreadExtensions;

namespace SnakeGameplay
{
    static class Menu
    {
        public static void Show()
        {

            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine("Press ENTER to start!");
                input = Console.ReadKey();
                Console.Clear();
            } while (input.Key != ConsoleKey.Enter);

            for (int i = 3; i > 0; --i)
            {
                Console.WriteLine($"Game starts in {i}...");
                Thread.Wait(500);
            }
            Console.Clear();
        }

        public static void ShowGameOver()
        {
            Console.Clear();
            Console.Write("Game Over! You looser!");

            Thread.Wait(2000);

            Console.Write(" Ha! >:P");

            Thread.Wait(2000);

            Console.Write("\n" +
                "\n________________________________________████________________________________" +
                "\n____________________________________████▒▒██________________________________" +
                "\n__________________________________████__▒▒██________________________________" +
                "\n________________________________██▒▒__▒▒▒▒▒▒██______________________________" +
                "\n______________________________██▒▒██________██______________________________" +
                "\n__████______________________██▒▒██__________██______________________________" +
                "\n██▒▒▒▒██████________________██▒▒██______▒▒__████____________________________" +
                "\n██▒▒▒▒██____████______██████▒▒▒▒▒▒██____▒▒▒▒██████████████__________________" +
                "\n██▒▒____████▒▒▒▒██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒████______________" +
                "\n██▒▒▒▒______██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒██____________" +
                "\n__██▒▒______██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████________" +
                "\n__██________██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██______" +
                "\n__██▒▒____██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██____" +
                "\n__██▒▒▒▒__▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒__██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██____" +
                "\n____██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒____██▒▒▒▒▒▒▒▒▒▒████▒▒▒▒▒▒▒▒██__" +
                "\n____████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██______██▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒██__" +
                "\n____██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██________██▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██__" +
                "\n______██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██________██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██__" +
                "\n______██▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██______██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██" +
                "\n________████__▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒____██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██" +
                "\n__________██____▒▒██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒____██▒▒__▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██" +
                "\n__________██____________████▒▒▒▒▒▒▒▒▒▒____██__▒▒__▒▒________▒▒▒▒▒▒▒▒▒▒▒▒██__" +
                "\n____________██______________________██__████__▒▒__________▒▒▒▒▒▒▒▒▒▒▒▒▒▒██__" +
                "\n______________██______________________██▒▒██______________▒▒__▒▒▒▒▒▒▒▒▒▒██__" +
                "\n________________██████████████████████▒▒▒▒██____________________▒▒▒▒▒▒██____" +
                "\n______________________██▒▒______██▒▒▒▒▒▒▒▒██____________________▒▒▒▒██______" +
                "\n______________________██▒▒▒▒__██▒▒▒▒▒▒▒▒████__________________▒▒▒▒██________" +
                "\n______________________██▒▒▒▒▒▒██▒▒▒▒▒▒██__██____________________██__________" +
                "\n________________________██████▒▒▒▒▒▒██____██________________████____________" +
                "\n______________________________██████______██__________██████________________" +
                "\n____________________________________________██____████______________________" +
                "\n____________________________________________██████__________________________");

            Thread.Wait(2000);
        }
    }
}
