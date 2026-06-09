using System;

public class Nodo
{
    public int ID { get; set; }
    public string Dato { get; set; } = string.Empty;

    public Nodo? HijoIzquierdo { get; set; }
    public Nodo? HijoDerecho { get; set; }

    public Nodo(int id, string dato)
    {
        ID = id;
        Dato = dato;
    }
}