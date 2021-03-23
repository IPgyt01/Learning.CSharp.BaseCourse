using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic7.OOP
{
    /// <summary>
    /// Класс описывающий человека.
    /// </summary>
    class User
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirthday;
        private int _age;

        // Свойство для установки и получения даты рождения.
        public DateTime DateOfBirthday { get => _dateOfBirthday; set => _dateOfBirthday = value; }
        
        // Свойство для установки и получения имени.
        public string FirstName { get => _firstName; set => _firstName = value; }
        
        // Свойство для установки и получения фамилии.
        public string LastName { get => _lastName; set => _lastName = value; }
        
        // Свойство для установки и получения возраста.
        public int Age 
        {
            get => _age;
            set 
            {
                if (value < 0) throw new ArgumentOutOfRangeException(
                    $"{FirstName} должен быть старше {value} лет");
                _age = value;
            } 
        }

        /// <summary>
        /// Контруктор юзера.
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="dateOfBirthday">Дата рождения</param>
        /// <param name="age">Возраст</param>
        public User(string firstName, string lastName, DateTime dateOfBirthday, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirthday = dateOfBirthday;
            _age = age;
        }

        /// <summary>
        /// Переопределенный метод ToString для форматированного вывода.
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            $"{_firstName} {_lastName} родился {_dateOfBirthday}, полных лет {_age}";
    }

    /// <summary>
    /// Класс работник, наследуется от человека(Юзера).
    /// </summary>
    class Employee : User
    {
        /// <summary>
        /// Место работы.
        /// </summary>
        private string _company;
        
        /// <summary>
        /// Стаж работы.
        /// </summary>
        private int _experience;

        /// <summary>
        /// Должность.
        /// </summary>
        private string _position;

        /// <summary>
        /// Контруктор сотрудника.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="dateOfBirthday">Дата рождения.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="company">Место работы.</param>
        /// <param name="experience">Стаж.</param>
        /// <param name="position">Позиция.</param>
        public Employee(string firstName, string lastName, DateTime dateOfBirthday, 
            int age,string company, int experience, string position):
            base(firstName, lastName, dateOfBirthday, age)
        {
            _company = company;
            _experience = experience;
            _position = position;
        }

        /// <summary>
        /// Конструктор, принмающий в качесвте параметра человека.
        /// </summary>
        /// <param name="user">Собственно человек</param>
        /// <param name="company">Место работы.</param>
        /// <param name="experience">Стаж.</param>
        /// <param name="position">Должность.</param>
        public Employee(User user, string company, int experience, string position) :
            base(user.FirstName, user.LastName, user.DateOfBirthday, user.Age)
        {
            _company = company;
            _experience = experience;
            _position = position;
        }

        /// <summary>
        /// Переопределенный вывод.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"работает в {_company} в должности {_position} " +
                $"со стажем {_experience}";
        }
    }
}
