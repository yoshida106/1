class Program
{
    static void Main(string[] args)
    {
        // Підготовка даних
        double[] xValues = { -4, -2, 0, 2, 4 };
        double[] yValues = { -37, -1, 11, -1, -37 };

        // 1. Обчислення скінчених різниць
        Console.WriteLine("1. Скінчені різниці:");
        double[] finiteDifferences = NewtonInterpolation.CalculateFiniteDifferences(xValues, yValues);
        for (int i = 0; i < finiteDifferences.Length; i++)
        {
            Console.WriteLine($"Δ^{i}f(x0) = {finiteDifferences[i]}");
        }

        // 2. Обчислення розділених різниць
        Console.WriteLine("\n2. Розділені різниці:");
        double[] dividedDifferences = NewtonInterpolation.CalculateDividedDifferences(xValues, yValues);
        for (int i = 0; i < dividedDifferences.Length; i++)
        {
            Console.WriteLine($"f[x0..x{i}] = {dividedDifferences[i]}");
        }

        // 3. Інтерполяція для рівномірних вузлів
        Console.WriteLine("\n3. Інтерполяція (рівномірні вузли):");
        TestInterpolation((x) => NewtonInterpolation.NewtonUniform(
            x, xValues, finiteDifferences));

        // 4. Інтерполяція для нерівномірних вузлів
        Console.WriteLine("\n4. Інтерполяція (нерівномірні вузли):");
        TestInterpolation((x) => NewtonInterpolation.NewtonNonUniform(
            x, xValues, dividedDifferences));
    }

    static void TestInterpolation(Func<double, double> interpolator)
    {
        // Тестові точки для перевірки
        double[] testPoints = { -3, -1, 1, 3 };

        foreach (double x in testPoints)
        {
            double interpolatedValue = interpolator(x);
            Console.WriteLine($"f({x}) ≈ {interpolatedValue:F4}");
        }

        // Перевірка в вузлах інтерполяції
        Console.WriteLine("\nПеревірка в вузлах:");
        foreach (var point in NewtonInterpolation.TableData)
        {
            double interpolatedValue = interpolator(point.Key);
            Console.WriteLine($"f({point.Key}) = {point.Value}, P({point.Key}) = {interpolatedValue}");
        }
    }
}