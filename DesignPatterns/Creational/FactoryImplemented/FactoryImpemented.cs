using System;
namespace DesignPatterns.FactoryImplemented;

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

public class ElderlyCreditCard : ICreditCard
{

    public string name { get; set; }

    public void pay()
    {
        // pay logic
    }
}

interface ICreditCardFactory
{
    string name { get; set; }
    string nation { get; set; }
    string profession { get; set; }
    int age { get; set; }

    ICreditCard createCard();
}

public class CreditCardFactory
{
    public string name { get; set; }
    public string nation { get; set; }
    public string profession { get; set; }
    public int age { get; set; }

    
    public CreditCardFactory(string name, string nation, string profession, int age)
    {
        this.name = name;
        this.nation = nation;
        this.profession = profession;
        this.age = age;

        // fetch ultime offerte
        // fetch carte disponibili
        // fetch carte disponibili per età
        // stagione
    }

    public ICreditCard createCard()
    {
        //switch vari
        //if che controllano quali opzioni rimangnono ecc

        if(age > 60)
        {
            return new ElderlyCreditCard();
        } else
        {

        }

        return new YouthCreditCard();
    }
}

public class User
{
    string name { get; set; }
    string nation { get; set; }
    string profession { get; set; }
    int age { get; set; }
    ICreditCard? card { get; set; } = null;

    public User(string name, string nation, string profession, int age )
    {
        this.name = name;
        this.nation = nation;
        this.profession = profession;
        this.age = age;
       
    }

    public void requestNewCreditCard()
    {
        CreditCardFactory creditCardFactory = new CreditCardFactory(name, nation,profession, age);

        card = creditCardFactory.createCard();
    }

    public void makePayment()
    {
        if(card != null)
        {
            card.pay();
        }
    }

}


