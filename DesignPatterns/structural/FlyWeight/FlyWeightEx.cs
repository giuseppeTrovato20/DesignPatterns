using System;
namespace DesignPatterns.structural.FlyWeight
{
    public class Soldier
    {
        public string Name;
        public int Health;
        public int AttackPower;
        public int DefensePower;
        public int PositionX;
        public int PositionY;

        public Soldier(string name, int health, int attackPower, int defensePower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            DefensePower = defensePower;
        }

        public void SetPosition(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Display()
        {
            Console.WriteLine($"Soldier {Name}: Health={Health}, AttackPower={AttackPower}, DefensePower={DefensePower}, Position=({PositionX},{PositionY})");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();

            for (int i = 0; i < 1000; i++)
            {
                Soldier soldier = new Soldier("Infantry", 100, 10, 5);
                soldier.SetPosition(i % 50, i / 50);
                soldiers.Add(soldier);
            }

            foreach (var soldier in soldiers)
            {
                soldier.Display();
            }
        }
    }
}

