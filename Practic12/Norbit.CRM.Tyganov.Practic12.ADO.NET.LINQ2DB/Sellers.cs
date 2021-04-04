using System;
using LinqToDB.Mapping;

namespace Norbit.CRM.Tyganov.Practic12.ADO.NET.LINQ2DB
{
    /// <summary>
    /// Класс, описывающий работника-продавца.
    /// </summary>
    [Table(Name = "Sellers")]
    public class Sellers
    {
        public Action ToStringChosen;
        /// <summary>
        /// Номер продавца.
        /// </summary>
        [PrimaryKey]
        public int IdSeller { get; set; }

        /// <summary>
        /// Имя работника.
        /// </summary>
        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        /// <summary>
        /// Стаж работы.
        /// </summary>
        [Column(Name = "Experience")]
        public int Experience { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [Column(Name = "PhoneNumber"), NotNull]
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Номер позиции в базе должностей.
        /// </summary>
        [Column(Name = "IdPosition"), NotNull]
        public int IdPositions { get; set; }
        

        // Поля ниже принадлежат другой таблице - таблице должностей.

        /// <summary>
        /// Наименование должности.
        /// </summary>
        [Column(Name = "NamePosition")]
        public string NamePosition { get; set; }

        /// <summary>
        /// Описание рабочих обязанностей соответствующей должности.
        /// </summary>
        [Column(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Sellers()
        { }

        /// <summary>
        /// Конструктор с параметрами, используется для inner join запроса.
        /// </summary>
        /// <param name="id">Номер.</param>
        /// <param name="name">Имя.</param>
        /// <param name="experince">Опыт.</param>
        /// <param name="namePosition">Должность.</param>
        public Sellers (int id, string name, int experince, string namePosition)
        {
            if (id == null || string.IsNullOrEmpty(name) ||
               experince == null ||  string.IsNullOrEmpty(namePosition))
            {
                throw new ArgumentNullException();
            }
            IdSeller = id;
            Name = name;
            Experience = experince;
            NamePosition = namePosition;
        }

        /// <summary>
        /// Переопределенный метод ToString для первого и второго случаев случая.
        /// </summary>
        /// <returns></returns>

        public override string ToString() =>
            $"Id работника {IdSeller}, Имя {Name}," +
            $" Номер телефона {PhoneNumber}, Должность {IdPositions}";

        //public override string ToString()
        //{
        //    return $"№ {IdSeller} Имя {Name} Стаж {Experience} Должность {NamePosition}";
        //}
    }
}
