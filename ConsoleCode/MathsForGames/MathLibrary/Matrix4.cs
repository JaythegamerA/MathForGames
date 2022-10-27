namespace MathLibrary
{
    public struct Matrix4
    {
        public float m1, m2, m3,
                     m4, m5, m6,
                     m7, m8, m9,
                     m10, m11, m12,
                     m13, m14, m15, m16;

        public Matrix4(float m1, float m2, float m3, float m4,
            float m5, float m6, float m7, float m8,
            float m9, float m10, float m11, float m12,
            float m13, float m14, float m15, float m16)
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
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m15 = m15;
            this.m16 = m16;
        }

        public Matrix4(float diagonal)
        {
            this.m1 = diagonal;
            this.m2 = 0;
            this.m3 = 0;
            this.m4 = 0;

            this.m5 = 0;
            this.m6 = diagonal;
            this.m7 = 0;
            this.m8 = 0;

            this.m9 = 0;
            this.m10 = 0;
            this.m11 = diagonal;
            this.m12 = 0;

            this.m13 = 0;
            this.m14 = 0;
            this.m15 = 0;
            this.m16 = diagonal;


        }

        //Returns a Matrix multiplied by the other Matrix
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(lhs.m1 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m9 * rhs.m3 + lhs.m13 * rhs.m4,
                               lhs.m2 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m10 * rhs.m3 + lhs.m14 * rhs.m4,
                               lhs.m3 * rhs.m1 + lhs.m7 * rhs.m2 + lhs.m11 * rhs.m3 + lhs.m15 * rhs.m4,
                               lhs.m4 * rhs.m1 + lhs.m8 * rhs.m2 + lhs.m12 * rhs.m3 + lhs.m16 * rhs.m4,

                               lhs.m1 * rhs.m5 + lhs.m5 * rhs.m6 + lhs.m9 * rhs.m7 + lhs.m13 * rhs.m8,
                               lhs.m2 * rhs.m5 + lhs.m6 * rhs.m6 + lhs.m10 * rhs.m7 + lhs.m14 * rhs.m8,
                               lhs.m3 * rhs.m5 + lhs.m7 * rhs.m6 + lhs.m11 * rhs.m7 + lhs.m15 * rhs.m8,
                               lhs.m4 * rhs.m5 + lhs.m8 * rhs.m6 + lhs.m12 * rhs.m7 + lhs.m16 * rhs.m8,

                               lhs.m1 * rhs.m9 + lhs.m5 * rhs.m10 + lhs.m9 * rhs.m11 + lhs.m13 * rhs.m12,
                               lhs.m2 * rhs.m9 + lhs.m6 * rhs.m10 + lhs.m10 * rhs.m11 + lhs.m14 * rhs.m12,
                               lhs.m3 * rhs.m9 + lhs.m7 * rhs.m10 + lhs.m11 * rhs.m11 + lhs.m15 * rhs.m12,
                               lhs.m4 * rhs.m9 + lhs.m8 * rhs.m10 + lhs.m12 * rhs.m11 + lhs.m16 * rhs.m12,


                               lhs.m1 * rhs.m13 + lhs.m5 * rhs.m14 + lhs.m9 * rhs.m15 + lhs.m13 * rhs.m16,
                               lhs.m2 * rhs.m13 + lhs.m6 * rhs.m14 + lhs.m10 * rhs.m15 + lhs.m14 * rhs.m16,
                               lhs.m3 * rhs.m13 + lhs.m7 * rhs.m14 + lhs.m11 * rhs.m15 + lhs.m15 * rhs.m16,
                               lhs.m4 * rhs.m13 + lhs.m8 * rhs.m14 + lhs.m12 * rhs.m15 + lhs.m16 * rhs.m16);
        }

        //Returns a Vector3 scaled by this Matrix
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.m1 * rhs.x + lhs.m5 * rhs.y + lhs.m9 * rhs.z + lhs.m13 * rhs.w,
                               lhs.m2 * rhs.x + lhs.m6 * rhs.y + lhs.m10 * rhs.z + lhs.m14 * rhs.w,
                               lhs.m3 * rhs.x + lhs.m7 * rhs.y + lhs.m11 * rhs.z + lhs.m15 * rhs.w,
                               lhs.m4 * rhs.x + lhs.m8 * rhs.y + lhs.m12 * rhs.z + lhs.m16 * rhs.w);
        }

        //Returns a Matrix4 scaled by this scalar
        public static Matrix4 operator *(Matrix4 lhs, float scalar)
        {
            return new Matrix4(lhs.m1 * scalar, lhs.m2 * scalar, lhs.m3 * scalar, lhs.m4 * scalar, lhs.m5 * scalar,
                lhs.m6 * scalar, lhs.m7 * scalar, lhs.m8 * scalar, lhs.m9 * scalar, lhs.m10 * scalar, lhs.m11 * scalar,
                lhs.m12 * scalar, lhs.m13 * scalar, lhs.m14 * scalar, lhs.m15 * scalar, lhs.m16 * scalar);
        }

        //Returns a Matrix4 scaled by the scalar
        public static Matrix4 operator *(float scalar, Matrix4 rhs)
        {
            return new Matrix4(scalar * rhs.m1, scalar * rhs.m2, scalar * rhs.m3, scalar * rhs.m4, scalar * rhs.m5, scalar
                * rhs.m6, scalar * rhs.m7, scalar * rhs.m8, scalar * rhs.m9, scalar * rhs.m10, scalar * rhs.m11,
                scalar * rhs.m12, scalar * rhs.m13, scalar * rhs.m14, scalar * rhs.m15, scalar * rhs.m16);
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
                    case 9:
                        return m10;
                    case 10:
                        return m11;
                    case 11:
                        return m12;
                    case 12:
                        return m13;
                    case 13:
                        return m14;
                    case 14:
                        return m15;
                    case 15:
                        return m16;
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
                    case 9:
                        m10 = value;
                        break;
                    case 10:
                        m11 = value;
                        break;
                    case 11:
                        m12 = value;
                        break;
                    case 12:
                        m13 = value;
                        break;
                    case 13:
                        m14 = value;
                        break;
                    case 14:
                        m15 = value;
                        break;
                    case 15:
                        m16 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        //Translation Matrix for 2D (Set unused z coordinate to 1)
        public static Matrix4 CreateTranslation(float x, float y)
        {
            return new Matrix4(0, 0, x, 0, 0, y, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0);
        }

        //Translation Matrix for 2D
        public static Matrix4 CreateTranslation(Vector4 vec)
        {
            return new Matrix4(0, 0, vec.x, 0, 0, vec.y, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0);
        }

        //Rotation on X-Axis
        public static Matrix4 CreateRotateX(float a)
        {
            return new Matrix4(1, 0, 0, 0, 0, MathF.Cos(a), -MathF.Sin(a), 0, 0, MathF.Sin(a), MathF.Cos(a), 0, 0, 0, 0, 1);
        }


        //Rotation on Y-Axis
        public static Matrix4 CreateRotateY(float a)
        {
            return new Matrix4(MathF.Cos(a), 0, MathF.Sin(a), 0, 0, 1, 0, 0, -MathF.Sin(a), 0, MathF.Cos(a), 0, 0, 0, 0, 1);
        }

        //Rotation on Z-Axis
        public static Matrix4 CreateRotateZ(float a)
        {
            return new Matrix4(MathF.Cos(a), -MathF.Sin(a), 0, 0, MathF.Sin(a), MathF.Cos(a), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        }

        //Rotation on XYZ-Axes
        public static Matrix4 Euler(float pitch, float yaw, float roll)
        {
            return new Matrix4(roll, 0, 0, pitch, 0, 0, yaw, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        //Scale in 2D(Assume unused z value is 1)
        public static Matrix4 CreateScale(float xScale, float yScale)
        {
            return new Matrix4(xScale, 0, 0, 0, yScale, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
        }

        //Scale in 3D
        public static Matrix4 CreateScale(float xScale, float yScale, float zScale)
        {
            return new Matrix4(xScale, 0, 0, 0, yScale, 0, 0, 0, zScale, 0, 0, 0, 0, 0, 0, 1);
        }

        //Scale in 3D
        public static Matrix4 CreateScale(Vector3 scale)
        {
            return new Matrix4(scale.x, 0, 0, 0, scale.y, 0, 0, 0, scale.z, 0, 0, 0, 0, 0, 0, 1);
        }

        //Only set the translation component of The Matrix
        public void SetTranslation(float x, float y)
        {
            m3 = x;
            m6 = y;
        }

        //Only set the translation component of The Matrix
        public void SetTranslation(Vector4 v)
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
        public Vector4 GetTranslation()
        {
            return new Vector4(m4, m8, m12, m16);
        }

        //Rotates the existing Matrix by a certain amount on the X-Axis
        public void RotateX(float radians)
        {
            m1 += radians;
        }

        //Rotates the existing Matrix by a certain amount on the Y-Axis
        public void RotateY(float radians)
        {
            m4 += radians;
        }

        //Rotates the existing Matrix by a certain amount on the Z-Axis
        public void RotateZ(float radians)
        {
            m7 += radians;
        }

        //Scales the existing Matrix by a certain amount on each axis
        public void Scale(float x, float y, float z)
        {
            m1 += x;
            m6 += y;
            m11 += z;
        }

        //Scales the existing Matrix by a certain amount on each axis
        public void Scale(Vector4 v)
        {
            m1 += v.x;
            m6 += v.y;
            m11 += v.z;
        }

        //Equals Functions
        public bool Equals(Matrix4 other)
        {
            if (MathF.Abs(m1 - other.m1) < 0.0001 && MathF.Abs(m2 - other.m2) < 0.0001
                && MathF.Abs(m3 - other.m3) < 0.0001 && MathF.Abs(m4 - other.m4) < 0.0001
                && MathF.Abs(m5 - other.m5) < 0.0001 && MathF.Abs(m6 - other.m6) < 0.0001
                && MathF.Abs(m7 - other.m7) < 0.0001 && MathF.Abs(m8 - other.m8) < 0.0001
                && MathF.Abs(m9 - other.m9) < 0.0001 && MathF.Abs(m10 - other.m10) < 0.0001
                && MathF.Abs(m11 - other.m11) < 0.0001 && MathF.Abs(m12 - other.m12) < 0.0001
                && MathF.Abs(m13 - other.m13) < 0.0001 && MathF.Abs(m14 - other.m14) < 0.0001
                && MathF.Abs(m15 - other.m15) < 0.0001 && MathF.Abs(m16 - other.m16) < 0.0001)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && this.Equals((Matrix4)obj);
        }


        //Equals and Not Equals Operators
        public static bool operator ==(Matrix4 lhs, Matrix4 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Matrix4 lhs, Matrix4 rhs)
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
            hash.Add(m10);
            hash.Add(m11);
            hash.Add(m12);
            hash.Add(m13);
            hash.Add(m14);
            hash.Add(m15);
            hash.Add(m16);

            return hash.ToHashCode();
        }

        //Converts the Matrix4 to a string for debugging purposes
        public override string ToString()
        {
            return m1.ToString() + "," + m2.ToString() + "," + m3.ToString()
                + "," + m4.ToString() + "," + m5.ToString() + "," + m6.ToString()
                + "," + m7.ToString() + "," + m8.ToString() + "," + m9.ToString() + ","
                + m10.ToString() + "," + m11.ToString() + "," + m12.ToString() + ","
                + m13.ToString() + "," + m14.ToString() + "," + m15.ToString() + ","
                + m16.ToString();
        }
    }
}