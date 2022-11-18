using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

using GameFramework;

namespace Tanks
{
    public static class GameObjectFactory
    {
        public static GameObject MakeTank(string pathToSprite)
        {
            Tank newTank = new Tank();
            if (!File.Exists(pathToSprite))
            {
                throw new FileNotFoundException("File not found at path: " + pathToSprite);
            }

            newTank.sprite = Raylib.LoadTexture(pathToSprite);

            return newTank;
        }

        public static GameObject MakeTurret(string pathToSprite)
        {
            TankTurret newTurret = new TankTurret();
            if (!File.Exists(pathToSprite))
            {
                throw new FileNotFoundException("File not found at path: " + pathToSprite);
            }

            newTurret.sprite = Raylib.LoadTexture(pathToSprite);

            return newTurret;
        }

        public static GameObject FireShell(string pathToSprite)
        {
            TankShell newShell = new TankShell();
            if (!File.Exists(pathToSprite))
            {
                throw new FileNotFoundException("File not found at path: " + pathToSprite);
            }

            newShell.sprite = Raylib.LoadTexture(pathToSprite);

            return newShell;
        }

        
    }
}