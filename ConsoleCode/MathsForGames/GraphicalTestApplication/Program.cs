using Raylib_cs;
using GameFramework;
using Tanks;
using TankProject;
using MathLibrary;

public class Program
{

    private static List<Shell> bullets = new List<Shell>();
    private static List<Shell> pendingBullets = new List<Shell>();
    private static List<Shell> killBullets = new List<Shell>();

    public static void Instantiate(Shell newBullet)
    {
        pendingBullets.Add(newBullet);
    }

    public static void Destroy(Shell toDestroy)
    {
        killBullets.Add(toDestroy);
    }

    static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 600;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Tank Project");
        Raylib.SetTargetFPS(60);

        Tank tank = new Tank();
        tank.localPosition = new Vector3(100, 100, 1);
        TankTurret turret = new TankTurret();
        turret.localPosition = tank.localPosition;

        turret.Parent = tank;

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            tank.Update(Raylib.GetFrameTime());
            turret.Update(Raylib.GetFrameTime());

            foreach (var bullet in bullets)
            {
                bullet.Update(Raylib.GetFrameTime());
            }

            // Draw Stuff
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            tank.Draw();

            turret.Draw();

            foreach (var bullet in bullets)
            {
                bullet.Draw();
            }


            Raylib.EndDrawing();

            //Destroy Bullets
            foreach (var kill in killBullets)
            {
                bullets.Remove(kill);
            }
            killBullets.Clear();

            //Process pending bullets
            foreach (var pending in pendingBullets)
            {
                bullets.Add(pending);
            }

            pendingBullets.Clear();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}

