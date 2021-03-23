using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic2.DataTypes
{
    class Program
    {
        /// <summary>
        /// Выполнение заданий.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Задание 1.
            CheckIMT();
            // Задание 2.
            TransformArray();
            // Задание 3.
            GetAverageLengthInLine();
            // Задание 4.
            AnyOperations.CheckDiffrenceStructAndClass();

            Console.ReadLine();
        }

        #region Task1 

        /// <summary>
        /// Вычислить IMT(индекс массы тела).
        /// </summary>
        /// <param name="weight">Вес</param>
        /// <param name="growth">Рост</param>
        /// <returns></returns>
        public static double CalculateIMT(int weight, int growth) => 
            weight / Math.Pow(growth, 2);

       /// <summary>
       /// Метод используется лишь для вывода индекса массы, но можно добавить сюда проверку
       /// на нормальность индекса.
       /// </summary>
        public static void CheckIMT()
        {
            Console.WriteLine("Введите ваш рост:");
            var growth = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ваш вес:");
            var weight = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateIMT(weight, growth));
        }

        #endregion

        #region Task2

        /// <summary>
        /// Сортировка массива методом пузырька.
        /// </summary>
        public static void TransformArray()
        {
            var arr = new int[25];
            var rand = new Random();
            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(0, 100);
            Console.WriteLine("Исходный массив: ");
            PrintArray(arr);
            var sortedArr = BubbleSort(arr);
            Console.WriteLine("Отсортированный массив: ");
            PrintArray(sortedArr);
            Console.WriteLine("Минимальное значение = " + sortedArr[0]);
            Console.WriteLine("Максимальное значение = " +
                sortedArr[sortedArr.Length - 1]);

        }

        public static void PrintArray(int[] arr)
        {
            foreach (var i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        /// <summary>
        /// Пузырьковая сортировка.
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <returns></returns>

        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        #endregion

        #region Task3
        /// <summary>
        /// Подсчет средней длины слова в строке
        /// </summary>
        public static void GetAverageLengthInLine()
        {
            Console.WriteLine("Введите строку: ");
            var lines = Console.ReadLine().Split(' ');
            var summ = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(',')) summ += lines[i].Length - 1;
                else summ += lines[i].Length;
            }

            Console.WriteLine("Средняя длина слова: " + (summ / lines.Length));
        }
        #endregion

        #region Task4


        /// <summary>
        /// Описание простой информации о произвольных людях в виде структуры.
        /// </summary>
        struct UserInfoStruct
        {
            // Reference type.
            public string Name;
            // Value type.
            public byte Age;

            public UserInfoStruct(string Name, byte Age)
            {
                this.Name = Name;
                this.Age = Age;
            }

            public void WriteUserInfo()
            {
                Console.WriteLine("Имя: {0}, возраст: {1}", Name, Age);
            }

            public static void CheckStructInfo()
            {
                var user1Struct = new UserInfoStruct("Alexandr", 26);
                Console.Write("user1: ");
                user1Struct.WriteUserInfo();
                var user2Struct = new UserInfoStruct("Elena", 22);
                Console.Write("user2: ");
                user2Struct.WriteUserInfo();

                // Показать главное отличие структур от классов
                user1Struct = user2Struct;
                user2Struct.Name = "Natalya";
                user2Struct.Age = 25;
                Console.Write("\nuser1: ");
                user1Struct.WriteUserInfo();
                Console.Write("user2: ");
                user2Struct.WriteUserInfo();
            }
        }

        /// <summary>
        /// Описание простой информации о произвольных людях в виде класса.
        /// </summary>

       // Нарушение принципа DRY. Используется лишь для примера.
        class UserInfoClass
        {
            public string Name;
            public byte Age;

            public UserInfoClass(string Name, byte Age)
            {
                this.Name = Name;
                this.Age = Age;
            }

            public void WriteUserInfo()
            {
                Console.WriteLine("Имя: {0}, возраст: {1}", Name, Age);
            }

            public static void ChecClassInfo()
            {
                var user1Class = new UserInfoClass("Alexandr", 26);
                Console.Write("user1: ");
                user1Class.WriteUserInfo();
                var user2Class = new UserInfoClass("Elena", 22);
                Console.Write("user2: ");
                user2Class.WriteUserInfo();

                // Показать главное отличие структур от классов
                user1Class = user2Class;
                user2Class.Name = "Natalya";
                user2Class.Age = 25;
                Console.Write("\nuser1: ");
                user1Class.WriteUserInfo();
                Console.Write("user2: ");
                user2Class.WriteUserInfo();
            }
        }



        /// <summary>
        /// Операции для демонстрации работы памяти.
        /// </summary>
        static class AnyOperations
        {
            /// <summary>
            /// Показывает отличие структуры от класса.
            /// </summary>
            public static void CheckDiffrenceStructAndClass()
            {
                Console.WriteLine("**********************************");
               // Вызовем сначала пример с присваиванием полей в структуре.
                UserInfoStruct.CheckStructInfo();
                Console.WriteLine();
                Console.WriteLine();
                // А теперь в классе.
                UserInfoClass.ChecClassInfo();
                Console.WriteLine();
                Console.WriteLine("Главное отличие структуры от класса заключается в том, " +
                    "что когда объекту одной структуры присвается другой объект," +
                    " создается копия первоначального объекта");
                Console.WriteLine("В то же время при той же операции с классами" +
                    " копируется не сам объект, а лишь ссылка на него");
                Console.ReadLine();
            }

            /// <summary>
            /// Как работает ref
            /// </summary>

            public static void LerningRef()
            {
                int x = 10;
                int y = 15;
                Addition(ref x, y); // вызов метода
                Console.WriteLine(x);   // 25

                Console.ReadLine();
            }

            public static void Addition(ref int x, int y)
            {
                x += y;
            }
           
            /// <summary>
            /// Принудительная сборка мусора
            /// </summary>
            public static void TrySystemGC()
            {
                long totalMemory = GC.GetTotalMemory(false);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        #endregion
    }
}
