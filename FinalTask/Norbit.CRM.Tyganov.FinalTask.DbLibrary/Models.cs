using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;
using System.Xml.Serialization;

namespace Norbit.CRM.Tyganov.FinalTask.DbLibrary
{
    /// <summary>
    /// Модель пользователя.
    /// </summary>
    [Table(Name ="User")]
    public class User
    {
        [PrimaryKey]
        public string Id { get; set; }

        [Column(Name ="UserDomainName")]
        public string UserDomainName { get; set; }

        /// <summary>
        /// Связь 1:N
        /// </summary>
        [Association(ThisKey ="Id", OtherKey ="UserId")]
        public Data data { get; set; }

        public override string ToString()
        {
            return $"User {UserDomainName}";
        }
    }

    /// <summary>
    /// Модель таблицы Data.
    /// </summary>
    [Table(Name ="Data")]
    public class Data
    {
        [PrimaryKey]
        public string Id { get; set; }

        [Column(Name ="UserId")]
        public string UserId { get; set; }

        [Column(Name ="Entity")]
        public string Entite { get; set; }
    }
}
