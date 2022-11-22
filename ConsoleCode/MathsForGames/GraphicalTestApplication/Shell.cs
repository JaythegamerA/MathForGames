﻿using MathLibrary;
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

        }
        protected override void OnDraw()
        {
            Raylib.DrawTexturePro(sprite, new Rectangle(16, 12, 16, 12), new Rectangle(localPosition.x, localPosition.y, 18, 14), new System.Numerics.Vector2(10, 8), localRotation, Color.YELLOW);
        }
    }

}
