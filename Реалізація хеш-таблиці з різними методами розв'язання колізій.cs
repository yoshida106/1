using System;
using System.Collections.Generic;
using System.Diagnostics;

public interface IHashTable
{
    bool Add(string value);
    bool Contains(string value);
}

public class ChainingHashTable : IHashTable
{
    private readonly LinkedList<string>[] _buckets;
    private readonly int _size;
    private readonly Func<string, int> _hashFunction;

    public ChainingHashTable(int size, Func<string, int> hashFunction)
    {
        _size = size;
        _buckets = new LinkedList<string>[size];
        _hashFunction = hashFunction;
        
        for (int i = 0; i < size; i++)
        {
            _buckets[i] = new LinkedList<string>();
        }
    }

    public bool Add(string value)
    {
        int index = _hashFunction(value) % _size;
        
        if (_buckets[index].Contains(value))
            return false;
            
        _buckets[index].AddLast(value);
        return true;
    }

    public bool Contains(string value)
    {
        int index = _hashFunction(value) % _size;
        return _buckets[index].Contains(value);
    }
}

public class OpenAddressingHashTable : IHashTable
{
    private readonly string[] _table;
    private readonly int _size;
    private readonly Func<string, int> _hashFunction;

    public OpenAddressingHashTable(int size, Func<string, int> hashFunction)
    {
        _size = size;
        _table = new string[size];
        _hashFunction = hashFunction;
    }

    public bool Add(string value)
    {
        int index = _hashFunction(value) % _size;
        int originalIndex = index;
        
        while (_table[index] != null)
        {
            if (_table[index] == value)
                return false;
                
            index = (index + 1) % _size;
            
            if (index == originalIndex)
                throw new Exception("Хеш-таблиця заповнена.");
        }
        
        _table[index] = value;
        return true;
    }

    public bool Contains(string value)
    {
        int index = _hashFunction(value) % _size;
        int originalIndex = index;
        
        while (_table[index] != null)
        {
            if (_table[index] == value)
                return true;
                
            index = (index + 1) % _size;
            
            if (index == originalIndex)
                break;
        }
        
        return false;
    }
}

public static class HashFunctions
{
    public static int SimpleHash(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += c;
        }
        return hash;
    }

    public static int ImprovedHash(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash = (hash << 5) ^ (hash >> 27) ^ c;
        }
        return Math.Abs(hash);
    }
}

public class HashTableTester
{
    public static void TestPerformance(IHashTable table, string[] values)
    {
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        foreach (var value in values)
        {
            table.Add(value);
        }
        stopwatch.Stop();
        Console.WriteLine($"Час додавання: {stopwatch.ElapsedTicks} ticks");
        

        stopwatch.Restart();
        foreach (var value in values)
        {
            table.Contains(value);
        }
        stopwatch.Stop();
        Console.WriteLine($"Час пошуку: {stopwatch.ElapsedTicks} ticks");
    }
}

class Program
{
    static void Main(string[] args)
    {
        const int tableSize = 100;
        var random = new Random();
        var testValues = new string[20];
        
        for (int i = 0; i < testValues.Length; i++)
        {
            testValues[i] = GenerateRandomString(random, 5);
            Console.WriteLine(testValues[i]);
        }
        
        Console.WriteLine("\nТестування з ланцюговим хешуванням (проста хеш-функція):");
        var chainingSimple = new ChainingHashTable(tableSize, HashFunctions.SimpleHash);
        HashTableTester.TestPerformance(chainingSimple, testValues);
        
        Console.WriteLine("\nТестування з ланцюговим хешуванням (покращена хеш-функція):");
        var chainingImproved = new ChainingHashTable(tableSize, HashFunctions.ImprovedHash);
        HashTableTester.TestPerformance(chainingImproved, testValues);
        
        Console.WriteLine("\nТестування з відкритою адресацією (проста хеш-функція):");
        var openAddressingSimple = new OpenAddressingHashTable(tableSize, HashFunctions.SimpleHash);
        HashTableTester.TestPerformance(openAddressingSimple, testValues);
        
        Console.WriteLine("\nТестування з відкритою адресацією (покращена хеш-функція):");
        var openAddressingImproved = new OpenAddressingHashTable(tableSize, HashFunctions.ImprovedHash);
        HashTableTester.TestPerformance(openAddressingImproved, testValues);
    }
    
    private static string GenerateRandomString(Random random, int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[length];
        
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        
        return new string(stringChars);
    }
}