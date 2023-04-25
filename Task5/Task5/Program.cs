using System;
using System.Collections.Generic;

namespace ShipProgram
{
    // "Корабль"
    interface IShip
    {
        int CargoCapacity { get; set; }
        void LoadCargo();
        void Move();
    }

    // "Грузовой Корабль"
    abstract class CargoShip : IShip
    {
        public int CargoCapacity { get; set; } // Грузоподъемность
        public bool IsMoving { get; private set; }

        public virtual void LoadCargo()
        {
            Console.WriteLine("Груз загружен на корабль");
        }

        public void Move()
        {
            IsMoving = true;
            Console.WriteLine("Корабль начал движение");
        }

        public void Stop()
        {
            IsMoving = false;
            Console.WriteLine("Корабль остановился");
        }


        public virtual void UnloadCargo()
        {
            Console.WriteLine("Груз выгружен с корабля");
        }
    }

    
    class Tanker : CargoShip
    {
        public int OilCapacity { get; set; }
        public bool IsPumping { get; private set; }

        public override void LoadCargo()
        {
            base.LoadCargo();
            OilCapacity = CargoCapacity;
            Console.WriteLine("Нефть загружена на танкер");
        }

        public void PumpOil()
        {
            IsPumping = true;
            Console.WriteLine("Началась откачка нефти");
        }

        public void StopPump()
        {
            IsPumping = false;
            Console.WriteLine("Откачка нефти остановлена");
        }

        public override void UnloadCargo()
        {
            base.UnloadCargo();
            OilCapacity = 0;
            Console.WriteLine("Нефть выгружена с танкера");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание списка объектов типа IShip
            List<IShip> ships = new List<IShip>();

            
            ships.Add(new Tanker() { CargoCapacity = 10000 });
            ships.Add(new Tanker() { CargoCapacity = 20000 });
            ships.Add(new Tanker() { CargoCapacity = 30000 });

            // Вызов методов объектов в списке
            foreach (IShip ship in ships)
            {
                ship.LoadCargo();
                ship.Move();
                
                Tanker tanker = ship as Tanker; // 
                tanker.Stop();

                if (tanker != null)
                {
                    tanker.PumpOil();
                    tanker.StopPump();
                    tanker.PumpOil();
                    tanker.UnloadCargo();
                }
                Console.WriteLine("Вместимость груза на корабле: " + ship.CargoCapacity);
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }
}