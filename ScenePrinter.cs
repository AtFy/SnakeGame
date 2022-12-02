using System;

namespace SnakeGameplay
{
    static class ScenePrinter
    {
        // Print the frame according to the game field state.
        public static bool Print(in int sizeX, in int sizeY, Unit[,] gameField)
        {
            bool isHasFruit = false;
            for (int i = 0; i < sizeX; ++i)
            {
                for (int j = 0; j < sizeY; ++j)
                {
                    switch (gameField.GetValue(i, j))
                    {
                        case Unit.FreeSpace:
                            Console.Write("  ");
                            break;
                        case Unit.Border:
                            Console.Write("#");
                            if (i == 0 || i == sizeX - 1 || j == 0)
                            {
                                Console.Write(" ");
                            }
                            break;
                        case Unit.Head:
                            Console.Write("o ");
                            break;
                        case Unit.Body:
                            Console.Write("x ");
                            break;
                        case Unit.Fruit:
                            Console.Write("F ");
                            isHasFruit = true;
                            break;
                    }

                }
                Console.WriteLine();
            }
            return isHasFruit;
        }

        public static void PrintMovementDirection(Direction? direction, int sizeX)
        {
            switch(direction)
            {
                case Direction.Up:
                    for (int i = 5; i < 10; ++i)
                    {
                        Console.SetCursorPosition(sizeX + 25, i);
                        Console.Write("|");
                    }

                    Console.SetCursorPosition(sizeX + 24, 5);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 23, 6);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 22, 7);
                    Console.Write("/");

                    Console.SetCursorPosition(sizeX + 26, 5);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 27, 6);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 28, 7);
                    Console.Write("\\");
                    break;

                case Direction.Down:
                    for (int i = 5; i < 10; ++i)
                    {
                        Console.SetCursorPosition(sizeX + 25, i);
                        Console.Write("|");
                    }

                    Console.SetCursorPosition(sizeX + 24, 9);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 23, 8);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 22, 7);
                    Console.Write("\\");

                    Console.SetCursorPosition(sizeX + 26, 9);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 27, 8);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 28, 7);
                    Console.Write("/");
                    break;

                case Direction.Left:
                    for (int i = sizeX + 20; i < sizeX + 30; ++i)
                    {
                        Console.SetCursorPosition(i, 7);
                        Console.Write("-");
                    }
                    
                    Console.SetCursorPosition(sizeX + 20, 6);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 21, 5);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 22, 4);
                    Console.Write("/");

                    Console.SetCursorPosition(sizeX + 20, 8);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 21, 9);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 22, 10);
                    Console.Write("\\");
                    break;

                case Direction.Right:
                    for (int i = sizeX + 20; i < sizeX + 30; ++i)
                    {
                        Console.SetCursorPosition(i, 7);
                        Console.Write("-");
                    }

                    Console.SetCursorPosition(sizeX + 29, 6);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 28, 5);
                    Console.Write("\\");
                    Console.SetCursorPosition(sizeX + 27, 4);
                    Console.Write("\\");

                    Console.SetCursorPosition(sizeX + 29, 8);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 28, 9);
                    Console.Write("/");
                    Console.SetCursorPosition(sizeX + 27, 10);
                    Console.Write("/");
                    break;

            }
        }
    }
}
