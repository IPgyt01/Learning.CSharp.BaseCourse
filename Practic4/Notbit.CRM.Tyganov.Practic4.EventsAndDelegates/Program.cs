using System;

namespace Notbit.CRM.Tyganov.Practic4.EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new NewArray();
            arr.TestArrays();
            Console.ReadLine();
        }
    }


    /// <summary>
    /// Класс для работы с зараннее созданными массивами
    /// </summary>
    class NewArray
    {
        /// <summary>
        /// Массив целочисленных значений.
        /// </summary>
        int[] _integerArr;
        /// <summary>
        /// Массив строк.
        /// </summary>
        string[] _stringArr;
        /// <summary>
        /// Массив значений двоичной точности.
        /// </summary>
        double[] _doubleArr;

        public NewArray()
        {
            _integerArr = new int[] { 2, 5, 6, 7, 3, 7, 8, 21, 25 };
            _stringArr = new string[] { "строкаааа", "строка",
                "строка из нескольких слов" };
            _doubleArr = new double[] { 1.5, 1.2, 0.3, 256.7 };
        }

        /// <summary>
        /// Метод для вывода значений на экран.
        /// </summary>
        /// <typeparam name="T">Произвольный тип данных</typeparam>
        /// <param name="array">Массив</param>
        private void PrintArray<T>(T[] array)
        {
            foreach (var i in array)
                Console.Write($"{i}, ");
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для тестирования работы сортировки.
        /// </summary>
        public void TestArrays()
        {
            Console.WriteLine("Исходный массив");
            PrintArray(_stringArr);
            Console.WriteLine("Отсортированный массив: ");
            // Cортировка строк.
            ArrayChanger.BubbleSort(_stringArr, ArrayChanger.CompareStringType);
            PrintArray(_stringArr);

            // Подписчик на событие, реализованный через лямбда выражение.
            ArrayChanger.EndSort += (ReportMessage) => Console.WriteLine(ReportMessage);
        }
    }
}
