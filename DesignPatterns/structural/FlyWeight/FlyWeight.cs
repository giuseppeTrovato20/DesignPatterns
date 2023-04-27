using System;
namespace DesignPatterns.structural.FlyWeight
{
    //utilizzato quando abbiamo alcuni casi molto specifici in cui:
    // - dobbiamo renderizzare migliaia o centinaia di migliaia di elementi a schermo
    // - 
    //riduce l'utilizzo di memoria condivendo oggetti
    //che hanno alcuni valori identici

    //proprietà invarianti / proprietà che non cambiano mai
    //proprietà variabili / dinamiche 


    public interface ICharacter
    {
        void Display();
    }

    public class Character : ICharacter
    {
        private char symbol;

        public Character(char symbol)
        {
            this.symbol = symbol;
        }

        public void Display()
        {
            Console.Write(symbol);
        }
    }

    public class CharacterFactory
    {
        private Dictionary<char, ICharacter> characters = new Dictionary<char, ICharacter>();
        //istanzia un oggetto per tutti i caratteri renderizzati e poi ci permette
        //di riutilizzarli più efficentemente andandolo a richiamare e modificando solamente
        //la posizione

        public ICharacter GetCharacter(char symbol)
        {
            ICharacter character;
            if (!characters.TryGetValue(symbol, out character))
            {
                character = new Character(symbol);
                characters.Add(symbol, character);
                Console.WriteLine($"New Character Created: {symbol}");
            }

            return character;
        }
    }

    public class TextProcessor
    {
        private List<ICharacter> characters = new List<ICharacter>();
        private CharacterFactory characterFactory = new CharacterFactory();

        public void ProcessText(string text)
        {
            foreach (char c in text)
            {
                ICharacter character = characterFactory.GetCharacter(c);
                characters.Add(character);
            }
        }

        public void DisplayText()
        {
            foreach (ICharacter c in characters)
            {
                c.Display();
            }

            Console.WriteLine("text");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextProcessor textProcessor = new TextProcessor();
            textProcessor.ProcessText("FlyweightDesignPatternExampleStyle");
            textProcessor.DisplayText();

            textProcessor.ProcessText("FlyweightInTextProcessor");
            textProcessor.DisplayText();
        }
    }
}

