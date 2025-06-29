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
    }
}
