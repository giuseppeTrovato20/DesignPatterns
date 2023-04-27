using System;
namespace DesignPatterns.Behavioural.Memento
{
    public class Memento
    {
        public string Text { get; private set; }

        public Memento(string text)
        {
            Text = text;
        }
    }

    public class Originator
    {
        public string Text { get; set; }

        public Memento Save()
        {
            return new Memento(Text);
        }

        public void Restore(Memento memento)
        {
            Text = memento.Text;
        }
    }

    public class Caretaker
    {
        private Stack<Memento> _mementos = new Stack<Memento>();

        public void Save(Originator originator)
        {
            _mementos.Push(originator.Save());
        }

        public void Undo(Originator originator)
        {
            if (_mementos.Count > 0)
            {
                originator.Restore(_mementos.Pop());
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var originator = new Originator();
            var caretaker = new Caretaker();

            originator.Text = "Prima riga di testo";
            caretaker.Save(originator);

            originator.Text += "\nSeconda riga di testo";
            caretaker.Save(originator);

            originator.Text += "\nTerza riga di testo";
            Console.WriteLine("Stato corrente: \n" + originator.Text);

            caretaker.Undo(originator);
            Console.WriteLine("\nDopo Undo: \n" + originator.Text);

            caretaker.Undo(originator);
            Console.WriteLine("\nDopo un altro Undo: \n" + originator.Text);
        }
    }
}

