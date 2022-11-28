using Raylib_cs;
using MathLibrary;
using GameFramework;
using System.Threading;

namespace TankProject
{
    public class Tank : GameObject
    {
       
        Texture2D tankBody = Raylib.LoadTexture("res/tankBody.png");

        Vector3 velocity;
        protected override void OnUpdate(float deltaTime)
        {

  
            Vector3 moveWish = new Vector3(0, 0, 0);

            Vector3 direction = new Vector3(LocalTransform.m1, LocalTransform.m2, 0);

            float moveX = 0.0f;
            float moveY = 0.0f;
            float rotationAngle = 0.0f;
            const float ROTATESPEED = 3.5f;
            const float MOVESPEED = 20.0f;


            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                 rotationAngle -= ROTATESPEED * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
               rotationAngle += ROTATESPEED * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                moveX += MathF.Cos(localRotation) * MOVESPEED * deltaTime;
                moveY -= MathF.Sin(localRotation) * MOVESPEED * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                moveX -= MathF.Cos(localRotation) * MOVESPEED * deltaTime;
                moveY += MathF.Sin(localRotation) * MOVESPEED * deltaTime;
            }

            moveWish = Vector3.ClampMagnitude(moveWish, 2);

            localPosition += velocity * deltaTime;

            Translate(moveX, moveY);
            Rotate(rotationAngle);
        }

        protected override void OnDraw()
        {
            Matrix3 myTransform = GlobalTransform;
            Vector3 pos = myTransform.GetTranslation();

            float rot = MathF.Atan2(myTransform.m2, myTransform.m1) * MathU.Rad2Deg;

            Vector2 origin = new Vector2(28, 24);

            Raylib.DrawTexturePro(tankBody, new Rectangle(56f, 48f, 56f, 48f), new Rectangle(localPosition.x, localPosition.y, 56, 48), new System.Numerics.Vector2(origin.x, origin.y), rot, Color.RED);
        }
    }
}