using System;

class Program
{
    // Función para cambiar un valor entero
    static void CambiarValor(int x)
    {
        x = 100;
        Console.WriteLine("Dentro de CambiarValor: " + x);
    }

    // Función para cambiar un arreglo
    static void CambiarReferencia(int[] arr)
    {
        arr[0] = 100;
        Console.WriteLine("Dentro de CambiarReferencia: " + arr[0]);
    }

    static void Main()
    {
        int numero = 5;
        int[] arreglo = { 1, 2, 3 };

        Console.WriteLine("ANTES");

        Console.WriteLine("Numero: " + numero);
        Console.WriteLine("Arreglo[0]: " + arreglo[0]);

        // Llamar funciones
        CambiarValor(numero);
        CambiarReferencia(arreglo);

        Console.WriteLine("\nDESPUÉS");

        Console.WriteLine("Numero: " + numero);
        Console.WriteLine("Arreglo[0]: " + arreglo[0]);
    }
}