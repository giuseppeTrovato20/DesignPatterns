using System;
namespace DesignPatterns.structural.Proxy
{
    public interface IFileAccess
    {
        void ApriFile(string fileName);
    }

    public class FileAccess : IFileAccess
    {
        public void ApriFile(string fileName)
        {
            Console.WriteLine($"File {fileName} aperto.");
        }
    }

    public class FileAccessProxy : IFileAccess
    {
        private FileAccess _fileAccess;
        private string _ruoloUtente;

        public FileAccessProxy(string ruoloUtente)
        {
            _ruoloUtente = ruoloUtente;
            _fileAccess = new FileAccess();
        }

        public void ApriFile(string fileName)
        {
            if (_ruoloUtente == "Amministratore" || _ruoloUtente == "UtenteAutorizzato")
            {
                _fileAccess.ApriFile(fileName);
            }
            else
            {
                Console.WriteLine($"Accesso negato per l'utente con il ruolo '{_ruoloUtente}'.");
            }
        }
    }

    public class Client
    {
        static void Main(string[] args)
        {
            IFileAccess utenteNonAutorizzato = new FileAccessProxy("UtenteNonAutorizzato");
            utenteNonAutorizzato.ApriFile("documento.txt");

            IFileAccess utenteAutorizzato = new FileAccessProxy("UtenteAutorizzato");
            utenteAutorizzato.ApriFile("documento.txt");
        }
    }
}

