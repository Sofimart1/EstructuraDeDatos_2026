using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulacroClase11
{
    public struct PuntoDeRed
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public PuntoDeRed(double latitud, double longitud)
        {
            if (latitud < -90.0 || latitud > 90.0)
                throw new ArgumentOutOfRangeException(nameof(latitud));

            if (longitud < -180.0 || longitud > 180.0)
                throw new ArgumentOutOfRangeException(nameof(longitud));

            Latitud = latitud;
            Longitud = longitud;
        }

        public override string ToString()
            => $"({Latitud}°, {Longitud}°)";
    }

    public class ServidorConexion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public PuntoDeRed Ubicacion { get; set; }
        public List<int> CodigosRespuesta { get; set; }

        private readonly long[] _cache = new long[100];

        public ServidorConexion(int id, string nombre,
                                PuntoDeRed ubicacion,
                                List<int> codigos)
        {
            ID = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
            CodigosRespuesta = codigos ?? new List<int>();
        }

        public override string ToString()
            => $"[{ID}] {Nombre} @ {Ubicacion}";

        public long DiagnosticarLatencia(int n, out string alerta)
        {
            if (n < 0 || n >= 100)
                throw new ArgumentOutOfRangeException(nameof(n));

            if (n <= 1)
            {
                alerta = string.Empty;
                return n;
            }

            if (_cache[n] != 0)
            {
                alerta = string.Empty;
                return _cache[n];
            }

            _cache[n] = DiagnosticarLatencia(n - 1, out _) +
                         DiagnosticarLatencia(n - 2, out _);

            alerta = _cache[n] > 10000
                ? $"ALERTA: Índice crítico en {Nombre}"
                : string.Empty;

            return _cache[n];
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var servidores = new List<ServidorConexion>
            {
                new ServidorConexion(1,"CDMX", new PuntoDeRed(19.43,-99.13), new List<int>{200,500}),
                new ServidorConexion(2,"NYC", new PuntoDeRed(40.71,-74.01), new List<int>{200,404}),
                new ServidorConexion(3,"Sydney", new PuntoDeRed(-33.87,151.21), new List<int>{500}),
                new ServidorConexion(4,"Londres", new PuntoDeRed(51.51,-0.13), new List<int>{200})
            };

            var criticos = servidores
                .Where(s => s.CodigosRespuesta.Contains(500))
                .ToList();

            Console.WriteLine("=== CRÍTICOS ===");

            foreach (var s in criticos)
                Console.WriteLine(s);

            long resultado = servidores[0].DiagnosticarLatencia(10, out string alerta);

            Console.WriteLine($"\nResultado: {resultado}");

            if (!string.IsNullOrEmpty(alerta))
                Console.WriteLine(alerta);
        }
    }
}