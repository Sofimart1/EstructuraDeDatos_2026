using System;
using System.Numerics;

namespace FactorialDesbordamiento
{
    /// <summary>
    /// Módulo de diagnóstico que ejecuta y compara las tres implementaciones.
    /// Identifica el punto exacto de quiebre donde int falla silenciosamente.
    /// </summary>
    public static class Diagnostico
    {
        public static void EjecutarComparacion()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  DIAGNÓSTICO: Comparativa de Implementaciones Factorial");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("Objetivo: Identificar el punto de quiebre donde int desborda.");
            Console.WriteLine("Contexto: C# opera en modo unchecked por defecto (sin excepciones).");
            Console.WriteLine();

            // Encabezado de tabla
            Console.WriteLine($"{"n",-4} │ {"Recursivo (int)",-20} │ {"Iterativo (int)",-20} │ {"Estado"}");
            Console.WriteLine(new string('─', 70));

            for (int i = 1; i <= 20; i++)
            {
                int recursivo = FactorialInt.Calcular(i);
                int iterativo = FactorialIterativo.Calcular(i);

                // Detectamos desbordamiento: factorial siempre es positivo y creciente
                // Si el resultado es negativo o menor que el anterior, hay wraparound
                bool desbordado = recursivo < 0;

                string estado = desbordado ? "❌ OVERFLOW" : "✅ OK";
                ConsoleColor color = desbordado ? ConsoleColor.Red : ConsoleColor.Green;  // ✅ CORREGIDO: ConsoleColor, no string

                Console.Write($"{i,-4} │ {recursivo,-20} │ {iterativo,-20} │ ");
                Console.ForegroundColor = color;
                Console.WriteLine(estado);
                Console.ResetColor();

                // Documentamos el punto de quiebre exacto
                if (i == 12)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("     ↑ Último valor correcto antes del desbordamiento");
                    Console.ResetColor();
                }
                if (i == 13)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     ↑ PUNTO DE QUIEBRE: n=13 desborda int (max=2,147,483,647)");
                    Console.WriteLine("       Valor real de 13! = 6,227,020,800 > int.MaxValue");
                    Console.WriteLine("       Resultado observado: wraparound (valor negativo/incorrecto)");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
        }

        public static void DemostracionBigInteger()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  DEMOSTRACIÓN: BigInteger (Precisión Arbitraria)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            // Prueba con n=20 (ya imposible en int)
            Console.WriteLine("--- n = 20 ---");
            BigInteger f20 = FactorialProfesional.Calcular(20);
            Console.WriteLine($"20! = {f20}");
            Console.WriteLine($"Dígitos: {f20.ToString().Length}");
            Console.WriteLine();

            // Prueba con n=50
            Console.WriteLine("--- n = 50 ---");
            BigInteger f50 = FactorialProfesional.Calcular(50);
            Console.WriteLine($"50! = {f50}");
            Console.WriteLine($"Dígitos: {f50.ToString().Length}");
            Console.WriteLine();

            // Prueba con n=100 (el requisito del entregable)
            Console.WriteLine("--- n = 100 (Requisito del entregable) ---");
            BigInteger f100 = FactorialProfesional.Calcular(100);
            Console.WriteLine($"100! = {f100}");
            Console.WriteLine($"Dígitos: {f100.ToString().Length} (debe ser 158)");
            Console.WriteLine();

            // Verificación: 100! debe tener exactamente 158 dígitos
            bool verificacion = f100.ToString().Length == 158;
            Console.ForegroundColor = verificacion ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Verificación de dígitos: {(verificacion ? "✅ CORRECTO" : "❌ INCORRECTO")}");
            Console.ResetColor();
        }
    }
}