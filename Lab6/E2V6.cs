using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab6
{
    class E2V6
    {
        public static void Main()
        {
            // Считываем все строки из файла
            string[] lines = File.ReadLines("../../E2V6/books.txt").ToArray();

            // Словарь. Ключ есть Жанр, значение - количество
            // книг с таким жанром.
            Dictionary<string, uint> genres = new Dictionary<string, uint>();

            foreach (string line in lines)
            {
                string[] splitted = line.Split();
                //string author = splitted[0]; // Не используется
                //string title = splitted[1]; // Не используется
                string genre = splitted[2];

                // Если такого жанра еще не встречалось (не содержится в словаре), добавляем его в словарь
                if (!genres.ContainsKey(genre))
                    // Пока что инициализируем нулем, будет увеличено в след. шаге
                    genres.Add(genre, 0);

                // Увеличиваем количество.
                // Получаем количество (обращением к словарю) и увеличиваем его на 1
                genres[genre]++;
            }

            // Записываем
            using(StreamWriter writer = new StreamWriter("../../E2V6/result/by_genres.txt"))
            {
                // Проходимся по всем жанрам (ключам словаря) что есть в словаре
                foreach (string genre in genres.Keys)
                    // Записываем "жанр: кол-во"
                    writer.WriteLine(genre + ": " + genres[genre]);
            }
        }
    }
}
