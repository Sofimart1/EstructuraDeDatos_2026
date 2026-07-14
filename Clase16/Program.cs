using System;

class Program
{
    // ============================================================
    // MÓDULO 1: Generador de calificaciones aleatorias
    // ============================================================
    static int[] GenerarCalificaciones(int cantidad)
    {
        int[] calificaciones = new int[cantidad];
        Random rng = new Random();

        for (int i = 0; i < cantidad; i++)
        {
            calificaciones[i] = rng.Next(0, 101); // 0 a 100 inclusive
        }

        return calificaciones;
    }

    // ============================================================
    // MÓDULO 2: Bubble Sort con contador de intercambios
    // ============================================================
    static int OrdenarPorBurbuja(int[] arr)
    {
        int intercambios = 0;
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false; // Bandera de optimización

            for (int j = 0; j < n - i - 1; j++)
            {
                // Compara elementos vecinos
                if (arr[j] > arr[j + 1])
                {
                    // Intercambio usando tupla (C# moderno)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    
                    intercambios++;
                    swapped = true;
                }
            }

            // Si no hubo intercambios, el arreglo ya está ordenado
            if (!swapped)
                break;
        }

        return intercambios;
    }

    // ============================================================
    // MÓDULO AUXILIAR: Imprimir arreglo
    // ============================================================
    static void ImprimirArreglo(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }

    // ============================================================
    // MÓDULO 3: Banco de pruebas con manejo de errores
    // ============================================================
    static void Main(string[] args)
    {
        try
        {
            // Generar 100 calificaciones aleatorias
            int[] calificaciones = GenerarCalificaciones(100);

            // Mostrar estado inicial
            Console.WriteLine("=== Estado inicial: calificaciones desordenadas ===");
            ImprimirArreglo(calificaciones);

            // Ejecutar Bubble Sort y contar intercambios
            int totalIntercambios = OrdenarPorBurbuja(calificaciones);

            // Mostrar estado final
            Console.WriteLine("\n=== Estado final: calificaciones ordenadas (menor a mayor) ===");
            ImprimirArreglo(calificaciones);

            // Mostrar contador de intercambios
            Console.WriteLine($"\n>>> Total de intercambios realizados: {totalIntercambios}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"[ERROR] Índice fuera de rango detectado: {ex.Message}");
            Console.WriteLine("Revisa los límites de tus ciclos for anidados.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR inesperado]: {ex.Message}");
        }
    }
}