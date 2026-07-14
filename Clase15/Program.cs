using System;
using System.Diagnostics;

class Program
{
    // ============================================================
    // GENERADOR DE DATOS: Crea un arreglo ordenado de matrículas
    // ============================================================
    static int[] GenerarMatriculas(int cantidad)
    {
        int[] matriculas = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            matriculas[i] = i + 1; // 1, 2, 3, ..., 10000
        }
        return matriculas;
    }

    // ============================================================
    // BÚSQUEDA LINEAL: O(n) - Recorre elemento por elemento
    // ============================================================
    static int BusquedaLineal(int[] arr, int objetivo, out int iteraciones)
    {
        iteraciones = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            iteraciones++;
            if (arr[i] == objetivo)
                return i; // Encontrado en índice i
        }
        return -1; // No encontrado
    }

    // ============================================================
    // BÚSQUEDA BINARIA: O(log n) - Divide y vencerás
    // ============================================================
    static int BusquedaBinaria(int[] arr, int objetivo, out int iteraciones)
    {
        iteraciones = 0;
        int izquierda = 0;
        int derecha = arr.Length - 1;

        while (izquierda <= derecha)
        {
            iteraciones++;
            
            // Cálculo seguro del centro (evita desbordamiento)
            int centro = izquierda + (derecha - izquierda) / 2;

            if (arr[centro] == objetivo)
                return centro; // ¡Encontrado!

            if (arr[centro] < objetivo)
                izquierda = centro + 1; // Descarta mitad izquierda
            else
                derecha = centro - 1;   // Descarta mitad derecha
        }

        return -1; // No encontrado
    }

    // ============================================================
    // MAIN: Orquestador y banco de pruebas
    // ============================================================
    static void Main(string[] args)
    {
        // Configuración
        const int CANTIDAD = 10000;
        int[] matriculas = GenerarMatriculas(CANTIDAD);

        Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     MOTOR DE BÚSQUEDA DE MATRÍCULAS - UNITEC                ║");
        Console.WriteLine("║     Algoritmos: Lineal O(n) vs Binaria O(log n)             ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
        Console.WriteLine();

        // Solicitar matrícula al usuario
        Console.Write("Ingresa la matrícula a buscar: ");
        string entrada = Console.ReadLine();

        // Validar entrada
        if (!int.TryParse(entrada, out int objetivo))
        {
            Console.WriteLine("\n❌ Error: Ingresa un número válido.");
            return;
        }

        // Variables para contar iteraciones
        int iterLineal, iterBinaria;

        // Medir tiempo de búsqueda lineal
        var swLineal = Stopwatch.StartNew();
        int idxLineal = BusquedaLineal(matriculas, objetivo, out iterLineal);
        swLineal.Stop();

        // Medir tiempo de búsqueda binaria
        var swBinaria = Stopwatch.StartNew();
        int idxBinaria = BusquedaBinaria(matriculas, objetivo, out iterBinaria);
        swBinaria.Stop();

        // ============================================================
        // REPORTE COMPARATIVO
        // ============================================================
        Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
        Console.WriteLine("                    REPORTE DE BÚSQUEDA");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"Tamaño del arreglo:      {matriculas.Length:N0} elementos");
        Console.WriteLine($"Matrícula objetivo:      {objetivo}");
        Console.WriteLine();

        // Resultado Búsqueda Lineal
        Console.WriteLine("┌─ BÚSQUEDA LINEAL [O(n)] ─────────────────────────────────────┐");
        if (idxLineal != -1)
            Console.WriteLine($"│  ✓ Encontrado en índice: {idxLineal}");
        else
            Console.WriteLine($"│  ✗ No encontrado.");
        Console.WriteLine($"│  Iteraciones realizadas: {iterLineal:N0}");
        Console.WriteLine($"│  Tiempo transcurrido:    {swLineal.Elapsed.TotalMicroseconds:F2} µs");
        Console.WriteLine("└──────────────────────────────────────────────────────────────┘");

        // Resultado Búsqueda Binaria
        Console.WriteLine();
        Console.WriteLine("┌─ BÚSQUEDA BINARIA [O(log n)] ────────────────────────────────┐");
        if (idxBinaria != -1)
            Console.WriteLine($"│  ✓ Encontrado en índice: {idxBinaria}");
        else
            Console.WriteLine($"│  ✗ No encontrado.");
        Console.WriteLine($"│  Iteraciones realizadas: {iterBinaria:N0}");
        Console.WriteLine($"│  Tiempo transcurrido:    {swBinaria.Elapsed.TotalMicroseconds:F2} µs");
        Console.WriteLine("└──────────────────────────────────────────────────────────────┘");

        // Validación cruzada
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("                    VALIDACIÓN CRUZADA");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        if (idxLineal == idxBinaria)
            Console.WriteLine("✓ Ambos algoritmos coinciden en el resultado.");
        else
            Console.WriteLine("⚠ ALERTA: Los algoritmos difieren. Revisar implementación.");

        // Observaciones
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("                    OBSERVACIONES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("• La búsqueda lineal revisa elemento por elemento.");
        Console.WriteLine("• La búsqueda binaria divide el espacio a la mitad cada vez.");
        Console.WriteLine("• Para 10,000 elementos: Lineal ≈ 10,000 iteraciones máximo");
        Console.WriteLine("                         Binaria ≈ 14 iteraciones máximo");
        Console.WriteLine("• La binaria REQUIERE que el arreglo esté ordenado.");
        Console.WriteLine();

        // Prueba con caso límite (último elemento)
        if (objetivo != CANTIDAD)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("              PRUEBA CON CASO LÍMITE: ÚLTIMO ELEMENTO");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            
            int ultimo = CANTIDAD;
            int iterL, iterB;
            
            BusquedaLineal(matriculas, ultimo, out iterL);
            BusquedaBinaria(matriculas, ultimo, out iterB);
            
            Console.WriteLine($"Buscando matrícula {ultimo}:");
            Console.WriteLine($"  Lineal:  {iterL:N0} iteraciones");
            Console.WriteLine($"  Binaria: {iterB:N0} iteraciones");
            Console.WriteLine($"  Diferencia: {iterL - iterB:N0} iteraciones ahorradas");
        }

        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}