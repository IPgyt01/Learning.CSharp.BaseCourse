using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic8.WorkingWithExceptions
{
    /// <summary>
    /// Класс для генерации ситуаций с исключениями.
    /// </summary>
    class ExceptionGenerator
    {
        /// <summary>
        /// Функция деления, формирует исключение выхода аргумента за ОДЗ.
        /// </summary>
        public void GetMathException()
        {
            Console.WriteLine("Введите делимое");
            var a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите делитель");
            var b = int.Parse(Console.ReadLine());
            if (b == 0) throw new ArgumentOutOfRangeException("Делить на 0 нельзя.");

            Console.WriteLine(a / b);
        }

        /// <summary>
        /// Формирует исключение при попытке перевода не числа в число.
        /// </summary>
        public void GetCastException()
        {
            Console.WriteLine("Введите число: ");
            var num = Console.ReadLine();
            var res = 0;
            if (int.TryParse(num, out res))
            {
                Console.WriteLine($"Отлично, вы ввели {res}");
                Console.ReadLine();
            }
            else throw new InvalidCastException();
        }

        /// <summary>
        /// Конвертирует текущую дату и время из UTC в местное время.
        /// </summary>
        public void ConvertToTimezone()
        {
            var timeUtc = DateTime.UtcNow;
            try
            {
                var yourTimezone = TimeZoneInfo.Local;
                var yourTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, yourTimezone);
                Console.WriteLine("Твой часовой пояс и время {0} {1}.",
                    yourTimezone.IsDaylightSavingTime(yourTime) ?
                        yourTimezone.DaylightName : yourTimezone.DisplayName, yourTime);
                Console.ReadLine();
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("Твой часовой пояс не найден.");
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("С твоим часовым поясом что-то не так");
            }
        }
    }
}
