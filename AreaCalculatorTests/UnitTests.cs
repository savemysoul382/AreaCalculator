using System;
using AreaCalculator;
using AreaCalculator.Shapes;
using NUnit.Framework;

namespace AreaCalculatorTests
{
    public class UnitTests
    {
        [Test]
        [Description(description: "Площадь треугольника с корректными входными данными")]
        public void TriangleCalculateAreaNormal()
        {
           Triangle triangle = new Triangle(a_side: 2, b_side: 3, c_side: 4);

            Double expected_area = GetArea(a_side: 2, b_side: 3, c_side: 4);
            
            Double result_area = triangle.Area;

            Double GetArea(Double a_side, Double b_side, Double c_side)
            {
                Double p = (a_side + b_side + c_side) / 2;
                return Math.Sqrt(d: p * (p - a_side) * (p - b_side) * (p - c_side));
            }

            Assert.AreEqual(expected: expected_area, actual: result_area);
        }

        [Test]
        [Description(description: "Площадь треугольника, одна сторона больше чем сумма двух других")]
        public void TriangleCalculateAreaNegativeValue()
        {
            Assert.Throws<ArgumentException>(code: () =>
            {
                Triangle triangle = new Triangle(a_side: 5, b_side: 1, c_side: 2);
            });
        }

        [Test]
        [Description(description: "Площадь треугольника, одна из сторон 0 или отрицательная")]
        public void TriangleCalculateAreaOneSideNegative()
        {
            //с шансом 1к3 будет выбираться рандомная сторона для установки негативного значения
            Int32 negative_side = Helper.GetInt32(right: 100);
            Int32 negative_value = Helper.GetInt32(min: -10000, max: 0);

            Assert.Throws<ArgumentException>(code: () =>
            {
                Triangle triangle = new Triangle(
                    a_side: negative_side <= 33 ? negative_value : 2,
                    b_side: negative_side > 33 && negative_side <= 66 ? negative_value : 3,
                    c_side: negative_side > 66 ? negative_value : 4);
            });
        }

        [Test]
        [Description(description: "Площадь круга с корректными входными данными")]
        public void CircleCalculateAreaNormal()
        {
            Double radius = Helper.GetInt32();
            Circle circle = new Circle(radius: radius);

            Double expected_area = Math.PI * Math.Pow(x: radius, y: 2);
            Double result_area = circle.Area;
           
            Assert.AreEqual(expected: expected_area, actual: result_area);
        }

        [Test]
        [Description(description: "Площадь круга с 0 или отрицательным значением")]
        public void CircleCalculateAreaNegativeValue()
        {
            Double radius = Helper.GetInt32(min: -10000, max: 0);

            Assert.Throws<ArgumentException>(code: () =>
            {
                Circle circle = new Circle(radius: radius);
            });
        }

        [Test]
        [Description(description: "Вычисление площади не знаю типа фигуры")]
        public void CalculateAreaUnknownShape()
        {
            Double radius = Helper.GetInt32();
            Circle circle = new Circle(radius: radius);
            Shape shape = new Shape(shape: circle);

            Double expected_area = circle.Area;
            Double result_area = shape.Area;

            Assert.AreEqual(expected: expected_area, actual: result_area);
        }

        [Test]
        [Description(description: "Является ли треугольник прямоугольным - является")]
        public void IsTriangleRightPositive()
        {
            Triangle triangle = new Triangle(a_side: 9, b_side: 12, c_side: 15);
            Boolean is_right = triangle.IsTriangleRight();

            Assert.IsTrue(condition: is_right);
        }

        [Test]
        [Description(description: "Является ли треугольник прямоугольным - не является")]
        public void IsTriangleRightNegative()
        {
            Triangle triangle = new Triangle(a_side: 8, b_side: 6, c_side: 7);
            Boolean is_right = triangle.IsTriangleRight();
            
            Assert.IsFalse(condition: is_right);
        }
    }
}
