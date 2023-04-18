using System;
namespace DesignPatterns.structural.Bridge
{
    // Astrazione - interfaccia per i motori
    public interface IMotore
    {
        string Accelera();
    }

    // Motore concreto 1: Motore a benzina
    public class MotoreBenzina : IMotore
    {
        public string Accelera()
        {
            return "Accelera con motore a benzina";
        }
    }

    // Motore concreto 2: Motore elettrico
    public class MotoreElettrico : IMotore
    {
        public string Accelera()
        {
            return "Accelera con motore elettrico";
        }
    }

    // Motore concreto 3: Motore Elettrico
    public class MotoreIdrogeno : IMotore
    {
        public string Accelera()
        {
            return "Accelera con motore ad idrogeno";
        }
    }


    // Astrazione - interfaccia per le automobili
    public interface IAutomobile
    {
        void Avvia();
    }

    // Automobile concreta 1: berlina
    public class Berlina : IAutomobile
    {
        private IMotore _motore;

        public Berlina(IMotore motore)
        {
            _motore = motore;
        }

        public void Avvia()
        {
            Console.WriteLine($"Berlina: {_motore.Accelera()}");
        }
    }

    // Automobile concreta 2: SUV
    public class SUV : IAutomobile
    {
        private IMotore _motore;

        public SUV(IMotore motore)
        {
            _motore = motore;
        }

        public void Avvia()
        {
            Console.WriteLine($"SUV: {_motore.Accelera()}");
        }
    }

    // Automobile concreta 3: Crossover
    public class Crossover : IAutomobile
    {
        private IMotore _motore;

        public Crossover(IMotore motore)
        {
            _motore = motore;
        }

        public void Avvia()
        {
            Console.WriteLine($"Crossover: {_motore.Accelera()}");
        }
    }

    public class Client
    {
        public static void Main()
        {
            EsempioBridge();
        }

        public static void EsempioBridge()
        {
            IMotore motoreBenzina = new MotoreBenzina();
            IMotore motoreElettrico = new MotoreElettrico();
            IMotore motoreIdrogeno = new MotoreIdrogeno();

            IAutomobile berlinaBenzina = new Berlina(motoreBenzina);
            IAutomobile berlinaElettrica = new Berlina(motoreElettrico);

            IAutomobile suvBenzina = new SUV(motoreBenzina);
            IAutomobile suvElettrico = new SUV(motoreElettrico);

            IAutomobile CrossoverIdrogeno = new Crossover(motoreIdrogeno);

            berlinaBenzina.Avvia(); // Berlina: Accelera con motore a benzina
            berlinaElettrica.Avvia(); // Berlina: Accelera con motore elettrico

            suvBenzina.Avvia(); // SUV: Accelera con motore a benzina
            suvElettrico.Avvia(); // SUV: Accelera con motore elettrico

            CrossoverIdrogeno.Avvia();
        }
    }
}

