using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norbit.CRM.Tyganov.Practic7.OOP
{
    /// <summary>
    /// Вспомогательный класс для задания точки.
    /// </summary>
    public class Point
    {
        private int _x;
        private int _y;

        /// <summary>
        /// Конструктор точки.
        /// </summary>
        /// <param name="x">Координата Х.</param>
        /// <param name="y">Координата Y.</param>
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Координата Х.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y.
        /// </summary>
        public int Y { get; set; }

    }

    /// <summary>
    /// Класс окружность.
    /// </summary>
    class Round
    {
        private double _radius;
        private double _diameter;

        /// <summary>
        /// Центр.
        /// </summary>
        public Point Center { get; set; }

        /// <summary>
        /// Радиус.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Радиус не может быть меньше 0");
                }

                _radius = value;
            }
        }
        
        /// <summary>
        /// Диаметр.
        /// </summary>
        public double Diameter
        {
            get => _diameter = _radius * 2;
            set
            {
                if (_radius > value)
                {
                    throw new ArgumentOutOfRangeException("Диаметр не может быть меньше радиуса!");
                }

                _diameter = _radius * 2;
            }

        }

        /// <summary>
        /// Конструктор окружности.
        /// </summary>
        /// <param name="center">Координаты центра.</param>
        /// <param name="radius">Радиус окружности.</param>
        public Round(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Найти длину окружности.
        /// </summary>
        /// <returns></returns>
        public double GetLength() => 2 * Math.PI * Radius;

        /// <summary>
        /// Найти площадь окружности.
        /// </summary>
        /// <returns></returns>

        public double GetSquare() => Math.PI * Math.Pow(Radius, 2);
    }

    /// <summary>
    /// Класс шар.
    /// </summary>
    class Ball : Round
    {

        /// <summary>
        /// Объем шара.
        /// </summary>
        public double Volume
        {
            get => Math.PI * Math.Pow(Diameter, 3) / 6;
            set
            {
                if (value != Math.PI * Math.Pow(Diameter, 3) / 6)
                    throw new ArgumentOutOfRangeException("Иди учи матешу.");
                _ = value;
            }
        }

        /// <summary>
        /// Конструктор, принимающий в качесвте параметра окружность,
        /// Ссылается на конструктор ниже.
        /// </summary>
        /// <param name="round">Окружность.</param>
        public Ball(Round round) : this(round.Center, round.Radius)
        {
        }

        /// <summary>
        /// Базовый конструктор, ссылается на конструктор окружности.
        /// </summary>
        /// <param name="center">Координаты центра.</param>
        /// <param name="radius">Радиус.</param>

        public Ball(Point center, double radius) : base(center, radius)
        {
        }

       
    }
}
