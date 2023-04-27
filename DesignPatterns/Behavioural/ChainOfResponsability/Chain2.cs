using System;
namespace DesignPatterns.Behavioural.ChainOfResponsability
{
    public abstract class Macchina
    {
        protected Macchina _successore;

        public void ImpostaSuccessore(Macchina successore)
        {
            _successore = successore;
        }

        public abstract void Lavora(Prodotto prodotto);
    }

    public class Taglio : Macchina
    {
        public override void Lavora(Prodotto prodotto)
        {
            if (prodotto.Fase == FaseProdotto.NonIniziato)
            {
                Console.WriteLine("Taglio del prodotto in corso...");
                prodotto.Fase = FaseProdotto.Tagliato;
            }
            _successore?.Lavora(prodotto);
        }
    }

    public class Assemblaggio : Macchina
    {
        public override void Lavora(Prodotto prodotto)
        {
            if (prodotto.Fase == FaseProdotto.Tagliato)
            {
                Console.WriteLine("Assemblaggio del prodotto in corso...");
                prodotto.Fase = FaseProdotto.Assemblato;
            }
            _successore?.Lavora(prodotto);
        }
    }

    public class Verniciatura : Macchina
    {
        public override void Lavora(Prodotto prodotto)
        {
            if (prodotto.Fase == FaseProdotto.Assemblato)
            {
                Console.WriteLine("Verniciatura del prodotto in corso...");
                prodotto.Fase = FaseProdotto.Verniciato;
            }
            _successore?.Lavora(prodotto);
        }
    }

    public enum FaseProdotto
    {
        NonIniziato,
        Tagliato,
        Assemblato,
        Verniciato
    }

    public class Prodotto
    {
        public FaseProdotto Fase { get; set; } = FaseProdotto.NonIniziato;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Macchina taglio = new Taglio();
            Macchina assemblaggio = new Assemblaggio();
            Macchina verniciatura = new Verniciatura();

            taglio.ImpostaSuccessore(assemblaggio);
            assemblaggio.ImpostaSuccessore(verniciatura);

            Prodotto prodotto = new Prodotto();
            taglio.Lavora(prodotto);

            Console.WriteLine($"Prodotto completato: {prodotto.Fase}");
        }
    }
}

