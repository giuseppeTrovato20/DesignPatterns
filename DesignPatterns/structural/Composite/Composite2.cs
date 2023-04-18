using System;
namespace DesignPatterns.structural.Composite;

public interface IComponent
{
    void Add(IComponent component);
    void Remove(IComponent component);
    void Display(int depth);
}

public class Composite : IComponent
{
    private readonly List<IComponent> _children = new List<IComponent>();
    private readonly string _name;

    public Composite(string name)
    {
        _name = name;
    }

    public void Add(IComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }

    public void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + _name);

        foreach (IComponent component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

public class Leaf : IComponent
{
    private readonly string _name;

    public Leaf(string name)
    {
        _name = name;
    }

    public void Add(IComponent component)
    {
        Console.WriteLine("Cannot add to a leaf");
    }

    public void Remove(IComponent component)
    {
        Console.WriteLine("Cannot remove from a leaf");
    }

    public void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + _name);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        var comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));

        root.Add(comp);

        var comp2 = new Composite("Composite Y");
        comp2.Add(new Leaf("Leaf YA"));
        comp2.Add(new Leaf("Leaf YB"));
        root.Add(comp2);

        root.Add(new Leaf("Leaf C"));
        root.Remove(new Leaf("Leaf B"));

        root.Display(1);

        Console.ReadKey();
    }
}
