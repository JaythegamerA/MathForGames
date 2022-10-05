using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector3
    {
        public float x, y, z;
        private int v1;
        private int v2;

        //3 parameter constructor
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(int v1, int v2) : this()
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public float Magnitude
        {
            get
            {
                return MathF.Sqrt((x * x) + (y * y) + (z * z));
            }
        }

        public void Normalize()
        {
            this /= Magnitude;
        }

        public Vector3 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        public void Scale(Vector3 rhs)
        {
            this.x *= rhs.x;
            this.y *= rhs.y;
            this.z *= rhs.z;
        }

        public Vector3 Scaled(Vector3 rhs)
        {
            return new Vector3(rhs.x * x, rhs.y * y, rhs.z * z);
        }

        //returns the dot product of 2 Vector3s
        public float Dot(Vector3 rhs)
        {
            return (this.x * rhs.x) + (this.y * rhs.y) + (this.z * rhs.z);
        }

        //returns the cross product of two Vector3s
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3((this.y * rhs.z) - (this.z * rhs.y),
                                (this.z * rhs.x) - (this.x * rhs.z),
                                (this.x * rhs.y) - (this.y * rhs.x));
        }

        #region Operators
        //  addition
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;
            result.z = lhs.z + rhs.z;
            return result;
        }

        //  subtraction
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;
            result.z = lhs.z - rhs.z;
            return result;
        }

        //  negation
        public static Vector3 operator -(Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = rhs.x * -1.0f;
            result.y = rhs.y * -1.0f;
            result.z = rhs.z * -1.0f;
            return result;
        }

        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        //equality comparisons
        //  ==
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            //if the difference of each component is less than twice the float.Epsilon, consider them equal
            if (MathF.Abs(lhs.x - rhs.x) < (float.Epsilon)
                && MathF.Abs(lhs.y - rhs.y) < (float.Epsilon)
                && MathF.Abs(lhs.z - rhs.z) < (float.Epsilon))
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
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        //override the default ToString implementation
        public override string ToString()
        {
            return "{ " + x + "(x) " + y + "(y) " + z + "(z) }";
        }
    }
}