using System.Collections.Generic;
using System.Linq;
using LinqToDB;

namespace Norbit.CRM.Tyganov.Practic12.ADO.NET.LINQ2DB
{
    /// <summary>
    /// Класс, описывающий взаимодействие с БД через Linq2DB.
    /// </summary>
    class Linq2DbProvaider : Provider
    {
        /// <summary>
        /// Реализация работы с БД.
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
