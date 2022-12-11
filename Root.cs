
namespace SnakeGameplay
{
    class Root
    {
        static void Main()
        {
            // Must be NOT an even.
            int sizeX = 15;
            int sizeY = 15;

            if(sizeX % 2 == 0)
            {
                ++sizeX;
            }
            if(sizeY % 2 == 0)
            {
                ++sizeY;
            }

            Menu.Show();
            var scene = new Scene(sizeX, sizeY);

            while (scene.CheckIfSnakeAlive())
            {
                scene.Update();
            }

            Menu.ShowGameOver();
        }
    }
}