﻿using System;
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
            GameField = new Unit[SizeX, SizeY]; 
            for(int i = 0; i < SizeX; ++i)
            {
                for(int j = 0; j < SizeY; ++j)
                {
                    if (CheckIfBorder(i, j, SizeX, SizeY))
                    {
                        GameField.SetValue(Unit.Border, i, j);
                    }
                    else
                    {
                        GameField.SetValue(Unit.FreeSpace, i, j);
                    }
                        
                }
            }

            _head = new Head(sizeX, sizeY, GameField);

            _bodies = new List<Body>();
            for (int i = 1; i < 4; ++i)
            {
                _bodies.Add(new Body(sizeX, sizeY, GameField, segmentSequenceNumber: i));
            }

            CreateFruit();
        }

        public int SizeX { get; }
        public int SizeY { get; }

        public Unit[,] GameField;

        private Direction? _lastDirection = Direction.Up;

        private Head _head;
        private List<Body> _bodies;

        // Frame update.
        public bool Update()
        {
            Console.Clear();
            ScenePrinter.Print(this);
            ScenePrinter.PrintMovementDirection(_lastDirection, SizeX * 2);
            Console.SetCursorPosition(0, SizeY + 1);

            if (!CheckIfFruit())
            {
                CreateFruit();
            }

            var newDirection = Input.GetDirection();
            if (!Input.IsOppositeDirection(newDirection, _lastDirection))
            {
                if (newDirection != null)
                {
                    _lastDirection = newDirection;
                }
            }

            // Move() returns false, if you collided the border, which causes defeat.
            if (!_head.Move(GameField, _lastDirection, _bodies))
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
            GameField[rnd.Next(1, SizeX - 1), rnd.Next(1, SizeY - 1)] = Unit.Fruit;
        }

        private bool CheckIfFruit()
        {
            for (int i = 0; i < SizeX; ++i)
            {
                for (int j = 0; j < SizeY; ++j)
                {
                    if(GameField[i, j] == Unit.Fruit)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
