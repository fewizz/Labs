using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{

    public class Person
    {
        public string Name {get; set;}
        public string SecondName { get; set; }
        public string Father { get; set; }
        public uint Age { get; set; }

        public override string ToString()
        {
            return SecondName + " " + Name + " " + Age;
        }

        public static List<Person> ReadFrom(string path) {
            List<Person> persons = new List<Person>();

            foreach (
                string str 
                in new StreamReader(path, Encoding.UTF8)
                .ReadToEnd()
                .Split(
                    new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries
                )
            )
            {
                string[] splitted = str.Split();
                persons.Add(
                    new Person {
                        Name = splitted[1],
                        SecondName = splitted[0],
                        Father = splitted[2],
                        Age = uint.Parse(splitted[3])
                    }
                );
            }

            return persons;
        }
    }

    public class Program
    {

        public static void Print(IEnumerable<object> coll)
        {
            foreach (var o in coll) Console.WriteLine(o.ToString() + " ");
        }

        public static void Print(IEnumerable<IEnumerable<object>> coll)
        {
            int group = 0;
            foreach (var o in coll)
            {
                Console.WriteLine("Группа #" + group++);
                Print(o);
            }
        }

        static void Main(string[] args)
        {
            List<Person> persons = Person.ReadFrom("../../names.txt");

            Console.WriteLine("Фильтрация, Совершеннолетние, фамилия с гласной буквы\n");
            char[] vowels = new char[] { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };
            Print(
                from person in persons
                where person.Age >= 18 && vowels.Contains(char.ToLower(person.Name[0]))
                select person
            );

            Console.WriteLine("\n\nПроекция\n");
            Print(
                from person in persons
                select new
                {
                    SecondName = person.SecondName,
                    Name = person.Name,
                    Adult = person.Age >= 18
                }
            );

            Console.WriteLine("\n\nСортировка, по имени и возрасту\n");
            Print(
                from person in persons
                orderby person.Name, person.Age
                select person
            );

            Console.WriteLine("\n\nГруппировка, по фамилии\n");
            Print(
                from person in persons
                group person by person.SecondName
            );

            Console.WriteLine("\n\nГруппировку с подсчетом количества элементов в каждой группе\n");
            Print(
                from g in (
                    from person in persons
                    group person by person.SecondName
                )
                select new
                {
                    Количество = g.Count(), Фамилия = g.First().SecondName
                }
            );

            Console.WriteLine("\n\nАгрегатные функции, число совершеннолетних\n");
            Console.WriteLine(
                (from person in persons
                where person.Age >= 18
                select person).Count()
            );

            Console.WriteLine("\n\nИзвлечение половины элементов\n");
            Print(
                persons.Skip(persons.Count / 2)
            );

            Console.WriteLine("\n\nЕсть ли несовершеннолетние?\n");
            Console.WriteLine(
                persons.Any(p => p.Age < 18) ? "Есть, " + persons.Count(p => p.Age < 18) : "Нет"
            );

            Console.ReadKey();
        }
    }
}
