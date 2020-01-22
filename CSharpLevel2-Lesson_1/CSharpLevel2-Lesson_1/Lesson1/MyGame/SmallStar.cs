using System;
using System.Drawing;

namespace MyGame
{
    class SmallStar : BaseObject
    {
        public SmallStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = Convert.ToInt32(random.NextDouble() * (double)Game.Height);
            }

            }
    }
}
