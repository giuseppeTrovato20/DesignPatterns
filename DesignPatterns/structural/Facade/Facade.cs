using System;
using DesignPatterns.structural.Bridge;

namespace DesignPatterns.structural.Facade
{
    // Componenti del sottosistema
    public class Motore
    {
        public void Avvia()
        {
            Console.WriteLine("Motore avviato.");
        }

        public void Spegni()
        {
            Console.WriteLine("Motore spento.");
        }
    }

    public class Luci
    {
        public void Accendi()
        {
            Console.WriteLine("Luci accese.");
        }

        public void Spegni()
        {
            Console.WriteLine("Luci spente.");
        }
    }

    public class SistemaAntifurto
    {
        public void Attiva()
        {
            Console.WriteLine("Sistema antifurto attivato.");
        }

        public void Disattiva()
        {
            Console.WriteLine("Sistema antifurto disattivato.");
        }
    }

    // Facade - Facciata
    public class AutoFacade
    {
        private readonly Motore _motore;
        private readonly Luci _luci;
        private readonly SistemaAntifurto _antifurto;

        public AutoFacade()
        {
            _motore = new Motore();
            _luci = new Luci();
            _antifurto = new SistemaAntifurto();
        }

        public void AccendiAuto()
        {
            _antifurto.Disattiva();
            _luci.Accendi();
            _motore.Avvia();
        }

        public void SpegniAuto()
        {
            _motore.Spegni();
            _luci.Spegni();
            _antifurto.Attiva();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            AutoFacade autoFacade = new AutoFacade();

            Console.WriteLine("=== Accendere l'auto ===");

            autoFacade.AccendiAuto();


            Console.WriteLine("\n=== Spegnere l'auto ===");

            autoFacade.SpegniAuto();

            Console.ReadLine();
        }
    }
}

