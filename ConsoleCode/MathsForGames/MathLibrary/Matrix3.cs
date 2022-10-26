using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix3
    {
        public float m1, m2, m3,  //first column 
                            m4, m5, m6,  //second column
                            m7, m8, m9;  //third column (translation vector)

        //constructor with each value specified
        public Matrix3(float m1, float m2, float m3,
                float m4, float m5, float m6,
                float m7, float m8, float m9)
        {
            //first column
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;

            //second column
            this.m4 = m4;
            this.m5 = m5;
            this.m6 = m6;

            //third 
            this.m7 = m7;
            this.m8 = m8;
            this.m9 = m9;
        }

        //initialize a 3x3 matrix with the assigned value on the diagonal
        public Matrix3(float val)
        {
            this.m1 = val;
            this.m2 = 0;
            this.m3 = 0;

            this.m4 = 0;
            this.m5 = val;
            this.m6 = 0;

            this.m7 = 0;
            this.m8 = 0;
            this.m9 = val;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return m1;
                    case 1: return m2;
                    case 2: return m3;
                    case 3: return m4;
                    case 4: return m5;
                    case 5: return m6;
                    case 6: return m7;
                    case 7: return m8;
                    case 8: return m9;
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
                }
            }
        }

        #region Operators
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                //first column
                (lhs.m1 * rhs.m1) + (lhs.m4 * rhs.m2) + (lhs.m7 * rhs.m3),
                (lhs.m2 * rhs.m1) + (lhs.m5 * rhs.m2) + (lhs.m8 * rhs.m3),
                (lhs.m3 * rhs.m1) + (lhs.m6 * rhs.m2) + (lhs.m9 * rhs.m3),
                //second column
                (lhs.m1 * rhs.m4) + (lhs.m4 * rhs.m5) + (lhs.m7 * rhs.m6),
                (lhs.m2 * rhs.m4) + (lhs.m5 * rhs.m5) + (lhs.m8 * rhs.m6),
                (lhs.m3 * rhs.m4) + (lhs.m6 * rhs.m5) + (lhs.m9 * rhs.m6),
                //third column
                (lhs.m1 * rhs.m7) + (lhs.m4 * rhs.m8) + (lhs.m7 * rhs.m9),
                (lhs.m2 * rhs.m7) + (lhs.m5 * rhs.m8) + (lhs.m8 * rhs.m9),
                (lhs.m3 * rhs.m7) + (lhs.m6 * rhs.m8) + (lhs.m9 * rhs.m9));
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z),
                               (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                               (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z));
        }

        public static Matrix3 operator *(Matrix3 lhs, float scalar)
        {
            return new Matrix3((lhs.m1 * scalar), (lhs.m2 * scalar), (lhs.m3 * scalar),
                                (lhs.m4 * scalar), (lhs.m5 * scalar), (lhs.m6 * scalar),
                                (lhs.m7 * scalar), (lhs.m8 * scalar), (lhs.m9 * scalar));
        }

        public static Matrix3 operator *(float scalar, Matrix3 rhs)
        {
            return new Matrix3((scalar * rhs.m1), (scalar * rhs.m2), (scalar * rhs.m3),
                                (scalar * rhs.m4), (scalar * rhs.m5), (scalar * rhs.m6),
                                (scalar * rhs.m7), (scalar * rhs.m8), (scalar * rhs.m9));
        }
        public bool Equals(Matrix3 other)
        {
            //if the difference of each component is less 0.0001, consider them equal
            if (MathF.Abs(m1 - other.m1) < 0.00001
                && MathF.Abs(m2 - other.m2) < 0.00001
                && MathF.Abs(m3 - other.m3) < 0.00001
                && MathF.Abs(m4 - other.m4) < 0.00001
                && MathF.Abs(m5 - other.m5) < 0.00001
                && MathF.Abs(m6 - other.m6) < 0.00001
                && MathF.Abs(m7 - other.m7) < 0.00001
                && MathF.Abs(m8 - other.m8) < 0.00001
                && MathF.Abs(m9 - other.m9) < 0.00001)
            {
                return true;
            }
            //otherwise, they are not equal
            else
            {
                return false;
            }
        }
        public static bool operator ==(Matrix3 lhs, Matrix3 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Matrix3 lhs, Matrix3 rhs)
        {
            return !(lhs == rhs);
        }
        //required implementation for checking equalities
        public override bool Equals(object? obj)
        {
            return obj != null && Equals((Matrix3)obj);
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

            //return the hashcode
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return "\n[ " + m1.ToString() + " " + m4.ToString() + " " + m7.ToString() + " \n"
                + " " + m2.ToString() + " " + m5.ToString() + " " + m8.ToString() + " \n"
                + " " + m3.ToString() + " " + m6.ToString() + " " + m9.ToString() + " ]";
        }
        #endregion

        #region Transform Factory
        //Translation Matrix for 2D
        // (set the unused z-coordinate to 1)
        public static Matrix3 CreateTranslation(float x, float y)
        {
            return new Matrix3(1f, 0f, 0f, 0f, 1f, 0f, x, y, 1f);
        }

        //Translation Matrix for 2d using a Vector 3 as input
        public static Matrix3 CreateTranslation(Vector3 vec)
        {
            return new Matrix3(1f, 0f, 0f, 0f, 1f, 0f, vec.x, vec.y, vec.z);
        }

        //Rotation on X-axis
        public static Matrix3 CreateRotateX(float a)
        {
            return new Matrix3((1f), (0f), (0f),
                                (0f), (MathF.Cos(a)), (-MathF.Sin(a)),
                                (0f), (MathF.Sin(a)), (MathF.Cos(a)));
        }

        //Rotation on Y-Axis
        public static Matrix3 CreateRotateY(float a)
        {
            return new Matrix3((MathF.Cos(a)), (0), (MathF.Sin(a)),
                                (0), (1), (0),
                                (-MathF.Sin(a)), (0), (MathF.Cos(a)));
        }

        //Rotation on Z-Axis
        public static Matrix3 CreateRotateZ(float a)
        {
            return new Matrix3((MathF.Cos(a)), (-MathF.Sin(a)), (0f),
                                (MathF.Sin(a)), (MathF.Cos(a)), (0f),
                                (0f), (0f), (1f));
        }

        //rotation on XYZ-Axes
        public static Matrix3 Euler(float pitch, float yaw, float roll)
        {
            //combine rotations in a specific order:
            //for right handed coordinate systems: pitch * yaw  * roll
            //reverse order for right handed?

            return CreateRotateX(pitch) * CreateRotateY(yaw) * CreateRotateZ(roll);
        }

        //Scale in 2D
        //  (assume Z is 1)
        public static Matrix3 CreateScale(float xScale, float yScale)
        {
            return new Matrix3((xScale), (0f), (0f),
                                (0f), (yScale), (0f),
                                (0f), (0f), (1f));
        }

        // scale in 3D
        public static Matrix3 CreateScale(float xScale, float yScale, float zScale)
        {
            return new Matrix3((xScale), (0f), (0f),
                                (0f), (yScale), (0f),
                                (0f), (0f), (zScale));
        }

        public static Matrix3 CreateScale(Vector3 scale)
        {
            return new Matrix3((scale.x), (0f), (0f),
                                (0f), (scale.y), (0f),
                                (0f), (0f), (scale.z));
        }
        #endregion

        #region Transform Methods
        // only set the translation component of the matrix
        public void SetTranslation(float x, float y)
        {
            m7 = x;
            m8 = y;
        }

        // only set the translation component of the matrix
        public void SetTranslation(Vector3 v)
        {
            m7 = v.x;
            m8 = v.y;
            m9 = v.z;
        }

        // add x and y onto the translation component of the matrix
        public void Translate(float x, float y)
        {
            m7 += x;
            m8 += y;
        }

        // returns the translation component of the matrix
        public Vector3 GetTranslation()
        {
            return new Vector3(m7, m8, m9);
        }

        // rotates the existing matrix by a certain amount on the X-axis
        public void RotateX(float radians)
        {
            //x column does not change

            //y column does

            m5 = MathF.Cos(radians);
            m6 = MathF.Sin(radians);

            //z column does

            m8 = -MathF.Sin(radians);
            m9 = MathF.Cos(radians);
        }

        // rotates the existing matrix by a certain amount on the Y-axis
        public void RotateY(float radians)
        {
            //x column does
            m1 = MathF.Cos(radians);

            m3 = -MathF.Sin(radians);

            //y column does not change​

            //z column does
            m7 = MathF.Sin(radians);

            m9 = MathF.Cos(radians);
        }

        // rotates the existing matrix by a certain amount on the Z-axis
        public void RotateZ(float radians)
        {
            //x column does
            m1 = MathF.Cos(radians);
            m2 = MathF.Sin(radians);


            //y column does
            m4 = -MathF.Sin(radians);
            m5 = MathF.Cos(radians);

        }
        // scales the existing matrix by a certain amount on each axis
        public void Scale(float x, float y, float z)
        {
            m1 *= x;
            m5 *= y;
            m9 *= z;
        }
        // scales the existing matrix by a certain amount on each axis
        public void Scale(Vector3 v)
        {
            m1 *= v.x;
            m5 *= v.y;
            m9 *= v.z;
        }
        #endregion
    }
}