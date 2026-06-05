using System;

class Program
{
    static void Main()
    {
        int lados = SeleccionarPoligono();

        double lado = PedirDatoPositivo("Ingresa la medida del lado: ");
        double apotema = PedirDatoPositivo("Ingresa la apotema: ");

        double area = CalcularArea(lados, lado, apotema);

        Console.WriteLine($"\nEl área del polígono es: {area}");
    }

    static int SeleccionarPoligono()
    {
        Console.WriteLine("Selecciona un polígono:");
        Console.WriteLine("1. Pentágono");
        Console.WriteLine("2. Hexágono");
        Console.WriteLine("3. Heptágono");

        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                return 5;
            case 2:
                return 6;
            case 3:
                return 7;
            default:
                Console.WriteLine("Opción inválida.");
                return SeleccionarPoligono();
        }
    }

    static double PedirDatoPositivo(string mensaje)
    {
        double numero;

        do
        {
            Console.Write(mensaje);
        }
        while (!double.TryParse(Console.ReadLine(), out numero) || numero <= 0);

        return numero;
    }

    static double CalcularArea(int lados, double lado, double apotema)
    {
        double perimetro = lados * lado;
        return (perimetro * apotema) / 2;
    }
}