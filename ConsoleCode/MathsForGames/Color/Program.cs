using Raylib_cs;
using MathLibrary;

namespace AIE
{
    public class Program
    {
        public static int Main()
        {
            // Initializing - LOAD THE THINGS
            const int screenW = 800;
            const int screenH = 450;

            Colour buttonColour = new Colour();

            Raylib.InitWindow(screenW, screenH, "Raylib");
            Raylib.SetTargetFPS(60);

            // Game Loop - PLAY THE GAME
            while (!Raylib.WindowShouldClose())
            {
                // Update

                // Draw
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.WHITE);

                buttonColour.Green = 100;
                buttonColour.Alpha = 100;
                buttonColour.Red = 00;



                if (Raylib.GetMousePosition().X >= 400 && Raylib.GetMousePosition().Y >= 225 && Raylib.GetMousePosition().X <= 450 && Raylib.GetMousePosition().Y <= 275)
                {
                    if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
                    {
                        buttonColour.Red = 100;
                        buttonColour.Alpha = 255;
                        buttonColour.Green = 00;
                    }
                }


                Raylib.DrawRectangle(400, 225, 50, 50, Raylib.GetColor(buttonColour.colour));
                Raylib.EndDrawing();
            }

            // Deinitializing - UNLOAD THE THINGS
            Raylib.CloseWindow();

            return 0;
        }
    }
}