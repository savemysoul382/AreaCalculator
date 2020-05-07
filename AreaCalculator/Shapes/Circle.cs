using System;
using AreaCalculator.Interfaces;

namespace AreaCalculator.Shapes
{
    public class Circle : IShape
    {
        #region Properties

        public Double Radius { get; }

        public Double Area { get => Math.PI * Math.Pow(x: Radius, y: 2); }

        #endregion

        #region Constructor

        public Circle(Double radius)
        {
            if (radius <= 0) throw new ArgumentException(message: "Значение не может быть отрицательным.");
            
            Radius = radius;
        }

        #endregion
    }
}