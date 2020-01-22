using System;
using System.Drawing;

namespace MyGame
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        Bitmap image = new Bitmap("..\\..\\img/asteroid.png");
        protected Random random = new Random();

        /// <summary>Инициализирует объект BaseObject</summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>Метод отрисовки объекта</summary>
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>Метод обновления местоположения объекта</summary>
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width - Size.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
        }
    }
}

