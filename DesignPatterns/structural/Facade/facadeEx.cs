using System;
namespace DesignPatterns.structural.FacadeFacadeEx
{
    class Produzione
    {
        public void AvviaProduzione() { /*...*/ }
        public void FermaProduzione() { /*...*/ }
    }

    class Magazzino
    {
        public void AggiungiProdotto() { /*...*/ }
        public void RimuoviProdotto() { /*...*/ }
    }

    class Spedizione
    {
        public void PreparaSpedizione() { /*...*/ }
        public void InviaSpedizione() { /*...*/ }
    }

    class ControlloQualità
    {
        public void EseguiControllo() { /*...*/ }
        public void GeneraReport() { /*...*/ }
    }

    // TODO: Implementare la classe FabbricaFacade qui
    // Implementa un metodo per far partire la fabbrica e uno per farla fermare

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Utilizzare la classe FabbricaFacade per interagire con il sistema della fabbrica
        }
    }
}

