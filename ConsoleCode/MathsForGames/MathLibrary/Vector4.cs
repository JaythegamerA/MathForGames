using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector4
    {
        public float x, y, z, w;

        //4 param constructor
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float Magnitude
        {
            get
            {
                return MathF.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
            }
        }

        public void Normalize()
        {
            this /= Magnitude;
        }

        public Vector4 Normalized
        {
            get
            {
                return new Vector4(x / Magnitude, y / Magnitude, z / Magnitude, w / Magnitude);
            }
        }

        public void Scale(Vector4 rhs)
        {
            x = rhs.x * x;
            y = rhs.y * y;
            z = rhs.z * z;
            w = rhs.w * w;
        }

        public Vector4 Scaled(Vector4 rhs)
        {
            return new Vector4(rhs.x * x, rhs.y * y, rhs.z * z, rhs.w * w);
        }

        //returns the dot product of 2 Vector4s
        public float Dot(Vector4 rhs)
        {
            return (this.x * rhs.x) + (this.y * rhs.y) + (this.z * rhs.z) + (this.w * rhs.w);
        }

        //returns the cross product of two Vector4s by finding the cross product of the 3rd Dimension subspaces of the Vector4s 
        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4((this.y * rhs.z) - (this.z * rhs.y),
                                (this.z * rhs.x) - (this.x * rhs.z),
                                (this.x * rhs.y) - (this.y * rhs.x), 0);
        }

        #region Operators
        //  addition
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;
            result.z = lhs.z + rhs.z;
            result.w = lhs.w + rhs.w;

            return result;
        }
        //  subtraction
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;
            result.z = lhs.z - rhs.z;
            result.w = lhs.w - rhs.w;

            return result;
        }
        //  negation
        public static Vector4 operator -(Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = -1 * rhs.x;
            result.y = -1 * rhs.y;
            result.z = -1 * rhs.z;
            result.w = -1 * rhs.w;

            return result;
        }
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }
        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        }
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        //equality comparisons
        //  ==
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            //if the difference of each component is less than twice the float.Epsilon, consider them equal
            if (MathF.Abs(lhs.x - rhs.x) < (float.Epsilon)
                && MathF.Abs(lhs.y - rhs.y) < (float.Epsilon)
                && MathF.Abs(lhs.z - rhs.z) < (float.Epsilon)
                && MathF.Abs(lhs.w - rhs.w) < (float.Epsilon))
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
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        //ToString() override
        public override string ToString()
        {
            return "{ " + x + "(x) " + y + "(y) " + z + "(z) " + w + "(w) }";
        }
    }
}