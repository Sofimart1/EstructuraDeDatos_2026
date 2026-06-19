using System;

namespace SimuladorCallStack
{
    /// <summary>
    /// Clase que contiene los métodos recursivos para simular 
    /// el comportamiento del Call Stack en la memoria RAM.
    /// </summary>
    public static class SimuladorStack
    {
        // ============================================================
        // EJERCICIO A: Cuenta Regresiva de Memoria
        // ============================================================
        
        /// <summary>
        /// Imprime una cuenta regresiva visualizando el comportamiento LIFO del Stack.
        /// 
        /// FASE DE APILADO: Muestra mensajes [APILANDO] en orden descendente (3, 2, 1)
        /// FASE DE RETORNO: Muestra mensajes [LIBERANDO] en orden ascendente (1, 2, 3)
        /// 
        /// CASO BASE: numero <= 0 (detiene la recursión)
        /// CASO RECURSIVO: llamada con numero - 1 (se acerca al caso base)
        /// </summary>
        public static void ImprimirCuentaRegresiva(int numero)
        {
            // ========== CASO BASE ==========
            // Condición de salida: cuando llegamos a 0 o menos, detenemos la recursión
            if (numero <= 0)
            {
                Console.WriteLine("🚀 ¡Despegue! Caso base alcanzado.");
                return; // Retorna sin llamarse a sí misma
            }

            // ========== FASE DE APILADO ==========
            // Este código se ejecuta DURANTE la fase de invocación (antes de la llamada recursiva)
            // Los mensajes aparecen en orden DESCENDENTE: 3, 2, 1
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[APILANDO] Marco de activación creado para número = {numero}");
            Console.WriteLine($"           Stack crece → Profundidad actual: {numero}");
            Console.ResetColor();

            // ========== LLAMADA RECURSIVA ==========
            // La función se llama a sí misma con un argumento más pequeño (numero - 1)
            // Esto garantiza que eventualmente alcanzaremos el caso base
            ImprimirCuentaRegresiva(numero - 1);

            // ========== FASE DE RETORNO ==========
            // Este código se ejecuta DESPUÉS de que la llamada recursiva regresa
            // Los mensajes aparecen en orden ASCENDENTE: 1, 2, 3 (efecto LIFO)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LIBERANDO] Marco de activación liberado para número = {numero}");
            Console.WriteLine($"            Stack decrece ← Memoria liberada");
            Console.ResetColor();
        }

        // ============================================================
        // EJERCICIO B: Sumatoria Recursiva con Validación
        // ============================================================

        /// <summary>
        /// Calcula la suma acumulativa de 1 hasta n de forma recursiva.
        /// 
        /// Fórmula: SumarHasta(n) = n + SumarHasta(n-1)
        /// Ejemplo: SumarHasta(4) = 4 + 3 + 2 + 1 = 10
        /// 
        /// CASO BASE: n == 1 (la suma de 1 número es 1)
        /// CASO RECURSIVO: n + SumarHasta(n - 1)
        /// </summary>
        /// <param name="n">Número hasta el cual sumar (debe ser positivo)</param>
        /// <returns>La suma de todos los enteros desde 1 hasta n</returns>
        public static int SumarHasta(int n)
        {
            // ========== CASO BASE ==========
            // La suma de 1 número (el 1) es 1. Aquí nos detenemos.
            if (n == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  [BASE] SumarHasta(1) retorna 1");
                Console.ResetColor();
                return 1;
            }

            // ========== FASE DE APILADO ==========
            // Visualizamos que estamos apilando un nuevo marco
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[APILANDO] SumarHasta({n}) espera: {n} + SumarHasta({n - 1})");
            Console.ResetColor();

            // ========== CASO RECURSIVO ==========
            // Llamamos a la función con un problema más pequeño (n - 1)
            int resultadoParcial = SumarHasta(n - 1);

            // ========== FASE DE RETORNO ==========
            // Combinamos el resultado recibido con la operación actual
            int resultado = n + resultadoParcial;
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LIBERANDO] SumarHasta({n}) retorna: {n} + {resultadoParcial} = {resultado}");
            Console.ResetColor();

            return resultado;
        }

        /// <summary>
        /// Versión con profundidad visible para la extensión opcional del Ejercicio A.
        /// Muestra el nivel actual del stack en cada llamada.
        /// </summary>
        public static void ImprimirCuentaRegresivaConProfundidad(int numero, int profundidad = 1)
        {
            // CASO BASE
            if (numero <= 0)
            {
                Console.WriteLine($"🚀 ¡Despegue! (Profundidad máxima alcanzada: {profundidad - 1})");
                return;
            }

            // FASE DE APILADO con profundidad
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[APILANDO] Nivel {profundidad}: número = {numero}");
            Console.ResetColor();

            // LLAMADA RECURSIVA (profundidad incrementa)
            ImprimirCuentaRegresivaConProfundidad(numero - 1, profundidad + 1);

            // FASE DE RETORNO
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LIBERANDO] Nivel {profundidad}: número = {numero}");
            Console.ResetColor();
        }
    }
}
