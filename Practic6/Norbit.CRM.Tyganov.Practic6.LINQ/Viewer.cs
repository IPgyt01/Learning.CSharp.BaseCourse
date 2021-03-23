using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic6.LINQ
{
    /// <summary>
    /// Вспомогательный класс для работы с последовательностью.
    /// </summary>
    class Viewer
    {
        /// <summary>
        /// Меню.
        /// </summary>
        /// <param name="sequence"></param>
        public void View(List<Employee> sequence)
        {
            Console.WriteLine("Пожалуйста, выюерете, что вы хотите сделать с поступившей последовательностью: ");
            Console.WriteLine("1 - Фильтровать, 2 - Пропустить несколько элементов," +
                " 3 - Группировать, 4 - Сделать цыганские фокусы");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    // Фильтрация.
                    Print(Employee.Filter(sequence));
                    break;
                case 2:
                    // Пропуск элементов.
                    Print(sequence.Skip(2));
                    break;
                case 3:
                    // Группировка.
                    Print(Employee.GroupEmployees(sequence));
                    break;
                case 4:
                    // Пересчет зарплаты.
                    Print(Employee.IncreaseSalary(sequence));
                    break;
            }
        }
        /// <summary>
        /// Функция для вывода на экран последовательности.
        /// </summary>
        /// <param name="employees">Последовательность сотрудников.</param>
        private void Print(IEnumerable<Employee> employees)
        {
            foreach(var i in employees)
            {
                Console.WriteLine($"Имя: {i.Name}, Company: {i.Company}");
                Console.WriteLine($" Число рабочих часов в неделю: {i.CountOfWorkingHours}, Ставка: {i.Rate}");
                Console.WriteLine();
                Console.WriteLine($"Заработная плата {i.Wage}");
            }
            Console.ReadLine();
        }
    }
}
