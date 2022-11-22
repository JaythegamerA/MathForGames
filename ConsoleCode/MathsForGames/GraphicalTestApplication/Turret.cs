using MathLibrary;
using Raylib_cs;
using GameFramework;
using GraphicalTestApplication;

namespace TankProject
{
    public class Turret : GameObject
    {

        Texture2D turretSprite = Raylib.LoadTexture("res/turret.png");
        protected override void OnUpdate(float deltaTime)
        {
            localPosition = parent.localPosition;

            Vector3 direction = new Vector3(LocalTransform.m1, LocalTransform.m2, 2);

            Vector3 shellOffset = new Vector3();

            shellOffset = localPosition + direction * 20;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_G))
            {
                localRotation += 3.5f * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_F))
            {
                localRotation -= 3.5f * deltaTime;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_H))
            {
                Shell shell = ShellSpawner.SpawnShell("res/shell.png");
                shell.localPosition = shellOffset;
                shell.localRotation = localRotation * MathU.Rad2Deg;
                shell.targetDirection = direction;
                 
                Program.Instantiate(shell);
            }
        }

        protected override void OnDraw()
        {
            Matrix3 myTransform = LocalTransform;
            Matrix3 tankTransform = GlobalTransform;
            Vector2 origin = new Vector2(9, 9);

            float rot = MathF.Atan2(myTransform.m2, myTransform.m1) * MathU.Rad2Deg;

            Raylib.DrawTexturePro(turretSprite, new Rectangle(26, 18, 26, 18), new Rectangle(localPosition.x, localPosition.y, 26, 18), new System.Numerics.Vector2(origin.x, origin.y), rot, Color.BLUE);
        }
    }
}