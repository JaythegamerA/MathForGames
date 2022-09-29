using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathLibrary;
using Raylib_cs;

namespace Vectors
{
    public class Player : GameObject
    {
        public Player(float radius, int screenWidth, int screenHeight)
        {
            this.radius = radius;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void Backstab(Enemy other)
        {
            //if the dot product of the player and the Enemy is 1
            if (normalVector.Dot(other.Normal) == 1)
            {
                //BACK STAB THE BOI
                Raylib.DrawCircle(0, 0, 50f, Color.BLACK);
            }
            //otherwise do nothing
        }

        public override void Update()
        {

            //TODO implement BACKSTAB
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                if (Raylib.CheckCollisionCircles(new System.Numerics.Vector2(position.x, position.y), radius,
                                                    new System.Numerics.Vector2(Program.gameObjects[1].Position.x, Program.gameObjects[1].Position.y),
                                                    Program.gameObjects[1].Radius * 2.5f))
                {
                    if (normalVector.Dot(Program.gameObjects[1].Normal) >= 0.707f)
                    {
                        Raylib.DrawCircle(0, 0, 50f, Color.BLACK);
                    }
                }
            }

            //keyboard input for WASD
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.x -= 1;
                this.normalVector.x = -1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.x += 1;
                this.normalVector.x = 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.y -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.y += 1;
            }

            //check position +/-r
            //if position +/- r exceeds the boundaries of the window
            //update position component with corresponding boundary
            //if collide with top/bottom, y value to the opposite boundary +/- r
            //if collide with left/right, x value to the opposite boundary +/- r
            //check upper bounds
            if (position.y < 0 - radius)
            {
                position.y = screenHeight + radius;
            }
            //check lower bounds
            if (position.y > screenHeight + radius)
            {
                position.y = 0 - radius;
            }
            //check left bounds
            if (position.x < 0 - radius)
            {
                position.x = screenWidth + radius;
            }
            //check right bounds
            if (position.x > screenWidth + radius)
            {
                position.x = 0 - radius;
            }
        }

        public override void Draw()
        {
            Raylib.DrawCircle((int)position.x, (int)position.y, radius, Color.BLUE);
            Raylib.DrawLine((int)position.x, (int)position.y, (int)(position.x + (radius * normalVector.x)), (int)(position.y + (radius * normalVector.y)), Color.GREEN);

        }
    }
}