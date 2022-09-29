using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

using static UnitTestProject.CompareUtils;

namespace UnitTestProject
{
    [TestClass]
    public class Vector4Tests
    {
        [TestMethod]
        public void Vector4Addition()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            Vector4 v4c = v4a + v4b;

            Assert.IsTrue(compare(new Vector4(18.5f, -44.24f, 850, 1), v4c));
        }

        [TestMethod]
        public void Vector4Subtraction()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            Vector4 v4c = v4a - v4b;

            Assert.IsTrue(compare(new Vector4(8.5f, -52.22f, 874, -1), v4c));
        }

        [TestMethod]
        public void Vector4PostScale()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4c = v4a * 4.89f;

            Assert.IsTrue(compare(new Vector4(66.0149993896f, -235.844696045f, 4215.1796875f, 0), v4c));
        }


        [TestMethod]
        public void Vector4PreScale()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4c = 4.89f * v4a;

            Assert.IsTrue(compare(new Vector4(66.0149993896f, -235.844696045f, 4215.1796875f, 0), v4c));
        }

        [TestMethod]
        public void Vector4Magnitude()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            float mag4 = v4a.Magnitude;

            Assert.AreEqual(mag4, 863.453735352f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector4Normalise()
        {
            Vector4 v4a = new Vector4(243, -48.23f, 862, 0);
            v4a.Normalize();

            Assert.IsTrue(compare(v4a, new Vector4(0.270935f, -0.0537745f, 0.961094f, 0)));
        }

        [TestMethod]
        public void Vector4Dot()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            float dot4 = v4a.Dot(v4b);

            Assert.AreEqual(dot4, -10468.9375f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector4Cross()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            Vector4 v4c = v4a.Cross(v4b);

            Assert.IsTrue(compare(v4c, new Vector4(-2860.62011719f, 4472.00000000f, 295.01498413f, 0)));
        }
    }
}
