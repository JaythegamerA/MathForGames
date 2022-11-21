﻿using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace TankProject
{
    public class Tank : GameObject
    {
       
        Texture2D tankBody = Raylib.LoadTexture("res/tankBody.png");

        Vector3 velocity;
        Vector3 acceleration;

        float drag = 5.5f;

     
        protected override void OnUpdate(float deltaTime)
        {

            float speed = 85f;

            Vector3 moveWish = new Vector3(0, 0, 0);

            Vector3 direction = new Vector3(LocalTransform.m1, LocalTransform.m2, 0);

            Vector3.ClampMagnitude(direction, 1);

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                localRotation -= 0.5f * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                localRotation += 0.5f * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                moveWish += direction + velocity * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                moveWish -= direction - velocity * deltaTime;
            }

            moveWish = Vector3.ClampMagnitude(moveWish, 1);

            acceleration = moveWish * speed;

            velocity += acceleration * deltaTime;

            velocity *= 1f - deltaTime * drag;

            localPosition += velocity * deltaTime;
        }

        protected override void OnDraw()
        {
            Matrix3 myTransform = GlobalTransform;
            Vector3 pos = myTransform.GetTranslation();

            float rot = MathF.Atan2(myTransform.m2, myTransform.m1) * MathUtils.Rad2Deg;

            Vector2 origin = new Vector2(28, 24);

            Raylib.DrawTexturePro(tankBody, new Rectangle(56f, 48f, 56f, 48f), new Rectangle(localPosition.x, localPosition.y, 56, 48), new System.Numerics.Vector2(origin.x, origin.y), rot, Color.RED);
        }
    }
}