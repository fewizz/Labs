using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class E1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            string res = "";
            foreach (string splitted in str.Split())
                res = splitted + " " + res;
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
