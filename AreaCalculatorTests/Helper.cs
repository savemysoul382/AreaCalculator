using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculatorTests
{
    public static class Helper
    {
        private static readonly Random random = new Random();
        /// <summary>
        /// Получить случайное неотрицательное значение Int32
        /// </summary>
        /// <returns>Случайное неотрицательное значение Int32</returns>
        public static Int32 GetInt32()
        {
            return random.Next();
        }

        /// <summary>
        /// Получить случайное неотрицательное значение Int32 в диапазоне от 0 до указанного числа включительно
        /// </summary>
        /// <param name="right"></param>
        /// <returns>Случайное неотрицательное значение Int32 в диапазоне от 0 до указанного числа включительно</returns>
        public static Int32 GetInt32(Int32 right)
        {
            return random.Next(minValue: 0, maxValue: right + 1);
        }

        /// <summary>
        /// Получить случайное значение Int32 в указанном диапазоне (включительно)
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns>Случайное значение Int32 в указанном диапазоне</returns>
        public static Int32 GetInt32(Int32 min, Int32 max)
        {
            return random.Next(
                minValue: min,
                maxValue: max + 1);
        }
    }
}
