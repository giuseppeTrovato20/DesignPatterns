using System;
namespace DesignPatterns.structural.Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class RealCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("La macchina sta guidando.");
        }
    }

    public class CarProxy : ICar
    {
        private RealCar realCar;
        private bool isDriverValid;

        public CarProxy(bool isDriverValid)
        {
            this.isDriverValid = isDriverValid;
        }

        public void Drive()
        {
            if (isDriverValid)
            {
                if (realCar == null)
                {
                    realCar = new RealCar();
                }

                realCar.Drive();
            }
            else
            {
                Console.WriteLine("Il conducente non è abilitato a guidare. Impossibile guidare la macchina.");
            }
        }
    }


    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ICar carWithValidDriver = new CarProxy(true);
    //        carWithValidDriver.Drive(); // La macchina sta guidando.

    //        ICar carWithInvalidDriver = new CarProxy(false);
    //        carWithInvalidDriver.Drive(); // Il conducente non è abilitato a guidare. Impossibile guidare la macchina.
    //    }
    //}
}

