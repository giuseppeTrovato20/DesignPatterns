using System;
namespace DesignPatterns.Prototype
{
    // Prototype abstract class
    public abstract class AnimalPrototype
    {
        public abstract AnimalPrototype Clone();
    }

    // Concrete prototype class
    public class Dog : AnimalPrototype
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog() { }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override AnimalPrototype Clone()
        {
            return new Dog(Name, Age);
        }

        public override string ToString()
        {
            return $"Dog: {Name}, {Age} years old";
        }
    }



}

