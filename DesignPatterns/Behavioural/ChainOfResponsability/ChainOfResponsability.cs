using System;
namespace DesignPatterns.Comportamental.ChainOfResponsability
{
    using System;

    // Handler Interface
    public interface IManutentoreAuto
    {
        IManutentoreAuto ProssimoManutentore { get; set; }
        void Ripara(GuastoAuto guasto);
    }

    // Concrete Handlers
    public class Meccanico : IManutentoreAuto
    {
        public IManutentoreAuto ProssimoManutentore { get; set; }

        public void Ripara(GuastoAuto guasto)
        {
            if (guasto.Tipo == "Motore")
                Console.WriteLine("Meccanico ha riparato il guasto al motore.");
            else if (ProssimoManutentore != null)
                ProssimoManutentore.Ripara(guasto);
        }
    }

    public class Elettricista : IManutentoreAuto
    {
        public IManutentoreAuto ProssimoManutentore { get; set; }

        public void Ripara(GuastoAuto guasto)
        {
            if (guasto.Tipo == "Elettronica")
                Console.WriteLine("Elettricista ha riparato il guasto all'elettronica.");
            else if (ProssimoManutentore != null)
                ProssimoManutentore.Ripara(guasto);
        }
    }

    public class Carrozziere : IManutentoreAuto
    {
        public IManutentoreAuto ProssimoManutentore { get; set; }

        public void Ripara(GuastoAuto guasto)
        {
            if (guasto.Tipo == "Carrozzeria")
                Console.WriteLine("Carrozziere ha riparato il guasto alla carrozzeria.");
            else if (ProssimoManutentore != null)
                ProssimoManutentore.Ripara(guasto);
        }
    }

    // Helper Class
    public class GuastoAuto
    {
        public string Tipo { get; set; }

        public GuastoAuto(string tipo)
        {
            Tipo = tipo;
        }
    }

    // Client
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        // Crea la catena di responsabilità
    //        IManutentoreAuto meccanico = new Meccanico();
    //        IManutentoreAuto elettricista = new Elettricista();
    //        IManutentoreAuto carrozziere = new Carrozziere();

    //        meccanico.ProssimoManutentore = elettricista;
    //        elettricista.ProssimoManutentore = carrozziere;

    //        // Esempio di utilizzo
    //        GuastoAuto guastoMotore = new GuastoAuto("Motore");
    //        GuastoAuto guastoElettronica = new GuastoAuto("Elettronica");
    //        GuastoAuto guastoCarrozzeria = new GuastoAuto("Carrozzeria");

    //        meccanico.Ripara(guastoMotore);
    //        meccanico.Ripara(guastoElettronica);
    //        meccanico.Ripara(guastoCarrozzeria);

    //        Console.ReadLine();
    //    }
    //}
}

