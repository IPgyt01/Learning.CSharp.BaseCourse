using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Configuration;



namespace Norbit.CRM.Tyganov.Practic5.SerializationLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            TrySerialization();
        }


        static void TrySerialization()
        {
            var data = new List<Person>
            {
               new Person
               {
                  FirstName = "Ivan",
                  LastName = "Ivanov",
                  Age = 20,
                  Company = "Norbit",
                  Position = "Programmer" 
               },
               new Person
               {
                  FirstName = "Kate",
                  LastName = "Ivanova",
                  Age = 30,
                  Company = "Google",
                  Position = "Marketer" 
               },
               new Person
               {
                   FirstName = "Vasya",
                   LastName = "Kotov",
                   Age = 23,
                   Company = "Yandex", 
                   Position = "Product Manager" 
               }
            };

            // Записать в Json файл (путь в App.config) с помощью сериализации.           
            File.WriteAllText(ConfigurationManager.AppSettings.Get("DestFolder"),
                JsonSerializer.Serialize(data.ToArray()));
            
           //Десериализовать из Json файла (путь в App.config).
            JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(
                ConfigurationManager.AppSettings.Get("DestFolder")));
            Console.ReadLine();

        }
    }
}
