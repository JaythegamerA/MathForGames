using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace TankProject
{
    public class Tank : GameObject
    {
        //Texture
        Texture2D tankBody = Raylib.LoadTexture("res/tankBody.png");

        Vector3 velocity;
        Vector3 acceleration;

        float drag = 1.5f;

        //Updating the object
        protected override void OnUpdate(float deltaTime)
        {

            float speed = 20f;

            Vector3 moveWish = new Vector3(0, 0, 0);

            Vector3 direction = new Vector3(LocalTransform.m1, LocalTransform.m2, 0);

            Vector3.ClampMagnitude(direction, 1);


            //Movement and Rotation of the Tank
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                localRotation -= 0.2f * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                localRotation += 0.2f * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                moveWish += direction + velocity * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                moveWish -= direction - velocity * deltaTime;
            }


            //Clamping Magnitude
            moveWish = Vector3.ClampMagnitude(moveWish, 1);


            //Setting Acceleration and Velocity
            acceleration = moveWish * speed;

            velocity += acceleration * deltaTime;

            velocity *= 1f - deltaTime * drag;


            //Applying movement
            localPosition += velocity * deltaTime;
        }

        protected override void OnDraw()
        {
            //Drawing the things
            Matrix3 myTransform = GlobalTransform;
            Vector3 pos = myTransform.GetTranslation();

            //Drawing Rotation
            float rot = MathF.Atan2(myTransform.m2, myTransform.m1) * MathUtils.Rad2Deg;

            //Setting up origin point
            Vector2 origin = new Vector2(28, 24);


            //Drawing Tankl
            Raylib.DrawTexturePro(tankBody, new Rectangle(56f, 48f, 56f, 48f), new Rectangle(localPosition.x, localPosition.y, 56, 48), new System.Numerics.Vector2(origin.x, origin.y), rot, Color.WHITE);
        }
    }
}