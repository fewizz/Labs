using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Set
    {
        private int[] Elements;
        public int Count { get{ return Elements.Length; }}

        public Set()
        {
            Console.Write("Введите размер множества: ");
            Elements = new int[int.Parse(Console.ReadLine())];
            Fill();
        }

        public Set(int[] array)
        {
            Elements = array;
        }

        public void Fill()
        {
            int count = Count;
            for(int i = 0; i < count; i++) {
                Console.Write("{0}/{1}: ", i + 1, count);
                Add(int.Parse(Console.ReadLine()));
            }
        }

        public int IndexOf(int val)
        {
            for (int i = 0; i < Count; i++) if (Elements[i] == val) return i;
            return -1;
        }

        public bool Contains(int val) { return IndexOf(val) != -1; }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Count; i++)
                res+=i+" => "+this[i] + "\n";
            return res;
        }

        public void Show()
        {
            Console.WriteLine(this.ToString());
        }

        public void Add(int val)
        {
            if (Contains(val)) return;
            Array.Resize(ref Elements, Count + 1);
            Elements[Count - 1] = val;
        }

        public void Add(Set s)
        {
            for (int i = 0; i < s.Count; i++) Add(s[i]);
        }

        public static Set operator ++ (Set s)
        {
            for (int i = 0; i < s.Count; i++) s.Elements[i]++;
            return s;
        }

        public static Set operator + (Set s0, Set s1)
        {
            Set s = new Set(new int[0]);
            s.Add(s0);
            s.Add(s1);
            return s;
        }

        public static Set operator * (Set s0, Set s1)
        {
            Set result = new Set(new int[0]);
            Set combined = s0 + s1;
            for (int i = 0; i < combined.Count; i++)
            {
                int elem = combined[i];
                if (s0.Contains(elem) && s1.Contains(elem) && !result.Contains(elem)) result.Add(elem);
            }
            return result;
        }

        public static Set operator / (Set s0, Set s1)
        {
            Set result = new Set(new int[0]);
            for (int i = 0; i < s0.Count; i++)
            {
                int elem = s0[i];
                if (s0.Contains(elem) && !s1.Contains(elem) && !result.Contains(elem)) result.Add(elem);
            }
            return result;
        }

        public static bool operator < (Set s0, Set s1) { return s0.Count < s1.Count; }
        public static bool operator > (Set s0, Set s1) { return s0.Count > s1.Count; }

        int this[int index] {
            get {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                return Elements[index];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Set s0 = new Set();
            s0.Add(1);
            s0.Add(1);
            s0.Add(2);
            s0.Add(3);
            s0.Add(4);
            Console.WriteLine("s0: \n" + s0);

            Set s1 = new Set();
            s1.Add(3);
            s1.Add(4);
            s1.Add(5);
            s1.Add(6);
            s1.Add(7);
            Console.WriteLine("s1: \n" + s1);

            Console.WriteLine("+: \n" + (s0 + s1));
            Console.WriteLine("*: \n" + (s0 * s1));
            Console.WriteLine("/: \n" + (s0 / s1));
            Console.WriteLine(">: \n" + (s0 > s1));

            Console.ReadKey();
        }
    }
}
