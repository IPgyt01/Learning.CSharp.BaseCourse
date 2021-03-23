using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notbit.CRM.Tyganov.Practic4.EventsAndDelegates
{
    public class ArrayChanger
    {
        /// <summary>
        /// Делегат для сравнения в зависимости от указанного типа.
        /// </summary>
        /// <typeparam name="T">Генерик параметр.</typeparam>
        /// <param name="first">Первый элемент сравнения.</param>
        /// <param name="second">Второй элемент сравнения.</param>
        /// <returns></returns>
        public delegate int Comparison<T>(T first, T second);
        
        /// <summary>
        /// Делегат события EndSort.
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо вывести.</param>
        public delegate void ArraySorted(string message);
        /// <summary>
        /// Событие о завершении сортировки.
        /// </summary>
        public static event ArraySorted EndSort;

        /// <summary>
        /// Сортировка методом пузырька.
        /// </summary>
        /// <typeparam name="T">Генерик-параметр.</typeparam>
        /// <param name="array">Входной массив.</param>
        /// <param name="compare">Способ сравнения элементов, указывается в зависимости
        /// от типа входного массива.</param>
        public static void  BubbleSort<T>(T[] array, Comparison<T> compare)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[j], array[i]) < 0)
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            EndSort?.Invoke("Сортировка завешена");
        }
        
        /// <summary>
        /// Сравнение целочисленных элементов
        /// </summary>
        /// <param name="first">Первый элемент для сравнения</param>
        /// <param name="second">Второй элемент для сравнения</param>
        /// <returns></returns>
        public static int CompareIntType(int first, int second) =>
            first > second ? 1 : -1;

        /// <summary>
        /// Сравнение строк.
        /// </summary>
        /// <param name="first">Первый элемент для сравнения</param>
        /// <param name="second">Второй элемент для сравнения</param>
        /// <returns></returns>
        public static int CompareStringType(string first, string second) =>
            first.Length > second.Length ? 1 : -1;

        /// <summary>
        /// Сравнение произвольного типа данных, 
        /// реализующего интерфейс IComparable(к задаче опционально).
        /// </summary>
        /// <typeparam name="T">Генерик параметр.</typeparam>
        /// <param name="first">Первый элемент для сравнения.</param>
        /// <param name="second">Второй элемент для сравнения.</param>
        /// <returns></returns>
        public static int CompareOtherComparableTypes<T>(T first, T second)
            where T : IComparable => first.CompareTo(second);

    }
}

