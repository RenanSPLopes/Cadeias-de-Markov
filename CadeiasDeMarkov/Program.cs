using System;

namespace CadeiasDeMarkov
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrizP = new double[3, 3];

            Console.WriteLine("*** Cadeias de Markov***");
            Console.WriteLine("Entre com a matriz P (tamanho 3x3): ");

            CarregaMatriz(matrizP);

            Console.WriteLine("Digite n: ");
            int n = int.Parse(Console.ReadLine());

            var pDeN = CalculaPDeN(matrizP, n);

            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
            {
                Console.WriteLine(string.Format("{0}{1} : {2}",i, j, Math.Round(pDeN[i, j], 3)));
            }

            Console.ReadLine();
        }

        private static double[,] CalculaPDeN(double[,] matrizP, int n)
        {
            var resultado = new double[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    resultado[i, j] = ProdutoEscalar(i, j, matrizP);
                }

            return resultado;
        }

        private static double ProdutoEscalar(int i, int j, double[,] matrizP)
        {
            double total = 0;
            for(int x = 0; x < 3; x++)
            {
                total += matrizP[i, x] * matrizP[x, j];
            }

            return total;
        }

        private static void CarregaMatriz(double[,] matrizP)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(string.Format("Digite o valor [{0}][{1}] da matriz :", i, j));
                    var v = Console.ReadLine();
                    matrizP[i, j] = double.Parse(v);
                }
        }
    }
}
