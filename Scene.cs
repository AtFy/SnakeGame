using System;
using System.Collections.Generic;


namespace SnakeGameplay
{
    public enum Unit
    {
        FreeSpace,
        Border,
        Fruit,
        Head,
        Body
    }
    class Scene
    {
        public Scene(in int sizeX, in int sizeY)
        {
            // Setting up userdata as the game field border sizes.
            SizeX = sizeX; 
            SizeY = sizeY;

            // Creating the game field and filling it up.
            _gameField = new Unit[SizeX, SizeY]; 
            for(int i = 0; i < SizeX; ++i)
            {
                for(int j = 0; j < SizeY; ++j)
                {
                    if (CheckIfBorder(i, j, SizeX, SizeY))
                    {
                        _gameField.SetValue(Unit.Border, i, j);
                    }
                    else
                    {
                        _gameField.SetValue(Unit.FreeSpace, i, j);
                    }
                        
                }
            }

            _head = new Head(sizeX, sizeY, _gameField);

            _bodies = new List<Body>();
            for (int i = 1; i < 4; ++i)
            {
                _bodies.Add(new Body(sizeX, sizeY, _gameField, segmentSequenceNumber: i));
            }

            CreateFruit();
        }

        public int SizeX { get; }
        public int SizeY { get; }

        private Unit[,] _gameField; //тут наверное стоит лист листов сделать????

        private Direction? _lastDirection = Direction.Up;

        private readonly Head _head;
        private List<Body> _bodies;

        // Frame update.
        public bool Update()
        {
            Console.Clear();
            if(!ScenePrinter.Print(SizeX, SizeY, _gameField))
            {
                CreateFruit();
            }
            ScenePrinter.PrintMovementDirection(_lastDirection, SizeX * 2);
            Console.SetCursorPosition(0, SizeY + 1);

            var newDirection = Input.GetDirection();
            if (!Input.IsOppositeDirection(newDirection, _lastDirection))
            {
                if (newDirection != null)
                {
                    _lastDirection = newDirection;
                }
            }

            // Move() returns false, if you collided the border, which causes defeat.
            if (!_head.Move(_gameField, _lastDirection, _bodies))
            {
                return false;
            }

            return true;
        }
        
        public static bool CheckIfBorder(in int x, in int y, in int sizeX, in int sizeY)
        {
            if(x == 0 || y == 0 || x == sizeX - 1 || y == sizeY - 1)
            {
                return true;
            }
            return false;
        }

        private void CreateFruit()
        {
            Random rnd = new Random();
            _gameField[rnd.Next(1, SizeX - 1), rnd.Next(1, SizeY - 1)] = Unit.Fruit;
        }
    }
}
