using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    /// <summary>
    /// Вспомогательный класс для работы с ошибками.
    /// </summary>
    public class ExceptionHelper
    {
        /// <summary>
        /// Метод, формирующий строку определенного формата с информацией о всех ошибках.
        /// </summary>
        /// <param name="exception">Ошибка.</param>
        /// <returns></returns>
        public string GetAllExceptionsInfo(Exception exception)
        {
            var exeptions = new StringBuilder();
            do
            {
                exeptions.AppendFormat($"Oшибка {exception.Message} вызвана в {exception.Source}," +
                                   $" стек в данный момент {exception.StackTrace}");

                exception = exception.InnerException;
            }
            while (exception != null);
            return exeptions.ToString();
        }
    }
}
