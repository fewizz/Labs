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
            string resultPath = path + "result/";

            string[] persons =
                new StreamReader(path + "names.txt", Encoding.UTF8).ReadToEnd()
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
                    string[] person1 = personsList[index].Split();

                    if (person0[0].Equals(person1[0]))
                    {
                        mathces++;
                        result += person1[1] + " " + person1[2] + "\r\n";
                        personsList.RemoveAt(index);
                    }
                    else index++;
                }

                if (mathces >= 2)
                    using(StreamWriter sw = new StreamWriter(resultPath + person0[0] + ".txt"))
                    {
                        sw.WriteLine(result);
                    }
                
            }

            int maxAge = -1;

            foreach (string person in persons)
                maxAge = Math.Max(maxAge, int.Parse(person.Split()[3]));

            using (StreamWriter ma = new StreamWriter(resultPath + "максимальный_возраст.txt"))
            {
                ma.WriteLine(maxAge);
            }
        }
    }
}
