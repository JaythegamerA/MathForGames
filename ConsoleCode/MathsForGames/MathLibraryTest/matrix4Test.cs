using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class Matrix4Tests
    {
        [TestMethod]
        public void Matrix4Multiply()
        {
            Matrix4 m4b = new Matrix4(1, 4, 1, 7,
                                      2, 3, 2, 8,
                                      3, 2, 3, 9,
                                      4, 1, 4, 1);

            Matrix4 m4c = new Matrix4(4, 7, 3, 4,
                                      5, 6, 4, 6,
                                      6, 5, 6, 8,
                                      7, 4, 5, 2);
            Matrix4 m4d = m4b * m4c;

            // https://www.wolframalpha.com/input/?i=%7B%7B1%2C2%2C3%2C4%7D%2C+%7B4%2C3%2C2%2C1%7D%2C+%7B1%2C2%2C3%2C4%7D%2C+%7B7%2C8%2C9%2C1%7D%7D+*+%7B%7B4%2C5%2C6%2C7%7D%2C+%7B7%2C6%2C5%2C4%7D%2C+%7B3%2C4%2C6%2C5%7D%2C+%7B4%2C6%2C8%2C2%7D%7D
            Assert.AreEqual(new Matrix4(43, 47, 43, 115,
                            53, 52, 53, 125,
                            66, 59, 66, 144,
                            38, 52, 38, 128), m4d);
        }

        [TestMethod]
        public void Vector4MatrixTransform()
        {
            // homogeneous point translation
            Matrix4 m4b = new Matrix4(1, 0, 0, 0,
                                      0, 1, 0, 0,
                                      0, 0, 1, 0,
                                      55, 44, 99, 1);

            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 1);

            Vector4 v4c = m4b * v4a;
            Assert.AreEqual(new Vector4(68.5f, -4.23f, 45, 1), v4c);
        }

        [TestMethod]
        public void Vector4MatrixTransform2()
        {
            // homogeneous point translation
            Matrix4 m4b = new Matrix4(1, 0, 0, 0,
                                      0, 1, 0, 0,
                                      0, 0, 1, 0,
                                      55, 44, 99, 1);

            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 0);

            Vector4 v4c = m4b * v4a;
            Assert.AreEqual(new Vector4(13.5f, -48.23f, -54, 0), v4c);
        }
    }
}