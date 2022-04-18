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
                CorposCelestes[i].Velocidade(CorposCelestes, Tempo);
                CorposCelestes[i].CalcularPosicao(Tempo);
            }
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