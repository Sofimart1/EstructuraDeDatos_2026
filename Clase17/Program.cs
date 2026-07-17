using System;

namespace OptimizadorBitacoras
{
    public struct Transaccion
    {
        public int Id;
        public double Monto;
        public long Timestamp;

        public Transaccion(int id, double monto, long timestamp)
        {
            Id = id;
            Monto = monto;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"ID:{Id,4} | Monto:{Monto,10:F2} | Timestamp:{Timestamp}";
        }
    }

    class Program
    {
        static long totalComparaciones = 0;
        static long totalDesplazamientos = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("  OPTIMIZADOR DE BITACORAS - INSERTION SORT");
            Console.WriteLine("  Estructura de Datos - Clase 17");
            Console.WriteLine("============================================================\n");

            // PRUEBA 1: Arreglo vacio
            Console.WriteLine("--- PRUEBA 1: Arreglo vacio ---");
            Transaccion[] vacio = new Transaccion[0];
            ProbarOrdenamiento(vacio, "Arreglo vacio");

            // PRUEBA 2: Un solo elemento
            Console.WriteLine("\n--- PRUEBA 2: Un solo elemento ---");
            Transaccion[] uno = new Transaccion[]
            {
                new Transaccion(1, 100.00, 1700000100000)
            };
            ProbarOrdenamiento(uno, "Un solo elemento");

            // PRUEBA 3: Arreglo ya ordenado (MEJOR CASO)
            Console.WriteLine("\n--- PRUEBA 3: Arreglo ya ordenado (MEJOR CASO) ---");
            Transaccion[] ordenado = new Transaccion[]
            {
                new Transaccion(101, 150.00, 1700000100000),
                new Transaccion(102, 200.50, 1700000200000),
                new Transaccion(103, 350.00, 1700000300000),
                new Transaccion(104, 500.75, 1700000400000),
                new Transaccion(105, 999.99, 1700000500000)
            };
            ProbarOrdenamiento(ordenado, "Arreglo ya ordenado");

            // PRUEBA 4: Arreglo en orden inverso (PEOR CASO)
            Console.WriteLine("\n--- PRUEBA 4: Arreglo en orden inverso (PEOR CASO) ---");
            Transaccion[] inverso = new Transaccion[]
            {
                new Transaccion(105, 999.99, 1700000500000),
                new Transaccion(104, 500.75, 1700000400000),
                new Transaccion(103, 350.00, 1700000300000),
                new Transaccion(102, 200.50, 1700000200000),
                new Transaccion(101, 150.00, 1700000100000)
            };
            ProbarOrdenamiento(inverso, "Arreglo en orden inverso");

            // PRUEBA 5: Datos con duplicados (ESTABILIDAD)
            Console.WriteLine("\n--- PRUEBA 5: Datos con duplicados (ESTABILIDAD) ---");
            Transaccion[] duplicados = new Transaccion[]
            {
                new Transaccion(201, 100.00, 1700000100000),
                new Transaccion(202, 250.00, 1700000200000),
                new Transaccion(203, 100.00, 1700000300000),
                new Transaccion(204, 150.00, 1700000400000),
                new Transaccion(205, 100.00, 1700000500000)
            };
            ProbarOrdenamiento(duplicados, "Datos con duplicados");

            // PRUEBA 6: Bitacora real (casi ordenada)
            Console.WriteLine("\n--- PRUEBA 6: Bitacora real (casi ordenada) ---");
            Transaccion[] bitacora = new Transaccion[]
            {
                new Transaccion(1001, 500.00, 1700000100000),
                new Transaccion(1002, 750.50, 1700000200000),
                new Transaccion(1003, 1200.00, 1700000050000),
                new Transaccion(1004, 300.00, 1700000300000),
                new Transaccion(1005, 899.99, 1700000150000),
                new Transaccion(1006, 1500.00, 1700000400000),
                new Transaccion(1007, 450.00, 1700000080000),
                new Transaccion(1008, 2000.00, 1700000500000),
                new Transaccion(1009, 675.25, 1700000250000),
                new Transaccion(1010, 1100.00, 1700000600000)
            };
            ProbarOrdenamiento(bitacora, "Bitacora real (casi ordenada)");

            // PRUEBA 7: Arreglo aleatorio
            Console.WriteLine("\n--- PRUEBA 7: Arreglo aleatorio ---");
            Transaccion[] aleatorio = GenerarArregloAleatorio(15);
            ProbarOrdenamiento(aleatorio, "Arreglo aleatorio");

            Console.WriteLine("\n============================================================");
            Console.WriteLine("  Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void InsertionSort(Transaccion[] arr)
        {
            totalComparaciones = 0;
            totalDesplazamientos = 0;
            int n = arr.Length;
            if (n <= 1) return;

            for (int i = 1; i < n; i++)
            {
                Transaccion clave = arr[i];
                int j = i - 1;

                while (j >= 0)
                {
                    totalComparaciones++;
                    if (arr[j].Timestamp > clave.Timestamp)
                    {
                        arr[j + 1] = arr[j];
                        totalDesplazamientos++;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = clave;
            }
        }

        static void ProbarOrdenamiento(Transaccion[] arr, string descripcion)
        {
            Console.WriteLine($"Descripcion: {descripcion}");
            Console.WriteLine($"Tamano: {arr.Length}");
            Console.WriteLine("\n  ORIGINAL:");
            ImprimirArreglo(arr);

            InsertionSort(arr);

            Console.WriteLine("  ORDENADO:");
            ImprimirArreglo(arr);
            Console.WriteLine($"  Comparaciones: {totalComparaciones}");
            Console.WriteLine($"  Desplazamientos: {totalDesplazamientos}");
            Console.WriteLine($"  Orden correcto: {(VerificarOrdenamiento(arr) ? "SI" : "NO")}");
        }

        static void ImprimirArreglo(Transaccion[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("    [Vacio]");
                return;
            }
            foreach (var t in arr)
            {
                Console.WriteLine($"    {t}");
            }
        }

        static bool VerificarOrdenamiento(Transaccion[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].Timestamp < arr[i - 1].Timestamp)
                    return false;
            }
            return true;
        }

        static Transaccion[] GenerarArregloAleatorio(int cantidad)
        {
            Random rnd = new Random();
            Transaccion[] arr = new Transaccion[cantidad];
            long baseTimestamp = 1700000000000;
            for (int i = 0; i < cantidad; i++)
            {
                arr[i] = new Transaccion(3000 + i, rnd.Next(10, 5000) + rnd.NextDouble(), baseTimestamp + rnd.Next(0, 1000000));
            }
            return arr;
        }
    }
}
