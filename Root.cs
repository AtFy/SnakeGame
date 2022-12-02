
namespace SnakeGameplay
{
    class Root
    {
        static void Main()
        {
            // Must be NOT an even.
            int sizeX = 15;
            int sizeY = 15;

            Menu.Show();
            Scene scene = new Scene(sizeX, sizeY);

            // scene.Update() returns false if the snake collided the border its tail which causes defeat.
            while (scene.Update())
            {
                
            }

            Menu.ShowGameOver();


        }
    }
}