using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Vectors
{
    public class Ball : GameObject
    {
        private Vector3 velocity;
        private float speed;

        public Ball(Vector3 velocity, float radius, float speed, int screenWidth, int screenHeight)
        {
            this.velocity = velocity;
            this.radius = radius;
            this.speed = speed;

            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            this.position = new Vector3(10, 10, 0);
        }

        public override void Update()
        {
            position += (velocity * speed) * Raylib_cs.Raylib.GetFrameTime();
            //bounces
            //check position +/-r
            //if position +/- r exceeds the boundaries of the window, update velocity
            //if collide with top/bottom, flip y value
            //if collide with left/right, flip x value
            //check upper or lower bounds
            if (position.y - radius <= 0 || position.y + radius >= screenHeight)
            {
                velocity.y = -velocity.y;
            }
            //check left/right bounds
            if (position.x - radius <= 0 || position.x + radius >= screenWidth)
            {
                velocity.x = -velocity.x;
            }
        }

        public override void Draw()
        {
            Raylib_cs.Raylib.DrawCircle((int)position.x, (int)position.y, radius, Raylib_cs.Color.BLUE);
        }
    }
}