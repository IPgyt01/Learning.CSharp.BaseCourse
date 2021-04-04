using System;

namespace Norbit.Crm.IdeLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Operations.GetSequence(n));
            Operations.PrintNSquare(n);
            //Ожидание, чтобы окно консоли не закрылось
            Console.ReadLine();
        }
    }
}
