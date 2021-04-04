using System.Collections.Generic;

namespace Norbit.CRM.Tyganov.Practic13.WebApiVesrion2
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
        public abstract string GetSeller(int id);
        public abstract void PushSeller(Sellers seller);

        public abstract void DeleteSeller(int id);
    }

    /// <summary>
    /// Класс, позволяющий выбрать какой-то конкретный способ взаимодействия с БД.
    /// </summary>
    public static class ProviderFactory
    {
        /// <summary>
        /// Выбрать нужный провайдер(В данном случае провайдер лишь один).
        /// </summary>
        /// <param name="choose">Выбор - число от 1 до 2.</param>
        /// <returns></returns>
        public static Provider GetProvider() => new Linq2DbProvaider();
    }
}
