using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic7.OOP
{
    class ViewHelper
    {
        public static void WorkingWithRoundAndBall()
        {
            var round = new Round(new Point(0, 0), 2);
            var ball = new Ball(round);
            Console.WriteLine($"Допустим, у нас есть круг вот здесь {round}");
            Console.WriteLine();
            Console.WriteLine($"Вот с таким радиусом {round.Radius} и вот таким центром" +
                $" {round.Center.X} {round.Center.Y}");
            Console.WriteLine();
            Console.WriteLine($"Благодаря ключевым словам base и this мы легко можем создать шар вот здесь {ball}");
            Console.WriteLine($"Вот с таким объемом {ball.Volume}");            
            Console.ReadLine();
        }

        public static void WorkingWithUserAndEmployee()
        {
            var user = new User("Вася", "Пупкин", new DateTime(1996, 7, 19), 25);
            Console.WriteLine(user.ToString());
            Console.WriteLine();

            var employee = new Employee(user, "Яндекс", 4, "Младший программист");
            Console.WriteLine(employee.ToString());
            Console.ReadLine();
        }
    }
}
