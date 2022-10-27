namespace MathLibrary
{
    public struct Colour
    {
        //The full color value
        public UInt32 colour;

        //Sets the red value
        public byte Red
        {
            get { return (byte)((colour >> 24) & 0xff); }
            set { colour = (colour & 0x00ffffff) | ((UInt32)value << 24); }
        }

        //Sets the green value
        public byte Green
        {
            get { return (byte)((colour >> 16) & 0xff); }
            set { colour = (colour & 0xff00ffff) | ((UInt32)value << 16); }
        }

        //Sets the blue value
        public byte Blue
        {
            get { return (byte)((colour >> 8) & 0xff); }
            set { colour = (colour & 0xffff00ff) | ((UInt32)value << 8); }
        }

        //Sets the alpha
        public byte Alpha
        {
            get { return (byte)((colour >> 0) & 0xff); }
            set { colour = (colour & 0xffffff00) | ((UInt32)value << 0); }
        }

        //Color Constructor that assigns everything
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