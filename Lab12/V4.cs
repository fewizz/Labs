using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public abstract class Vechicle : ICloneable, IComparable
    {
        int speed = 0;

        public int Speed { get { return speed; } set { speed = value; } }
        public bool Moving { get { return speed != 0; } }

        public Vechicle() { }
        public Vechicle(int speed) { this.speed = speed; }

        public abstract string GetInfo();
        public abstract void SetSpeedFactor(int factor);

        public override string ToString()
        {
            return "Type: " + this.GetType().Name + ", SPEED: " + speed + ", " + GetInfo();
        }

        public abstract object Clone();

        public int CompareTo(object obj)
        {
            return (obj as Vechicle).speed - speed;
        }
    }

    class Car : Vechicle
    {
        int oilQuality = 95;

        public int OilQuality { get { return oilQuality; } }

        public Car() { }
        public Car(int oq) { SetSpeedFactor(oq); oilQuality = oq; }

        public override void SetSpeedFactor(int factor)
        {
            this.oilQuality = factor;
            Speed = oilQuality / 2;
        }

        public override string GetInfo()
        {
            return "Path Type: Road, Oil quality: " + oilQuality;
        }

        public override object Clone()
        {
            return new Car(oilQuality);
        }
    }

    class Train : Vechicle
    {
        int wagons = 0;

        public int Wagons { get { return wagons; } }

        public Train() { }
        public Train(int wagons) { SetSpeedFactor(wagons); this.wagons = wagons; }

        public override void SetSpeedFactor(int factor)
        {
            this.wagons = factor;
            Speed = Math.Max(0, 8000 - wagons*10);
        }

        public override string GetInfo()
        {
            return "Path: Rails, Wagons: " + wagons;
        }

        public override object Clone()
        {
            return new Train(wagons);
        }
    }

    class Steamship : Vechicle
    {
        int engines = 0;

        public int Engined { get { return engines; } }

        public Steamship() { }
        public Steamship(int engines)
        {
            SetSpeedFactor(engines);
            this.engines = engines;
        }

        public override void SetSpeedFactor(int factor)
        {
            this.engines = factor;
            Speed = engines * 40;
        }

        public override string GetInfo()
        {
            return "Path: Water, Engines: " + engines;
        }

        public override object Clone()
        {
            return new Steamship(engines);
        }
    }

    public class TransportComp : ICloneable, IComparer<Vechicle>, IEnumerable
    {
        Random r = new Random();
        List<Vechicle> Items = new List<Vechicle>();

        public void AddRandom()
        {
            Vechicle v = null;
            switch (r.Next(0, 3))
            {
                case 0: v = new Car(); break;
                case 1: v = new Train(); break;
                case 2: v = new Steamship(); break;
            }
            v.SetSpeedFactor(r.Next(100));
            Add(v);
        }

        public void Add(Vechicle v)
        {
            Items.Add(v);
        }

        public void SetSpeedFactor(int val, int index)
        {
            Items[index].SetSpeedFactor(val);
        }

        public void SetRandomSpeedFactor(int index)
        {
            SetSpeedFactor(r.Next(1000), index);
        }

        public void RemoveAt(int index)
        {
            Items.RemoveAt(index);
        }

        public void Show()
        {
            int index = 0;
            foreach (Vechicle v in this) Console.WriteLine(index++ + ") " + v.ToString());
        }

        public void Sort()
        {
            Items.Sort(this as IComparer<Vechicle>);
        }

        public object Clone()
        {
            TransportComp tc = new TransportComp();
            foreach (Vechicle v in Items) tc.Add(v.Clone() as Vechicle);
            return tc;
        }

        public int Compare(Vechicle x, Vechicle y)
        {
            return x.CompareTo(y);
        }

        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }

    class V4
    {
        static void Print(TransportComp tc0, TransportComp tc1)
        {
            Console.WriteLine("tc0: ");
            tc0.Show();

            Console.WriteLine("tc1: ");
            tc1.Show();

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            TransportComp tc0 = new TransportComp();
            for (int i = 0; i < 4; i++) tc0.AddRandom();

            TransportComp tc1 = (TransportComp)tc0.Clone();

            Print(tc0, tc1);

            tc1.SetSpeedFactor(0, 0);

            Console.WriteLine("After tc1's first item change");
            Print(tc0, tc1);

            tc1.Sort();
            Console.WriteLine("tc1 after sorting: ");
            tc1.Show();

            Console.ReadKey();

        }
    }
}
