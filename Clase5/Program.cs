using System;

class Program
{
    static void Main()
    {
        Nodo? raiz = new Nodo(10, "Raíz");

        raiz = ArbolBinario.InsertarNodo(raiz,
            new Nodo(5, "Izquierda"));

        raiz = ArbolBinario.InsertarNodo(raiz,
            new Nodo(15, "Derecha"));

        raiz = ArbolBinario.InsertarNodo(raiz,
            new Nodo(3, "Nodo 3"));

        raiz = ArbolBinario.InsertarNodo(raiz,
            new Nodo(7, "Nodo 7"));

        raiz = ArbolBinario.InsertarNodo(raiz,
            new Nodo(12, "Nodo 12"));

        raiz = ArbolBinario.InsertarNodo(raiz,
            new Nodo(20, "Nodo 20"));

        Console.WriteLine("Búsqueda del nodo con ID = 7");
        string? resultado =
            ArbolBinario.BuscarNodo(raiz, 7);

        Console.WriteLine(resultado ?? "No encontrado");

        Console.ReadKey();
    }
}