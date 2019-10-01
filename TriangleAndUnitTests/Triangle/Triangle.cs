using System;

namespace Triangle
{
    public class Triangle
    {
        public static bool FixingTriangle(double a, double b, double c)
        {
           return (a < b + c && b < a + c && c < a + b) && (a > 0 && b > 0 && c > 0);
        }
    }
}
