
namespace SnakeGameplay
{
    class Body
    {
        public Body(Scene scene, in int segmentSequenceNumber)
        {
            X = ((scene.SizeX) / 2) + segmentSequenceNumber;
            Y = ((scene.SizeY) / 2);
            Create(scene);
        }
        public Body(Scene scene, int x, int y)
        {
            X = x;
            Y = y;
            Create(scene);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Move(Scene scene, ref int headX, ref int headY)
        {
            int tempX = X;
            int tempY = Y;

            X = headX;
            Y = headY;
            Create(scene);

            headX = tempX;
            headY = tempY;
        }
        public void Delete(Scene scene)
        {
            scene.SetElement(X, Y, Unit.FreeSpace);
        }

        private void Create(Scene scene)
        {
            scene.SetElement(X, Y, Unit.Body);
        }
    }
}
