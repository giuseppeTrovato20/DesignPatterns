using System;
namespace DesignPatterns.Builder;

public class Car
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }

    public Car(CarBuilder builder)
    {
        Model = builder.Model;
        Color = builder.Color;
        Year = builder.Year;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}\nColor: {Color}\nYear: {Year}");
    }
}

public class CarBuilder
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }

    public CarBuilder SetModel(string model)
    {
        Model = model;
        return this;
    }

    public CarBuilder SetColor(string color)
    {
        Color = color;
        return this;
    }

    public CarBuilder SetYear(int year)
    {
        Year = year;
        return this;
    }

    public Car Build()
    {
        return new Car(this);
    }


}


