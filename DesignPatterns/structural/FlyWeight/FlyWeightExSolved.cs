using System;
namespace DesignPatterns.structural.FlyWeightExSolved
{
    public interface ISoldier
    {
        void Display(int positionX, int positionY);
    }

    public class SoldierFlyweight : ISoldier
    {
        private readonly string _name;
        private readonly int _health;
        private readonly int _attackPower;
        private readonly int _defensePower;

        public SoldierFlyweight(string name, int health, int attackPower, int defensePower)
        {
            _name = name;
            _health = health;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }

        public void Display(int positionX, int positionY)
        {
            Console.WriteLine($"Soldier {_name}: Health={_health}, AttackPower={_attackPower}, DefensePower={_defensePower}, Position=({positionX},{positionY})");
        }
    }

    public class SoldierFlyweightFactory
    {
        private readonly Dictionary<string, SoldierFlyweight> _flyweights = new Dictionary<string, SoldierFlyweight>();

        public SoldierFlyweight GetSoldierFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
            {
                _flyweights[key] = new SoldierFlyweight("Infantry", 100, 10, 5);
            }

            return _flyweights[key];
        }
    }

    public class SoldierContext
    {
        private readonly ISoldier _soldierFlyweight;
        private readonly int _positionX;
        private readonly int _positionY;

        public SoldierContext(ISoldier soldierFlyweight, int positionX, int positionY)
        {
            _soldierFlyweight = soldierFlyweight;
            _positionX = positionX;
            _positionY = positionY;
        }

        public void Display()
        {
            _soldierFlyweight.Display(_positionX, _positionY);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<SoldierContext> soldiers = new List<SoldierContext>();
            SoldierFlyweightFactory factory = new SoldierFlyweightFactory();

            for (int i = 0; i < 1000; i++)
            {
                SoldierFlyweight soldierFlyweight = factory.GetSoldierFlyweight("Infantry");
                SoldierContext soldierContext = new SoldierContext(soldierFlyweight, i % 50, i / 50);
                soldiers.Add(soldierContext);
            }

            foreach (var soldier in soldiers)
            {
                soldier.Display();
            }
        }
    }
}

