using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class Matrix4TransformTests
    {
        [TestMethod]
        public void Matrix4SetRotateX()
        {
            Matrix4 m4a = Matrix4.CreateRotateX(4.5f);

            // https://www.wolframalpha.com/input/?i=%7B+++++%7B1%2C+0%2C+0%2C+0%7D%2C+++++%7B0%2C+cos%284.5%29%2C+sin%284.5%29%2C+0%7D%2C+++++%7B0%2C+-sin%284.5%29%2C+cos%284.5%29%2C+0%7D%2C+%7B0%2C0%2C0%2C1%7D+%7D
            Assert.AreEqual(new Matrix4(1, 0, 0, 0,
                            0, -0.210796f, 0.97753f, 0,
                            0, -0.97753f, -0.210796f, 0,
                            0, 0, 0, 1), m4a);
        }

        [TestMethod]
        public void Matrix4SetRotateY()
        {
            Matrix4 m4b = Matrix4.CreateRotateY(-2.6f);

            // https://www.wolframalpha.com/input/?i=%7B+++++%7Bcos%28-2.6%29%2C+0%2C+-sin%28-2.6%29%2C+0%7D%2C+++++%7B0%2C+1%2C+0%2C+0%7D%2C+++++%7Bsin%28-2.6%29%2C+0%2C+cos%28-2.6%29%2C+0%7D%2C+%7B0%2C0%2C0%2C1%7D+%7D
            Assert.AreEqual(new Matrix4(-0.856889f, 0, -0.515501f, 0,
                            0, 1, 0, 0,
                            0.515501f, 0, -0.856889f, 0,
                            0, 0, 0, 1), m4b);
        }

        [TestMethod]
        public void Matrix4SetRotateZ()
        {
            Matrix4 m4c = Matrix4.CreateRotateZ(0.72f);

            // https://www.wolframalpha.com/input/?i=%7B+%7Bcos%280.72%29%2C+sin%280.72%29%2C+0%2C+0%7D%2C+%7B-sin%280.72%29%2C+cos%280.72%29%2C+0%2C+0%7D%2C+%7B0%2C+0%2C+1%2C+0%7D%2C+%7B0%2C+0%2C+0%2C+1%7D+%7D
            Assert.AreEqual(new Matrix4(0.751806f, -0.659385f, 0, 0,
                            0.659385f, 0.751806f, 0, 0,
                            0, 0, 1, 0,
                            0, 0, 0, 1), m4c);
        }

        [TestMethod]
        public void Vector4MatrixRotateY()
        {
            Matrix4 m4b = Matrix4.CreateRotateY(-2.6f);

            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = m4b * v4a;

            Assert.AreEqual(new Vector4(432.79425f, -48.23f, -745.597351f, 0), v4b);
        }

        [TestMethod]
        public void Vector4MatrixRotateZ()
        {
            // homogeneous point translation
            Matrix4 m4c = Matrix4.CreateRotateZ(2.2f);
            m4c.m13 = 55; m4c.m14 = 44; m4c.m15 = 99; m4c.m16 = 1;

            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 1);

            Vector4 v4c = m4c * v4a;
            Assert.AreEqual(new Vector4(8.061456f, 61.468708f, 45, 1), v4c);
        }

        [TestMethod]
        public void Vector4MatrixRotateZ2()
        {
            // homogeneous point translation
            Matrix4 m4c = Matrix4.CreateRotateZ(2.2f);
            m4c.m13 = 55; m4c.m14 = 44; m4c.m15 = 99; m4c.m16 = 1;

            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 0);

            Vector4 v4c = m4c * v4a;
            Assert.AreEqual(new Vector4(-46.9385452f, 17.46871f, -54, 0), v4c);
        }



        [TestMethod]
        public void Vector4MatrixRotateZ3()
        {
            Matrix4 m4c = Matrix4.CreateRotateZ(0.72f);

            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = m4c * v4a;

            Assert.AreEqual(new Vector4(-21.6527443f, -45.16128f, 862, 0), v4b);
        }
    }
}