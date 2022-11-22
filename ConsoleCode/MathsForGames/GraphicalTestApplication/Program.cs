using MathLibrary;
using Raylib_cs;
using TankProject;


public class Program
{

    private static List<Shell> shell = new List<Shell>();
    private static List<Shell> upcomingshell = new List<Shell>();

    public static void Instantiate(Shell newShell)
    {
        upcomingshell.Add(newShell);
    }

    static int Main()
    {

        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW*2, screenH*2, "TankProject");
        Raylib.SetTargetFPS(60);

        Tank tank = new Tank();
        tank.localPosition = new Vector3(200, 200, 2);
        Turret turret = new Turret();
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

            foreach (var pending in upcomingshell)
            {
                shell.Add(pending);
            }

            upcomingshell.Clear();
        }

        Raylib.CloseWindow();

        return 0;
    }
}