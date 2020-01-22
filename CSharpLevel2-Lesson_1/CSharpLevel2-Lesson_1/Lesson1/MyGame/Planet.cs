using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyGame
{
    class Planet : BaseObject
    {
        /// <summary>Список картинок для планет</summary>
        List<Bitmap> bitMapList = new List<Bitmap>() {
            new Bitmap("..\\..\\img/planets/moon_03.png"),
            new Bitmap("..\\..\\img/planets/moon_04.png"),
            new Bitmap("..\\..\\img/planets/planet_01.png"),
            new Bitmap("..\\..\\img/planets/planet_02.png"), 
            new Bitmap("..\\..\\img/planets/planet_03.png"), 
            new Bitmap("..\\..\\img/planets/planet_04.png"), 
            new Bitmap("..\\..\\img/planets/planet_05.png"), 
            new Bitmap("..\\..\\img/planets/planet_06.png"), 
            new Bitmap("..\\..\\img/planets/planet_07.png"), 
            new Bitmap("..\\..\\img/planets/planet_08.png"), 
            new Bitmap("..\\..\\img/planets/planet_09.png"), 
            new Bitmap("..\\..\\img/planets/planet_10.png"), 
            new Bitmap("..\\..\\img/planets/planet_11.png"), 
            new Bitmap("..\\..\\img/planets/planet_12.png"), 
            new Bitmap("..\\..\\img/planets/planet_13.png"), 
            new Bitmap("..\\..\\img/planets/planet_14.png"), 
            new Bitmap("..\\..\\img/planets/planet_15.png"), 
            new Bitmap("..\\..\\img/planets/planet_16.png"), 
            new Bitmap("..\\..\\img/planets/planet_17.png") };

        Bitmap image;

        /// <summary>Инициализирует объект Planet при помощи базового конструктора BaseObject</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = bitMapList[random.Next(0,bitMapList.Count)];
        }

        /// <summary>Метод отрисовки объекта</summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>Метод обновления местоположения и изображения объекта</summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                image = bitMapList[random.Next(0, bitMapList.Count)];
                Pos.Y = Convert.ToInt32(random.NextDouble() * (double)Game.Height);
                Size.Width = Convert.ToInt32((random.NextDouble() + 0.5) * Size.Width);
                Size.Height = Size.Width;
                Dir.X = Convert.ToInt32((random.NextDouble() + 0.5) * Dir.X);
            }
        }
    }
}
