using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class Matrix3Tests
    {
        [TestMethod]
        public void Matrix3ReflexiveProperty()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Assert.IsTrue(m3a.Equals(m3a));
        }

        [TestMethod]
        public void Matrix3SymmetricProperty()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Matrix3 m3b = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Assert.IsTrue(m3a.Equals(m3b) && m3b.Equals(m3a));
        }

        [TestMethod]
        public void Matrix3TransitiveProperty()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Matrix3 m3b = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Matrix3 m3c = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Assert.IsTrue(m3a.Equals(m3b) && m3b.Equals(m3c) && m3a.Equals(m3c));
        }

        [TestMethod]
        public void Matrix3SuccessiveEquality()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Matrix3 m3b = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Assert.IsTrue(m3a.Equals(m3b));
            Assert.IsTrue(m3a.Equals(m3b));
            Assert.IsTrue(m3a.Equals(m3b));
        }

        [TestMethod]
        public void Matrix3EqualsEqualityParity()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
#pragma warning disable CS1718 // Comparison made to same variable
            Assert.IsTrue(m3a.Equals(m3a) && m3a == m3a);
#pragma warning restore CS1718 // Comparison made to same variable
        }

        [TestMethod]
        public void Matrix3EqualsInequalityParity()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Matrix3 m3b = new Matrix3(34, -34, 12, 79, 23, 89, 23, 75, 71);

            Assert.IsTrue(!m3a.Equals(m3b) && m3a != m3b);
        }

        [TestMethod]
        public void Matrix3EqualityOperator()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Matrix3 m3b = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);

            Assert.IsTrue(m3a == m3b);
        }

        [TestMethod]
        public void Matrix3InequalityOperator()
        {
            Matrix3 m3a = new Matrix3(13.5f, -48.23f, 862, 45, 12, 89, 45, 87, 7);
            Matrix3 m3b = new Matrix3(34, -34, 12, 79, 23, 89, 23, 75, 71);

            Assert.IsTrue(m3a != m3b && !(m3a == m3b));
        }

        [TestMethod]
        public void Matrix3Multiply()
        {
            Matrix3 m3a = new Matrix3(1, 3, 1, 2, 2, 2, 3, 1, 3);
            Matrix3 m3c = new Matrix3(4, 6, 4, 5, 5, 6, 6, 4, 5);

            Matrix3 m3d = m3a * m3c;

            Assert.AreEqual(new Matrix3(28, 28, 28, 33, 31, 33, 29, 31, 29), m3d);
        }

        [TestMethod]
        public void Vector3MatrixTransform()
        {
            Matrix3 m3b = Matrix3.CreateRotateY(1.76f);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = m3b * v3a;

            Assert.AreEqual(new Vector3(-849.156067f, -48.23f, -148.863144f), v3b);
        }

        [TestMethod]
        public void Vector3MatrixTransform2()
        {
            Matrix3 m3c = Matrix3.CreateRotateZ(9.62f);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3c = m3c * v3a;

            Assert.AreEqual(new Vector3(-22.599422f, 44.69507f, 862f), v3c);
        }
    }
}