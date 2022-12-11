using System;
using System.Collections.Generic;


namespace SnakeGameplay
{
    class Head
    {
        public Head(Scene scene)
        {
            IsAlive = true;
            X = (scene.SizeX) / 2;
            Y = (scene.SizeY) / 2;
            Create(scene);

        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { set; get; }

        private double LastTailTile { get; set; }
        private void Create(Scene scene)
        {
            scene.SetElement(X, Y, Unit.Head);
        }

        // Move() just moves the snake's head across the field. Replaces previous head location with a Unit.FreeSpace.
        // Move() returns false, if you collided the border or your tail, which causes defeat.
        public void Move(Scene scene)
        {
            if (scene.GetCurrentDirection() == Direction.Up)
            {
                DeleteCurrentHead(scene, out int lastX, out int lastY);
                X -= 1;
                MoveHeadTail(scene, lastX, lastY);
            }

            if (scene.GetCurrentDirection() == Direction.Down)
            {
                DeleteCurrentHead(scene, out int lastX, out int lastY);
                X += 1;
                MoveHeadTail(scene, lastX, lastY);
            }

            if (scene.GetCurrentDirection() == Direction.Left)
            {
                DeleteCurrentHead(scene, out int lastX, out int lastY);
                Y -= 1;
                MoveHeadTail(scene, lastX, lastY);
            }

            if (scene.GetCurrentDirection() == Direction.Right)
            {
                DeleteCurrentHead(scene, out int lastX, out int lastY);
                Y += 1;
                MoveHeadTail(scene, lastX, lastY);
            }
        }

        private void MoveHeadTail(Scene scene, int lastX, int lastY)
        {
            List<Body> bodies = scene.GetBodies();

            if (!CheckIfCanMove(scene))
            {
                IsAlive = false;
            }
            LastTailTile = bodies[bodies.Count - 1].X + (bodies[bodies.Count - 1].Y * 0.1);
            CheckIfFruitConsumed(scene);

            for (int i = 0; i < bodies.Count; ++i)
            {
                bodies[i].Delete(scene);
                bodies[i].Move(scene, ref lastX, ref lastY);
            }
            scene.SetElement(X, Y, Unit.Head);
        }
        private void DeleteCurrentHead(Scene scene, out int lastX, out int lastY)
        {
            scene.SetElement(X, Y, Unit.FreeSpace);

            lastX = X;
            lastY = Y;
        }
        private bool CheckIfCanMove(Scene scene)
        {
            List<Body> bodies = scene.GetBodies();
            Direction direction = scene.GetCurrentDirection();

            if(X == bodies[bodies.Count - 1].X && Y == bodies[bodies.Count - 1].Y)
            {
                return true;
            }

            if (direction == Direction.Down || direction == Direction.Right)
            {
                if (!Scene.CheckIfBorder(X, Y, scene.SizeX, scene.SizeY) && scene.GetThisSectorElement(X, Y) != Unit.Body)
                {
                    return true;
                }
                return false;
            }

            if (!Scene.CheckIfBorder(X, Y, scene.SizeX, scene.SizeY) && scene.GetThisSectorElement(X, Y) != Unit.Body)
            {
                return true;
            }
            return false;

        }
        private void CheckIfFruitConsumed(Scene scene)
        {
            if(scene.GetThisSectorElement(X, Y) == Unit.Fruit)
            {
                List<Body> bodies = scene.GetBodies();
                bodies.Add(new Body(scene, Convert.ToInt32(LastTailTile), Convert.ToInt32((LastTailTile * 10d) % 10)));
            }
        }
    }
}
