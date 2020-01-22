using System;
using System.Drawing;
using System.Collections.Generic;

namespace MyGame
{
    class Star : BaseObject
    {
        /// <summary>Список картинок для анимации звёзд</summary>
        List<Bitmap> bitMapList = new List<Bitmap>() { new Bitmap("..\\..\\img/stars/star1.png"),
            new Bitmap("..\\..\\img/stars/star2.png"), new Bitmap("..\\..\\img/stars/star3.png"),
            new Bitmap("..\\..\\img/stars/star4.png"), new Bitmap("..\\..\\img/stars/star5.png"),
            new Bitmap("..\\..\\img/stars/star6.png"), new Bitmap("..\\..\\img/stars/star7.png") };

        int starsForm = 0;
        
        /// <summary>Инициализирует объект Star при помощи базового конструктора BaseObject</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>Метод отрисовки объекта</summary>
        public override void Draw()
        {
            starsForm++;
            if (starsForm == bitMapList.Count)
                starsForm = 0;
            Game.Buffer.Graphics.DrawImage(bitMapList[starsForm], Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>Метод обновления местоположения объекта</summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width) Pos.X = Game.Width + Size.Width;

        }
    }
}
