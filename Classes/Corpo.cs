using System;
using System.Linq;

namespace TrabalhoN1.Classes
{
    public class Corpo
    {
        
        double G = 6.674184 * Math.Pow(10,-11);
        public string Nome { get; set; }
        public double Massa { get; set; }
        public double Raio { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double VelX { get; set; }
        public double VelY { get; set; }


        public Corpo()
        {
            Nome = "";
        }
        public double Aceleracao(double forca)
        {
            double a = 0;
            a = forca * Massa;
            return a;
        }
        public double Distancia(Corpo corpoVizinho)
        {
            double d = 0;
            double x2 = Math.Pow((corpoVizinho.PosX - this.PosX),2);
            double y2 = Math.Pow((corpoVizinho.PosY - this.PosY),2);
            d = Math.Sqrt(x2+y2);
            return d;
        }
        public double Forca(Corpo corpoVizinho)
        {
            double f = 0;
            f = G*(Massa*corpoVizinho.Massa)/Distancia(corpoVizinho);
            return f;

        }
        public void Velocidade(Corpo[] CorposCelestes, double tempo)
        {
            // nao esta completo
            double[] velXArray = new double[CorposCelestes.Length];
            double[] velYArray = new double[CorposCelestes.Length];

            foreach (Corpo corpoVizinho in CorposCelestes)
            {
                int count = 0;
                if (corpoVizinho != this)
                {
                    double at = Aceleracao(Forca(corpoVizinho)) * tempo;
                    velXArray[count] = VelX * at; // precisa calcular o angulo da aceleração, pois nao vai ser igual para x e y
                    velYArray[count] = VelY * at;
                    count++;
                }
            }

            this.VelX = this.VelX + velXArray.Average();
            this.VelY = this.VelY + velYArray.Average();
        }
        public void CalcularPosicao()
        {
            // x = r Cos theta
            // y = r Sin theta
            // r^2 = x^2 + y^2
        }
    }
}