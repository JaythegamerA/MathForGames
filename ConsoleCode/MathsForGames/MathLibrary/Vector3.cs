using System.Diagnostics.CodeAnalysis;

namespace MathLibrary
{
    public struct Vector3
    {
        public float x, y, z;

        //Vector3 Constructor
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Calculates the Magnitude
        public float Magnitude
        {
            get
            {
                return MathF.Sqrt(x * x + y * y + z * z);
            }
        }

        //Normalizes a Vector3
        public void Normalize()
        {
            float mag = Magnitude;
            if (mag != 0)
            {
                this /= Magnitude;
            }
        }

        //Same thing as Normalize, but returns the value
        public Vector3 Normalized
        {
            get
            {
                return this /= Magnitude;
            }
        }

        //Scales a Vector3
        public void Scale(Vector3 rhs)
        {
            this.x *= rhs.x;
            this.y *= rhs.y;
            this.z *= rhs.z;
        }

        //Same thing as Scale, but returns the value
        public Vector3 Scaled(Vector3 rhs)
        {
            return new Vector3(x * rhs.x, y * rhs.y, z * rhs.z);
        }

        //Calculates the Dot Product for a Vector3
        public float Dot(Vector3 rhs)
        {
            return ((x * rhs.x) + (y * rhs.y) + (z * rhs.z));
        }

        //Calculates the Cross Product for a Vector3
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3((y * rhs.z) - (rhs.y * z), (z * rhs.x) - (rhs.z * x), (x * rhs.y) - (rhs.x * y));
        }


        //For limiting Magnitude
        public static Vector3 ClampMagnitude(Vector3 vec, float maxMagnitude)
        {
            float curMag = vec.Magnitude;

            if (curMag > maxMagnitude)
            {
                return vec.Normalized * maxMagnitude;
            }

            return vec;
        }

        //Multiplcation Operators
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }

        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }

        //Division Operator
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        //Addition Operator
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        //Subtraction Operators
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vector3 operator -(Vector3 rhs)
        {
            return new Vector3(-rhs.x, -rhs.y, -rhs.z);
        }


        //Equals(Vector3)
        //Equals(object) - override!
        // == operator
        // != operator
        //GetHashCode()

        public bool Equals(Vector3 other)
        {
            if (MathF.Abs(x - other.x) < 0.0001 && MathF.Abs(y - other.y) < 0.0001 && MathF.Abs(z - other.z) < 0.0001)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && this.Equals((Vector3)obj);
        }


        //Equals and Not Equals Operators
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(x);
            hash.Add(y);
            hash.Add(z);

            return hash.ToHashCode();
        }

        //Converts the Vector3 to a string for debugging purposes
        public override string ToString()
        {
            return x.ToString() + "," + y.ToString() + "," + z.ToString();
        }
    }
}