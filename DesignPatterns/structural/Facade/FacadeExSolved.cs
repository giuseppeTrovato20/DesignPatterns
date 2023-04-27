using System;
namespace DesignPatterns.structural.FacadeExSolved
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

    class FabbricaFacade
    {
        private Produzione _produzione;
        private Magazzino _magazzino;
        private Spedizione _spedizione;
        private ControlloQualità _controlloQualità;

        public FabbricaFacade()
        {
            _produzione = new Produzione();
            _magazzino = new Magazzino();
            _spedizione = new Spedizione();
            _controlloQualità = new ControlloQualità();
        }

        public void IniziaProcessoFabbricazione()
        {
            _produzione.AvviaProduzione();
            _magazzino.AggiungiProdotto();
            _controlloQualità.EseguiControllo();
        }

        public void CompletaProcessoFabbricazione()
        {
            _produzione.FermaProduzione();
            _controlloQualità.GeneraReport();
            _spedizione.PreparaSpedizione();
            _spedizione.InviaSpedizione();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FabbricaFacade fabbricaFacade = new FabbricaFacade();
            fabbricaFacade.IniziaProcessoFabbricazione();
            // Altri processi...
            fabbricaFacade.CompletaProcessoFabbricazione();
        }
    }
}

