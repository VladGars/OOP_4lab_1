using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    public int HorsePower { get; }

    public Engine(int horsePower)
    {
        this.HorsePower = horsePower;
    }

    public void Start() => Console.WriteLine("Двигун запущено.");

    public override string ToString() => $"Двигун ({HorsePower} к.с.)";
}


public class Wheel
{
    public int Diameter { get; }

    public Wheel(int diameter)
    {
        this.Diameter = diameter;
    }

    public override string ToString() => $"Колесо ({Diameter} дюймів)";
}


public class Car
{

    private Engine engine;
    private List<Wheel> wheels;
    public string Brand { get; }
    private bool isFueled = false;

    public Car(string brand, Engine engine, List<Wheel> wheels)
    {
        this.Brand = brand;
        this.engine = engine;
        this.wheels = wheels;
        Console.WriteLine($"Створено автомобіль: {brand}");
    }


    public void Drive()
    {
        if (isFueled)
        {
            Console.WriteLine($"Автомобіль {Brand} починає рух.");
            engine.Start(); 
            Console.WriteLine("Колеса обертаються...");
        }
        else
        {
            Console.WriteLine($"Автомобіль {Brand} не заправлений і не може їхати.");
        }
    }

    public void Refuel()
    {
        this.isFueled = true;
        Console.WriteLine($"Автомобіль {Brand} заправлено.");
    }

    public void ChangeWheel(int wheelIndex, Wheel newWheel)
    {
        if (wheelIndex >= 0 && wheelIndex < wheels.Count)
        {
            Console.WriteLine($"Міняємо колесо №{wheelIndex + 1} з {wheels[wheelIndex]} на {newWheel}.");
            wheels[wheelIndex] = newWheel;
        }
    }

    public void PrintBrand()
    {
        Console.WriteLine($"Марка автомобіля: {Brand}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;


        var carEngine = new Engine(300);
        var carWheels = new List<Wheel>
        {
            new Wheel(18), new Wheel(18), new Wheel(18), new Wheel(18)
        };


        var myCar = new Car("Audi A6", carEngine, carWheels);
        Console.WriteLine("----------");


        myCar.PrintBrand(); 
        myCar.Drive();      
        myCar.Refuel();     
        myCar.Drive();      
        Console.WriteLine("----------");

 
        var spareWheel = new Wheel(19);
        myCar.ChangeWheel(0, spareWheel);
    }
}