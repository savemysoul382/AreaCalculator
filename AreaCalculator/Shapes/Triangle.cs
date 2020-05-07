using System;
using AreaCalculator.Interfaces;

namespace AreaCalculator.Shapes
{
    public class Triangle : IShape
    {
        #region Properties
        
        public Double ASide { get; }

        public Double BSide { get; }

        public Double CSide { get; }

        public Double Area
        {
            get
            {
                Double p = (ASide + BSide + CSide) / 2;
                return Math.Sqrt(d: p * (p - ASide) * (p - BSide) * (p - CSide));
            }
        }

        #endregion

        #region Constructor

        public Triangle(Double a_side, Double b_side, Double c_side)
        {
            if (a_side <= 0 || b_side <= 0 || c_side <= 0)
            {
                throw new ArgumentException(message: "Значение не может быть отрицательным.");
            }

            if (a_side > b_side + c_side || b_side > a_side + c_side || c_side > a_side + b_side)
            {
                throw new ArgumentException(message: "Одна сторона треугольника больше суммы двух других сторон. Такой треугольник не может существовать.");
            }

            this.ASide = a_side;
            this.BSide = b_side;
            this.CSide = c_side;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        /// <returns>true - прямоугольный, иначе false</returns>
        public Boolean IsTriangleRight()
        {
            return (ASide == Math.Sqrt(Math.Pow(BSide, 2) + Math.Pow(CSide, 2)) || BSide == Math.Sqrt(Math.Pow(ASide, 2) + Math.Pow(CSide, 2)) || CSide == Math.Sqrt(Math.Pow(ASide, 2) + Math.Pow(BSide, 2)));
        }

        #endregion
    }
}