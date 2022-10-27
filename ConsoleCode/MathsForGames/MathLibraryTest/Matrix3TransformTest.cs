using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class Matrix3TransformTests
    {
        [TestMethod]
        public void Vector3MatrixTranslation()
        {
            // homogeneous point translation
            Matrix3 m3b = new Matrix3(1, 0, 0,
                                      0, 1, 0,
                                      55, 44, 1);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 1);

            Vector3 v3b = m3b * v3a;

            Assert.AreEqual(new Vector3(68.5f, -4.23f, 1), v3b);
        }

        [TestMethod]
        public void Vector3MatrixTranslation2()
        {
            // homogeneous point translation
            Matrix3 m3b = new Matrix3(1, 0, 0,
                                      0, 1, 0,
                                      55, 44, 1);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 0);

            Vector3 v3b = m3b * v3a;

            Assert.AreEqual(new Vector3(13.5f, -48.23f, 0), v3b);
        }

        [TestMethod]
        public void Vector3MatrixTranslationMethod()
        {
            // homogeneous point translation
            Matrix3 m3b = Matrix3.CreateTranslation(55, 44);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 1);

            Vector3 v3b = m3b * v3a;

            Assert.AreEqual(new Vector3(68.5f, -4.23f, 1), v3b);
        }

        [TestMethod]
        public void Vector3MatrixTranslationMethod2()
        {
            // homogeneous point translation
            Matrix3 m3b = Matrix3.CreateTranslation(new Vector3(55, 44, 1));

            Vector3 v3a = new Vector3(13.5f, -48.23f, 0);

            Vector3 v3b = m3b * v3a;

            Assert.AreEqual(new Vector3(13.5f, -48.23f, 0), v3b);
        }

        [TestMethod]
        public void Matrix3CreateRotateX()
        {
            Matrix3 m3a = Matrix3.CreateRotateX(3.98f);

            Assert.AreEqual(new Matrix3(1, 0, 0,
                            0, -0.668648f, 0.743579f,
                            0, -0.743579f, -0.668648f), m3a);
        }

        [TestMethod]
        public void Matrix3CreateRotateY()
        {
            Matrix3 m3b = Matrix3.CreateRotateY(1.76f);

            Assert.AreEqual(new Matrix3(-0.188077f, 0, 0.982154f,
                            0, 1, 0,
                            -0.982154f, 0, -0.188077f), m3b);
        }

        [TestMethod]
        public void Matrix3CreateRotateZ()
        {
            Matrix3 m3c = Matrix3.CreateRotateZ(9.62f);

            Assert.AreEqual(new Matrix3(-0.981005f, -0.193984f, 0,
                             0.193984f, -0.981005f, 0,
                             0, 0, 1), m3c);
        }

        [TestMethod]
        public void Vector3MatrixCreateRotateZ2()
        {
            // homogeneous point translation
            Matrix3 m3c = Matrix3.CreateRotateZ(2.2f);
            m3c.m7 = 55; m3c.m8 = 44; m3c.m9 = 1;

            Vector3 v3a = new Vector3(13.5f, -48.23f, 1);

            Vector3 v3c = m3c * v3a;

            Assert.AreEqual(new Vector3(86.04901f, 83.29811f, 1f), v3c);
        }

        [TestMethod]
        public void Vector3MatrixCreateRotateZ3()
        {
            // homogeneous point translation
            Matrix3 m3c = Matrix3.CreateRotateZ(2.2f);
            m3c.m7 = 55; m3c.m8 = 44; m3c.m9 = 1;

            Vector3 v3a = new Vector3(13.5f, -48.23f, 0);

            Vector3 v3c = m3c * v3a;

            Assert.AreEqual(new Vector3(31.049013f, 39.29811f, 0), v3c);
        }

        [TestMethod]
        public void Matrix3CreateScaleMethod2Param()
        {
            Assert.AreEqual(new Matrix3(5.0f, 0.0f, 0.0f,
                0.0f, 6.3f, 0.0f,
                0.0f, 0.0f, 1.0f),
                Matrix3.CreateScale(5.0f, 6.3f));
        }

        [TestMethod]
        public void Matrix3CreateScaleMethod3Param()
        {
            Assert.AreEqual(new Matrix3(5.0f, 0.0f, 0.0f,
               0.0f, 6.3f, 0.0f,
               0.0f, 0.0f, 3.2f),
               Matrix3.CreateScale(5.0f, 6.3f, 3.2f));
        }

        [TestMethod]
        public void Matrix3CreateScaleMethodVectorParam()
        {
            Assert.AreEqual(new Matrix3(5.0f, 0.0f, 0.0f,
                0.0f, 6.3f, 0.0f,
                0.0f, 0.0f, 3.2f),
                Matrix3.CreateScale(new Vector3(5.0f, 6.3f, 3.2f)));
        }
    }
}