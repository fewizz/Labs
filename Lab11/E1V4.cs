using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public abstract class Vechicle
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
            return "Type: " + this.GetType().Name + ", Speed: " + speed + ", " + GetInfo();
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
            Speed = 50 + 100 / wagons;
        }

        public override string GetInfo()
        {
            return "Path: Rails, Wagons: " + wagons;
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
    }

    class TransportComp
    {
        List<Vechicle> Items = new List<Vechicle>();

        public void Add()
        {
            Console.Write("Выберите (Машина - 0, Поезд - 1 Пароход - 2): ");
            int type = int.Parse(Console.ReadLine());
            Vechicle v = null;
            switch (type)
            {
                case 0:
                    v = new Car();
                    break;
                case 1:
                    v = new Train();
                    break;
                case 2:
                    v = new Steamship();
                    break;
            }

            Change(v);
            Items.Add(v);
        }

        private static void Change(Vechicle v)
        {
            int type = (v is Car ? 0 : (v is Train ? 1 : 2));

            if (v is Car)
                Console.Write("Kачество масла: ");
            else if (v is Train)
                Console.Write("Количество вагонов: ");
            else if (v is Steamship)
                Console.Write("Количество двигаетелей: ");
            v.SetSpeedFactor(int.Parse(Console.ReadLine()));
        }

        public void SetSpeedFactor(int val, int index)
        {
            Items[index].SetSpeedFactor(val);
        }

        public void ChangeSpeedFactor(int index)
        {
            Change(Items[index]);
        }

        public void RemoveAt(int index)
        {
            Items.RemoveAt(index);
        }

        public void Show()
        {
            int index = 0;
            foreach (Vechicle v in Items) Console.WriteLine(index++ + ") " + v.ToString());
        }
    }

    class E1V4
    {

        static void Main(string[] args)
        {
            TransportComp tc = new TransportComp();

            Console.WriteLine(
                    "1. Добавить объект в коллекцию\n" +
                    "2. Удалить объект из коллекции\n" +
                    "3. Вывести сведения об объектах\n" +
                    "4. Внести изменения\n" +
                    "5. Выход"
                );

            while (true)
            {
                int action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        tc.Add();
                        break;
                    case 2:
                        Console.Write("Индекс: ");
                        tc.RemoveAt(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        tc.Show();
                        break;
                    case 4:
                        Console.Write("Индекс: ");
                        tc.ChangeSpeedFactor(int.Parse(Console.ReadLine()));
                        break;
                    case 5:
                        return;
                }
            }
        }
    }
}
