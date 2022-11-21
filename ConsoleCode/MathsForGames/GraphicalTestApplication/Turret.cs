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

        Texture2D turretSprite = Raylib.LoadTexture("res/turret.png");
        protected override void OnUpdate(float deltaTime)
        {
            localPosition = parent.localPosition;

            Vector3 direction = new Vector3(LocalTransform.m1, LocalTransform.m2, 0);

            Vector3 ShellOffset = new Vector3();

            ShellOffset = localPosition + direction * 20;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                localRotation += 1 * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                localRotation -= 1 * deltaTime;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Shell shell = ShellSpawner.SpawnShell("res/bullet.png");
                shell.localPosition = ShellOffset;
                shell.localRotation = localRotation * MathUtils.Rad2Deg;
                shell.targetDirection = direction;

                Program.Instantiate(shell);
            }
        }

        protected override void OnDraw()
        {
            Matrix3 myTransform = LocalTransform;
            Matrix3 tankTransform = GlobalTransform;
            Vector2 origin = new Vector2(9, 9);

            float rot = MathF.Atan2(myTransform.m2, myTransform.m1) * MathUtils.Rad2Deg;

            Raylib.DrawTexturePro(turretSprite, new Rectangle(26, 18, 26, 18), new Rectangle(localPosition.x, localPosition.y, 26, 18), new System.Numerics.Vector2(origin.x, origin.y), rot, Color.WHITE);
        }
    }
}