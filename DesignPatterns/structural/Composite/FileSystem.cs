using System;
namespace DesignPatterns.structural.Composite3
{
    interface IComponent
    {
        void Display(int depth);
    }


    // Componente astratta
    public abstract class FileSystemComponent: IComponent
    {
        protected string _name;

        public FileSystemComponent(string name)
        {
            _name = name;
        }

        public abstract void Display(int depth);
    }

    // Componente astratta
    public abstract class DirectorySystemComponent : IComponent
    {
        protected string _name;

        public DirectorySystemComponent(string name)
        {
            _name = name;
        }

        public abstract void Add(DirectorySystemComponent dir);
        public abstract void Add(FileSystemComponent file);
        public abstract void remove();

        public abstract void Display(int depth);
    }

    // Foglia
    public class File : FileSystemComponent
    {
        public File(string name) : base(name) { }

        public override void Display(int depth)
        {
            Console.WriteLine( "/" + _name);
        }
    }

    // Composite
    public class Directory : DirectorySystemComponent
    {
        private List<IComponent> _components = new List<IComponent>();

        public Directory(string name) : base(name) { }

        public override void Add(FileSystemComponent component)
        {
            _components.Add(component);
        }

        public override void Add(DirectorySystemComponent directory)
        {
            _components.Add(directory);
        }

        public void Remove(FileSystemComponent component)
        {
            _components.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine("/" + _name);

            foreach (var component in _components)
            {
                component.Display(depth + 2);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Directory root = new Directory("root");
            Directory home = new Directory("home");
            Directory documents = new Directory("documents");
            Directory pictures = new Directory("pictures");

            File file1 = new File("file1.txt");
            File file2 = new File("file2.txt");
            File image1 = new File("image1.jpg");

            root.Add(home);

            home.Add(documents);
            home.Add(pictures);

            documents.Add(file1);
            documents.Add(file2);

            pictures.Add(image1);

            root.Display(1);
        }
    }
}

