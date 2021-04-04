using System.Collections.Generic;

namespace Norbit.CRM.Tyganov.Practic12.ADO.NET.LINQ2DB
{
    /// <summary>
    /// Класс провайдера - основа. Описывает способы взаимодействия с базой данных.
    /// </summary>
    public abstract class Provider
    {
        /// <summary>
        /// Строка подключения к БД.
        /// </summary>
        public static string ConnectionString = @"Data Source=WSAMARA37\SQLEXPRESS;Initial Catalog=WebPortalDataBase;Integrated Security=True";
        
        /// <summary>
        /// Скелет модели работы - Получить работников.
        /// </summary>
        /// <returns>Возвращает лист работников.</returns>
        public abstract List<Sellers> GetSellers();
    }

    /// <summary>
    /// Класс, позволяющий выбрать какой-то конкретный способ взаимодействия с БД.
    /// </summary>
    public static class ProviderFactory
    {
        /// <summary>
        /// Выбрать нужный провайдер.
        /// </summary>
        /// <param name="choose">Выбор - число от 1 до 2.</param>
        /// <returns></returns>
        public static Provider GetProvider(int choose)
        {
            switch(choose)
            {
                case 1:
                    return new AdoNetProvider();
                case 2:
                    return new Linq2DbProvaider();
                default: return null;
            }
        }
    }
}
