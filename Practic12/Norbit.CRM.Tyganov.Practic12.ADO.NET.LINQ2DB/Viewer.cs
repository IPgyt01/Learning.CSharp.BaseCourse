using System;
using System.Collections.Generic;

namespace Norbit.CRM.Tyganov.Practic12.ADO.NET.LINQ2DB
{
    /// <summary>
    /// Вспомогательный класс для обеспечения красивого вывода.
    /// </summary>
    class Viewer
    {
        public void Print<T>(IEnumerable<T> equatable)
        {
            if (equatable == null)
            {
                throw new ArgumentNullException(nameof(equatable));
            }
            foreach (var t in equatable)
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Вызывает нужный метод в зависимости от выбора пользователя.
        /// </summary>

        public void WorkWithDB()
        {
            Console.WriteLine("Выберете что хотити сделать:");
            Console.WriteLine("1 - Вывести всех работников");
            Console.WriteLine("2 - Вывести работников с указанием должности");
            int choose;
            if (int.TryParse(Console.ReadLine(), out choose))
            {
                var db = ProviderFactory.GetProvider(choose);
                var sellers = db.GetSellers();
                Print(sellers);
            }
        }
    }
}
