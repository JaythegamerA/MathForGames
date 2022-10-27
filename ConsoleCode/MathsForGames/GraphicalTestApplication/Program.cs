using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace TankProject
{
    public class Program
    {

        private static List<Bullet> bullets = new List<Bullet>();
        private static List<Bullet> pendingBullets = new List<Bullet>();
        private static List<Bullet> killBullets = new List<Bullet>();

        public static void Instantiate(Bullet newBullet)
        {
            pendingBullets.Add(newBullet);
        }

        public static void Destroy(Bullet toDestroy)
        {
            killBullets.Add(toDestroy);
        }

        static int Main()
        {
            // Initializing - LOAD THE THINGS
            const int screenW = 800;
            const int screenH = 450;

            Raylib.InitWindow(screenW, screenH, "Tank Demo");
            Raylib.SetTargetFPS(60);

            Tank tank = new Tank();
            tank.localPosition = new Vector3(100, 100, 1);
            Turret turret = new Turret();
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
}