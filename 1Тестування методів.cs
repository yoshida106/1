class Program
{
    static void Main(string[] args)
    {
        // Приклад системи рівнянь:
        // 4x1 +  x2 -  x3 = 5
        //  x1 + 3x2 +  x3 = 6
        //  x1 - 2x2 + 5x3 = 7
        
        double[,] matrix = {
            { 4,  1, -1 },
            { 1,  3,  1 },
            { 1, -2,  5 }
        };
        
        double[] vector = { 5, 6, 7 };
        
        Console.WriteLine("Метод Гауса:");
        double[] gaussSolution = LinearSystems.GaussMethod((double[,])matrix.Clone(), (double[])vector.Clone());
        Console.WriteLine("\nОстаточний розв'язок:");
        Console.WriteLine($"x1 = {gaussSolution[0]:F6}, x2 = {gaussSolution[1]:F6}, x3 = {gaussSolution[2]:F6}");
        
        Console.WriteLine("\n----------------------------------------\n");
        
        Console.WriteLine("Метод простих ітерацій (ε = 1e-6):");
        double[] iterationSolution = LinearSystems.SimpleIterationMethod(matrix, vector, 1e-6);
        Console.WriteLine("\nОстаточний розв'язок:");
        Console.WriteLine($"x1 = {iterationSolution[0]:F6}, x2 = {iterationSolution[1]:F6}, x3 = {iterationSolution[2]:F6}");
    }
}