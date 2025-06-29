
using System;
using System.Collections.Generic;
using System.Linq;

// Завдання 1

public abstract class Customer
{
    public string Address { get; set; }
    public abstract string GetCustomerName();
}

public class PrivateCustomer : Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string GetCustomerName()
    {
        return $"{FirstName} {LastName}";
    }
}

public class CompanyCustomer : Customer
{
    public string CompanyName { get; set; }

    public override string GetCustomerName()
    {
        return CompanyName;
    }
}

public class Order
{
    public Customer Customer { get; set; }

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public string GetCustomerName() => Customer.GetCustomerName();
    public string GetDeliveryAddress() => Customer.Address;
}


// Завдання 2

public abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public abstract string GetQuantityDescription();
    public abstract decimal GetTotalCost();
}

public class GoodsByWeight : Product
{
    public float Weight { get; set; }

    public override string GetQuantityDescription() => $"{Weight} кг";
    public override decimal GetTotalCost() => Price * (decimal)Weight;
}

public class GoodsByPiece : Product
{
    public int Amount { get; set; }

    public override string GetQuantityDescription() => $"{Amount} шт";
    public override decimal GetTotalCost() => Price * Amount;
}

public class Liquid : Product
{
    public float Volume { get; set; }

    public override string GetQuantityDescription() => $"{Volume} л";
    public override decimal GetTotalCost() => Price * (decimal)Volume;
}

public class OrderWithProducts
{
    private List<Product> items = new List<Product>();

    public void AddItem(Product item)
    {
        items.Add(item);
    }

    public void PrintOrderDetails()
    {
        Console.WriteLine("Список товарів у замовленні:");
        foreach (var item in items)
        {
            Console.WriteLine($"Назва: {item.Name}, Ціна: {item.Price}, Кількість: {item.GetQuantityDescription()}, Сума: {item.GetTotalCost()}");
        }
    }

    public decimal TotalCost() => items.Sum(item => item.GetTotalCost());
}
