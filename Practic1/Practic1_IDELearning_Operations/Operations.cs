using System;
using System.Text;

namespace Norbit.Crm.IdeLearning
{
    /// <summary>
    /// Различные операции для первой практики
    /// </summary>
    public static class Operations
    {
        /// <summary>
        /// Собирает последовательность через запятую от 1 до N.
        /// </summary>
        /// <param name="n">длина последовательности</param>
        public static string GetSequence(int n)
        {
            var builder = new StringBuilder();
            for (var i = 1; i <= n; i++)
            {
                _ = (i == n) ? builder.Append($"{i}.") :
                builder.Append($"{i}, ");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Выводит квадрат из * размера N без центра.
        /// </summary>
        /// <param name="n">Размерность квадрата</param>
        public static void PrintNSquare(int n)
        {
            if (n % 2 == 0) Console.WriteLine("Пожалуйста введи нечетное число");
            else
            {
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < n; j++)
                    {
                        if (i == n / 2 && j == n / 2) Console.Write(" ");
                        else Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
