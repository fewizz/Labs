using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8Lib;

namespace Lab8
{

    class Program
    {
        static void Main(string[] args)
        {
            int i0;
            int[] ia = new int[5];
            ArrayUtil.FillRandom(ia, 0, 100);
            Console.WriteLine("FillRandom(0, 100): " + ArrayUtil.ToString(ia));
            Console.WriteLine("Sum: " + ArrayUtil.Sum(ia));
            Console.WriteLine("Mul: " + ArrayUtil.Mul(ia));
            Console.WriteLine("Max: " + ArrayUtil.Max(ia, out i0) + ", index="+i0);

            Console.WriteLine();

            double[] da = new double[5];
            ArrayUtil.FillRandom(da);
            Console.WriteLine("FillRandom: " + ArrayUtil.ToString(da));
            Console.WriteLine("Sum: " + ArrayUtil.Sum(da));
            Console.WriteLine("Mul: " + ArrayUtil.Mul(da));
            Console.WriteLine("Max: " + ArrayUtil.Max(da, out i0) + ", index=" + i0);

            Console.WriteLine();

            string[] sa = new string[5];
            ArrayUtil.FillRandom(sa, 10);
            Console.WriteLine("FillRandom: " + ArrayUtil.ToString(sa));
            Console.WriteLine("Max: " + ArrayUtil.MaxBySize(sa, out i0) + ", index=" + i0);

            Console.ReadKey();
        }
    }
}
