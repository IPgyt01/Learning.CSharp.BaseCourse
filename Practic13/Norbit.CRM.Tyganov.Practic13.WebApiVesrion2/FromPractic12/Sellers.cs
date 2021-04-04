using LinqToDB.Mapping;

namespace Norbit.CRM.Tyganov.Practic13.WebApiVesrion2
{
    /// <summary>
    /// Класс, описывающий работника-продавца.
    /// </summary>
    [Table(Name = "Sellers")]
    public class Sellers
    {
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
        [Column(Name = "Experience"), NotNull]
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

        public Sellers(int idSeller, string name, int experience, int phoneNumber, int idPositions)
        {
            IdSeller = idSeller;
            Name = name;
            Experience = experience;
            PhoneNumber = phoneNumber;
            IdPositions = idPositions;
        }

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Sellers()
        {
        }

        /// <summary>
        /// Переопределенный метод ToString для первого случая.
        /// </summary>
        /// <returns></returns>

        public override string ToString() =>
            $"Id работника {IdSeller}, Имя {Name}," +
            $" Номер телефона {PhoneNumber}, Опыт работы {Experience} Должность {IdPositions}";
    }
}
