using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class E2V7_Shiiskaya
    {
        static void Main(string[] args)
        {
            const int m = 3, n = 4;
            int[,] a = new int[m, n] {
{ 2,-2, 8, 9 },
{-4,-5, 6,-2 },
{ 7, 0, 1, 1 }
};
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write("\t" + a[i, j]);
                Console.WriteLine();

            }
            int negative = 0;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    if (a[j, i] < 0)
                    {
                        negative++;
                        break;
                    }
            Console.WriteLine(n - negative);

            Console.ReadKey();
        }

    }
}
