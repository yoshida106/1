
using System;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string GroupNumber { get; set; }

    public Student() : this("Ім'я за замовчуванням", "Прізвище за замовчуванням", "Група-000")
    {
    }

    public Student(string firstName) : this(firstName, "Прізвище не вказано", "Група не вказана")
    {
    }

    public Student(string firstName, string lastName, string groupNumber)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.GroupNumber = groupNumber;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Ім'я: {FirstName}, Прізвище: {LastName}, Група: {GroupNumber}");
    }
}

class Program
{
    static void Main()
    {
        Student student1 = new Student();
        student1.DisplayInfo();

        Student student2 = new Student("Андрій");
        student2.DisplayInfo();

        Student student3 = new Student("Марія", "Шевченко", "ІТ-101");
        student3.DisplayInfo();
    }
}
