using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using System.Text.Json;


namespace Norbit.CRM.Tyganov.FinalTask.DbLibrary
{
    /// <summary>
    /// Провайдер реализует работу с базой данных.
    /// </summary>
    public class Linq2DbProvider
    {
        /// <summary>
        /// Получение последней сделки пользователя.
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>Возвращает Trade - объект сделки.</returns>
        public Trade GetLastTrade(string userName)
        {
            using(var context = new LinqHelper())
            {
                var listTrades = context.Users
                   .Where(user => user.UserDomainName.Contains(userName))
                   .Select(trades => trades.data.Entite).ToList();

                var result = new List<Trade>();

                listTrades
                    .ForEach(x => result
                    .Add(JsonSerializer.Deserialize<Trade>(x)));

                return result
                    .OrderByDescending(x => x.Created)
                    .FirstOrDefault();
            }
        }
    }

    /// <summary>
    /// Вспомогательный класс связывает БД и Trade.
    /// </summary>
    public class LinqHelper : LinqToDB.Data.DataConnection
    {
        /// <summary>
        /// ConfigurationManager не видит key-value пару почему-то. Времени разбираться с этим нет.
        /// </summary>
        private static string _connectionString = @"Data Source=WSAMARA37\SQLEXPRESS;Initial Catalog=LEARN_training01;Integrated Security=True";
        public LinqHelper() : base(ProviderName.SqlServer2017, _connectionString) { }

        public ITable<User> Users => GetTable<User>();
        public ITable<Data> Data => GetTable<Data>();
    }
}
