using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic3.Library
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _array;
        public int Length { get; set; }
        public int Capacity { get; set; }

        /// <summary>
        /// Переропределение индексатора.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Capacity)
                    throw new ArgumentOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index < 0 || index > Capacity)
                    throw new ArgumentOutOfRangeException();
                _array[index] = value;
            }
        }

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public DynamicArray()
        {
            _array = new T[8];
            Capacity = 8;
            Length = 0;
        }

        /// <summary>
        /// Контруктор, принимающий в качесвте параметра - размер массива.
        /// </summary>
        /// <param name="capacity">Размер массива.</param>
        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
            Capacity = capacity;
            Length = 0;
        }

        /// <summary>
        /// Конструктор, преобразующий коллекцию в массив.
        /// </summary>
        /// <param name="collection">Исходная коллекция.</param>

        public DynamicArray(IEnumerable<T> collection)
        {
            _array = new T[collection.ToArray().Length];
            Array.Copy(collection.ToArray(), _array, collection.ToArray().Length);
            Length = _array.Length;
            Capacity = collection.Count();

        }


        /// <summary>
        /// Добавить элемент в конец массива
        /// </summary>
        /// <param name="item">Элемент, который нужно добавить.</param>
        public void Add(T item)
        {
            if(Capacity <= Length)
            {
                Capacity *= 2;
                var extendedArr = new T[Capacity];
                Array.Copy(_array, extendedArr, Length);
                _array = extendedArr;
            }

            _array[Length] = item;
            Length++;
        }

        /// <summary>
        /// Добавить последовательность в конец массива.
        /// </summary>
        /// <param name="collection">Коллекция, реализующая IEnumerable</param>
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            
            // Способ 1.
            var shortArr = new T[Length];
            Array.Copy(_array, shortArr, Length);
            var temp = shortArr.ToList();
            foreach (var i in collection)
                temp.Add(i);
            _array = temp.ToArray();
            Length = _array.Length;
            Capacity = Length;

            // Способ 2. ПОДПРАВИТЬ
            //Capacity = Length + collection.Count();
            //var temp = new T[Capacity];
            //Array.Copy(_array, temp, Length);
            //var collectionArr = collection.ToArray();
            //for(var i = Length; i < temp.Length; i++)
            //{
            //    for(var j = 0; j < collectionArr.Length; j++)
            //    {
            //        temp[i] = collectionArr[j];
            //    }
            //}
            //_array = temp;
            //Length = _array.Length
            
            //По идее можно еще сделать как-то через Take и Skip,
            //но я решил так не заморачиваться.
        }

        /// <summary>
        /// Удалить элемент по индексу.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns></returns>
        public bool Remove(int index)
        {
            if (index < 0 && index > _array.Length)
                throw new ArgumentOutOfRangeException();
            // Взять все, что до индекса и связать со всем, что после.
            _array = _array.Take(index).Concat(_array.Skip(index + 1)).ToArray();
            return true;
        }

        /// <summary>
        /// Вставить элемент на указанную позицию.
        /// </summary>
        /// <param name="item">Элемент.</param>
        /// <param name="index">Индекс позиции.</param>
        public void Insert(T item, int index)
        {
            if (index < 0 || index > _array.Length) 
                throw new ArgumentOutOfRangeException();
            // Делим массив по индексу, меняем последний элемент в первой половине,
            // объединяем со второй половиной + тот замененный элемент.
            // Не уверен, что такой способ эффективен, но зато гораздо короче чем привычное
            // добавление через условия.
            var firstHalf = _array.Take(index).ToArray();
            firstHalf[firstHalf.Length - 1] = item;
            _array = firstHalf.Concat(_array.Skip(index-1)).ToArray();
            Length++;
            Capacity++;
        }

        /// <summary>
        /// Реализация IEnumerable.
        /// </summary>
        /// <returns></returns>

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        /// <summary>
        /// Реализация IEnumerable.
        /// </summary>
        /// <returns></returns>

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }
    }
}
