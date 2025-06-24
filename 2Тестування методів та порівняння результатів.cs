class Program
{
    static void Main(string[] args)
    {
        const double a = 0.0;
        const double b = 1.0;
        double exactValue = NumericalIntegration.ExactIntegralValue();
        
        Console.WriteLine("Точне значення інтеграла: " + exactValue);
        Console.WriteLine("==========================================");
        
        int[] partitions = { 10, 100, 1000 };
        
        foreach (int n in partitions)
        {
            Console.WriteLine($"\nКількість розбиттів: n = {n}");
            
            // Обчислення методом середніх прямокутників
            double midpointResult = NumericalIntegration.MidpointRectangleMethod(a, b, n);
            double midpointError = Math.Abs(midpointResult - exactValue);
            
            Console.WriteLine($"Метод середніх прямокутників:");
            Console.WriteLine($"Результат: {midpointResult:F6}");
            Console.WriteLine($"Похибка: {midpointError:E3}");
            
            // Обчислення методом трапецій
            double trapezoidalResult = NumericalIntegration.TrapezoidalMethod(a, b, n);
            double trapezoidalError = Math.Abs(trapezoidalResult - exactValue);
            
            Console.WriteLine($"\nМетод трапецій:");
            Console.WriteLine($"Результат: {trapezoidalResult:F6}");
            Console.WriteLine($"Похибка: {trapezoidalError:E3}");
        }
    }
}