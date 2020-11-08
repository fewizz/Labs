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
            for (int r = 0; r < matHeight; r++)
            {
                for (int c = 0; c < matWidth; c++)
                {
                    Console.Write("{0}, {1}: ", r+1, c+1);
                    mat[r, c] = int.Parse(Console.ReadLine());
                }
            }

            int rowsContainingZero = 0;

            for (int r = 0; r < matHeight; r++)
            {
                for (int c = 0; c < matWidth; c++)
                {
                    if (mat[r, c] == 0)
                    {
                        ++rowsContainingZero;
                        break;
                    }
                }
            }

            Console.WriteLine(
                "Rows not containing zero: "
                + (matHeight - rowsContainingZero)
            );

            Console.WriteLine("Matrix:");
            for (int r = 0; r < matHeight; r++)
            {
                for (int c = 0; c < matWidth; c++)
                    Console.Write("{0, -4} ", mat[r, c]);
                Console.WriteLine();
            }

            for (int c = 0; c < matWidth; c++) {
                int old = mat[0, c];
                mat[0, c] = mat[1, c];
                mat[1, c] = old;
            }

            Console.WriteLine("After 1 and 2 rows swap:");
            for (int r = 0; r < matHeight; r++)
            {
                for (int c = 0; c < matWidth; c++)
                    Console.Write("{0, -4} ", mat[r, c]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
