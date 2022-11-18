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
            
            Matrix3 myTransform = GlobalTransform;
           
            Vector2 scale = new Vector2(new Vector2(GlobalTransform.m1, GlobalTransform.m2).Magnitude,
                new Vector2(GlobalTransform.m4, GlobalTransform.m5).Magnitude);

          
            Vector3 pos = myTransform.GetTranslation();

            
            Raylib.DrawTexturePro(
            
                sprite,
                
                new Rectangle(0, 0, (float)sprite.width, (float)sprite.height),
         
                new Rectangle(pos.x, pos.y, sprite.width * scale.x, sprite.height * scale.y),
                
                new System.Numerics.Vector2(origin.x * sprite.width * scale.x, origin.y * sprite.height * scale.y),
               
                MathUtils.AngleFrom2D(GlobalTransform.m1, GlobalTransform.m2) * MathUtils.RadiansToDegrees,
              
                Color.WHITE
                );
        }
    }
}