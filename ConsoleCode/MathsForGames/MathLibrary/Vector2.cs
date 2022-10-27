namespace MathLibrary
{
    public struct Vector2
    {
        public float x, y;


        //Vector2 Constructor
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        //Calculates the Magnitude
        public float Magnitude
        {
            get
            {
                return MathF.Sqrt(x * x + y * y);
            }
        }
        //Normalizes a Vector2
        public void Normalize()
        {
            this /= Magnitude;
        }

        //Same thing as Normalize, but returns the value
        public Vector2 Normalized
        {
            get
            {
                return new Vector2(x / Magnitude, y / Magnitude);
            }
        }

        //Scales a Vector2
        public void Scale(Vector2 rhs)
        {
            this.x *= rhs.x;
            this.y *= rhs.y;
        }

        //Same thing as Scale, but returns the value
        public Vector2 Scaled(Vector2 rhs)
        {
            return new Vector2(x * rhs.x, y * rhs.y);
        }

        //Calculates Dot Product for a Vector2
        public float Dot(Vector2 rhs)
        {
            return ((x * rhs.x) + (y * rhs.y));
        }

        //Multiplcation Operators
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }

        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
        }

        //Division Operator
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }

        //Addition Operator
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        //Subtraction Operators
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator -(Vector2 rhs)
        {
            return new Vector2(-rhs.x, -rhs.y);
        }

        //Equals Functions for Vector2s and Objects
        public bool Equals(Vector2 other)
        {
            if (MathF.Abs(x - other.x) < 0.0001 && MathF.Abs(y - other.y) < 0.0001)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && this.Equals((Vector2)obj);
        }


        //Equals and Not Equals Operators
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(x);
            hash.Add(y);

            return hash.ToHashCode();
        }


        //Converts the Vector2 to a string for debugging purposes
        public override string ToString()
        {
            return x.ToString() + "," + y.ToString();
        }
    }
}