using System.Collections.Generic;
using System;

namespace SnakeGameplay
{
    class Head
    {
        public Head(in int fieldSizeX, in int fieldSizeY, Unit[,] gameField)
        {
            X = (fieldSizeX) / 2;
            Y = (fieldSizeY) / 2;
            Create(gameField);

        }
        public int X { get; set; }
        public int Y { get; set; }

        private double LastTailTile { get; set; }
        private void Create(Unit[,] gameField)
        {
            gameField[X, Y] = Unit.Head;
        }

        

        // Move() just moves the snake's head across the field. Replaces previous head location with a Unit.FreeSpace.
        // Move() returns false, if you collided the border or your tail, which causes defeat.
        public bool Move(Unit[,] gameField, Direction direction, List<Body> bodies)
        {
            switch (direction)
            {
                case Direction.Up:
                    gameField[X, Y] = Unit.FreeSpace;

                    int lastX = X;
                    int lastY = Y;
                    X -= 1;

                    if (CheckIfCanMove(gameField, direction, bodies))
                    {
                        LastTailTile = bodies[bodies.Count - 1].X + (bodies[bodies.Count - 1].Y * 0.1);
                        CheckIfFruitConsumed(gameField, bodies);
                        gameField[X, Y] = Unit.Head;

                        for (int i = 0; i < bodies.Count; ++i)
                        {
                            bodies[i].Delete(gameField);
                            bodies[i].Move(gameField, ref lastX, ref lastY);
                        }
                        return true;
                    }
                    return false;

                case Direction.Down:
                    gameField[X, Y] = Unit.FreeSpace;

                    lastX = X;
                    lastY = Y;
                    X += 1;

                    if (CheckIfCanMove(gameField, direction, bodies))
                    {
                        LastTailTile = bodies[bodies.Count - 1].X + (bodies[bodies.Count - 1].Y * 0.1);
                        CheckIfFruitConsumed(gameField, bodies);
                        gameField[X, Y] = Unit.Head;

                        for (int i = 0; i < bodies.Count; ++i)
                        {
                            bodies[i].Delete(gameField);
                            bodies[i].Move(gameField, ref lastX, ref lastY);
                        }
                        return true;
                    }
                    return false;

                case Direction.Left:
                    gameField[X, Y] = Unit.FreeSpace;

                    lastX = X;
                    lastY = Y;
                    Y -= 1;

                    if (CheckIfCanMove(gameField, direction, bodies))
                    {
                        LastTailTile = bodies[bodies.Count - 1].X + (bodies[bodies.Count - 1].Y * 0.1);
                        CheckIfFruitConsumed(gameField, bodies);
                        gameField[X, Y] = Unit.Head;

                        for (int i = 0; i < bodies.Count; ++i)
                        {
                            bodies[i].Delete(gameField);
                            bodies[i].Move(gameField, ref lastX, ref lastY);
                        }
                        return true;
                    }
                    return false;

                case Direction.Right:
                    gameField[X, Y] = Unit.FreeSpace;

                    lastX = X;
                    lastY = Y;
                    Y += 1;
                    
                    if (CheckIfCanMove(gameField, direction, bodies))
                    {
                        LastTailTile = bodies[bodies.Count - 1].X + (bodies[bodies.Count - 1].Y * 0.1);
                        CheckIfFruitConsumed(gameField, bodies);
                        gameField[X, Y] = Unit.Head;

                        for (int i = 0; i < bodies.Count; ++i)
                        {
                            bodies[i].Delete(gameField);
                            bodies[i].Move(gameField, ref lastX, ref lastY);
                        }
                        return true;
                    }
                    return false;
                
                default:
                    return true;
            }
        }

        private bool CheckIfCanMove(Unit[,] gameField, Direction direction, List<Body> bodies)
        {
            // TODO: Fix this UI bug.
            if(X == bodies[bodies.Count - 1].X && Y == bodies[bodies.Count - 1].Y)
            {
                return true;
            }

            if (direction == Direction.Down || direction == Direction.Right)
            {
                // Magic +1 appeared due to IsBorder() logic.
                if (!Scene.CheckIfBorder(X, Y, gameField.GetUpperBound(0) + 1, gameField.GetUpperBound(1) + 1) && gameField[X, Y] != Unit.Body)
                {
                    return true;
                }
                return false;
            }

            if (!Scene.CheckIfBorder(X, Y, gameField.GetUpperBound(0), gameField.GetUpperBound(1)) && gameField[X, Y] != Unit.Body)
            {
                return true;
            }
            return false;

        }
        private void CheckIfFruitConsumed(Unit[,] gameField, List<Body> bodies)
        {
            if(gameField[X,Y] == Unit.Fruit) // здесь добавить логику, сравнение координат последнего сегмента с предпоследним
            {
                bodies.Add(new Body(Convert.ToInt32(LastTailTile), Convert.ToInt32((LastTailTile * 10d) % 10), gameField));
            }
        }
    }
}
