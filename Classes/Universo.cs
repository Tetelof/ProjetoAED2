using System;
namespace TrabalhoN1.Classes
{
    public class Universo
    {
        public double Tempo { get; set; }
        
        public void CalcularIteracao(Corpo[] CorposCelestes)
        {
            Corpo corpo1 = CorposCelestes[0];
            for (int i = 1; i < CorposCelestes.Length; i++)
            {
                CorposCelestes[i].Velocidade(CorposCelestes, Tempo);
                CorposCelestes[i].CalcularPosicao(Tempo);
            }
        }
    }
}