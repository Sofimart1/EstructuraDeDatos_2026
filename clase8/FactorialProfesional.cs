using System.Numerics;

namespace FactorialDesbordamiento
{
    /// <summary>
    /// Implementación profesional del factorial usando BigInteger.
    /// 
    /// BigInteger (System.Numerics) no tiene tamaño fijo en memoria.
    /// Crece dinámicamente en el Heap para acomodar números de longitud arbitraria.
    /// El único límite real es la memoria RAM disponible.
    /// 
    /// Diferencias clave vs int:
    /// - Tamaño: int = 4 bytes fijos; BigInteger = lo que necesita
    /// - Ubicación: int vive en Stack; BigInteger (datos internos) en Heap
    /// - Rendimiento: BigInteger es más lento pero permite valores masivos
    /// - Uso profesional: criptografía, finanzas, computación científica
    /// </summary>
    public static class FactorialProfesional
    {
        /// <summary>
        /// Calcula el factorial con precisión arbitraria usando BigInteger.
        /// Puede calcular 100! (158 dígitos) sin desbordamiento.
        /// </summary>
        public static BigInteger Calcular(BigInteger n)
        {
            // Caso base: usamos BigInteger.One para compatibilidad de tipos
            if (n == 0 || n == 1)
                return BigInteger.One;

            // Caso recursivo: n! = n * (n-1)!
            // BigInteger maneja automáticamente la expansión de memoria
            return n * Calcular(n - 1);
        }

        /// <summary>
        /// Versión iterativa con BigInteger para mejor rendimiento
        /// (evita la sobrecarga de marcos de activación en el Stack).
        /// </summary>
        public static BigInteger CalcularIterativo(BigInteger n)
        {
            BigInteger resultado = BigInteger.One;

            for (BigInteger i = 2; i <= n; i++)
            {
                resultado *= i;
            }

            return resultado;
        }
    }
} 