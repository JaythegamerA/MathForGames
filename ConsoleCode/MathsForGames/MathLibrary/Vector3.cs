namespace MathLibrary
{
    public struct Vector4
    {
        public float x, y, z, w;

        //Vector4 Constructor
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        //Calculates the Magnitude
        public float Magnitude
        {
            get
            {
                return MathF.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
            }
        }

        //Normalizes a Vector4
        public void Normalize()
        {
            this /= Magnitude;
        }

        //Same thing as Normalize, but returns the value
        public Vector4 Normalized
        {
            get
            {
                return new Vector4(x / Magnitude, y / Magnitude, z / Magnitude, w / Magnitude);
            }
        }

        //Scales a Vector4
        public void Scale(Vector4 rhs)
        {
            this.x *= rhs.x;
            this.y *= rhs.y;
            this.z *= rhs.z;
            this.w *= rhs.w;
        }

        //Same thing as Scale, but returns the value
        public Vector4 Scaled(Vector4 rhs)
        {
            return new Vector4(x * rhs.x, y * rhs.y, z * rhs.z, w * rhs.w);
        }

        //Calculates the Dot Product for a Vector4
        public float Dot(Vector4 rhs)
        {
            return ((x * rhs.x) + (y * rhs.y) + (z * rhs.z) + (w * rhs.w));
        }

        //Calculates the Cross Product for a Vector4
        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4((y * rhs.z) - (rhs.y * z), (z * rhs.x) - (rhs.z * x), (x * rhs.y) - (rhs.x * y), 0);
        }

        //Multiplcation Operators
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }

        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        }

        //Division Operator
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        //Addition Operator
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        //Subtraction Operators
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        public static Vector4 operator -(Vector4 rhs)
        {
            return new Vector4(-rhs.x, -rhs.y, -rhs.z, -rhs.w);
        }

        public bool Equals(Vector4 other)
        {
            if (MathF.Abs(x - other.x) < 0.0001 && MathF.Abs(y - other.y) < 0.0001 && MathF.Abs(z - other.z) < 0.0001 && MathF.Abs(w - other.w) < 0.0001)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && this.Equals((Vector4)obj);
        }


        //Equals and Not Equals Operators
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            return lhs.Equals(rhs);
        }

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



        //Converts the Vector4 to a string for debugging purposes
        public override string ToString()
        {
            return x.ToString() + "," + y.ToString() + "," + z.ToString() + "," + w.ToString();
        }
    }
}