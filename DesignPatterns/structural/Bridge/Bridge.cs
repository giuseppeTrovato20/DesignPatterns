using System;
namespace DesignPatterns.structural.Bridge
{

    //ci permette di disaccoppiare due implementazioni concrete
    //facendole comunicare con due interfacce distinte
    //e ci permette di andare aggiungere nuove implementazione concrete

    // Astrazione - interfaccia per le forme
    public interface IForma
    {
        void Disegna();
    }

    // Implementazione - interfaccia per i renderer
    public interface IRenderer
    {
        string Renderizza();
    }

    // Renderer concreto 1: Renderer ASCII art
    public class RenderPng : IRenderer
    {
        public string Renderizza()
        {
            return "Rendering as png";
        }
    }

    // Renderer concreto 2: Renderer vettoriale
    public class RendererVettoriale : IRenderer
    {
        public string Renderizza()
        {
            return "Rendering vettoriale";
        }
    }

    // Forma concreta 1: cerchio
    public class Cerchio : IForma
    {
        private IRenderer _renderer;

        public Cerchio(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public void Disegna()
        {
            Console.WriteLine($"Disegno un cerchio. {_renderer.Renderizza()}");
        }
    }

    // Forma concreta 2: rettangolo
    public class Rettangolo : IForma
    {
        private IRenderer _renderer;

        public Rettangolo(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public void Disegna()
        {
            Console.WriteLine($"Disegno un rettangolo. {_renderer.Renderizza()}");
        }
    }

    public class Client
    {
        public static void Main()
        {
            EsempioBridge();
        }

        public static void EsempioBridge()
        {
            IRenderer rendererPng = new RenderPng();
            IRenderer rendererVettoriale = new RendererVettoriale();

            IForma cerchioPng = new Cerchio(rendererPng);
            IForma cerchioVettoriale = new Cerchio(rendererVettoriale);

            IForma rettangoloPng = new Rettangolo(rendererPng);
            IForma rettangoloVettoriale = new Rettangolo(rendererVettoriale);

            cerchioPng.Disegna(); // Disegno un cerchio. Rendering come png
            cerchioVettoriale.Disegna(); // Disegno un cerchio. Rendering vettoriale

            rettangoloPng.Disegna(); // Disegno un rettangolo. Rendering come png
            rettangoloVettoriale.Disegna(); // Disegno un rettangolo. Rendering vettoriale
        }
    }
}

