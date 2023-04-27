using System;
namespace DesignPatterns.Behavioural.command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class AumentaVolume : ICommand
    {
        private Altoparlante _altoparlante;
        private int _incremento;

        public AumentaVolume(Altoparlante altoparlante, int incremento)
        {
            _altoparlante = altoparlante;
            _incremento = incremento;
        }

        public void Execute()
        {
            _altoparlante.SetVolume(_altoparlante.GetVolume() + _incremento);
        }

        public void Undo()
        {
            _altoparlante.SetVolume(_altoparlante.GetVolume() - _incremento);
        }
    }

    public class DiminuisciVolume : ICommand
    {
        private Altoparlante _altoparlante;
        private int _decremento;

        public DiminuisciVolume(Altoparlante altoparlante, int decremento)
        {
            _altoparlante = altoparlante;
            _decremento = decremento;
        }

        public void Execute()
        {
            _altoparlante.SetVolume(_altoparlante.GetVolume() - _decremento);
        }

        public void Undo()
        {
            _altoparlante.SetVolume(_altoparlante.GetVolume() + _decremento);
        }
    }

    public class Altoparlante
    {
        private int _volume;

        public int GetVolume()
        {
            return _volume;
        }

        public void SetVolume(int volume)
        {
            _volume = volume;
            Console.WriteLine($"Il volume è stato impostato a {_volume}");
        }
    }

    public class Telecomando
    {
        private ICommand lastCommand;
        private ICommand[] commands;

        public Telecomando(ICommand[] commands)
        {
            this.commands = commands;
        }

        public void PressButton(int n)
        {
            commands[n].Execute();
            lastCommand = commands[n];

        }

        public void PressUndo()
        {
            lastCommand.Undo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Altoparlante altoparlante = new Altoparlante();

            ICommand aumentaVolume = new AumentaVolume(altoparlante, 10);
            ICommand diminuisciVolume = new DiminuisciVolume(altoparlante, 5);

            Telecomando telecomando = new Telecomando(new ICommand[] { aumentaVolume, diminuisciVolume });


            telecomando.PressButton(1); // Aumenta il volume di 10

            telecomando.PressButton(2); // Diminuisce il volume di 5

            telecomando.PressUndo(); // Annulla l'ultimo comando (Aumenta il volume di 5)
        }
    }   
}

