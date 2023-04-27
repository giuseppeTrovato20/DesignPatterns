using System;
namespace DesignPatterns.structural.FlyWeight
{
    interface IAlbero
    {
        public string tipo { get; set; }
        public int altezza { get; set; }
        public string coloreFoglie { get; set; }
    }



    public class Albero
    {
        public string tipo { get; set; }
        public int altezza { get; set; }
        public string coloreFoglie { get; set; }

        public Albero(string tipo, string coloreFoglie, int altezza)
        {
            this.tipo = tipo;
            this.coloreFoglie = coloreFoglie;
            this.altezza = altezza;
        }

    }

    // Classe ForestaVr
    public class ForestaVr
    {
        private List<AlberoContext> _alberi = new List<AlberoContext>();

        public void PiantaAlbero(Albero tree, int x, int y)
        {
            AlberoContext albero = new AlberoContext(tree, x, y );
            _alberi.Add(albero);
        }

        public void MostraForesta()
        {
            foreach (AlberoContext albero in _alberi)
            {
                albero.MostraAlbero();
            }
        }
    }


    public class AlberoContext
    {

        public Albero albero { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public AlberoContext(Albero albero, int x, int y)
        {
            this.albero = albero;
            this.x = x;
            this.y = y;
        }

        public void MostraAlbero()
        {
            Console.WriteLine($"Albero di tipo {albero.tipo} alle coordinate ({x}, {y}) e dimensione {albero.altezza}, con le foglie {albero.coloreFoglie}.");
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ForestaVr foresta = new ForestaVr();

                                                //2k     2k        1k
            Albero pinoFoglieGialle = new Albero("Pino", "gialle", 5);

            Albero pinoFoglieRosse = new Albero("Pino", "rosse", 5);
            Albero pinoFoglieGialleAlto = new Albero("Pino", "gialle", 15);

            for (int i = 0; i < 6; i++)
            {
                                                     //1k 1k 
                foresta.PiantaAlbero(pinoFoglieGialle, i, i);

            }
            
            //altri 10k alberi

            foresta.MostraForesta();
        }
    }
}

