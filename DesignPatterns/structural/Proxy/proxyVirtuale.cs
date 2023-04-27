using System;
namespace DesignPatterns.structural.Proxy
{
    // Interfaccia comune per LibroReale e LibroProxy
    public interface ILibro
    {
        string LeggiPagina(int numeroPagina);
    }

    // Classe LibroReale
    public class LibroReale : ILibro
    {
        private List<string> _pagine;

        public LibroReale(string contenuto)
        {
            _pagine = contenuto.Split('\n').ToList();
        }

        public string LeggiPagina(int numeroPagina)
        {
            return _pagine[numeroPagina];
        }
    }

    // Classe LibroProxy
    public class LibroProxy : ILibro
    {
        private string _contenuto;
        private LibroReale _libroReale;

        public LibroProxy(string contenuto)
        {
            _contenuto = contenuto;
        }

        public string LeggiPagina(int numeroPagina)
        {
            if (_libroReale == null)
            {
                _libroReale = new LibroReale(_contenuto);
            }
            return _libroReale.LeggiPagina(numeroPagina);
        }
    }

    // Classe Client
    public class AppEBookReader
    {
        static void Main(string[] args)
        {
            // Caricamento del contenuto del libro
            string contenutoLibro = "Lorem ipsum dolor sit amet...\n...Finis.";

            ILibro libro = new LibroProxy(contenutoLibro);

            // Leggi una pagina specifica del libro
            Console.WriteLine(libro.LeggiPagina(10));
        }
    }
}

