using System;

class LinearSystems
{
    // Метод Гауса для розв'язання СЛАР
    public static double[] GaussMethod(double[,] matrix, double[] vector)
    {
        int n = vector.Length;
        
        // Прямий хід (елімінація)
        for (int k = 0; k < n - 1; k++)
        {
            // Виведення проміжного стану
            Console.WriteLine($"\nЕтап {k + 1}: Прямий хід (елімінація для рядка {k + 1})");
            PrintMatrix(matrix, vector);
            
            for (int i = k + 1; i < n; i++)
            {
                double factor = matrix[i, k] / matrix[k, k];
                for (int j = k; j < n; j++)
                {
                    matrix[i, j] -= factor * matrix[k, j];
                }
                vector[i] -= factor * vector[k];
            }
        }
        
        // Виведення матриці після прямого ходу
        Console.WriteLine("\nМатриця після прямого ходу:");
        PrintMatrix(matrix, vector);
        
        // Зворотній хід
        double[] solution = new double[n];
        for (int i = n - 1; i >= 0; i--)
        {
            double sum = 0;
            for (int j = i + 1; j < n; j++)
            {
                sum += matrix[i, j] * solution[j];
            }
            solution[i] = (vector[i] - sum) / matrix[i, i];
            
            // Виведення проміжного результату
            Console.WriteLine($"\nЗворотній хід: x[{i + 1}] = {solution[i]}");
        }
        
        return solution;
    }
    
    // Допоміжна функція для виведення матриці
    private static void PrintMatrix(double[,] matrix, double[] vector)
    {
        int n = vector.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],10:F4}");
            }
            Console.WriteLine($" | {vector[i],10:F4}");
        }
    }