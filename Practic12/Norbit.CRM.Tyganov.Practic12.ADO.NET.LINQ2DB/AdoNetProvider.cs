using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Norbit.CRM.Tyganov.Practic12.ADO.NET.LINQ2DB
{
    /// <summary>
    /// Реализация взаимодействия с БД через ADO.NET.
    /// </summary>
    class AdoNetProvider : Provider
    {
        /// <summary>
        /// Непосредственно взаимодействие с БД.
        /// </summary>
        /// <returns></returns>
        public override List<Sellers> GetSellers()
        {
            var query = @"SELECT [IdSeller], [Name], [Experience], [NamePosition]
                    FROM [WebPortalDataBase].[dbo].[Sellers] sel
                    INNER JOIN Position p ON p.IdPosition = sel.IdPosition";
            var sellers = new List<Sellers>();
            using (var context = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, context);
                try
                {
                    context.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        sellers.Add(new Sellers(
                            (int)reader[0],
                            (string)reader[1],
                            (int)reader[2],
                            (string)reader[3]));
                    }
                    reader.Close();
                    context.Close();
                }
                catch (SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return sellers;
        }
    }
}
