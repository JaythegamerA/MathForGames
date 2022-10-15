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

        public bool Equals(Vector4 other)
        {
            if (MathF.Abs(x - other.x) < 0.0001 &&
                MathF.Abs(y - other.y) < 0.0001 &&
                MathF.Abs(z - other.z) < 0.0001 &&
                MathF.Abs(w - other.w) < 0.0001)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && Equals((Vector4)obj);
        }

        /// <summary>
        /// Determines if two vectors are approximately equal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>True if approximately equal, false if not</returns>
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Determines if two vectors are approximately inequal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>True if approximately inequal, false if not</returns>
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(x);
            hash.Add(y);
            hash.Add(z);
            hash.Add(w);

            return hash.ToHashCode();
        }
        #endregion

        //ToString() override
        public override string ToString()
        {
            return "{ " + x + "(x) " + y + "(y) " + z + "(z) " + w + "(w) }";
        }
    }
}