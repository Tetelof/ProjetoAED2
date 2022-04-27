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
            }
            foreach (Corpo corpo in CorposCelestes)
            {
                CalcularPosicao(corpo);
                CalcularVelocidade(corpo);
                corpo.ForcaX = 0;
                corpo.ForcaY = 0;
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
            double distancia =  CalculaDistancia(corpo1, corpo2); //572.7704601321545
            Forca = G*(corpo1.Massa*corpo2.Massa)/Math.Pow(distancia,2); //0.000010001
            
            corpo1.ForcaX += Forca * (corpo2.PosX - corpo1.PosX) / distancia; //-0.996911498
            corpo1.ForcaY += Forca * (corpo2.PosY - corpo1.PosY) / distancia; //4.772112942693402E-07
        }
        public void CalcularPosicao(Corpo corpo)
        {
            double ax = (corpo.ForcaX * corpo.Massa);
            double posx = (corpo.VelX * Tempo) + (((corpo.ForcaX / corpo.Massa)/2) * (Tempo*Tempo)); //109.67+ (-1.62149) * 100
            double posy = (corpo.VelY * Tempo) + (((corpo.ForcaY / corpo.Massa)/2) * (Tempo*Tempo));

            corpo.PosX = corpo.PosX + posx; //1264.39165689528285
            corpo.PosY = corpo.PosY + posy; //391.2458414005469
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
                log += "Nome " + Convert.ToString(corpo.Nome)+"; "+
                    "Massa " + Convert.ToString(Math.Round(corpo.Massa,2))+"; "+
                    "Raio " + Convert.ToString(Math.Round(corpo.Raio,2))+"; "+
                    "PosX " + Convert.ToString(Math.Round(corpo.PosX,2))+"; "+
                    "PosY " + Convert.ToString(Math.Round(corpo.PosY,2))+"; "+
                    "VelX " + Convert.ToString(Math.Round(corpo.VelX,2))+"; "+
                    "VelY " + Convert.ToString(Math.Round(corpo.VelY,2))+Environment.NewLine
                ;
            }

            return log;
        }
        public void CalculaColisao(Corpo[] corpos)
        {
            for (int i = 0; i < corpos.Length; i++)
            {
                for (int j = 0; j < corpos.Length; j++)
                {
                    if (i != j)
                    {
                        if ((corpos[i].PosX + corpos[i].Raio < corpos[j].PosX + corpos[j].Raio)&&(corpos[i].PosY + corpos[i].Raio < corpos[j].PosY + corpos[j].Raio))
                        {
                            double memx = corpos[i].VelX;
                            double memy = corpos[i].VelY;
                            corpos[i].VelX = corpos[j].VelX;
                            corpos[i].VelY = corpos[j].VelY;
                            corpos[j].VelX = memx;
                            corpos[j].VelY = memy;
                        }
                    }
                }
            }
        }
    }
}