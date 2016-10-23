using System;

namespace CadeiasDeMarkov
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrizP = new double[3,3];

            Console.WriteLine("*** Cadeias de Markov***");
            Console.WriteLine("Entre com a matriz P (tamanho 3x3): ");

            for(int i = 0; i < 3; i++) 
                for(int j = 0; j < 3; j++)
                {
                    Console.WriteLine(string.Format("Digite o valor [{0}][{1}] da matriz :", i, j));
                    var v = Console.ReadLine();
                    matrizP[i, j] = double.Parse(v);
                }

            //Console.WriteLine("Entre com M : ")

        }
    }
}
