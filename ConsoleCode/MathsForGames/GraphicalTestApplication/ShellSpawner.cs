using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankProject;

namespace GraphicalTestApplication
{
    public static class BulletSpawner
    {
        public static Shell SpawnShell(string pathToShellSprite)
        {
            Shell newShellt = new Shell();

            //The program throws an error if it can't find the bullet sprite
            if (!File.Exists(pathToShellSprite))
            {
                throw new Exception("File not found at path: " + pathToShellSprite);
            }

            newShellt.sprite = Raylib.LoadTexture(pathToShellSprite);

            return newShellt;
        }
    }
}