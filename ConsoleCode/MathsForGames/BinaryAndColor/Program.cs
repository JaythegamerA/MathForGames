using Raylib_cs;

public class Program
{
    public static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Raylib");
        Raylib.SetTargetFPS(60);

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update

            // Draw
            Raylib.BeginDrawing();

            Raylib.EndDrawing();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}