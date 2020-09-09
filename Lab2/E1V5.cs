using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class E1V5
    {
        static void Main(string[] args)
        {
            double
                begin = -8,
                end = 10,
                step = 0.25,
                x = begin;

            Console.WriteLine("|   x   |   y   |");

            while (x <= end)
            {
                double y = double.NaN;
                if (x >= -8 && x < -5)
                    y = -3;
                if (x >= -5 && x < -3)
                    y = x + 3;
                if (x >= -3 && x < 3)
                    y = Math.Sqrt(9 - x * x);
                if (x >= 3 && x < 8)
                    y = (x - 3) * (3d / 5d);
                if (x >= 8 && x <= 10)
                    y = 3;

                Console.WriteLine("|{0,7:F3}|{1,7:F3}|", x, y);
                x += step;
            }

            Console.ReadKey();
        }
    }
}
