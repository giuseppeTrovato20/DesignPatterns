using System;
namespace DesignPatterns.structural.ProxyProtettivo2Solved
{
    public interface ISicurezza
    {
        bool ControllaAccesso(string codice);
    }

    public class ControlloAccessi : ISicurezza
    {
        public bool ControllaAccesso(string codice)
        {
            if (codice == "1234")
            {
                Console.WriteLine("Accesso consentito.");
                return true;
            }
            else
            {
                Console.WriteLine("Accesso negato.");
                return false;
            }
        }
    }

    public class ControlloAccessiProxy : ISicurezza
    {
        private ControlloAccessi _controlloAccessi;

        public ControlloAccessiProxy()
        {
            _controlloAccessi = new ControlloAccessi();
        }

        public bool ControllaAccesso(string codice)
        {
            // Implementazione del controllo dell'accesso protetto
            if (codice == "9999") // Codice di amministratore
            {
                return _controlloAccessi.ControllaAccesso(codice);
            }
            else
            {
                Console.WriteLine("Accesso negato: solo gli amministratori hanno accesso.");
                return false;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ISicurezza controlloAccessi = new ControlloAccessiProxy();
            controlloAccessi.ControllaAccesso("1234");
            controlloAccessi.ControllaAccesso("4321");
            controlloAccessi.ControllaAccesso("9999");
        }
    }
}

