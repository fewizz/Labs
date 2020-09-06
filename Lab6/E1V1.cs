using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class E1V1
    {
        static void Main(string[] args)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y'};
            
            string str = new StreamReader("../../E1.txt")
                                            .ReadToEnd()
                                            .Replace('\n', ' ')
                                            .Replace('\r', ' ');

            foreach (string substr in str.Split('.')) {
                string trimmed = substr.Trim();
                if (trimmed.Equals("")) continue;
                char first = trimmed.ToLower()[0];

                if (vowels.Contains(first)) Console.WriteLine(trimmed+"\n");
            }

            Console.ReadKey();
        }
    }
}
