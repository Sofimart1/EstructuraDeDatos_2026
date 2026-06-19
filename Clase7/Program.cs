using System;

namespace SimuladorCallStack
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// Coordina la ejecución de los dos ejercicios de simulación del Call Stack.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗══╗");
            Console.WriteLine("║     SIMULADOR DEL CALL STACK - Estructura de Datos         ║");
            Console.WriteLine("║     UNITEC | Clase 7: Lógica de Recursividad               ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // ============================================================
            // EJERCICIO A: Cuenta Regresiva de Memoria
            // ============================================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  EJERCICIO A: Cuenta Regresiva de Memoria");
            Console.WriteLine("  Objetivo: Visualizar el efecto LIFO del Call Stack");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            int numeroA = Validador.SolicitarNumeroPositivo("Introduce un número para la cuenta regresiva: ");
            
            Console.WriteLine();
            Console.WriteLine(">>> INICIANDO FASE DE APILADO (Invocación) <<<");
            Console.WriteLine("    Los marcos se crean en orden descendente...");
            Console.WriteLine();

            SimuladorStack.ImprimirCuentaRegresiva(numeroA);

            Console.WriteLine();
            Console.WriteLine(">>> FIN DE LA EJECUCIÓN <<<");
            Console.WriteLine("    Observa cómo los mensajes [LIBERANDO] aparecen en orden");
            Console.WriteLine("    inverso a los [APILANDO] → Principio LIFO");
            Console.WriteLine();

            // Pregunta si quiere ver la versión con profundidad (extensión opcional)
            Console.Write("¿Deseas ver la versión con nivel de profundidad? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.WriteLine();
                Console.WriteLine("--- VERSIÓN CON PROFUNDIDAD ---");
                SimuladorStack.ImprimirCuentaRegresivaConProfundidad(numeroA);
            }

            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para continuar al Ejercicio B...");
            Console.ReadKey(true);
            Console.Clear();

            // ============================================================
            // EJERCICIO B: Sumatoria Recursiva con Validación
            // ============================================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  EJERCICIO B: Sumatoria Recursiva con Validación Profesional");
            Console.WriteLine("  Objetivo: Calcular suma acumulativa con manejo de errores");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            // Demostración con entrada válida
            int numeroB = Validador.SolicitarNumeroPositivo("Introduce un número positivo para sumar: ");
            
            Console.WriteLine();
            Console.WriteLine(">>> TRAZA DE EJECUCIÓN DE SumarHasta(" + numeroB + ") <<<");
            Console.WriteLine();

            int resultado = SimuladorStack.SumarHasta(numeroB);

            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine($"  RESULTADO FINAL: La suma de 1 hasta {numeroB} es: {resultado}");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");

            // Verificación matemática (fórmula de Gauss)
            int verificacion = numeroB * (numeroB + 1) / 2;
            Console.WriteLine($"  Verificación con fórmula de Gauss n(n+1)/2: {verificacion}");
            Console.WriteLine($"  ¿Coinciden? {(resultado == verificacion ? "✅ SÍ" : "❌ NO")}");
            Console.WriteLine();

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey(true);
        }
    }
}

