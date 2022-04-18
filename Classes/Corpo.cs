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
        public double Angulo(Corpo corpoVizinho)
        {
            double angulo = 0;
            double x2 = corpoVizinho.PosX;
            // theta = ACos((x1-x2)/Hipotenusa)
            // hipotenusa = Distancia()
            double anguloRadiano = Math.Acos((this.PosX-x2)/Distancia(corpoVizinho)); // Math.Acos() retorna angulo em radianos
            angulo = anguloRadiano * 180 / Math.PI; // transformando de radianos para graus

            return angulo;
        }
        public void Velocidade(Corpo[] CorposCelestes, double tempo)
        {
            // nao esta completo
            double[] velXArray = new double[CorposCelestes.Length-1];
            double[] velYArray = new double[CorposCelestes.Length-1];

            foreach (Corpo corpoVizinho in CorposCelestes)
            {
                int count = 0;
                if (corpoVizinho != this)
                {
                    // V = v0 * a * t
                    // a = f * t
                    
                    double Fx = Forca(corpoVizinho) * Math.Cos(Angulo(corpoVizinho));
                    double Fy = Forca(corpoVizinho) * Math.Cos(Angulo(corpoVizinho));

                    velXArray[count] = VelX * Aceleracao(Fx) * tempo;
                    velYArray[count] = VelY * Aceleracao(Fy) * tempo;

                    count++;
                }
            }

            this.VelX = this.VelX + velXArray.Sum();
            this.VelY = this.VelY + velYArray.Sum();
        }
        public void CalcularPosicao(double Tempo)
        {
            PosX = PosX + VelX * Tempo;
            PosY = PosY + VelY * Tempo;
        }
    }
}