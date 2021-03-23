using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic6.LINQ
{
    /// <summary>
    /// Класс, описывающий модель работника.
    /// </summary>
    class Employee
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Место работы.
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Количество рабочих часов в месяц.
        /// </summary>
        public int CountOfWorkingHours { get; set; }
        /// <summary>
        /// Почасовая ставка.
        /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// Заработная плата. Формируется в зависимости от количества часов и почасовой ставки.
        /// </summary>
        public int Wage
        {
            get
            {
                return CountOfWorkingHours * Rate;
            }
            set
            {
                if (Rate < 0 || CountOfWorkingHours < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Wage = CountOfWorkingHours * Rate;
            }
        }
        /// <summary>
        /// Контруторк
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="company">Компания</param>
        /// <param name="countOfWorkingHours">Число рабочих часов в месяц.</param>
        /// <param name="rate">Почасовая ставка.</param>
        public Employee(string name, string company, int countOfWorkingHours, int rate)
        {
            Name = name;
            Company = company;
            CountOfWorkingHours = countOfWorkingHours;
            Rate = rate;
        }

        /// <summary>
        /// Отфильтровать последовательность по критерию заработной платы.
        /// Реализована с помощью FROM.
        /// </summary>
        /// <param name="employees">Последовательность работников</param>
        /// <returns></returns>
        public static List<Employee> Filter(IEnumerable<Employee> employees) =>
           new List<Employee>(from worker in (List<Employee>)employees where worker.Wage > 1000 select worker);

        /// <summary>
        /// Пересчет зарплаты, в случае, если сотрудник перерабатывает.
        /// </summary>
        /// <param name="employees">Последовательность работников.</param>
        /// <returns></returns>
        public static List<Employee> IncreaseSalary(IEnumerable<Employee> employees)
        {
            var elevated = employees.Where(worker => worker.CountOfWorkingHours > 40).ToList();
            var temp = elevated.Select(worker => worker.Rate * 2).ToList();
            for (var i = 0; i < elevated.Count; i++)
            {
                elevated[i].Rate = temp[i];
            }
            return elevated;
        }

        /// <summary>
        /// Сгруппировать сотрудников по количеству рабочих часов.
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Employee[] GroupEmployees(IEnumerable<Employee> employees) =>
            (Employee[])employees
                .GroupBy(x => x.CountOfWorkingHours)
                .OrderBy(x => x.Key)
                .ToArray();

    }
}
