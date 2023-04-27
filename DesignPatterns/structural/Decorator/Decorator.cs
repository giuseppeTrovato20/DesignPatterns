using System;
namespace DesignPatterns.structural.Decorator
{

    //ci permette di aggiungere funzionalità ad un oggetto già istanziato

    public interface ICar
    {
        string GetDescription();

        // numero double 
        double GetCost();
    }

    public class BaseCar : ICar
    {
        public string GetDescription()
        {
            return "Base model";
        }

        public double GetCost()
        {
            return 20000;
        }
    }

    public abstract class CarDecorator : ICar
    {
        protected ICar _car;

        public CarDecorator(ICar car)
        {
            _car = car;
        }

        public virtual string GetDescription()
        {
            return _car.GetDescription();
        }

        public virtual double GetCost()
        {
            return _car.GetCost();
        }
    }

    public class SportPackage : CarDecorator
    {
        public SportPackage(ICar car) : base(car)
        {
        }

        //funzionalità del metodo non cambia + aggiunge qualcosa
        public override string GetDescription()
        {
            return _car.GetDescription() + ", Sport package";
        }

        // get 
        public override double GetCost()
        {
            return _car.GetCost() + 5000;
        }
    }

    public class LuxuryPackage : CarDecorator
    {
        public LuxuryPackage(ICar car) : base(car)
        {
        }

        public override string GetDescription()
        {
            return _car.GetDescription() + ", Luxury package";
        }

        public override double GetCost()
        {
            return _car.GetCost() + 7000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICar baseCar = new BaseCar();


            ICar sportsCar = new SportPackage(baseCar);



            ICar luxuryCar = new LuxuryPackage(baseCar);


            ICar sportsLuxuryCar = new LuxuryPackage(sportsCar);

            Console.WriteLine("Base Car: ");
            Console.WriteLine(baseCar.GetDescription());
            Console.WriteLine("Cost: $" + baseCar.GetCost());

            Console.WriteLine("\nSports Car: ");
            Console.WriteLine(sportsCar.GetDescription());
            Console.WriteLine("Cost: $" + sportsCar.GetCost());

            Console.WriteLine("\nLuxury Car: ");
            Console.WriteLine(luxuryCar.GetDescription());
            Console.WriteLine("Cost: $" + luxuryCar.GetCost());

            Console.WriteLine("\nSports & Luxury Car: ");
            Console.WriteLine(sportsLuxuryCar.GetDescription());
            Console.WriteLine("Cost: $" + sportsLuxuryCar.GetCost());

            Console.ReadKey();
        }
    }

}

