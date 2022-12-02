using System;
using System.Threading.Tasks;
using ThreadExtensions;

namespace SnakeGameplay
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Enter
    }

    static class Input
    {
        private static ConsoleKey _key;

        // Input key listener async task.
        private static async Task<ConsoleKey> ListenKeyAsync()
        { 
            try
            {
                ConsoleKey key = default;
                await Task.Run(() => key = Console.ReadKey(true).Key);
                return key;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Asking a key from the listener when needed.
        private static async void GetKeyFromListenerAsync()
        {
           _key = await ListenKeyAsync();
        }

        // Converting key into specific direction.
        public static Direction? GetDirection()
        {

            GetKeyFromListenerAsync();
            Thread.Wait(1000);

            switch (_key)
            {
                case ConsoleKey.A:
                    return Direction.Left;

                case ConsoleKey.D:
                    return Direction.Right;

                case ConsoleKey.S:
                    return Direction.Down;

                case ConsoleKey.W:
                    return Direction.Up;

                case ConsoleKey.Enter:
                    return Direction.Enter;

                default:
                    return null;
            }
        }
        public static bool IsOppositeDirection(Direction? newDirection,Direction? lastDirection)
        {
            switch (newDirection)
            {
                case Direction.Up:
                    if(lastDirection == Direction.Down)
                    {
                        return true;
                    }
                    return false;

                case Direction.Down:
                    if(lastDirection == Direction.Up)
                    {
                        return true;
                    }
                    return false;

                case Direction.Left:
                    if (lastDirection == Direction.Right)
                    {
                        return true;
                    }
                    return false;

                case Direction.Right:
                    if (lastDirection == Direction.Left)
                    {
                        return true;
                    }
                    return false;

                default:
                    return false;
            }
        }
    }
}
