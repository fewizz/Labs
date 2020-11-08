using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("Enter 5 values for first list:");
            List<int> list1 = new List<int>();
            for(int i = 0; i < 5; i++)
                list1.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine("First list:");
            foreach (int i in list1)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.Write("Enter value to add to the end of first list: ");
            list1.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine("First list after addition:");
            foreach (int i in list1)
                Console.Write(i + " ");
            Console.WriteLine();

            // 2
            Console.WriteLine("Enter 3 values for second list:");
            List<int> list2 = new List<int>();
            for (int i = 0; i < 3; i++)
                list2.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine("Second list:");
            foreach (int i in list2)
                Console.Write(i + " ");
            Console.WriteLine();

            // 3
            list1.InsertRange(2, list2);
            Console.WriteLine("First list after insertion of second list at position 3:");
            foreach (int i in list1)
                Console.Write(i + " ");
            Console.WriteLine();

            // 4
            Console.WriteLine("First list size: " + list1.Count);
            // 5
            Console.WriteLine("First list's max value:" + list1.Max());
            // 6
            Console.WriteLine("First list's min value:" + list1.Min());

            // 7
            Console.WriteLine("Array, created from first list:");
            int[] arr = list1.ToArray();
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();

            // 8
            list2.RemoveAt(1);
            Console.WriteLine("Second list, after removing second element:");
            foreach (int i in list2)
                Console.Write(i + " ");
            Console.WriteLine();

            //
            list1.Insert(0, list1.IndexOf(10));

            Console.ReadKey();
        }
    }
}
