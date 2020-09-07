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
            string txt = new StreamReader(path+"names.txt").ReadToEnd();

            List<string> persons =
                txt.Split(
                    new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries
                ).ToList();

            int maxAge = -1;

            foreach (string subs in persons)
                maxAge = Math.Max(maxAge, int.Parse(subs.Split()[3]));

            while(persons.Count > 0)
            {
                string secondNameToCheck = persons[0].Split()[0];
                StreamWriter sw = null;

                for (int x = 1; x < persons.Count;)
                {
                    string secondName = persons[x].Split()[0];
                    if (secondNameToCheck.Equals(secondName))
                    {
                        if (sw == null)
                        {
                            sw = new StreamWriter(
                                path + secondName + ".txt",
                                true
                            );
                            sw.WriteLine(persons[0].Split()[0]);
                        }

                        sw.WriteLine(persons[x]);
                        persons.RemoveAt(x);
                    }
                    else x++;
                }
                if(sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
                persons.RemoveAt(0);
            }

            using (StreamWriter ma = new StreamWriter(path + "max_age.txt"))
            {
                ma.WriteLine(maxAge);
            }
        }
    }
}
