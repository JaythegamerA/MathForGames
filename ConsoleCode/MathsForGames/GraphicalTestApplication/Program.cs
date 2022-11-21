using MathLibrary;
using Raylib_cs;
using Tanks;
using TankProject;


public class Program
{

    private static List<Shell> shell = new List<Shell>();
    private static List<Shell> pendingshell = new List<Shell>();

    public static void Instantiate(Shell newShell)
    {
        pendingshell.Add(newShell);
    }

    static int Main()
    {

        const int screenW = 800;
        const int screenH = 515;

        Raylib.InitWindow(screenW, screenH, "TankProject");
        Raylib.SetTargetFPS(60);

        Tank tank = new Tank();
        tank.localPosition = new Vector3(100, 100, 1);
        TankTurret turret = new TankTurret();
        turret.localPosition = tank.localPosition;

        turret.Parent = tank;

        
        while (!Raylib.WindowShouldClose())
        {
            tank.Update(Raylib.GetFrameTime());
            turret.Update(Raylib.GetFrameTime());

            foreach (var shell in shell)
            {
                shell.Update(Raylib.GetFrameTime());
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.GRAY);

            tank.Draw();

            turret.Draw();

            foreach (var shell in shell)
            {
                shell.Draw();
            }

            Raylib.EndDrawing();

            foreach (var pending in pendingshell)
            {
                shell.Add(pending);
            }

            pendingshell.Clear();
        }

        Raylib.CloseWindow();

        return 0;
    }
}