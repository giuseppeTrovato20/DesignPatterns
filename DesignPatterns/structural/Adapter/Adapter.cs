using System;
namespace DesignPatterns.structural.Adapter
{
    // Interfaccia IBird
    public interface IBird
    {
        void Fly();

        //cinguettio
        void Chirp();
    }

    // Classe concreta di uccello, un passerotto
    public class Sparrow : IBird
    {
        public void Fly()
        {
            Console.WriteLine("Sparrow vola");
        }

        //cinguettio
        public void Chirp()
        {
            Console.WriteLine("Sparrow fa cip cip...");
        }
    }

    // Interfaccia IToyDuck
    public interface IToyDuck
    {
        void Squeak();
    }

    // Classe concreta di papera giocattolo
    public class ToyDuck : IToyDuck
    {
        public void Squeak()
        {
            Console.WriteLine("IToyDuck fa squeak");
        }
    }

    // Adapter class
    public class BirdToToyDuckAdapter : IToyDuck
    {
        private readonly IBird _bird;

        public BirdToToyDuckAdapter(IBird bird)
        {
            _bird = bird;
        }

        public void Squeak()
        {
            //cinguetta al posto di squeak
            _bird.Chirp();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IBird sparrow = new Sparrow();
            IToyDuck toyDuck = new ToyDuck();
            IToyDuck birdAdapter = new BirdToToyDuckAdapter(sparrow);

            Console.WriteLine("Uccello:");
            sparrow.Fly();
            sparrow.Chirp();

            Console.WriteLine("\nGiocattolo per Anatra:");
            toyDuck.Squeak();

            Console.WriteLine("\nAdapter in azione:");
            birdAdapter.Squeak();

            Console.ReadLine();
        }
    }
}

