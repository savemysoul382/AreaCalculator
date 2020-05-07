using System;
using AreaCalculator.Interfaces;

namespace AreaCalculator
{
    public class Shape : IShape
    {
        #region Fields

        private readonly IShape shape;

        #endregion

        #region Properties

        public Double Area { get => this.shape.Area; }

        #endregion

        #region Constructor

        public Shape(IShape shape)
        {
            this.shape = shape;
        }

        #endregion
    }
}
