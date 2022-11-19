using Raylib_cs;
using GameFramework;
using Tanks;
using TankProject;

public class Program
{
    private static List<GameObject> gameObjects = new List<GameObject>();
    private static List<GameObject> targets = new List<GameObject>();
    private static List<GameObject> projectiles = new List<GameObject>();

    private static List<GameObject> pendingObjects = new List<GameObject>();
    private static List<GameObject> pendingProjectiles = new List<GameObject>();

    private static List<GameObject> killObjects = new List<GameObject>();


    //  used for adding game objects to the gameObjects list
    public static void AddRootGameObject(GameObject newGameObject)
    {
        pendingObjects.Add(newGameObject);
    }

    //  used for adding projectiles to the projectile list
    public static void AddProjectile(GameObject newProjectile)
    {
        pendingProjectiles.Add((Shell)newProjectile);
    }

    public static void Destroy(GameObject toDestroy)
    {
        killObjects.Add(toDestroy);
    }

    public static int Main()
    {
      
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Tank Projcet");
        Raylib.SetTargetFPS(60);

        
        bool isPaused = false;

        gameObjects.Add(GameObjectFactory.MakeTank("res/tankBody.png"));


      
        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update GAMEPLAY
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
            {
                isPaused = !isPaused;
            }

            if (!isPaused)
            {
               
                foreach (var go in gameObjects)
                {
                    go.Update(Raylib.GetFrameTime());
                }

                
                foreach (var go in projectiles)
                {
                    go.Update(Raylib.GetFrameTime());
                }

                
                }
            }

            // Draw GAMEPLAY
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            foreach (var go in gameObjects)
            {
                go.Draw();
            }

         

            foreach (var go in projectiles)
            {
                go.Draw();
            }

            Raylib.EndDrawing();

            
            foreach (var kill in killObjects)
            {
                gameObjects.Remove(kill);
                targets.Remove(kill);
                projectiles.Remove(kill);
            }
            killObjects.Clear();

            // Add all objects that are waiting to be alive
            foreach (var pending in pendingObjects)
            {
                gameObjects.Add(pending);
            }
            pendingObjects.Clear();

            foreach (var pending in pendingProjectiles)
            {
                projectiles.Add((Shell)pending);
            }
            pendingProjectiles.Clear();


         Raylib.CloseWindow();
                return 0;
    }

    internal static void Instantiate(Shell shell)
    {
        throw new NotImplementedException();
    }
}

