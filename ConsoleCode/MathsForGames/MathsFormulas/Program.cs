using AIE;

class Program
{
     static void main(string[] args)
    {
      float quad = MathsFormulas.BasicQuadratic(5.0f);
        
        float sqrtofFour=(float)Math.Sqrt(4);

        MathsFormulas.QuadraticRoots roots = MathsFormulas.GetQuadraticRoots(1, -5, 4);
        
        return;
    }
}