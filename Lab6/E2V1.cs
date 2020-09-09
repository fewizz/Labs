using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class E2V1
    {
        public static void Main(string[] args)
        {
            string path = "../../E2V1/";

            string[] persons =
                new StreamReader(path + "names.txt").ReadToEnd()
                .Split(
                    new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries
                );

            List<string> personsList = persons.ToList();

            while(personsList.Count > 0)
            {
                string[] person0 = personsList.First().Split();

                string result = "";
                int mathces = 0;
                
                for (int index = 0; index < personsList.Count;)
                {
                    string[] person = personsList[index].Split();

                    if (person0[0].Equals(person[0]))
                    {
                        mathces++;
                        result += person[1] + " " + person[2] + "\n";
                        personsList.RemoveAt(index);
                    }
                    else index++;
                }

                if (mathces >= 2)
                    using(StreamWriter sw = new StreamWriter(path + person0[0] + ".txt"))
                    {
                        sw.WriteLine(result);
                    }
                
            }

            int maxAge = -1;

            foreach (string person in persons)
                maxAge = Math.Max(maxAge, int.Parse(person.Split()[3]));

            using (StreamWriter ma = new StreamWriter(path + "maxAge.txt"))
            {
                ma.WriteLine(maxAge);
            }
        }
    }
}
