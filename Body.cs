
namespace SnakeGameplay
{
    class Body
    {
        public Body(in int fieldSizeX, in int fieldSizeY, Unit[,] gameField, in int segmentSequenceNumber)
        {
            X = ( (fieldSizeX) / 2 ) + segmentSequenceNumber;
            Y = ( (fieldSizeY) / 2 );
            Create(gameField);
        }

        public Body(int x, int y, Unit[,] gameField)
        {
            X = x;
            Y = y;
            Create(gameField);
        }
        public int X { get; set; }
        public int Y { get; set; }
        private void Create(Unit[,] gameField)
        {
            gameField[X, Y] = Unit.Body; 
        }
        public void Move(Unit[,] gameField, ref int headX, ref int headY)
        {
            int tempX = X;
            int tempY = Y;

            X = headX;
            Y = headY;
            Create(gameField);

            headX = tempX;
            headY = tempY;
        }

        public void Delete(Unit[,] gameField)
        {
            gameField[X, Y] = Unit.FreeSpace;
        }
        

    }
}
