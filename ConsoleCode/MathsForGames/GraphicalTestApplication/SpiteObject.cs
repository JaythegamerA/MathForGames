using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameFramework;
using MathLibrary;
using Raylib_cs;

namespace Tanks
{
    public class SpriteObject : GameObject
    {
        public Texture2D sprite;

        public Vector3 origin = new Vector3(0.5f, 0.5f, 0.5f);

        protected override void OnDraw()
        {
            // calculate the local transform matrix
            Matrix3 myTransform = GlobalTransform;
            //extracts the x axis vector and y axis vector, then stores the magnitude of each as the x and y component
            //of a scale vector2
            Vector2 scale = new Vector2(new Vector2(GlobalTransform.m1, GlobalTransform.m2).Magnitude,
                new Vector2(GlobalTransform.m4, GlobalTransform.m5).Magnitude);

            // extract the position
            Vector3 pos = myTransform.GetTranslation();

            // draw the sprite
            Raylib.DrawTexturePro(
                //  texture to draw 
                sprite,
                //  source rect: 0,0, width, height of portion you want drawn
                new Rectangle(0, 0, (float)sprite.width, (float)sprite.height),
                //destination: portion of the screen: start point x, y, width, height (SCALING * width/height)
                new Rectangle(pos.x, pos.y, sprite.width * scale.x, sprite.height * scale.y),
                //origin: pivot point: default top left corner, for middle origin: half of destination width/height
                new System.Numerics.Vector2(origin.x * sprite.width * scale.x, origin.y * sprite.height * scale.y),
                //rotation              `
                MathU.AngleFrom2D(GlobalTransform.m1, GlobalTransform.m2) * MathU.RadiansToDegrees,
                //tint                  `
                Color.WHITE
                );
        }
    }
}