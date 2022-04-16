using System;
using System.IO;
using TrabalhoN1.Classes;


namespace TrabalhoN1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Arquivos/inicialTrabalho.uni");
            string linha = sr.ReadLine() ?? "";
            string[] cabecalho = linha.Split(";");

            Universo universo = new Universo();
            universo.Tempo = double.Parse(cabecalho[2]);

            Corpo[] CorposCelestes = new Corpo[int.Parse(cabecalho[0])];

            int count = 0;
            while(sr.EndOfStream)
            {
                linha = sr.ReadLine();
                string[] parametros = linha.Split(";");
                CorposCelestes[count] = new Corpo
                {
                    Nome = parametros[0],
                    Massa = float.Parse(parametros[1]),
                    Raio = float.Parse(parametros[2]),
                    PosX = int.Parse(parametros[3]),
                    PosY = int.Parse(parametros[4]),
                    VelX = int.Parse(parametros[5]),
                    VelY = int.Parse(parametros[6])
                };
                count++;
            }
            sr.Close();

            Console.WriteLine("vrau");
            
        }
    }
}
