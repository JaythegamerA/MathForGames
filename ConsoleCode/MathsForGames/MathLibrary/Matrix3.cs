namespace MathLibrary
{
    public struct Matrix3
{
    public float m1, m2, m3,
                 m4, m5, m6,
                 m7, m8, m9;

    public Matrix3(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
    {
        this.m1 = m1;
        this.m2 = m2;
        this.m3 = m3;
        this.m4 = m4;
        this.m5 = m5;
        this.m6 = m6;
        this.m7 = m7;
        this.m8 = m8;
        this.m9 = m9;
    }

    public Matrix3(float diagonal)
    {
        this.m1 = diagonal;
        this.m2 = 0;
        this.m3 = 0;

        this.m4 = 0;
        this.m5 = diagonal;
        this.m6 = 0;

        this.m7 = 0;
        this.m8 = 0;
        this.m9 = diagonal;
    }

    //Returns a Matrix multiplied by the other Matrix
    public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
    {
        return new Matrix3(lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
                           lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
                           lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,

                           lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,
                           lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
                           lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,

                           lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
                           lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
                           lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);
    }

    //Returns a Vector3 scaled by this Matrix
    public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
    {
        return new Vector3(lhs.m1 * rhs.x + lhs.m4 * rhs.y + lhs.m7 * rhs.z,
                           lhs.m2 * rhs.x + lhs.m5 * rhs.y + lhs.m8 * rhs.z,
                           lhs.m3 * rhs.x + lhs.m6 * rhs.y + lhs.m9 * rhs.z);
    }

    //Returns a Matrix3 scaled by this scalar
    public static Matrix3 operator *(Matrix3 lhs, float scalar)
    {
        return new Matrix3(lhs.m1 * scalar, lhs.m2 * scalar, lhs.m3 * scalar, lhs.m4 * scalar, lhs.m5 * scalar, lhs.m6 * scalar, lhs.m7 * scalar, lhs.m8 * scalar, lhs.m9 * scalar);
    }

    //Returns a Matrix3 scaled by the scalar
    public static Matrix3 operator *(float scalar, Matrix3 rhs)
    {
        return new Matrix3(scalar * rhs.m1, scalar * rhs.m2, scalar * rhs.m3, scalar * rhs.m4, scalar * rhs.m5, scalar * rhs.m6, scalar * rhs.m7, scalar * rhs.m8, scalar * rhs.m9);
    }

    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return m1;
                case 1:
                    return m2;
                case 2:
                    return m3;
                case 3:
                    return m4;
                case 4:
                    return m5;
                case 5:
                    return m6;
                case 6:
                    return m7;
                case 7:
                    return m8;
                case 8:
                    return m9;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        set
        {
            switch (index)
            {
                case 0:
                    m1 = value;
                    break;
                case 1:
                    m2 = value;
                    break;
                case 2:
                    m3 = value;
                    break;
                case 3:
                    m4 = value;
                    break;
                case 4:
                    m5 = value;
                    break;
                case 5:
                    m6 = value;
                    break;
                case 6:
                    m7 = value;
                    break;
                case 7:
                    m8 = value;
                    break;
                case 8:
                    m9 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    //Translation Matrix for 2D (Set unused z coordinate to 1)
    public static Matrix3 CreateTranslation(float x, float y)
    {
        return new Matrix3(1, 0, 0, 0, 1, 0, x, y, 1);
    }

    //Translation Matrix for 2D
    public static Matrix3 CreateTranslation(Vector3 vec)
    {
        return new Matrix3(1, 0, 0, 0, 1, 0, vec.x, vec.y, 1);
    }

    //Rotation on X-Axis
    public static Matrix3 CreateRotateX(float a)
    {
        return new Matrix3(1, 0, 0, 0, MathF.Cos(a), -MathF.Sin(a), 0, MathF.Sin(a), MathF.Cos(a));
    }


    //Rotation on Y-Axis
    public static Matrix3 CreateRotateY(float a)
    {
        return new Matrix3(MathF.Cos(a), 0, MathF.Sin(a), 0, 1, 0, -MathF.Sin(a), 0, MathF.Cos(a));
    }

    //Rotation on Z-Axis
    public static Matrix3 CreateRotateZ(float a)
    {
        return new Matrix3(MathF.Cos(a), MathF.Sin(a), 0, -MathF.Sin(a), MathF.Cos(a), 0, 0, 0, 1);
    }

    //Rotation on XYZ-Axes
    public static Matrix3 Euler(float pitch, float yaw, float roll)
    {
        return new Matrix3(roll, 0, 0, pitch, 0, 0, yaw, 0, 0);
    }

    //Scale in 2D(Assume unused z value is 1)
    public static Matrix3 CreateScale(float xScale, float yScale)
    {
        return new Matrix3(xScale, 0, 0, 0, yScale, 0, 0, 0, 1);
    }

    //Scale in 3D
    public static Matrix3 CreateScale(float xScale, float yScale, float zScale)
    {
        return new Matrix3(xScale, 0, 0, 0, yScale, 0, 0, 0, zScale);
    }

    //Scale in 3D
    public static Matrix3 CreateScale(Vector3 scale)
    {
        return new Matrix3(scale.x, 0, 0, 0, scale.y, 0, 0, 0, scale.z);
    }

    //Only set the translation component of The Matrix
    public void SetTranslation(float x, float y)
    {
        m3 = x;
        m6 = y;
    }

    //Only set the translation component of The Matrix
    public void SetTranslation(Vector3 v)
    {
        m3 = v.x;
        m6 = v.y;
    }

    //Add X and Y onto the translation component of The Matrix
    public void Translate(float x, float y)
    {
        m3 += x;
        m6 += y;
    }

    //Returns the translation component of The Matrix
    public Vector3 GetTranslation()
    {
        return new Vector3(m3, m6, m9);
    }

    //Rotates the existing Matrix by a certain amount on the X-Axis
    public void RotateX(float radians)
    {
        this *= CreateRotateX(radians);
    }

    //Rotates the existing Matrix by a certain amount on the Y-Axis
    public void RotateY(float radians)
    {
        this *= CreateRotateY(radians);
    }

    //Rotates the existing Matrix by a certain amount on the Z-Axis
    public void RotateZ(float radians)
    {
        this *= CreateRotateZ(radians);
    }

    //Scales the existing Matrix by a certain amount on each axis
    public void Scale(float x, float y, float z)
    {
        m1 += x;
        m5 += y;
        m9 += z;
    }

    //Scales the existing Matrix by a certain amount on each axis
    public void Scale(Vector3 v)
    {
        m1 += v.x;
        m5 += v.y;
        m9 += v.z;
    }

    //Equals Functions
    public bool Equals(Matrix3 other)
    {
        if (MathF.Abs(m1 - other.m1) < 0.0001 && MathF.Abs(m2 - other.m2) < 0.0001
            && MathF.Abs(m3 - other.m3) < 0.0001 && MathF.Abs(m4 - other.m4) < 0.0001
            && MathF.Abs(m5 - other.m5) < 0.0001 && MathF.Abs(m6 - other.m6) < 0.0001
            && MathF.Abs(m7 - other.m7) < 0.0001 && MathF.Abs(m8 - other.m8) < 0.0001
            && MathF.Abs(m9 - other.m9) < 0.0001)
        {
            return true;
        }
        return false;
    }

    public override bool Equals(object? obj)
    {
        return obj != null && this.Equals((Matrix3)obj);
    }


    //Equals and Not Equals Operators
    public static bool operator ==(Matrix3 lhs, Matrix3 rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Matrix3 lhs, Matrix3 rhs)
    {
        return !(lhs == rhs);
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();

        hash.Add(m1);
        hash.Add(m2);
        hash.Add(m3);
        hash.Add(m4);
        hash.Add(m5);
        hash.Add(m6);
        hash.Add(m7);
        hash.Add(m8);
        hash.Add(m9);

        return hash.ToHashCode();
    }

    //Converts the Matrix3 to a string for debugging purposes
    public override string ToString()
    {
        return m1.ToString() + "," + m2.ToString() + "," + m3.ToString()
            + "," + m4.ToString() + "," + m5.ToString() + "," + m6.ToString()
            + "," + m7.ToString() + "," + m8.ToString() + "," + m9.ToString();
    }
}
}