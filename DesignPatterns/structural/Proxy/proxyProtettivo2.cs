using System;
namespace DesignPatterns.structural.Proxy
{
    public interface ISicurezza
    {
        bool ControllaAccesso(string codice);
    }

    public class ControlloAccessi : ISicurezza
    {
        public bool ControllaAccesso(string codice)
        {
            // Implementazione del controllo degli accessi
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
            // TODO: Implementa il controllo dell'accesso protetto
            throw new NotImplementedException();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ISicurezza controlloAccessi = new ControlloAccessiProxy();
            controlloAccessi.ControllaAccesso("1234");
            controlloAccessi.ControllaAccesso("4321");
        }
    }
}

