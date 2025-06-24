using System;

// Перелічуваний тип Gender
enum Gender
{
    Male = 1,
    Female = 2
}

// Структура Person
struct Person
{
    public Gender Gender;
    public string FirstName;
    public string LastName;
}

class Program
{
    static void Main(string[] args)
    {
        // Масив для зберігання імен та прізвищ
        string[] firstNames = { "Іван", "Петро", "Марія", "Олена", "Олексій", "Наталія", "Андрій", "Софія", "Віктор", "Тетяна" };
        string[] lastNames = { "Шевченко", "Франко", "Коваленко", "Петренко", "Сидоренко", "Павленко", "Іваненко", "Михайленко", "Григоренко", "Ткаченко" };

        // Створення та заповнення масиву Person
        Person[] people = new Person[10];
        Random random = new Random();

        for (int i = 0; i < people.Length; i++)
        {
            people[i].Gender = (Gender)random.Next(1, 3); // Випадково Male або Female
            people[i].FirstName = firstNames[random.Next(firstNames.Length)];
            people[i].LastName = lastNames[random.Next(lastNames.Length)];
        }

        // Виведення чоловіків
        Console.WriteLine("Чоловіки:");
        foreach (var person in people)
        {
            if (person.Gender == Gender.Male)
            {
                Console.WriteLine($"{person.LastName} {person.FirstName}");
            }
        }

        // Виведення жінок
        Console.WriteLine("\nЖінки:");
        foreach (var person in people)
        {
            if (person.Gender == Gender.Female)
            {
                Console.WriteLine($"{person.LastName} {person.FirstName}");
            }
        }
    }
}