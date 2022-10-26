using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Colour
    {
        public UInt32 colour;

        public Colour(byte r, byte g, byte b, byte a)
        {
            //  shift r to the 0x00ffffff
            //  shift b to the 0xff00ffff
            //  shift g to the 0xffff00ff
            //  just add a to the end @ 0xffffff00
            colour = (UInt32)(r << 24) | (UInt32)(g << 16) | (UInt32)(b << 8) | (UInt32)(a);
        }

        public byte Red
        {
            get
            {
                //  RGBA
                //      shifts the R component of colour all the way to the right (in this case 24 bits)
                return (byte)(colour >> 24);
            }
            set
            {
                //applies a bitmask to ONLY work in the corresponding byte
                colour = (colour & 0x00ffffff) | ((UInt32)value << 24);
            }
        }
        public byte Green
        {
            get
            {
                //  RGBA
                //      shifts the G component to the right  (in this case 16)
                return (byte)(colour >> 16);
            }
            set
            {
                //applies a bitmask to ONLY work in the corresponding byte
                colour = (colour & 0xff00ffff) | ((UInt32)value << 16);
            }
        }
        public byte Blue
        {
            get
            {
                //  RGBA
                //      shifts the B component to the right  (in this case 8)
                return (byte)(colour >> 8);
            }
            set
            {
                //applies a bitmask to ONLY work in the corresponding byte
                colour = (colour & 0xffff00ff) | ((UInt32)value << 8);
            }
        }
        public byte Alpha
        {
            get
            {
                //RGBA
                //      Alpha is already right most so just return 8 bits from the right
                return (byte)(colour);
            }
            set
            {
                //applies a bitmask to ONLY work in the corresponding byte
                colour = (colour & 0xffffff00) | value;
            }
        }
        public override string ToString()
        {
            return String.Format("R: {0}, G: {1}, B: {2}, A: {3}", Red, Green, Blue, Alpha);
        }
    }
}