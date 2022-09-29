using Raylib_cs;
using MathLibrary;

namespace Vectors
{
    public class Program
    {
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static int Main()
        {
            //initialize
            const int screenWidth = 800;
            const int screenHeight = 450;

            gameObjects.Add(new Player(10f, screenWidth, screenHeight));
            gameObjects.Add(new Enemy(new Vector3(500, 200, 0), 10f, new Vector3(1, 0, 0)));

            Raylib.InitWindow(screenWidth, screenHeight, "My MathLibrary in Raylib");
            Raylib.SetTargetFPS(60);


            //game loop
            while (!Raylib.WindowShouldClose())
            {
                //update

                foreach (GameObject obj in gameObjects)
                {
                    obj.Update();
                }

                //draw
                //drawing objects to the screen
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);

                foreach (GameObject obj in gameObjects)
                {
                    obj.Draw();
                }

                Raylib.EndDrawing();

            }

            //deinitialize
            //aka cleanup
            Raylib.CloseWindow();

            return 0;
        }
    }
}