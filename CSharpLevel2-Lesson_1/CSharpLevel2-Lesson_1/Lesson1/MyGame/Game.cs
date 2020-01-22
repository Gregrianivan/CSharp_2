using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;

        const int commonSpeed = 6;
        const int planetSpeed = 3;
        const int numOfPlanets = 3;
        const int numOfStars = 30;
        const int numOfAsteroids = 15;
        const int numOfSmallStars = 50;
        const int maxSize = 30;
        const int minSize = 10;



        /// <summary>Ширина окна</summary>
        public static int Width { get; set; }
        /// <summary>Высота окна</summary>
        public static int Height { get; set; }

        static Game()
        {
        }

        /// <summary>Метод создания объектов в окне</summary>
        public static void Load()
        {
            Random rand = new Random();
            _objs = new BaseObject[numOfStars + numOfAsteroids + numOfPlanets + numOfSmallStars];

            for (int i = 0; i < _objs.Length - numOfStars - numOfPlanets - numOfAsteroids; i++)
            {
                _objs[i] = new SmallStar(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)), new Point(rand.Next(-commonSpeed, -1), 0), new Size(1, 1));
            }

            for (int i = _objs.Length - numOfStars - numOfPlanets - numOfAsteroids; i < _objs.Length - numOfPlanets - numOfAsteroids; i++)
            {
                int size = rand.Next(minSize/2, maxSize/2);
                _objs[i] = new Star(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)), new Point(rand.Next(-commonSpeed * 2, -1), 0), new Size(size, size));
            }

            for (int i = _objs.Length  - numOfPlanets - numOfAsteroids; i < _objs.Length - numOfAsteroids; i++)
            {
                int size = rand.Next(minSize * 3, maxSize * 3);
                _objs[i] = new Planet(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)), new Point(rand.Next(-planetSpeed / 2, -1), 0), new Size(size, size));
            }

            for (int i = _objs.Length - numOfAsteroids; i < _objs.Length; i++)
            {
                int size = rand.Next(minSize, maxSize);
                _objs[i] = new BaseObject(new Point(Convert.ToInt32(rand.NextDouble() * (double)(Game.Width - size)),
                    Convert.ToInt32(rand.NextDouble() * (double)(Game.Height - size))), new Point(rand.Next(-commonSpeed, commonSpeed),
                    rand.Next(-commonSpeed, commonSpeed)), new Size(size, size));
            }
        }

        /// <summary>Таймер для отрисовки</summary>
        static public Timer timer = new Timer { Interval = 100 };

        /// <summary>Метод создания графики в форме </summary>
        /// <param name="form">Форма</param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            timer.Start();
            timer.Tick += Timer_Tick;

        }

        /// <summary>Метод обработки события счёта таймера</summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Параметры события</param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>Метод отрисовки объектов</summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        /// <summary>Метод обновления объектов на форме</summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

    }
}

