using System;

namespace Clase6Referencias
{
    class Alumno
    {
        public string Nombre { get; set; }
    }

    class Program
    {
        // Módulo 1
        static void Intercambiar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Módulo 2
        static int CalcularYValidar(int dividendo, int divisor, out int residuo)
        {
            residuo = dividendo % divisor;
            return dividendo / divisor;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== MÓDULO 1: REF ===");

            int x = 10;
            int y = 25;

            Console.WriteLine($"Antes: x = {x}, y = {y}");

            Intercambiar(ref x, ref y);

            Console.WriteLine($"Después: x = {x}, y = {y}");

            Console.WriteLine("\n=== MÓDULO 2: OUT ===");

            int cociente = CalcularYValidar(17, 5, out int residuo);

            Console.WriteLine($"Cociente: {cociente}");
            Console.WriteLine($"Residuo: {residuo}");

            Console.WriteLine("\n=== MÓDULO 3: REFERENCIAS ===");

            Alumno alumno1 = new Alumno
            {
                Nombre = "Dany"
            };

            Alumno alumno2 = alumno1;

            alumno2.Nombre = "3Treum";

            Console.WriteLine($"Alumno 1: {alumno1.Nombre}");
            Console.WriteLine($"Alumno 2: {alumno2.Nombre}");

            Console.WriteLine("\nObservación:");
            Console.WriteLine("Ambas variables apuntan al mismo objeto en memoria.");
        }
    }
}