using Raylib_cs;
using GameFramework;
using Tanks;
using TankProject;
using MathLibrary;

public class Program
{

    private static List<Shell> bullets = new List<Shell>();
    private static List<Shell> pendingBullets = new List<Shell>();


    public static void Instantiate(Shell newBullet)
    {
        pendingBullets.Add(newBullet);
    }

  
    static int Main()
    {
     
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Tank Project");
        Raylib.SetTargetFPS(60);

        Tank tank = new Tank();
        tank.localPosition = new Vector3(100, 100, 10);
        TankTurret turret = new TankTurret();
        turret.localPosition = tank.localPosition;

        turret.Parent = tank;

     
        while (!Raylib.WindowShouldClose())
        {
            tank.Update(Raylib.GetFrameTime());
            turret.Update(Raylib.GetFrameTime());

            foreach (var bullet in bullets)
            {
                bullet.Update(Raylib.GetFrameTime());
            }

         
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            tank.Draw();

            turret.Draw();

            foreach (var bullet in bullets)
            {
                bullet.Draw();
            }

            Raylib.EndDrawing();

            
        }

        Raylib.CloseWindow();

        return 0;
    }
}

