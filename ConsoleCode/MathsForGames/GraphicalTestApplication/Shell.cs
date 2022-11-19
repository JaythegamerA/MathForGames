using MathLibrary;
using Raylib_cs;
using GameFramework;

namespace TankProject
{
    public class Shell : GameObject
    {

        float speed = 40f;
        internal Texture2D sprite;
        internal Vector3 targetDirection;

        protected override void OnUpdate(float deltaTime)
        {
            LocalPosition += targetDirection * speed * deltaTime;

            if (LocalPosition.x < 0 || LocalPosition.y < 0 || LocalPosition.x > 800 || LocalPosition.y > 450)
            {
                Program.Destroy(this);
            }
        }
        protected override void OnDraw()
        {
            Raylib.DrawTexturePro(sprite, new Rectangle(16, 12, 16, 12), new Rectangle(LocalPosition.x, LocalPosition.y, 16, 12), new System.Numerics.Vector2(8, 6), LocalRotation, Color.WHITE);
        }
    }

}
