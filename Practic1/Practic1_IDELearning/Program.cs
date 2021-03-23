using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
