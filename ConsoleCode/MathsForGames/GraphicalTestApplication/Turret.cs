using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;
using GameFramework;
using TankProject;
using GraphicalTestApplication;

namespace Tanks
{

    public class TankTurret : SpriteObject
    {

      
        private void MakeTurret()
        {
            
            TankTurret turret = (TankTurret)GameObjectFactory.MakeTurret("res/turret.png");
          
            turret.origin = new Vector3(0, 0.5f, 0.5f);
           
            turret.Parent = this;
            turret.localPosition = localPosition;
        }
        private void FireShell()
        {
            Shell newShell = (Shell)GameObjectFactory.FireShell("res/bullet.png");

            newShell.localPosition = GlobalTransform.GetTranslation();

            newShell.Translate(GlobalTransform.m1 * this.sprite.width, GlobalTransform.m2 * this.sprite.width);

            newShell.localRotation = -MathUtils.AngleFrom2D(GlobalTransform.m1, GlobalTransform.m2);
           
        }
        protected override void OnUpdate(float deltaTime)
        {

            float rotationAngle = 0.0f;
            
            const float ROTATESPEED = 1f;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                rotationAngle += ROTATESPEED * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                rotationAngle -= ROTATESPEED * deltaTime;
            }

            Rotate(rotationAngle);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                FireShell();
            }
        }
    }
}