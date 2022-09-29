namespace MathLibrary
{
    public struct Colour
    {
        public UInt32 colour;

        public byte Red
        {
            get { return (byte)((colour >> 24) & 0xff); }
            set { colour = (colour & 0x00ffffff) | ((UInt32)value << 24); }
        }

        public byte Green
        {
            get { return (byte)((colour >> 16) & 0xff); }
            set { colour = (colour & 0xff00ffff) | ((UInt32)value << 16); }
        }

        public byte Blue
        {
            get { return (byte)((colour >> 8) & 0xff); }
            set { colour = (colour & 0xffff00ff) | ((UInt32)value << 8); }
        }

        public byte Alpha
        {
            get { return (byte)((colour >> 0) & 0xff); }
            set { colour = (colour & 0xffffff00) | ((UInt32)value << 0); }
        }

        public Colour(byte r, byte g, byte b, byte a)
        {
            colour = 0;
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }
    }
}