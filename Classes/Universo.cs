using System;
namespace TrabalhoN1.Classes
{
    public class Universo
    {
        public double Tempo { get; set; }
        
        public void CalcularIteracao(Corpo[] CorposCelestes)
        {
            for (int i = 0; i < CorposCelestes.Length; i++)
            {
                for (int j = 0; j < CorposCelestes.Length; j++)
                {
                    if (i != j)
                    {
                        CalculaForcas(CorposCelestes[i],CorposCelestes[j]);
                    }
                }
                CalcularPosicao(CorposCelestes[i]);
                CalcularVelocidade(CorposCelestes[i]);
            }
        }
        private double CalculaDistancia(Corpo corpo1, Corpo corpo2)
        {
            double d = 0;
            double x2 = Math.Pow((corpo1.PosX - corpo2.PosX),2);
            double y2 = Math.Pow((corpo1.PosY - corpo2.PosY),2);
            d = Math.Sqrt(x2+y2);
            return d; //572.7704601321545
        }
        public void CalculaForcas(Corpo corpo1, Corpo corpo2)
        {
            double G = 6.674184 * Math.Pow(10,-11);
            double Forca = 0;
            double distancia =  CalculaDistancia(corpo1, corpo2);
            Forca = G*(corpo1.Massa*corpo2.Massa)/Math.Pow(distancia,2); //6.074056279975799E-06
            
            corpo1.ForcaX += Forca * (corpo1.PosX - corpo2.PosX) / distancia; //6.055281089506516E-06
            corpo1.ForcaY += Forca * (corpo1.PosY - corpo2.PosY) / distancia; //-4.772112942693402E-07
        }
        public void CalcularPosicao(Corpo corpo)
        {
            double ax = (corpo.ForcaX * corpo.Massa);

            corpo.PosX += (corpo.VelX * Tempo) + ((corpo.ForcaX * corpo.Massa)/2) * (Tempo*Tempo); //1264.39165689528285
            corpo.PosY += (corpo.VelY * Tempo) + ((corpo.ForcaY * corpo.Massa)/2) * (Tempo*Tempo); //391.2458414005469
        }
        public void CalcularVelocidade(Corpo corpo)
        {
            corpo.VelX += corpo.ForcaX * corpo.Massa;
            corpo.VelY += corpo.ForcaY * corpo.Massa;
        }

        public string LogIteracao(Corpo[] CorposCelestes)
        {
            string log = string.Empty;

            foreach (Corpo corpo in CorposCelestes)
            {
                log += Convert.ToString(corpo.Nome)+";"+
                    Convert.ToString(corpo.Massa)+";"+
                    Convert.ToString(corpo.Raio)+";"+
                    Convert.ToString(corpo.PosX)+";"+
                    Convert.ToString(corpo.PosY)+";"+
                    Convert.ToString(corpo.VelX)+";"+
                    Convert.ToString(corpo.VelY)+Environment.NewLine
                ;
            }

            return log;
        }
    }
}