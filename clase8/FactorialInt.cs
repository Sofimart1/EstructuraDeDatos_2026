namespace FactorialDesbordamiento
{
    /// <summary>
    /// Implementación recursiva del factorial usando tipo int (32 bits).
    /// 
    /// PUNTO DE QUIEBRE DOCUMENTADO:
    /// El tipo int en C# tiene un rango de -2,147,483,648 a 2,147,483,647.
    /// El factorial crece de forma super-exponencial:
    /// 
    ///   n=10  → 3,628,800           (✅ correcto)
    ///   n=12  → 479,001,600         (✅ correcto)
    ///   n=13  → 6,227,020,800        (❌ OVERFLOW - excede int.MaxValue)
    ///   n=20  → 2,432,902,008,176,640,000 (❌ imposible en int)
    /// 
    /// A partir de n=13, ocurre desbordamiento aritmético silencioso (wraparound)
    /// porque C# opera en contexto unchecked por defecto. El valor "da la vuelta"
    /// y aparece como número negativo o incorrecto sin lanzar excepción.
    /// </summary>
    public static class FactorialInt
    {
        /// <summary>
        /// Calcula el factorial de forma recursiva usando int.
        /// ADVERTENCIA: Produce resultados incorrectos para n >= 13.
        /// </summary>
        public static int Calcular(int n)
        {
            // Caso base: 0! = 1 y 1! = 1
            if (n == 0 || n == 1)
                return 1;

            // Caso recursivo: n! = n * (n-1)!
            // El desbordamiento ocurre aquí cuando el producto excede int.MaxValue
            return n * Calcular(n - 1);
        }
    }
}
