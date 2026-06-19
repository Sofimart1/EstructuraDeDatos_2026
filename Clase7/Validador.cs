using System;

namespace SimuladorCallStack
{
    /// <summary>
    /// Clase responsable de validar las entradas del usuario.
    /// Aplica el principio de "Validación en la Frontera".
    /// </summary>
    public static class Validador
    {
        /// <summary>
        /// Solicita un número entero positivo al usuario con validación robusta.
        /// Usa int.TryParse para evitar excepciones no controladas.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar al usuario</param>
        /// <returns>Un número entero mayor que 0</returns>
        public static int SolicitarNumeroPositivo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                // Validación profesional: TryParse + verificación de rango
                if (int.TryParse(entrada, out int numero) && numero > 0)
                {
                    return numero;
                }

                // Mensaje de error en rojo (requisito del ejercicio)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo se aceptan enteros positivos.");
                Console.ResetColor();
                Console.WriteLine("Inténtalo de nuevo.\n");
            }
        }

        /// <summary>
        /// Solicita cualquier número entero (positivo, negativo o cero).
        /// Para el Ejercicio A que puede aceptar cualquier valor para demostrar el stack.
        /// </summary>
        public static int SolicitarEntero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int numero))
                {
                    return numero;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Debes introducir un número entero válido.");
                Console.ResetColor();
            }
        }
    }
} 
