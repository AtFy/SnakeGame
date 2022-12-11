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

            _head = new Head(this);

            _bodies = new List<Body>();
            for (int i = 1; i < 4; ++i)
            {
                _bodies.Add(new Body(this, segmentSequenceNumber: i));
            }

            CreateFruit();
        }

        public int SizeX { get; }
        public int SizeY { get; }

        private Unit[,] _gameField;
        private Direction _lastDirection = Direction.Up;
        private Head _head;
        private List<Body> _bodies;

        // Frame update.
        public void Update()
        {
            Console.Clear();
            ScenePrinter.Print(this);
            ScenePrinter.PrintMovementDirection(this);
            Console.SetCursorPosition(0, SizeY + 1);

            if (!CheckIfFruitExist())
            {
                CreateFruit();
            }

            var newDirection = Input.GetDirection();
            if (!Input.CheckIfOppositeDirection(this, newDirection))
            {

                _lastDirection = newDirection;
            }

            _head.Move(this);
        }
        public bool CheckIfSnakeAlive()
        {
            return _head.IsAlive;
        }
        public Unit GetThisSectorElement(int x, int y)
        {
            return _gameField[x, y];
        }
        public void SetElement(int x, int y, Unit unit)
        {
            _gameField[x, y] = unit;
        }
        public static bool CheckIfBorder(in int x, in int y, in int sizeX, in int sizeY)
        {
            if(x == 0 || y == 0 || x == sizeX - 1 || y == sizeY - 1)
            {
                return true;
            }
            return false;
        }
        public Direction GetCurrentDirection()
        {
            return _lastDirection;
        }
        public List<Body> GetBodies()
        {
            return _bodies;
        }

        private void CreateFruit()
        {
            Random rnd = new Random();
            int fruitX, fruitY;

            while (true)
            {
                fruitX = rnd.Next(1, SizeX - 1);
                fruitY = rnd.Next(1, SizeY - 1);
                if (GetThisSectorElement(fruitX, fruitY) != Unit.Body &&
                GetThisSectorElement(fruitX, fruitY) != Unit.Head)
                {
                    SetElement(fruitX, fruitY, Unit.Fruit);
                    return;
                }
            }
        }
        private bool CheckIfFruitExist()
        {
            for (int i = 0; i < SizeX; ++i)
            {
                for (int j = 0; j < SizeY; ++j)
                {
                    if(_gameField[i, j] == Unit.Fruit)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
