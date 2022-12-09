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

        // Converting key into specific direction.
        public static Direction GetDirection()
        {

            GetKeyFromListenerAsync();
            Thread.Wait(1000);

            if(_key == ConsoleKey.A)
            {
                return Direction.Left;
            }
            if (_key == ConsoleKey.D)
            {
                return Direction.Right;
            }
            if (_key == ConsoleKey.S)
            {
                return Direction.Down;
            }
            return Direction.Up;
        }
        public static bool CheckIfOppositeDirection(Direction newDirection, Direction lastDirection)
        {
            if(newDirection == Direction.Up)
            {
                if (lastDirection == Direction.Down)
                {
                    return true;
                }
                return false;
            }
            if (newDirection == Direction.Down)
            {
                if (lastDirection == Direction.Up)
                {
                    return true;
                }
                return false;
            }
            if (newDirection == Direction.Left)
            {
                if (lastDirection == Direction.Right)
                {
                    return true;
                }
                return false;
            }
                if (lastDirection == Direction.Left)
                {
                    return true;
                }
                return false;
        }

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
       
    }
}
