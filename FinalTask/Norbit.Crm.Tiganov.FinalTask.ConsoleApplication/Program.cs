using System;
using System.Net;
using Norbit.CRM.Tyganov.FinalTask.DbLibrary;
using System.IO;
using Newtonsoft.Json;

namespace Norbit.Crm.Tiganov.FinalTask.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GetLastTrade();
            Console.ReadLine();
        }

        /// <summary>
        /// Функция обращается к веб-сервису для получения последней сделки пользователя.
        /// </summary>
        public static void GetLastTrade()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://localhost:44364/api/values/lastTrade");
           
            request.Credentials = CredentialCache.DefaultCredentials;
           
            using(var response = (HttpWebResponse)request.GetResponse())
            {
                using(var stream = new StreamReader(response.GetResponseStream()))
                {
                    var trade = JsonConvert.DeserializeObject<Trade>(stream.ReadToEnd());
                    Console.WriteLine($"Дата {trade.Amount} Сумма {trade.Created}");
                }
            }
        }
    }
}
