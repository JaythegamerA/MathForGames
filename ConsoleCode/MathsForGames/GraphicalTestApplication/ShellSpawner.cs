using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankProject;

namespace GraphicalTestApplication
{
    public static class ShellSpawner
    {
        public static Shell SpawnShell(string pathToShellSprite)
        {
            Shell newShell = new Shell();

          
            if (!File.Exists(pathToShellSprite))
            {
                throw new Exception("File not found at path: " + pathToShellSprite);
            }

            newShell.sprite = Raylib.LoadTexture(pathToShellSprite);

            return newShell;
        }
    }
}