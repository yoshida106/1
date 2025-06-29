using System;

public class Publisher
{
    public string Name { get; set; }

    public Publisher(string name)
    {
        Name = name;
    }
}

public class Book : ICloneable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public Publisher Publisher { get; set; }

    public Book(string title, string author, int year, Publisher publisher)
    {
        Title = title;
        Author = author;
        Year = year;
        Publisher = publisher;
    }

    public Book(Book other)
    {
        Title = other.Title;
        Author = other.Author;
        Year = other.Year;
        Publisher = new Publisher(other.Publisher.Name); 

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public Book DeepClone()
    {
        return new Book(Title, Author, Year, new Publisher(Publisher.Name));
    }

    public void DisplayInfo(string label = "")
    {
        Console.WriteLine($"{label}Назва: {Title}, Автор: {Author}, Рік: {Year}, Видавництво: {Publisher.Name}");
    }
}

class Program
{
    static void Main()
    {
        Book original = new Book("1984", "George Orwell", 1949, new Publisher("Penguin"));

        Book copyConstructor = new Book(original);
        
        Book shallowCopy = (Book)original.Clone();

        Book deepCopy = original.DeepClone();

        Console.WriteLine("Початкові значення:");
        original.DisplayInfo("Original: ");
        copyConstructor.DisplayInfo("Copy (constructor): ");
        shallowCopy.DisplayInfo("Shallow Copy: ");
        deepCopy.DisplayInfo("Deep Copy: ");

        original.Publisher.Name = "HarperCollins";

        Console.WriteLine("\nПісля зміни назви видавництва в оригіналі:");
        original.DisplayInfo("Original: ");
        copyConstructor.DisplayInfo("Copy (constructor): ");
        shallowCopy.DisplayInfo("Shallow Copy: ");
        deepCopy.DisplayInfo("Deep Copy: ");
    }
}
