using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class E2Sh
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int K = 0;
            for(int begin = 0, index = 0; index < str.Length; index++)
            {
                char ch = str[index];
                if(!char.IsLetter(ch))
                {
                    begin = index = index + 1;
                    continue;
                }

                int size = index - begin + 1;
                if (size > K && size <= 20) K = size;
            }
            Console.WriteLine(K);

            for (int j = 0; j < str.Length; ++j)
            {
                char ch = str[j];

                if (char.IsLetter(ch))
                {
                    int begin = ch >= 'a' ? 'a' : 'A';
                    int letter = ch - begin;
                    int transfomedLetter = (letter + K) % 26;
                    ch = (char) (begin + transfomedLetter);
                }
                Console.Write(ch);
            }

            Console.ReadKey();
        }
    }
}
