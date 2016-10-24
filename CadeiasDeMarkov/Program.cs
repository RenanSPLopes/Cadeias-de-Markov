using System;
using System.Runtime.Remoting;

namespace CadeiasDeMarkov
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrizP = new double[3, 3];
            var matrizM = new double[1,3];

            Console.WriteLine("*** Cadeias de Markov***");
            Console.WriteLine("Entre com a matriz P (tamanho 3x3): ");

            CarregaMatrizP(matrizP);

            Console.WriteLine("Digite M : ");
            CarregaMatrizM(matrizM);

            Console.WriteLine("Digite n: ");
            int n = int.Parse(Console.ReadLine());

            var pDeN = CalculaPdeN(matrizP, matrizP, n);

            var m = CalculaM(matrizM, pDeN);
            ImprimeMatriz(pDeN, n);
            ImprimeMM(m, n);

            Console.ReadLine();
        }

        private static double[,] CalculaM(double[,] matrizM, double[,] pDeN)
        {
            var resultado = new double[1,3];
            for (int i = 0; i < 3; i++)
            {
                resultado[0,i] = ProdutoEscalar(0, i, matrizM, pDeN);
            }

            return resultado;
        }

        private static double[,] CalculaPdeN(double[,] matrizA, double[,] matrizB, int n)
        {
            if (n == 1)
                return matrizA;

            var resultado = new double[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    resultado[i, j] = ProdutoEscalar(i, j, matrizA, matrizB);
                }

            return CalculaPdeN(resultado, matrizA, n-1);
        }

        private static double ProdutoEscalar(int i, int j, double[,] matrizA, double[,] matrizB)
        {
            double total = 0;
            for(int x = 0; x < 3; x++)
            {
                total += matrizA[i, x] * matrizB[x, j];
            }

            return total;
        }

        private static void CarregaMatrizP(double[,] matrizP)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Digite o valor [{i}][{j}] da matriz :");
                    var v = Console.ReadLine();
                    matrizP[i, j] = double.Parse(v);
                }
        }

        private static void CarregaMatrizM(double[,] matrizM)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Digite o valor {i} de M : ");
                var v = Console.ReadLine();
                matrizM[0, i] = double.Parse(v);
            }
        }

        private static void ImprimeMatriz(double[,] pDeN, int n)
        {
            Console.WriteLine($"\n**** P({n}): ****");
            Console.Write($"[{Math.Round(pDeN[0, 0], 3)} ");
            Console.Write($"{Math.Round(pDeN[0, 1], 3)} ");
            Console.WriteLine($"{Math.Round(pDeN[0, 2], 3)}]");
            Console.Write($"[{Math.Round(pDeN[1, 0], 3)} ");
            Console.Write($"{Math.Round(pDeN[1, 1], 3)} ");
            Console.WriteLine($"{Math.Round(pDeN[1, 2], 3)}]");
            Console.Write($"[{Math.Round(pDeN[2, 0], 3)} ");
            Console.Write($"{Math.Round(pDeN[2, 1], 3)} ");
            Console.WriteLine($"{Math.Round(pDeN[2, 2], 3)}]");
        }

        private static void ImprimeMM(double[,] m, int n)
        {
            Console.WriteLine($"\n**** M({n}): ****");
            Console.Write($"[{Math.Round(m[0, 0], 3)} ");
            Console.Write($"{Math.Round(m[0, 1], 3)} ");
            Console.WriteLine($"{Math.Round(m[0, 2], 3)}]");
        }
    }
}
