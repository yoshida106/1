using System;

public class Money
{
    public decimal Amount { get; set; }

    public Money(decimal amount)
    {
        Amount = amount;
    }

    public static Money operator +(Money a, Money b)
    {
        return new Money(a.Amount + b.Amount);
    }

    public static Money operator -(Money a, Money b)
    {
        return new Money(a.Amount - b.Amount);
    }

    public override string ToString()
    {
        return $"{Amount:C}"; // Формат у вигляді валюти
    }
}

public class TimePeriod
{
    public int Hours { get; set; }
    public int Minutes { get; set; }

    public TimePeriod(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
        Normalize();
    }

    private void Normalize()
    {
        if (Minutes >= 60)
        {
            Hours += Minutes / 60;
            Minutes = Minutes % 60;
        }
    }

    public static TimePeriod operator +(TimePeriod a, TimePeriod b)
    {
        return new TimePeriod(a.Hours + b.Hours, a.Minutes + b.Minutes);
    }

    public override string ToString()
    {
        return $"{Hours} год. {Minutes} хв.";
    }
}

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public static bool operator ==(Car a, Car b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Brand == b.Brand && a.Model == b.Model && a.Year == b.Year;
    }

    public static bool operator !=(Car a, Car b) => !(a == b);

    public override bool Equals(object obj)
    {
        return obj is Car car && this == car;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Brand, Model, Year);
    }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public static bool operator <(Product a, Product b)
    {
        return a.Price < b.Price;
    }

    public static bool operator >(Product a, Product b)
    {
        return a.Price > b.Price;
    }

    public static bool operator <=(Product a, Product b) => a.Price <= b.Price;
    public static bool operator >=(Product a, Product b) => a.Price >= b.Price;
}

class Program
{
    static void Main()
    {
        Money m1 = new Money(150.75m);
        Money m2 = new Money(89.25m);
        Money sum = m1 + m2;
        Money difference = m1 - m2;

        Console.WriteLine("Операції з грошима:");
        Console.WriteLine($"Сума: {sum}");
        Console.WriteLine($"Різниця: {difference}");

        TimePeriod t1 = new TimePeriod(2, 30);
        TimePeriod t2 = new TimePeriod(1, 45);
        TimePeriod total = t1 + t2;

        Console.WriteLine("\nОперації з часом:");
        Console.WriteLine($"{t1} + {t2} = {total}");

        Car car1 = new Car("Toyota", "Corolla", 2020);
        Car car2 = new Car("Toyota", "Corolla", 2020);
        Car car3 = new Car("Honda", "Civic", 2021);

        Console.WriteLine("\nПорівняння автомобілів:");
        Console.WriteLine($"car1 == car2: {car1 == car2}");
        Console.WriteLine($"car1 != car3: {car1 != car3}");

        Product p1 = new Product("Товар A", 100m);
        Product p2 = new Product("Товар B", 150m);

        Console.WriteLine("\nПорівняння продуктів за ціною:");
        Console.WriteLine($"p1 < p2: {p1 < p2}");
        Console.WriteLine($"p1 > p2: {p1 > p2}");
        Console.WriteLine($"p1 <= p2: {p1 <= p2}");
        Console.WriteLine($"p1 >= p2: {p1 >= p2}");
    }
}
