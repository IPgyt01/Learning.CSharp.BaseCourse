using System.Collections.Generic;
using System.Linq;
using LinqToDB;

namespace Norbit.CRM.Tyganov.Practic13.WebApiVesrion2
{
    /// <summary>
    /// Класс, описывающий взаимодействие с БД через Linq2DB.
    /// </summary>
    class Linq2DbProvaider : Provider
    {
        /// <summary>
        /// Вывести всех продавцов.
        /// </summary>
        /// <returns></returns>
        public override List<Sellers> GetSellers()
        {
            using (var context = new SellersDB())
            {
                return context.Sellers.ToList();
            }
        }

        /// <summary>
        /// Вывести какого-то конкретного продавца.
        /// </summary>
        /// <param name="id">Индекс продавца.</param>
        /// <returns></returns>
        public override string GetSeller(int id)
        {
            using (var context = new SellersDB())
            {
                return context.Sellers.Where((seller) => seller.IdPositions == id).First().ToString();
            }
        }

        /// <summary>
        /// Добавить запись в таблицу.
        /// </summary>
        /// <param name="data"></param>
        public override void PushSeller(Sellers seller)
        {
            using (var context = new SellersDB())
            {
                context.Insert(seller);
            }
        }

        /// <summary>
        /// Удалить запись по индексу
        /// </summary>
        /// <param name="id">индекс</param>
        public override void DeleteSeller(int id)
        {
            using (var context = new SellersDB())
            {
                try
                {
                    context.Delete(
                        context.Sellers.FirstOrDefault(seller => seller.IdSeller == id));
                }
                catch
                {
                    throw new LinqToDBException("Не удалось провести удаление, проверьте id");
                }
            }
        }

        /// <summary>
        /// Вспомогательный класс для связи БД и Кода в класс Sellers.
        /// </summary>

        public class SellersDB : LinqToDB.Data.DataConnection
        {
            public SellersDB()
                : base(ProviderName.SqlServer2017, Provider.ConnectionString)
            {
            }
            public ITable<Sellers> Sellers => GetTable<Sellers>();
        }
    }
}
