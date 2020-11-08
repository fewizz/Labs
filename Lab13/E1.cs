using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class E1
    {
        public delegate double Func(double x);

        static void Main(string[] args)
        {
            Func F = (double x) => x + 1;

            double result = FindX(F, -2, 4, 0.0001);

            Console.WriteLine("x = " + result);

            Console.ReadKey();
        }

        public static double FindX(Func F, double a, double b, double e)
        {
            double middle = -1;

            while (true)
            {
                middle = (a + b) / 2.0;

                int middleSign = Math.Sign(F(middle));

                if (Math.Sign(F(a)) != middleSign)
                    b = middle;

                else
                if (Math.Sign(F(b)) != middleSign)
                    a = middle;

                else throw new Exception("Can't find interception of line with y = 0");

                if (b - a < e) return middle;
            }
        }
    }
}
