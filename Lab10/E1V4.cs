using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Vechicle
    {
        int speed = 0;

        public int Speed { get { return speed; } set { speed = value; } }
        public bool Moving { get { return speed != 0; } }

        public Vechicle() { }
        public Vechicle(int speed) { this.speed = speed; }

        public virtual string GetInfo() { return ""; }
        public override string ToString()
        {
            return "Type: "+this.GetType().Name + ", Speed: " + speed + ", "+GetInfo();
        }
    }

    class Car : Vechicle
    {
        int oilQuality = 95;

        public int OilQuality { get { return oilQuality; } }

        public Car() { }
        public Car(int oq) : base(oq / 2) { oilQuality = oq; }

        public override string GetInfo()
        {
            return "Path Type: Road, Oil Quality: "+oilQuality;
        }
    }

    class Train : Vechicle
    {
        int wagons = 0;

        public int Wagons { get { return wagons; } }

        public Train() { }
        public Train(int wagons) : base(50 + 100 / wagons) { this.wagons = wagons; }

        public override string GetInfo()
        {
            return "Path: Rails, Wagons: "+wagons;
        }
    }

    class Steamship : Vechicle
    {
        int engines = -1;

        public int Engined { get { return engines; } }

        public Steamship() {}
        public Steamship(int engines) : base(engines*40)
        {
            this.engines = engines;
        }

        public override string GetInfo()
        {
            return "Path: Water, Engines: " + engines;
        }
    }

    class E1V4
    {
        static void Main(string[] args)
        {
            Vechicle[] vechicles = new Vechicle[] { new Vechicle(30), new Car(95), new Train(5), new Steamship(2) };
            foreach (Vechicle v in vechicles) Console.WriteLine(v);
            Console.ReadKey();
        }
    }
}
