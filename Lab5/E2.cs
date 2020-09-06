using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class E2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            String text = Console.ReadLine();

            int K = -1;

            // Also works when text contains only one letter
            for (int chi = 0, begin = -1; chi < text.Length; chi++)
            {
                char ch = text[chi];

                bool isLetter = ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z';

                if (begin == -1) {
                    if (isLetter)
                        begin = chi;
                    else continue;
                }

                int size = chi - begin;
                if (isLetter) size++; // consider this letter too
                K = Math.Max(K, Math.Min(20, size));
                if(!isLetter)
                    begin = -1;
            }

            char[] transformedText = text.ToCharArray();

            for (int chi = 0; chi < text.Length; chi++)
            {
                char ch = text[chi];

                bool uppercase = ch >= 'A' && ch <= 'z';
                bool lowercase = ch >= 'a' && ch <= 'z';

                int firstChar = -1;

                if (uppercase) firstChar = 'A';
                if (lowercase) firstChar = 'a';
                if (firstChar == -1) continue;

                int engLettersCount = 'z' - 'a' + 1;
                int oldLetter = ch - firstChar;
                int newLetter = (oldLetter + K) % engLettersCount;

                transformedText[chi] = (char) (firstChar + newLetter);
            }

            Console.WriteLine(transformedText);

            Console.WriteLine("K: " + K);
            Console.ReadKey();
        }
    }
}
