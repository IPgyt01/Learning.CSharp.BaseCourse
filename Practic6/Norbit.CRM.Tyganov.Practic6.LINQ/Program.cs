using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic6.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Лист сотрудников.
            var employees = new List<Employee>
            {
                new Employee("Вася", "Google", 20, 1000),
                new Employee("Ваня", "Google", 40, 2000),
                new Employee("Вася", "Google", 28, 950),
                new Employee("Вася", "Google", 15, 250),
                new Employee("Вася", "Google", 47, 1000),
            };
            //Вьюер - вспомогательный элемент для отображения работы.
            var viewer = new Viewer();
            viewer.View(employees);
        }
    }
}
