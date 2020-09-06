using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class E3
    {
        public static void Main(string[] args)
        {
            int[][] arr2 = new int[5][];
            arr2[0] = new int[5];
            arr2[1] = new int[3];
            arr2[2] = new int[8];
            arr2[3] = new int[4];
            arr2[4] = new int[6];

            Random rand = new Random();
            int sum = 0;
            for (int arrIndex = 0; arrIndex < arr2.Length; arrIndex++)
            {
                for (int i = 0; i < arr2[arrIndex].Length; i++)
                {
                    int val = rand.Next(-500, 501);
                    arr2[arrIndex][i] = val;
                    sum += val;
                }
            }

            Console.WriteLine("Sum of all elements: " + sum);

            Console.WriteLine("Jagged array:");
            for (int arrIndex = 0; arrIndex < arr2.Length; arrIndex++)
            {
                for (int i = 0; i < arr2[arrIndex].Length; i++)
                    Console.Write("{0, -4} ", arr2[arrIndex][i]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
