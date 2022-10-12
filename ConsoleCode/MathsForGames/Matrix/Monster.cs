using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace Matrix
{
    public class Monster : SpriteObject
    {

        protected override void OnUpdate(float deltaTime)
        {
            //  TODO: Implement me!
            float xMove = 0.0f;
            float yMove = 0.0f;

            float spriteScalar = 0.0f;

            float rotationAngle = 0.0f;

            const float ROTATESPEED = 1f;

            const float MOVESPEED = 20.0f;

            //  check for input

            //
            //  Translation
            //

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                xMove -= MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                xMove += MOVESPEED * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                yMove -= MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                yMove += MOVESPEED * deltaTime;
            }

            //
            //  Rotation
            //

            //  Rotate counter-clockwise
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                rotationAngle += ROTATESPEED * deltaTime;
            }

            //  Rotate clockwise
            if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                rotationAngle -= ROTATESPEED * deltaTime;

            }

            //
            //  Scaling
            //

            //  Scale up:
            if (Raylib.IsKeyDown(KeyboardKey.KEY_FOUR))
            {
                spriteScalar += 1 * deltaTime;
            }

            //  Scale down:
            if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE))
            {
                spriteScalar -= 1 * deltaTime;
            }


            //  apply the movement / rotation / scaling
            Translate(xMove, yMove);
            Rotate(rotationAngle);
            Scale(spriteScalar, spriteScalar);


            //  F to make your minion pay respect
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                GameObject minion = GameObjectFactory.MakeSprite("res/chort.png");
                Program.AddRootGameObject(minion);
                minion.Parent = this;
                children.Add(minion);
                minion.LocalPosition = LocalPosition;
            }
        }
    }
}