using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector2
    {
        public float x, y;

        //3 parameter constructor
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float Magnitude
        {
            get
            {
                return MathF.Sqrt((x * x) + (y * y));
            }
        }

        public void Normalize()
        {
            x = x / Magnitude;
            y = y / Magnitude;
        }

        public Vector2 Normalized
        {
            get
            {
                return new Vector2(x / Magnitude, y / Magnitude);
            }
        }

        public void Scale(Vector2 rhs)
        {
            x = rhs.x * x;
            y = rhs.y * y;
        }

        public Vector2 Scaled(Vector2 rhs)
        {
            return new Vector2(rhs.x * x, rhs.y * y);
        }

        //operations:
        //  addition
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            Vector2 result = new Vector2();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;
            return result;
        }

        //  subtraction
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            Vector2 result = new Vector2();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;
            return result;
        }

        //  negation
        public static Vector2 operator -(Vector2 rhs)
        {
            Vector2 result = new Vector2();
            result.x = rhs.x * -1.0f;
            result.y = rhs.y * -1.0f;
            return result;
        }

        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }
        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
        }
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }

        //equality comparisons
        //  ==
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            //if the difference of each component is less than twice the float.Epsilon, consider them equal
            if (MathF.Abs(lhs.x - rhs.x) < (float.Epsilon)
                && MathF.Abs(lhs.y - rhs.y) < (float.Epsilon))
            {
                return true;
            }
            //otherwise, they are not equal
            else
            {
                return false;
            }
        }

        //  !=
        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }

        //override the default ToString implementation
        public override string ToString()
        {
            return "{ " + x + "(x) " + y + "(y) }";
        }
    }
}