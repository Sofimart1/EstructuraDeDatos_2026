using System;

public class ArbolBinario
{
    public static Nodo? InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
    {
        if (raiz == null)
            return nuevoNodo;

        if (nuevoNodo.ID < raiz.ID)
        {
            raiz.HijoIzquierdo =
                InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
        }
        else if (nuevoNodo.ID > raiz.ID)
        {
            raiz.HijoDerecho =
                InsertarNodo(raiz.HijoDerecho, nuevoNodo);
        }

        return raiz;
    }

    public static string? BuscarNodo(Nodo? raiz, int idTarget)
    {
        if (raiz == null)
            return null;

        if (idTarget == raiz.ID)
            return raiz.Dato;

        if (idTarget < raiz.ID)
            return BuscarNodo(raiz.HijoIzquierdo, idTarget);

        return BuscarNodo(raiz.HijoDerecho, idTarget);
    }
}