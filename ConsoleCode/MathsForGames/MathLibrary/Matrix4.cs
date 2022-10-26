using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix4
    {
        public float
                    m1, m2, m3, m4,     //first column
                    m5, m6, m7, m8,     //second column
                    m9, m10, m11, m12,    //third column
                    m13, m14, m15, m16;    //fourth column (translation vector)

        //initialize a 4x4 matrix using the specified value at each index of the matrix
        public Matrix4(float m1, float m2, float m3, float m4,
                        float m5, float m6, float m7, float m8,
                        float m9, float m10, float m11, float m12,
                        float m13, float m14, float m15, float m16)
        {
            //first column
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            //second column
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            //third column
            this.m9 = m9; this.m10 = m10; this.m11 = m11; this.m12 = m12;
            //fourth column
            this.m13 = m13; this.m14 = m14; this.m15 = m15; this.m16 = m16;
        }

        //initialize a 4x4 matrix with the assigned value on the diagonal
        public Matrix4(float val)
        {
            //first column
            this.m1 = val; this.m2 = 0; this.m3 = 0; this.m4 = 0;
            //second column
            this.m5 = 0; this.m6 = val; this.m7 = 0; this.m8 = 0;
            //third column
            this.m9 = 0; this.m10 = 0; this.m11 = val; this.m12 = 0;
            //fourth column
            this.m13 = 0; this.m14 = 0; this.m15 = 0; this.m16 = val;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return this.m1;
                    case 1: return this.m2;
                    case 2: return this.m3;
                    case 3: return this.m4;
                    case 4: return this.m5;
                    case 5: return this.m6;
                    case 6: return this.m7;
                    case 7: return this.m8;
                    case 8: return this.m9;
                    case 9: return this.m10;
                    case 10: return this.m11;
                    case 11: return this.m12;
                    case 12: return this.m13;
                    case 13: return this.m14;
                    case 14: return this.m15;
                    case 15: return this.m16;
                }
                return 0;

            }
            set
            {
                switch (index)
                {
                    case 0: m1 = value; break;
                    case 1: m2 = value; break;
                    case 2: m3 = value; break;
                    case 3: m4 = value; break;
                    case 4: m5 = value; break;
                    case 5: m6 = value; break;
                    case 6: m7 = value; break;
                    case 7: m8 = value; break;
                    case 8: m9 = value; break;
                    case 9: m10 = value; break;
                    case 10: m11 = value; break;
                    case 11: m12 = value; break;
                    case 12: m13 = value; break;
                    case 13: m14 = value; break;
                    case 14: m15 = value; break;
                    case 15: m16 = value; break;
                }
            }
        }

        #region Operators
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                //first column
                (lhs.m1 * rhs.m1) + (lhs.m5 * rhs.m2) + (lhs.m9 * rhs.m3) + (lhs.m13 * rhs.m4),
                (lhs.m2 * rhs.m1) + (lhs.m6 * rhs.m2) + (lhs.m10 * rhs.m3) + (lhs.m14 * rhs.m4),
                (lhs.m3 * rhs.m1) + (lhs.m7 * rhs.m2) + (lhs.m11 * rhs.m3) + (lhs.m15 * rhs.m4),
                (lhs.m4 * rhs.m1) + (lhs.m8 * rhs.m2) + (lhs.m12 * rhs.m3) + (lhs.m16 * rhs.m4),
                //second column
                (lhs.m1 * rhs.m5) + (lhs.m5 * rhs.m6) + (lhs.m9 * rhs.m7) + (lhs.m13 * rhs.m8),
                (lhs.m2 * rhs.m5) + (lhs.m6 * rhs.m6) + (lhs.m10 * rhs.m7) + (lhs.m14 * rhs.m8),
                (lhs.m3 * rhs.m5) + (lhs.m7 * rhs.m6) + (lhs.m11 * rhs.m7) + (lhs.m15 * rhs.m8),
                (lhs.m4 * rhs.m5) + (lhs.m8 * rhs.m6) + (lhs.m12 * rhs.m7) + (lhs.m16 * rhs.m8),
                //third column
                (lhs.m1 * rhs.m9) + (lhs.m5 * rhs.m10) + (lhs.m9 * rhs.m11) + (lhs.m13 * rhs.m12),
                (lhs.m2 * rhs.m9) + (lhs.m6 * rhs.m10) + (lhs.m10 * rhs.m11) + (lhs.m14 * rhs.m12),
                (lhs.m3 * rhs.m9) + (lhs.m7 * rhs.m10) + (lhs.m11 * rhs.m11) + (lhs.m15 * rhs.m12),
                (lhs.m4 * rhs.m9) + (lhs.m8 * rhs.m10) + (lhs.m12 * rhs.m11) + (lhs.m16 * rhs.m12),
                //fourth column
                (lhs.m1 * rhs.m13) + (lhs.m5 * rhs.m14) + (lhs.m9 * rhs.m15) + (lhs.m13 * rhs.m16),
                (lhs.m2 * rhs.m13) + (lhs.m6 * rhs.m14) + (lhs.m10 * rhs.m15) + (lhs.m14 * rhs.m16),
                (lhs.m3 * rhs.m13) + (lhs.m7 * rhs.m14) + (lhs.m11 * rhs.m15) + (lhs.m15 * rhs.m16),
                (lhs.m4 * rhs.m13) + (lhs.m8 * rhs.m14) + (lhs.m12 * rhs.m15) + (lhs.m16 * rhs.m16));
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            //TODO IMPLEMENT ME PLEASE & THANK YOU
            return new Vector4(
                //first column
                (lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w),
                //second column
                (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w),
                //third column
                (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w),
                //fourth column
                (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w));
        }

        public static Matrix4 operator *(Matrix4 lhs, float scalar)
        {
            return new Matrix4(
                //first column
                (lhs.m1 * scalar), (lhs.m2 * scalar), (lhs.m3 * scalar), (lhs.m4 * scalar),
                //second column
                (lhs.m5 * scalar), (lhs.m6 * scalar), (lhs.m7 * scalar), (lhs.m8 * scalar),
                //third column
                (lhs.m9 * scalar), (lhs.m10 * scalar), (lhs.m11 * scalar), (lhs.m12 * scalar),
                //fourth column
                (lhs.m13 * scalar), (lhs.m14 * scalar), (lhs.m15 * scalar), (lhs.m16 * scalar)
                );
        }

        public static Matrix4 operator *(float scalar, Matrix4 rhs)
        {
            return new Matrix4(
                //first column
                (scalar * rhs.m1), (scalar * rhs.m2), (scalar * rhs.m3), (scalar * rhs.m4),
                //second column
                (scalar * rhs.m5), (scalar * rhs.m6), (scalar * rhs.m7), (scalar * rhs.m8),
                //third column
                (scalar * rhs.m9), (scalar * rhs.m10), (scalar * rhs.m11), (scalar * rhs.m12),
                //fourth column
                (scalar * rhs.m13), (scalar * rhs.m14), (scalar * rhs.m15), (scalar * rhs.m16)
                );
        }

        public bool Equals(Matrix4 other)
        {
            //if the difference of each component is less 0.0001, consider them equal
            if (MathF.Abs(m1 - other.m1) < 0.00001 &&
                MathF.Abs(m2 - other.m2) < 0.00001 &&
                MathF.Abs(m3 - other.m3) < 0.00001 &&
                MathF.Abs(m4 - other.m4) < 0.00001 &&
                MathF.Abs(m5 - other.m5) < 0.00001 &&
                MathF.Abs(m6 - other.m6) < 0.00001 &&
                MathF.Abs(m7 - other.m7) < 0.00001 &&
                MathF.Abs(m8 - other.m8) < 0.00001 &&
                MathF.Abs(m9 - other.m9) < 0.00001 &&
                MathF.Abs(m10 - other.m10) < 0.00001 &&
                MathF.Abs(m11 - other.m11) < 0.00001 &&
                MathF.Abs(m12 - other.m12) < 0.00001 &&
                MathF.Abs(m13 - other.m13) < 0.00001 &&
                MathF.Abs(m14 - other.m14) < 0.00001 &&
                MathF.Abs(m15 - other.m15) < 0.00001 &&
                MathF.Abs(m16 - other.m16) < 0.00001)
            {
                return true;
            }
            //otherwise, they are not equal
            else
            {
                return false;
            }
        }

        public static bool operator ==(Matrix4 lhs, Matrix4 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Matrix4 lhs, Matrix4 rhs)
        {
            return !(lhs == rhs);
        }

        //required implementation for checking equalities
        public override bool Equals(object? obj)
        {
            return obj != null && Equals((Matrix4)obj);
        }

        //required implementation for checking equalities
        public override int GetHashCode()
        {
            //create a new hashcode
            HashCode hash = new HashCode();

            //add every parameter to the hashcode
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

            //return the hashcode
            return hash.ToHashCode();
        }

        //required implementation for checking equalities
        public override string ToString()
        {
            return "\n" + m1.ToString() + " " + m5.ToString() + " " + m9.ToString() + " " + m13.ToString() + " \n"
                  + " " + m2.ToString() + " " + m6.ToString() + " " + m10.ToString() + " " + m14.ToString() + " \n"
                  + " " + m3.ToString() + " " + m7.ToString() + " " + m11.ToString() + " " + m15.ToString() + " \n"
                  + " " + m4.ToString() + " " + m8.ToString() + " " + m12.ToString() + " " + m16.ToString();
        }
        #endregion

        #region Transform Factory
        //Translation Matrix for 2d
        // (set z and w to 1)
        public static Matrix4 CreateTranslation(float x, float y)
        {
            return new Matrix4(
                //first column - x
                1f, 0f, 0f, 0f,
                //second column - y
                0f, 1f, 0f, 0f,
                //third column - z
                0f, 0f, 1f, 0f,
                //fourth column - w
                x, y, 0f, 1f
                );
        }

        //translation matrix for 3d using vector4 as input
        public static Matrix4 CreateTranslation(Vector3 vec)
        {
            return new Matrix4(
                //first column - x
                1f, 0f, 0f, 0f,
                //second column - y
                0f, 1f, 0f, 0f,
                //third column - z
                0f, 0f, 1f, 0f,
                //fourth column - w
                vec.x, vec.y, vec.z, 1f
                );
        }

        public static Matrix4 CreateRotateX(float a)
        {
            return new Matrix4(
                //first column - x
                1f, 0f, 0f, 0f,
                //second column - y
                0f, MathF.Cos(a), -MathF.Sin(a), 0f,
                //third column - z
                0f, MathF.Sin(a), MathF.Cos(a), 0f,
                //fourth column - w
                0f, 0f, 0f, 1f);
        }

        public static Matrix4 CreateRotateY(float a)
        {
            return new Matrix4(
                //first column - x
                MathF.Cos(a), 0f, MathF.Sin(a), 0f,
                //second column - y
                0f, 1f, 0f, 0f,
                //third column - z
                -MathF.Sin(a), 0f, MathF.Cos(a), 0f,
                //fourth column - w
                0f, 0f, 0f, 1f);
        }

        public static Matrix4 CreateRotateZ(float a)
        {
            return new Matrix4(
                //first column - x
                MathF.Cos(a), -MathF.Sin(a), 0f, 0f,
                //second column - y
                MathF.Sin(a), MathF.Cos(a), 0f, 0f,
                //third column - z
                0f, 0f, 1f, 0f,
                //fourth column - w
                0f, 0f, 0f, 1f);
        }

        public static Matrix4 Euler(float pitch, float yaw, float roll)
        {
            return CreateRotateX(pitch) * CreateRotateY(yaw) * CreateRotateZ(roll);
        }

        public static Matrix4 CreateScale(float xScale, float yScale)
        {
            return new Matrix4(
                //first column - x
                xScale, 0f, 0f, 0f,
                //second column - y
                0f, yScale, 0f, 0f,
                //third column - z
                0f, 0f, 1f, 0f,
                //fourth column - w
                0f, 0f, 0f, 1f
                );
        }

        public static Matrix4 CreateScale(float xScale, float yScale, float zScale)
        {
            return new Matrix4(
                //first column - x
                xScale, 0f, 0f, 0f,
                //second column - y
                0f, yScale, 0f, 0f,
                //third column - z
                0f, 0f, zScale, 0f,
                //fourth column - w
                0f, 0f, 0f, 1f
                );
        }

        public static Matrix4 CreateScale(Vector3 scale)
        {
            return new Matrix4(
                //first column - x
                scale.x, 0f, 0f, 0f,
                //second column - y
                0f, scale.y, 0f, 0f,
                //third column - z
                0f, 0f, scale.z, 0f,
                //fourth column - w
                0f, 0f, 0f, 1f
                );
        }

        public static Matrix4 CreateScale(Vector4 scale)
        {
            return new Matrix4(
                //first column - x
                scale.x, 0f, 0f, 0f,
                //second column - y
                0f, scale.y, 0f, 0f,
                //third column - z
                0f, 0f, scale.z, 0f,
                //fourth column - w
                0f, 0f, 0f, scale.w
                );
        }
        #endregion

        #region Transform Methods
        // only set the translation component of the matrix
        public void SetTranslation(float x, float y)
        {
            m13 = x;
            m14 = y;
        }

        // only set the translation component of the matrix
        public void SetTranslation(Vector3 v)
        {
            m13 = v.x;
            m14 = v.y;
            m15 = v.z;
        }

        // only set the translation component of the matrix
        public void SetTranslation(Vector4 v)
        {
            m13 = v.x;
            m14 = v.y;
            m15 = v.z;
            m16 = v.w;
        }

        // add x and y onto the translation component of the matrix
        public void Translate(float x, float y)
        {
            m13 += x;
            m14 += y;
        }

        // returns the translation component of the matrix
        public Vector3 GetTranslation()
        {
            return new Vector3(m13, m14, m15);
        }

        // rotates the existing matrix by a certain amount on the X-axis
        public void RotateX(float radians)
        {
            //x column does not change

            //y column does
            m6 = MathF.Cos(radians);
            m7 = MathF.Sin(radians);

            //z column does
            m10 = -MathF.Sin(radians);
            m11 = MathF.Cos(radians);
        }

        // rotates the existing matrix by a certain amount on the Y-axis
        public void RotateY(float radians)
        {
            //x column does
            m1 = MathF.Cos(radians);
            m3 = -MathF.Sin(radians);

            //y column does not change​

            //z column does
            m9 = MathF.Sin(radians);
            m11 = MathF.Cos(radians);
        }

        // rotates the existing matrix by a certain amount on the Z-axis
        public void RotateZ(float radians)
        {
            //x column does
            m1 = MathF.Cos(radians);
            m2 = MathF.Sin(radians);

            //y column does
            m5 = -MathF.Sin(radians);
            m6 = MathF.Cos(radians);
        }
        // scales the existing matrix by a certain amount on each axis
        public void Scale(float x, float y, float z)
        {
            m1 *= x;
            m6 *= y;
            m11 *= z;
        }
        // scales the existing matrix by a certain amount on each axis
        public void Scale(Vector3 v)
        {
            m1 *= v.x;
            m6 *= v.y;
            m11 *= v.z;
        }
        #endregion
    }
}