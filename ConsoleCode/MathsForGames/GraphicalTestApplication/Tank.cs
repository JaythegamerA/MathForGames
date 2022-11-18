using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace Tanks
{
    public class Tank : SpriteObject
    {
        
        private void AddTurret()
        {
            TankTurret turret = (TankTurret)GameObjectFactory.MakeTurret("res/turret.png");
            
            
            turret.LocalPosition = LocalPosition;
        }
        protected override void OnUpdate(float deltaTime)
        {
            if (ChildCount == 0)
            {
                AddTurret();
            }

            //
            //  Parameters
            //
            float moveX = 0.0f;
            float moveY = 0.0f;
            float rotationAngle = 0.0f;
            const float ROTATESPEED = 1f;
            const float MOVESPEED = 20.0f;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                rotationAngle += ROTATESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                rotationAngle -= ROTATESPEED * deltaTime;
            }
         
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                moveX += MathF.Cos(LocalRotation) * MOVESPEED * deltaTime;
                moveY -= MathF.Sin(LocalRotation) * MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                moveX -= MathF.Cos(LocalRotation) * MOVESPEED * deltaTime;
                moveY += MathF.Sin(LocalRotation) * MOVESPEED * deltaTime;
            }

            

            Translate(moveX, moveY);
            Rotate(rotationAngle);
        }
    }
}