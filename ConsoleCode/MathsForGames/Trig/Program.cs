using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;

public class Program
{

    public static void DrawCircle(int centerX, int centerY, int radius, Color color, int lineSegments = 24)
    {
        //how many lines make up this circle

        //angle between each corner of the circle
        float stepSize = (2 * MathF.PI) / lineSegments;


        //generate the "circle"
        for (int i = 0; i < lineSegments; i++)
        {
            int startPointX = (int)(radius * MathF.Cos(i * stepSize));
            int startPointY = (int)(radius * MathF.Sin(i * stepSize));

            int endPointX = (int)(radius * MathF.Cos(stepSize * (i + 1)));
            int endPointY = (int)(radius * MathF.Sin(stepSize * (i + 1)));

            //Raylib.DrawCircle(centerX + startPointX, centerY + startPointY, 1.0f, Color.BLUE);
            Raylib.DrawLine(centerX + startPointX, centerY + startPointY, centerY + endPointX, centerY + endPointY, color);
        }
    }

    public static int[] GetCirclePoints(int centerX, int centerY, int radius, int lineSegments, float offset = 0.0f)
    {
        int[] points = new int[lineSegments * 2];

        //angle between each corner of the circle
        float stepSize = (2 * MathF.PI) / lineSegments;


        //generate the "circle"
        for (int i = 0; i < lineSegments; i++)
        {
            int startPointX = (int)(radius * MathF.Cos(i * stepSize + offset));
            int startPointY = (int)(radius * MathF.Sin(i * stepSize + offset));

            points[(i * 2)] = startPointX + centerX;
            points[(i * 2) + 1] = startPointY + centerY;
        }
        return points;
    }

    public static int Main()
    {
        //initialize
        const int screenWidth = 800;
        const int screenHeight = 450;

        Raylib.InitWindow(screenWidth, screenHeight, "Trig in Raylib");
        Raylib.SetTargetFPS(60);

        Texture2D texDog = Raylib.LoadTexture(@"res/dog.png");

        float linePosX = screenWidth / 2;
        float linePosY = screenHeight / 2;

        float angle = 0.0f;


        Vector2 initialPos = new Vector2();
        initialPos.X = linePosX;
        initialPos.Y = linePosY;

        Vector2 finalPos = new Vector2();
        finalPos.X = linePosX;
        finalPos.Y = linePosY;


        //game loop
        while (!Raylib.WindowShouldClose())
        {
            //update
            angle += Raylib.GetFrameTime();

            float offsetX = MathF.Sin(angle);
            float offsetY = MathF.Cos(angle);

            finalPos.X += offsetX;
            finalPos.Y += offsetY;

            int[] points = GetCirclePoints(200, 200, 60, 4, (float)Raylib.GetTime());

            //spawning a circle

            //draw
            //drawing objects to the screen
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DARKGRAY);

            Raylib.DrawLine((int)initialPos.X, (int)initialPos.Y, (int)finalPos.X, (int)finalPos.Y, Color.BLACK);
            Raylib.DrawTexture(texDog, 100, 100, Color.GRAY);

            DrawCircle(200, 200, 60, Color.RED);

            for (int i = 0; i < points.Length / 2; i++)
            {
                Raylib.DrawCircle(points[i * 2], points[(i * 2) + 1], 10, Color.BROWN);
            }

            Raylib.EndDrawing();

            initialPos.X += offsetX;
            initialPos.Y += offsetY;
        }

        //deinitialize
        //aka cleanup
        Raylib.CloseWindow();

        return 0;
    }
}