using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class E2V1
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter matrix height: ");
            int matHeight = int.Parse(Console.ReadLine());
            Console.Write("Enter matrix width: ");
            int matWidth = int.Parse(Console.ReadLine());
            int[,] mat = new int[matHeight, matWidth];

            Console.WriteLine("Enter values for mat elements:");
            for (int h = 0; h < matHeight; h++)
            {
                for (int w = 0; w < matWidth; w++)
                {
                    Console.Write("{0},{1}: ", h+1, w+1);
                    mat[h, w] = int.Parse(Console.ReadLine());
                }
            }

            int stringsContainingZero = 0;

            for (int h = 0; h < matHeight; h++)
            {
                for (int w = 0; w < matWidth; w++)
                {
                    if (mat[h, w] == 0)
                    {
                        ++stringsContainingZero;
                        break;
                    }
                }
            }

            Console.WriteLine(
                "Amount of strings not containing zero: "
                + (matHeight - stringsContainingZero)
            );

            Console.WriteLine("Matrix:");
            for (int h = 0; h < matHeight; h++)
            {
                for (int w = 0; w < matWidth; w++)
                    Console.Write("{0, 4} ", mat[h, w]);
                Console.WriteLine();
            }

            for (int w = 0; w < matWidth; w++) {
                int old = mat[0, w];
                mat[0, w] = mat[1, w];
                mat[1, w] = old;
            }

            Console.WriteLine("After 1 and 2 strings swap:");
            for (int h = 0; h < matHeight; h++)
            {
                for (int w = 0; w < matWidth; w++)
                    Console.Write("{0, 4} ", mat[h, w]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
