namespace TrabalhoN1.Classes
{
    public class Corpo
    {
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
    }
}