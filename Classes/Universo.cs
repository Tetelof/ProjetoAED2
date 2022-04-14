using System;
namespace TrabalhoN1.Classes
{
    public class Universo
    {
        double G = 6.674184 * Math.Pow(10,-11);
        public double Distancia(Corpo corpo1, Corpo corpo2)
        {
            double d = 0;
            double x2 = Math.Pow((corpo2.PosX-corpo1.PosX),2);
            double y2 = Math.Pow((corpo2.PosY-corpo1.PosY),2);
            d = Math.Sqrt(x2+y2);
            return d;
        }
        public double Forca(Corpo corpo1, Corpo corpo2)
        {
            double f = 0;

            return f;
        }
    }
}