using MathLibrary;
using Raylib_cs;
using GameFramework;

namespace TankProject
{
    public class Shell : GameObject
    {

        float speed = 40f;


        protected override void OnUpdate(float deltaTime)
        {
            localPosition += targetDirection * speed * deltaTime;

            if (localPosition.x < 0 || localPosition.y < 0 || localPosition.x > 800 || localPosition.y > 450)
            {
                Program.Destroy(this);
            }
        }
        protected override void OnDraw()
        {
            Raylib.DrawTexturePro(sprite, new Rectangle(16, 12, 16, 12), new Rectangle(localPosition.x, localPosition.y, 16, 12), new System.Numerics.Vector2(8, 6), localRotation, Color.WHITE);
        }
    }

}
