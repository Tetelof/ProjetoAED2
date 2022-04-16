using System;
namespace TrabalhoN1.Classes
{
    public class Universo
    {
        double G = 6.674184 * Math.Pow(10,-11);
        public double Tempo { get; set; }
        
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
            f = G*(corpo1.Massa*corpo2.Massa)/Distancia(corpo1,corpo2);

            return f;
        }
        public double[] Posicao(Corpo corpo1, Corpo corpo2)
        {
            // nao sei se é necessario calcular força para conseguir a posição, se nao precisar, pode remover o corpo2 da função
            // provavelmente era pra essa função estar na outra classe...


            double[] posicao = new double[] {0,0};
            // formula S = S0 + V0*T + a/2*t^2 onde:
            // S= posX/Y final, 
            // S0= posX/Y atual, 
            // V0= VelX/Y atual, 
            // T= Tempo,
            // a= aceleração

            double a2t2 = corpo1.Aceleracao(Forca(corpo1,corpo2))/2 * Math.Pow(Tempo,2);

            double posX = corpo1.PosX + (corpo1.VelX * Tempo) + a2t2;
            double posY = corpo1.PosY + (corpo1.VelY * Tempo) + a2t2;
            posicao[0] = posX;
            posicao[1] = posY;

            return posicao;
        }

        public double[] Velocidade(Corpo corpo1, Corpo corpo2)
        {

            // provavelmente era pra essa função estar na outra classe...
            // ia fazer as coisas ficarem pelo menos mais simples

            double[] velocidade = new double[] {0,0};

            double at = corpo1.Aceleracao(Forca(corpo1,corpo2)) * Tempo;
            
            double velX = corpo1.VelX * at;
            double velY = corpo1.VelY * at;

            velocidade[0] = velY;
            velocidade[1] = velX;


            return velocidade;
        }
        
    }
}