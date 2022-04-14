namespace TrabalhoN1.Classes
{
    public class Corpo
    {
        public string Nome { get; set; }
        public float Massa { get; set; }
        public float Raio { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }


        public Corpo()
        {
            Nome = "";
        }
        public float Aceleracao(float forca)
        {
            float a = 0;
            a = forca * Massa;
            return a;
        }
    }
}