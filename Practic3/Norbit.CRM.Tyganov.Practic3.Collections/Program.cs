using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norbit.CRM.Tyganov.Practic3.Library;


namespace Norbit.CRM.Tyganov.Practic3.Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            GetFrequancyWords();
            // Задание 2 и 3.
            TestArray();
            // Задание 4.
            var pesron1 = new Person("Иван", 20, "Norbit");
            var person2 = new Person("Александр", 22, "Norbit");
            var notPerson = new Bycicle(30, "Крутой велик");
            if (pesron1.Equals(person2) == false)
                Console.WriteLine("Эти ребята разные");
           
            if (!person2.Equals(notPerson))
            {
                Console.WriteLine("Один из нас - не человек!");
            }
            // Задание 5.
            Console.WriteLine(string.Join(" ", ZipSum(new[] { 1, 3, 5 }, 
                new[] { 5, 3, -1 })));
            Console.ReadLine();
        }

        /// <summary>
        /// Найти количество повторений слова в тексте
        /// </summary>

        static void GetFrequancyWords()
        {
            const string text = "Any any string with anything information witH help Dictionary";
            var dict = FrequancyWords.GetCountFrequncyWords(text);
            foreach (var element in dict)
                Console.WriteLine($"Слово {element.Key} встречается {element.Value} раз");
            Console.ReadLine();
        }

        /// <summary>
        /// "Тестирование" для второго задания.
        /// </summary>
        static void TestArray()
        {
            int[] sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var arr = new DynamicArray<int>(sequence);
            arr.Add(9);
            var adder = new int[] { 10, 11, 12 };
            arr.AddRange(adder);
            arr.Remove(5);
            arr.Insert(3, 3);
            foreach(var c in arr)
                Console.WriteLine(c);
            Console.ReadLine();
        }

        /// <summary>
        /// Возвращает последовательность из попарных сумм элементов 
        /// входящих двух последовательностей.
        /// </summary>
        /// <param name="first">Первая последовательность.</param>
        /// <param name="second">Вторая последовательность.</param>
        /// <returns></returns>
        private static IEnumerable<int> ZipSum(IEnumerable<int> first,
            IEnumerable<int> second)
        {
            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return e1.Current + e2.Current;
            }
        }
    }

    /// <summary>
    /// Класс для сравнения
    /// </summary>
    class Person
    {
        private string _name;
        private int _age;
        private string _company;

        public Person(string name, int age, string company)
        {
            _age = age;
            _name = name;
            _company = company;
        }
        
        /// <summary>
        /// Переопределение сравнения.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
           var comparablePerson = obj as Person;
           if (obj is Person == true)
                return _name == comparablePerson._name
                    && _age == comparablePerson._age
                    && _company == comparablePerson._company;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Класс для сравнения
    /// </summary>
    class Bycicle
    {
        private int _speed;
        private string _specialCharactecristic;
        public Bycicle(int speed, string other)
        {
            _speed = speed;
            _specialCharactecristic = other;
        }
    }
}
