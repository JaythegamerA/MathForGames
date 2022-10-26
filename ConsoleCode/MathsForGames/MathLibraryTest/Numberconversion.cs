using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class NumberConversionExerciseTests
    {

        [TestMethod]
        public void QuestionThree()
        {
            Colour c = new Colour();
            c.Red = Convert.ToByte((UInt32)94);

            Console.WriteLine(c.ToString());
            Assert.AreEqual("10111100", Convert.ToString(c.Red, 2).PadRight(8, '0'));
        }

        [TestMethod]
        public void QuestionFour()
        {
            Colour c = new Colour();
            c.Red = 94;

            Console.WriteLine(c.ToString());
            Assert.AreEqual("10111100000000000000000000000000",
                Convert.ToString(c.colour, 2).PadRight(32, '0'));
        }

        [TestMethod]
        public void QuestionFive()
        {
            Colour c = new Colour();
            c.Red = 94;

            string colour = Convert.ToString(c.colour, 2).PadRight(32, '0');

            Console.WriteLine(c.ToString());
            Assert.AreEqual(3154116608, Convert.ToUInt32(colour, 2));
        }

        [TestMethod]
        public void QuestionSix()
        {
            Colour c = new Colour();
            c.Red = 94;
            c.colour = (c.colour & 0x00ff0000) | (c.colour >> 8);

            Console.WriteLine(c.ToString());

            Assert.AreEqual("00000000101111000000000000000000",
                ("00000000" + Convert.ToString(c.colour, 2)).PadRight(32, '0'));

        }


        [TestMethod]
        public void QuestionSeven()
        {
            Colour c = new Colour();
            c.Red = 94;
            c.colour = (c.colour & 0x00ff0000) | ((UInt32)c.colour >> 8);

            string colour = ("00000000" + Convert.ToString(c.colour, 2)).PadRight(32, '0');

            Console.WriteLine(c);
            Assert.AreEqual((UInt32)12320768, Convert.ToUInt32(colour.ToString(), 2));
        }

    }
}