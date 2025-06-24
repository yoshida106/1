using System;
using System.Collections.Generic;

class NewtonInterpolation
{
    // Табличні дані для тестування
    public static Dictionary<double, double> TableData = new Dictionary<double, double>
    {
        {-4, -37},
        {-2, -1},
        {0, 11},
        {2, -1},
        {4, -37}
    };

    // Функція для обчислення факторіалу
    private static int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }

    // Метод для обчислення скінчених різниць
    public static double[] CalculateFiniteDifferences(double[] x, double[] y)
    {
        int n = x.Length;
        double[] differences = new double[n];
        Array.Copy(y, differences, n);

        for (int i = 1; i < n; i++)
        {
            for (int j = n - 1; j >= i; j--)
            {
                differences[j] = differences[j] - differences[j - 1];
            }
        }

        return differences;
    }

    // Метод для обчислення розділених різниць
    public static double[] CalculateDividedDifferences(double[] x, double[] y)
    {
        int n = x.Length;
        double[] differences = new double[n];
        Array.Copy(y, differences, n);

        for (int i = 1; i < n; i++)
        {
            for (int j = n - 1; j >= i; j--)
            {
                differences[j] = (differences[j] - differences[j - 1]) / (x[j] - x[j - i]);
            }
        }

        return differences;
    }

    // Інтерполяційний многочлен Ньютона для рівномірних вузлів
    public static double NewtonUniform(double x, double[] xValues, double[] finiteDifferences)
    {
        double h = xValues[1] - xValues[0];
        double t = (x - xValues[0]) / h;
        double result = finiteDifferences[0];
        double term = 1.0;

        for (int i = 1; i < finiteDifferences.Length; i++)
        {
            term *= (t - (i - 1)) / i;
            result += term * finiteDifferences[i];
        }

        return result;
    }

    // Інтерполяційний многочлен Ньютона для нерівномірних вузлів
    public static double NewtonNonUniform(double x, double[] xValues, double[] dividedDifferences)
    {
        double result = dividedDifferences[0];
        double term = 1.0;

        for (int i = 1; i < dividedDifferences.Length; i++)
        {
            term *= (x - xValues[i - 1]);
            result += term * dividedDifferences[i];
        }

        return result;
    }
}