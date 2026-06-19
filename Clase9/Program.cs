using System;
using System.Diagnostics;

namespace OptimizacionFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  CLASE 9: Optimización Algorítmica Avanzada                  ║");
            Console.WriteLine("║  Recursividad vs. Memoization — Fibonacci en C#              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Documentación del árbol de llamadas de F(5)
            MostrarArbolLlamadas();

            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para continuar al benchmark...");
            Console.ReadKey(true);
            Console.Clear();

            // Solicitar entrada con validación robusta
            Console.Write("Ingresa un número (35-43 recomendado): ");
            string input = Console.ReadLine();

            // Validación: int.TryParse + verificación de rango
            if (!int.TryParse(input, out int n) || n < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: ingresa un número positivo.");
                Console.ResetColor();
                return;
            }

            // Advertencia para valores muy grandes con método inseguro
            if (n > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Advertencia: valores > 50 pueden tardar días con el método inseguro.");
                Console.ResetColor();
            }

            Console.WriteLine();

            // Ejecutar benchmark comparativo
            EjecutarBenchmark(n);

            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Muestra la estructura del árbol de llamadas redundantes para F(5).
        /// </summary>
        static void MostrarArbolLlamadas()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ÁRBOL DE LLAMADAS REDUNDANTES: F(5)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("                    F(5)");
            Console.WriteLine("                   /    \\");
            Console.WriteLine("                F(4)    F(3)");
            Console.WriteLine("               /  \\     /  \\");
            Console.WriteLine("            F(3) F(2) F(2) F(1)");
            Console.WriteLine("           /  \\   |     |");
            Console.WriteLine("        F(2) F(1) [●]   [●]");
            Console.WriteLine("        /  \\");
            Console.WriteLine("      F(1) F(0)");
            Console.WriteLine();
            Console.WriteLine("  [●] = Subproblemas repetidos");
            Console.WriteLine("  F(2) aparece 3 veces. F(3) aparece 2 veces.");
            Console.WriteLine("  Cada ejecución redundante es trabajo desperdiciado por la CPU.");
            Console.WriteLine();
            Console.WriteLine("  COMPLEJIDAD: O(2ⁿ) — el árbol crece exponencialmente.");
            Console.WriteLine("  F(50) requiere ~10¹⁵ llamadas (más de 13 días en CPU moderna).");
        }

        /// <summary>
        /// Ejecuta la comparativa de rendimiento entre ambos métodos.
        /// </summary>
        static void EjecutarBenchmark(int n)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine($"  BENCHMARK: Comparativa de Rendimiento para F({n})");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            // --- Método Inseguro (fuerza bruta) ---
            Console.WriteLine("--- Método Inseguro (O(2ⁿ)) ---");
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            long resultadoInseguro = FibonacciInseguro(n);
            sw.Stop();

            long tiempoInseguro = sw.ElapsedMilliseconds;

            Console.WriteLine($"Resultado: F({n}) = {resultadoInseguro}");
            Console.WriteLine($"Tiempo: {tiempoInseguro} ms");
            Console.WriteLine();

            // --- Método Pro (Memoization) ---
            Console.WriteLine("--- Método Pro con Memoization (O(n)) ---");

            // Inicializar caché: arreglo de tamaño n+1, todo en -1 (centinela)
            long[] cache = new long[n + 1];
            for (int i = 0; i <= n; i++)
                cache[i] = -1;

            sw.Restart();
            long resultadoPro = FibonacciPro(n, cache);
            sw.Stop();

            long tiempoPro = sw.ElapsedMilliseconds;

            Console.WriteLine($"Resultado: F({n}) = {resultadoPro}");
            Console.WriteLine($"Tiempo: {tiempoPro} ms");
            Console.WriteLine();

            // --- Verificación y comparativa ---
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ANÁLISIS COMPARATIVO");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");

            bool resultadosIguales = resultadoInseguro == resultadoPro;
            Console.WriteLine($"Resultados idénticos: {(resultadosIguales ? "✅ SÍ" : "❌ NO")}");

            if (tiempoInseguro > 0 && tiempoPro >= 0)
            {
                double mejora = tiempoPro == 0 ? 
                    (double)tiempoInseguro : 
                    (double)tiempoInseguro / tiempoPro;
                Console.WriteLine($"Mejora de rendimiento: {mejora:F0}x más rápido");
            }

            Console.WriteLine();
            Console.WriteLine($"Inseguro: {tiempoInseguro} ms  vs  Pro: {tiempoPro} ms");
            Console.WriteLine();
            Console.WriteLine("El número retornado es idéntico; el costo para obtenerlo");
            Console.WriteLine("es radicalmente diferente. Memoization demuestra por qué");
            Console.WriteLine("los algoritmos eficientes son una necesidad de ingeniería.");
        }

        // ============================================================
        // MÓDULO A: Fibonacci Recursivo Tradicional (Fuerza Bruta)
        // ============================================================

        /// <summary>
        /// Fibonacci recursivo tradicional (fuerza bruta).
        /// Complejidad: O(2ⁿ) — cada llamada genera 2 llamadas adicionales.
        /// </summary>
        static long FibonacciInseguro(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
        }

        // ============================================================
        // MÓDULO B: Fibonacci con Memoization (Estrategia Pro)
        // ============================================================

        /// <summary>
        /// Fibonacci optimizado con Memoization (caché de datos).
        /// Complejidad: O(n) — cada valor se calcula exactamente una vez.
        /// </summary>
        /// <param name="n">Índice de Fibonacci a calcular</param>
        /// <param name="cache">Arreglo caché inicializado en -1 (centinela)</param>
        static long FibonacciPro(int n, long[] cache)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            // ¿Ya lo calculamos antes? Retorno inmediato desde el caché
            if (cache[n] != -1)
                return cache[n];

            // Calcular, guardar en caché y retornar
            cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
            return cache[n];
        }
    }
}