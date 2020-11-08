using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Car
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public string FIO { get; set; }

        public Car(string b, string n, string fio)
        {
            Brand = b;
            Number = n;
            FIO = fio;
        }
    }

    public class Camera
    {
        public delegate void SpeedFineHandler(Car car, int speed, int max);
        public event SpeedFineHandler SpeedFine;

        int maxSpeed;

        public Camera(int speed)
        {
            maxSpeed = speed;
        }

        public void OnCar(Car c, int speed)
        {

            if (speed > maxSpeed)
            {
                Console.WriteLine("Камера: Превышение скорости " + speed + "/" + maxSpeed+ " км/ч");
                SpeedFine.Invoke(c, speed, maxSpeed);
            }
        }
    }

    public class GIBDD
    {
        public void ListenCamera(Camera c) {
            c.SpeedFine += (Car car, int speed, int max) => {
                string str = "ГИБДД: "+car.FIO+", вам штраф за превышение скорости ("+speed+"км/ч) на "+car.Brand +", знак: "+ car.Number;

                Console.WriteLine(str);

                using (StreamWriter ma = new StreamWriter(car.FIO+".txt"))
                {
                    ma.WriteLine(str);
                }
            };
        }
    }

    public class E2
    {

        public static void Main() {
            GIBDD gibdd = new GIBDD();

            Camera cam60 = new Camera(60);
            Camera cam80 = new Camera(80);

            gibdd.ListenCamera(cam60);
            gibdd.ListenCamera(cam80);

            Car uaz = new Car("UAZ", "К010МА", "Алексей Иванов Иванович");
            Car bmw = new Car("BMW", "А666АА", "Ребятин Алексей Викторович");
            Car merc = new Car("Mercedes", "Б122СС", "Толоченков Алексей Андреевич");
            Car lada = new Car("Lada", "А843БВ", "Тухватов Азат Илалович");
            Car kamaz = new Car("Kamaz", "У095КА", "Габидуллин Камиль Рашидович");

            cam60.OnCar(uaz, 40);
            cam60.OnCar(bmw, 100);
            cam60.OnCar(merc, 125);
            cam80.OnCar(lada, 80);
            cam80.OnCar(kamaz, 85);

            Console.ReadKey();
        }
    }
}
