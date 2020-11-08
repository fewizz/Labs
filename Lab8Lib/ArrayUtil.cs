using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8Lib
{
    public static class ArrayUtil
    {
        public static void FillRandom(int[] arr, int from, int to)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++) arr[i] = rnd.Next(from, to + 1);
        }

        public static void FillRandom(char[] arr, char from, char to, Random r = null)
        {
            Random rnd = r;
            if(rnd == null) r = new Random();
            for (int i = 0; i < arr.Length; i++) arr[i] = (char) rnd.Next(from, to + 1);
        }

        public static void FillRandom(double[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++) arr[i] = rnd.NextDouble();
        }

        public static void FillRandom(string[] arr, int maxLen)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                char[] a = new char[rnd.Next(0, maxLen)];
                FillRandom(a, 'a', 'z', rnd);
                arr[i] = new string(a);
            }
        }

        public static void FillRandom(int[][] arr, int from, int to) { foreach (var v in arr) FillRandom(v, from, to); }
        public static void FillRandom(double[][] arr) { foreach (var v in arr) FillRandom(v); }

        public static int Sum(int[] arr) { int r = 0; foreach (var v in arr) r+=v; return r; }
        public static double Sum(double[] arr) { var r = 0.0; foreach (var v in arr) r += v; return r; }

        public static int Sum(int[][] arr) { int r = 0; foreach (var v in arr) r += Sum(v); return r; }
        public static double Sum(double[][] arr) { var r = 0.0; foreach (var v in arr) r += Sum(v); return r; }

        public static int Mul(int[] arr) { var res = 1; foreach (var v in arr) res *= v; return res; }
        public static double Mul(double[] arr) { var res = 1.0; foreach (var v in arr) res *= v; return res; }

        public static int Mul(int[][] arr) { var res = 1; foreach (var v in arr) res *= Mul(v); return res; }
        public static double Mul(double[][] arr) { var res = 1.0; foreach (var v in arr) res *= Mul(v); return res; }

        public static T Max<T>(T[] a, out int index) where T:IComparable
        {
            index = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i].CompareTo(a[index]) > 0)
                    index = i;
            return a[index];
        }

        public static string MaxBySize(string[] a, out int index)
        {
            index = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i].Length > a[index].Length)
                    index = i;
            return a[index];
        }

        public static T Max<T>(T[][] a, out int index0, out int index1) where T : IComparable
        {
            index0 = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                if (Max(a[i], out index1).CompareTo(Max(a[index0], out index1)) > 0)
                    index0 = i;
            return Max(a[index0], out index1);
        }

        public static string ToString<T>(T[] a) where T : IFormattable
        {
            StringBuilder sb = new StringBuilder();
            foreach (T t in a) sb.Append(t.ToString()).Append(" ");
            return sb.ToString();
        }

        public static string ToString<T>(T[][] a) where T : IFormattable
        {
            StringBuilder sb = new StringBuilder();
            foreach (T[] t in a) sb.Append(ToString(t)).Append("\n");
            return sb.ToString();
        }

        public static string ToString(string[] a)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in a) sb.Append(s).Append(" ");
            return sb.ToString();
        }
    }
}
