
using System;

class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
    }
}

class Dog : Animal
{
    public string Breed { get; set; }

    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }

    public void Bark()
    {
        Console.WriteLine($"{Name} гавкає: Гав-гав!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Порода: {Breed}");
    }
}

class Cat : Animal
{
    public string Color { get; set; }

    public Cat(string name, int age, string color) : base(name, age)
    {
        Color = color;
    }

    public void Meow()
    {
        Console.WriteLine($"{Name} нявкає: Няв-няв!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Колір: {Color}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("Барсик", 3, "Німецька вівчарка");
        Cat cat = new Cat("Мурка", 2, "Білий");

        Console.WriteLine("Інформація про собаку:");
        dog.DisplayInfo();
        dog.Bark();

        Console.WriteLine("\nІнформація про кішку:");
        cat.DisplayInfo();
        cat.Meow();
    }
}
