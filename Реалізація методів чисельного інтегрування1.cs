using System;

class NumericalIntegration
{
    // Функція f(x) = x² + 2x + 1
    public static double Function(double x)
    {
        return x * x + 2 * x + 1;
    }

    public static double ExactIntegralValue()
    {
        return 7.0 / 3.0; 

    public static double MidpointRectangleMethod(double a, double b, int n)
    {
        double h = (b - a) / n;
        double sum = 0.0;
        
        for (int i = 0; i < n; i++)
        {
            double x_mid = a + (i + 0.5) * h;
            sum += Function(x_mid);
        }
        
        return sum * h;
    }

    public static double TrapezoidalMethod(double a, double b, int n)
    {
        double h = (b - a) / n;
        double sum = (Function(a) + Function(b)) / 2.0;
        
        for (int i = 1; i < n; i++)
        {
            double x = a + i * h;
            sum += Function(x);
        }
        
        return sum * h;
    }
}