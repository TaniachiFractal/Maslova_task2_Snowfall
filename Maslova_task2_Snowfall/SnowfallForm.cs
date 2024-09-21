using System;
using System.Drawing;
using System.Windows.Forms;
using Maslova_task2_Snowfall.Classes;

namespace Maslova_task2_Snowfall
{
    /// <summary>
    /// The main animation form
    /// Основная форма анимации
    /// </summary>
    public partial class SnowfallForm : Form
    {
        /// <summary>
        /// The main drawing canvas
        /// Основное полe для рисования
        /// </summary>
        private readonly Graphics canvas;

        /// <summary>
        /// Base constructor: Init timer, Init snowflakes
        /// Базовый конструктор: инициализация таймера, снежинок
        /// </summary>
        public SnowfallForm()
        {
            InitializeComponent();

            canvas = pbCanvas.CreateGraphics();

            Snowflake.Snowflakes(50, Height, Width);

            var animTimer = new Timer
            {
                Interval = 30
            };
            animTimer.Tick += AnimTimer_Tick;
            animTimer.Start();
        }

        /// <summary>
        /// Animate snowflakes
        /// Анимировать снежинки
        /// </summary>
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            var newImage = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            var newGraphics = Graphics.FromImage(newImage);
            newGraphics.DrawImage(Snowflake.SnowforestImg, 0, 0);
            foreach (var snowflake in Snowflake.Snowflakes())
            {
                snowflake.MoveSnowflake(Height);
                newGraphics.RotateTransform(snowflake.flyRotation);
                newGraphics.DrawImage(Snowflake.SnowflakeImg, new Rectangle(snowflake.X, snowflake.Y, snowflake.size, snowflake.size));
            }
            canvas.DrawImage(newImage, 0, 0);
        }
    }
}
