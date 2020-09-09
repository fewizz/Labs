using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class E2V5
    {
        public static void Main(string[] args)
        {
            int N;

            while (true)
            {
                try
                {
                    Console.Write("Enter N, from 1(incl.) to 27(excl.): ");
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N < 1 || N >= 27)
                        Console.WriteLine("Invalid N.");
                    else break;
                } catch(FormatException) {
                    Console.WriteLine("FormatException, try again");
                }
            }

            for(int num = 100; num < 1000; num++)
                if (num / 100 + num / 10 % 10 + num % 10 == N)
                    Console.WriteLine(num);

            Console.ReadKey();
        }
    }
}
