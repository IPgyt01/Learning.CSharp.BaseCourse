using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLibrary;

namespace Norbit.CRM.Tyganov.Practic8.WorkingWithExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var exception = new ExceptionGenerator();
                exception.GetMathException();
                exception.GetCastException();
                exception.ConvertToTimezone();
            }
            catch(Exception e)
            {
                var helper = new ExceptionHelper();
                Console.WriteLine(helper.GetAllExceptionsInfo(e));
                Console.ReadLine();
                throw;
            }
        }
    }
}
