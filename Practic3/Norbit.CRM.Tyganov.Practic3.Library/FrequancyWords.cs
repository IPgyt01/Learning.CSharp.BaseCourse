using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic3.Library
{
    /// <summary>
    /// Класс для работы с повторяющимися словами.
    /// </summary>
    public static class FrequancyWords
    {
        /// <summary>
        /// Найти количество повторяющихся слов в тексте.
        /// </summary>
        /// <param name="text">Текст</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetCountFrequncyWords(string text) => text
            // Перевод всех символов в нижний регистр  
                .ToLower()
            // Сплитим строку
                .Split(' ', '.', (char)StringSplitOptions.RemoveEmptyEntries)
            // Используем группировку, чтобы сформировать ключи для словаря.
                .GroupBy(x => x)
            // Вычленяем только ключи подходящие по условию, можно задать кол-во
            // повторений.
                .Where(x => x.Count() >= 1)
            // Запись в словарь (ключ - слово, значение - количество повторений.
                .ToDictionary(group => group.Key, group => group.Count());
    }
}
