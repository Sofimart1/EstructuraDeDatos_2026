using System;

namespace FactorialDesbordamiento
{
    /// <summary>
    /// Entregable Bimestral 8: Factorial y Gestión de Desbordamiento de Datos
    /// UNITEC - Estructura de Datos
    /// 
    /// Objetivos cumplidos:
    /// 1. Implementar versiones iterativa y recursiva con int
    /// 2. Diagnosticar el punto de quiebre (n=13, overflow silencioso)
    /// 3. Refactorizar con BigInteger para precisión arbitraria
    /// 4. Demostrar 100! con 158 dígitos correctos
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  ENTREGABLE BIMESTRAL 8                                      ║");
            Console.WriteLine("║  Factorial y Gestión de Desbordamiento de Datos              ║");
            Console.WriteLine("║  UNITEC - Estructura de Datos | C# Moderno                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // PARTE A: Implementación tradicional y diagnóstico del punto de quiebre
            Diagnostico.EjecutarComparacion();

            Console.WriteLine("Presiona cualquier tecla para ver la solución profesional...");
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine();

            // PARTE B: Refactorización profesional con BigInteger
            Diagnostico.DemostracionBigInteger();

            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  CONCLUSIONES");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("• int (32 bits) falla silenciosamente a partir de n=13");
            Console.WriteLine("• El desbordamiento es 'wraparound': el valor da la vuelta");
            Console.WriteLine("• C# en modo unchecked no lanza excepción → error invisible");
            Console.WriteLine("• BigInteger resuelve el problema con precisión arbitraria");
            Console.WriteLine("• BigInteger aloja datos en el Heap, no en el Stack");
            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey(true);
        }
    }
}
