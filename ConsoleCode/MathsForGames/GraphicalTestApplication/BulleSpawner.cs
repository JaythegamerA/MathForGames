using GameFramework;
using MathLibrary;
using Raylib_cs;

namespace TankProject
{
    public static class BulletSpawner
    {
        public static Bullet SpawnBullet(string pathToBulletSprite)
        {
            Bullet newBullet = new Bullet();

            //The program throws an error if it can't find the bullet sprite
            if (!File.Exists(pathToBulletSprite))
            {
                throw new Exception("File not found at path: " + pathToBulletSprite);
            }

            newBullet.sprite = Raylib.LoadTexture(pathToBulletSprite);

            return newBullet;
        }
    }
}