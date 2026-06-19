namespace FactorialDesbordamiento
{
    /// <summary>
    /// Implementación iterativa del factorial usando int.
    /// Produce exactamente el mismo resultado matemático que la versión recursiva
    /// pero sin usar el Call Stack para almacenar marcos de activación.
    /// 
    /// El punto de quiebre es idéntico: n=13 desborda el tipo int.
    /// </summary>
    public static class FactorialIterativo
    {
        /// <summary>
        /// Calcula el factorial de forma iterativa usando un bucle for.
        /// ADVERTENCIA: Produce resultados incorrectos para n >= 13.
        /// </summary>
        public static int Calcular(int n)
        {
            int resultado = 1;

            // Acumulamos multiplicando desde 2 hasta n
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;  // Desbordamiento silencioso cuando resultado > int.MaxValue
            }

            return resultado;
        }
    }
}