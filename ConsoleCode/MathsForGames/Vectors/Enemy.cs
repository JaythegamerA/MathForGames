using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathLibrary;
using Raylib_cs;

namespace Vectors
{
    public class Enemy : GameObject
    {
        public Enemy(Vector3 position, float radius, Vector3 direction)
        {
            this.position = position;
            this.radius = radius;
            this.normalVector = direction.Normalized;
        }

        public override void Update()
        {
            //todo
            //implement enemy FOV and "lose" state
            //dot product result
        }
        public override void Draw()
        {
            Raylib.DrawCircle((int)position.x, (int)position.y, radius, Color.RED);
            Raylib.DrawLine((int)position.x, (int)position.y, (int)(position.x + (radius * normalVector.x)), (int)(position.y + (radius * normalVector.y)), Color.GREEN);

        }
    }
}