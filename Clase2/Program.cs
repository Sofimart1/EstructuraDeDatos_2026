using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Algoritmos Recursivos ===\n");

        // FACTORIAL
        Console.Write("Ingresa un número para calcular su factorial: ");

        if (int.TryParse(Console.ReadLine(), out int numFactorial))
        {
            try
            {
                long resultado = CalcularFactorial(numFactorial);

                Console.WriteLine($"{numFactorial}! = {resultado}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida.");
        }

        // FIBONACCI
        Console.Write("\nIngresa la posición de Fibonacci: ");

        if (int.TryParse(Console.ReadLine(), out int numFib))
        {
            try
            {
                long resultadoFib = GenerarFibonacci(numFib);

                Console.WriteLine($"Fibonacci({numFib}) = {resultadoFib}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida.");
        }
    }

    // FUNCIÓN FACTORIAL
    static long CalcularFactorial(int n)
    {
        // Validación
        if (n < 0)
        {
            throw new ArgumentException("No existe factorial de números negativos.");
        }

        // Caso base
        if (n == 0 || n == 1)
        {
            return 1;
        }

        // Caso recursivo
        return n * CalcularFactorial(n - 1);
    }

    // FUNCIÓN FIBONACCI
    static long GenerarFibonacci(int n)
    {
        // Validación
        if (n < 0)
        {
            throw new ArgumentException("El número no puede ser negativo.");
        }

        // Caso base 1
        if (n == 0)
        {
            return 0;
        }

        // Caso base 2
        if (n == 1)
        {
            return 1;
        }

        // Caso recursivo
        return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
    }
}