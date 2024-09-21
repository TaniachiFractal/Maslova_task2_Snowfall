using System;
using System.Collections.Generic;
using System.Drawing;

namespace Maslova_task2_Snowfall.Classes
{
    /// <summary>
    /// Properties of a snowflake
    /// Свойства снежинки
    /// </summary>
    internal class Snowflake
    {
        /// <summary>
        /// The image of a snowflake
        /// Картинка снежинки
        /// </summary>
        public readonly static Image SnowflakeImg = Properties.Resources.snowflake;
        /// <summary>
        /// The image of a forest
        /// Картинка леса
        /// </summary>
        public readonly static Image SnowforestImg = Properties.Resources.snowforest;

        #region fields
        /// <summary>
        /// x coord of a snowflake
        /// координата x снежинки
        /// </summary>
        public int X;
        /// <summary>
        /// y coord of a snowflake
        /// координата y снежинки
        /// </summary>
        public int Y;
        /// <summary>
        /// The angle of a snowflake flight
        /// Угол полёта снежинки
        /// </summary>
        public float flyRotation;
        /// <summary>
        /// The width and the height of a square snowflake image
        /// Ширина и высота квадратного изображения снежинки.
        /// </summary>
        public int size;
        /// <summary>
        /// The fall speed
        /// Скорость падения
        /// </summary>
        private double fallSpeed;
        /// <summary>
        /// The stating fall speed
        /// Начальная скорость падения
        /// </summary>
        private readonly int startFallSpeed;
        #endregion

        /// <summary>
        /// Create a snowflake with random size, location, speed according to the target field size
        /// Создать снежинку случайного размера, местоположения и скорости в соответствии с размером целевого поля.
        /// </summary>
        public Snowflake(int fieldHeight, int fieldWidth, Random rnd)
        {
            size = rnd.Next(SnowflakeImg.Width / 6, SnowflakeImg.Width);
            X = rnd.Next(-20, fieldWidth - 10);
            Y = rnd.Next(-fieldHeight, -size * 3);
            startFallSpeed = size / 10;
            fallSpeed = startFallSpeed;
            flyRotation = 0.3f * rnd.Next(-1, 1);
        }


        /// <summary>
        /// The list of snowflakes
        /// Лист снежинок
        /// </summary>
        private static List<Snowflake> snowflakes;
        /// <summary>
        /// Generate the list of snowflakes
        /// Сгенерировать лист снежинок
        /// </summary>
        public static void Snowflakes(int count, int fieldHeight, int fieldWidth)
        {
            var rnd = new Random();
            snowflakes = new List<Snowflake>();
            for (var i = 0; i < count; i++)
            {
                snowflakes.Add(new Snowflake(fieldHeight, fieldWidth, rnd));
            }

        }
        /// <summary>
        /// Get snowflake list
        /// Получить лист снежинок
        /// </summary>
        public static List<Snowflake> Snowflakes()
        {
            return snowflakes;
        }


        /// <summary>
        /// Move the snowflake down or teleport it to the top
        /// Переместь снежинку вниз или телепортировать наверх
        /// </summary>
        public void MoveSnowflake(int fieldHeight)
        {
            Y += (int)fallSpeed;
            fallSpeed += 0.01;
            if (Y - 100 > fieldHeight)
            {
                Y = -size;
                fallSpeed = startFallSpeed;
            }
        }
    }
}
