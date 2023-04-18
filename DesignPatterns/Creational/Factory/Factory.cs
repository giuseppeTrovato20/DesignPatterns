using System;
namespace DesignPatterns.Factory
{
    public interface ICreditCard
    {
        string name { get; set; }
        void pay();
    }

    public class YouthCreditCard : ICreditCard
    {

        public string name { get; set; }

        public void pay()
        {
            // pay logic
        }
    }

    public class StartUpCreditCard : ICreditCard
    {

        public string name { get; set; }

        public void pay()
        {
            // pay logic
        }
    }

    public class PIvaCreditCard : ICreditCard
    {

        public string name { get; set; }

        public void pay()
        {
            // pay logic
        }
    }

    public class ForeignCreditCard : ICreditCard
    {

        public string name { get; set; }

        public void pay()
        {
            // pay logic
        }
    }

    public class User
    {
        string name { get; set; }
        string nation { get; set; }
        string profession { get; set; }
        int age { get; set; }
        ICreditCard? card { get; set; } = null;

        public User(string name, string nation, string profession, int age)
        {
            this.name = name;
            this.nation = nation;
            this.profession = profession;
            this.age = age;
        }

        public void requestNewCreditCard()
        {



        }

        public void makePayment()
        {
            card.pay();
        }

    }

}

