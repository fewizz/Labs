using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class E1V9
    {
        static void Main(string[] args)
        {
            double
                begin = -7,
                end = 3,
                step = 0.25,
                x = begin;

            Console.WriteLine("|   x   |   y   |");

            while (x <= end)
            {
                double y = double.NaN;
                if (x >= -7 && x < -6)
                    y = 2;
                if (x >= -6 && x < -2)
                    y = 0.25*(x + 2);
                if (x >= -2 && x < 0)
                    y = 2 - Math.Sqrt(-x*(4 + x));
                if (x >= 0 && x < 2)
                    y = Math.Sqrt(4 - x * x);
                if (x >= 2 && x <= 3)
                    y = -x + 2;

                Console.WriteLine("|{0,7:F3}|{1,7:F3}|", x, y);
                x += step;
            }

            Console.ReadKey();
        }
    }
}
