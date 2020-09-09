using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class E1V1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int[] arr = new int[int.Parse(Console.ReadLine())];
            
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter value for array element {0}: ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            int product = 1;
            for (int i = 0; i < arr.Length; i += 2)
                product *= arr[i];
            Console.WriteLine("Product of elements with even index: " + product);

            int firstZeroIndex = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == 0) { firstZeroIndex = i; break; }

            int lastZeroIndex = arr.Length;
            for (int i = arr.Length - 1; i >= 0; i--)
                if (arr[i] == 0) { lastZeroIndex = i; break; }

            int sum = 0;
            for(int i = firstZeroIndex + 1; i < lastZeroIndex; i++)
                sum += arr[i];

            Console.WriteLine("Sum of elements between first and last zero: "+sum);

            Console.WriteLine("Array's elements: ");
            foreach(int elem in arr)
                Console.Write(elem + " ");

            Console.ReadKey();
        }
    }
}
