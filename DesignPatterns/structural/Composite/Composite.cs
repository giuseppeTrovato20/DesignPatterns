using System;
namespace DesignPatterns.structural.Composite;

// Interfaccia Comune per Elementi Singoli e Compositi
public interface IScommessaComponent
{
    //void AddComponent(IScommessaComponent component);
    void DisplayInfo();
}


// Composite Class
public class CategoriaScommessa : IScommessaComponent
{
    private readonly List<IScommessaComponent> _components = new List<IScommessaComponent>();
    private readonly string _name;

    public CategoriaScommessa(string name)
    {
        _name = name;
    }

    public void AddComponent(IScommessaComponent component)
    {
        _components.Add(component);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Categoria Scommessa: {_name}");

        foreach (var component in _components)
        {
            component.DisplayInfo();
        }
    }
}

// Leaf Class
public class Scommessa : IScommessaComponent
{
    private readonly string _name;
    private readonly double _quota;

    public Scommessa(string name, double quota)
    {
        _name = name;
        _quota = quota;
    }

    public void AddComponent(IScommessaComponent component)
    {
        throw new NotImplementedException();
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Scommessa: {_name} - Quota: {_quota}");
    }
}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        // Creazione oggetti scommessa (Leaf)
//        var scommessa1 = new Scommessa("Manchester United vince", 1.5);
//        var scommessa2 = new Scommessa("Real Madrid vince", 2.0);
//        var scommessa3 = new Scommessa("Barcellona vince", 1.7);

//        // Creazione categorie scommessa (Composite)
//        var calcio = new CategoriaScommessa("Calcio");
//        var championsLeague = new CategoriaScommessa("Champions League");
//        var serieA = new CategoriaScommessa("Serie A");

//        // Aggiunta scommesse alle categorie
//        championsLeague.AddComponent(scommessa1);
//        championsLeague.AddComponent(scommessa2);
//        serieA.AddComponent(scommessa3);

//        // Aggiunta categorie alla categoria principale "calcio"
//        calcio.AddComponent(championsLeague);
//        calcio.AddComponent(serieA);

//        // Visualizzazione informazioni scommesse
//        calcio.DisplayInfo();

//        Console.ReadLine();
//    }
//}

