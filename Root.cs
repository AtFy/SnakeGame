
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

            // scene.Update() returns false if the snake collided the border its tail which causes defeat.
            while (scene.Update())
            {
                
            }
            Menu.ShowGameOver();
        }
    }
}