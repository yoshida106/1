    // Метод простих ітерацій
    public static double[] SimpleIterationMethod(double[,] A, double[] b, double epsilon)
    {
        int n = b.Length;
        double[] x = new double[n];  // Поточне наближення
        double[] xNew = new double[n];  // Нове наближення
        int iteration = 0;
        double error;
        
        // Початкове наближення (можна взяти нульовий вектор)
        Array.Fill(x, 0);
        
        do
        {
            iteration++;
            
            // Обчислення нового наближення
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        sum += A[i, j] * x[j];
                    }
                }
                xNew[i] = (b[i] - sum) / A[i, i];
            }
            
            // Обчислення похибки
            error = 0;
            for (int i = 0; i < n; i++)
            {
                error = Math.Max(error, Math.Abs(xNew[i] - x[i]));
            }
            
            // Виведення проміжних результатів
            Console.WriteLine($"\nІтерація {iteration}:");
            Console.WriteLine($"x1 = {xNew[0]:F6}, x2 = {xNew[1]:F6}, x3 = {xNew[2]:F6}");
            Console.WriteLine($"Похибка: {error:E6}");
            
            // Оновлення поточного наближення
            Array.Copy(xNew, x, n);
            
        } while (error > epsilon && iteration < 1000);
        
        return x;
    }
}