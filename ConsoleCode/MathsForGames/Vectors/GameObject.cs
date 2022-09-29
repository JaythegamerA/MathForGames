using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathLibrary;

namespace Vectors
{

    public class GameObject
    {
        //direction vector
        protected Vector3 normalVector;

        public Vector3 Normal
        {
            get { return normalVector; }
        }

        protected float radius;//for storing the radius of the object

        public float Radius
        {
            get { return radius; }
        }

        protected Vector3 position;

        public Vector3 Position
        {
            get { return position; }
        }
        protected int screenWidth;
        protected int screenHeight;

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}