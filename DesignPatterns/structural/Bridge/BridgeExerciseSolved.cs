using System;
namespace DesignPatterns.structural.Bridge
{
    public abstract class PiattaformaScommesse
    {
        protected OperazioneScommesse _operazioneScommesse;

        public PiattaformaScommesse(OperazioneScommesse operazioneScommesse)
        {
            _operazioneScommesse = operazioneScommesse;
        }

        public abstract void EseguiScommessa();
    }

    public abstract class OperazioneScommesse
    {
        public abstract void PiazzaScommessa();
    }

    public class PiattaformaA : PiattaformaScommesse
    {
        public PiattaformaA(OperazioneScommesse operazioneScommesse) : base(operazioneScommesse)
        {
        }

        public override void EseguiScommessa()
        {
            Console.WriteLine("Scommessa eseguita sulla Piattaforma A:");
            _operazioneScommesse.PiazzaScommessa();
        }
    }

    public class PiattaformaB : PiattaformaScommesse
    {
        public PiattaformaB(OperazioneScommesse operazioneScommesse) : base(operazioneScommesse)
        {
        }

        public override void EseguiScommessa()
        {
            Console.WriteLine("Scommessa eseguita sulla Piattaforma B:");
            _operazioneScommesse.PiazzaScommessa();
        }
    }

    public class ScommessaSingola : OperazioneScommesse
    {
        public override void PiazzaScommessa()
        {
            Console.WriteLine("Scommessa singola piazzata.");
        }
    }

    public class ScommessaMultipla : OperazioneScommesse
    {
        public override void PiazzaScommessa()
        {
            Console.WriteLine("Scommessa multipla piazzata.");
        }
    }

    public class ScommessaLive : OperazioneScommesse
    {
        public override void PiazzaScommessa()
        {
            Console.WriteLine("Scommessa live piazzata.");
        }
    }

    //class ClientEx
    //{
    //    static void Main(string[] args)
    //    {
    //        OperazioneScommesse scommessaSingola = new ScommessaSingola();
    //        OperazioneScommesse scommessaMultipla = new ScommessaMultipla();
    //        OperazioneScommesse scommessaLive = new ScommessaLive();

    //        PiattaformaScommesse piattaformaA = new PiattaformaA(scommessaSingola);
    //        PiattaformaScommesse piattaformaB = new PiattaformaB(scommessaMultipla);

    //        piattaformaA.EseguiScommessa(); // Output: Scommessa eseguita sulla Piattaforma A: Scommessa singola piazzata.
    //        piattaformaB.EseguiScommessa(); // Output: Scommessa eseguita sulla Piattaforma B: Scommessa multipla piazzata.

    //        piattaformaA = new PiattaformaA(scommessaLive);
    //        piattaformaA.EseguiScommessa(); // Output: Scommessa eseguita sulla Piattaforma A: Scommessa live piazzata.
    //    }
    //}
}

