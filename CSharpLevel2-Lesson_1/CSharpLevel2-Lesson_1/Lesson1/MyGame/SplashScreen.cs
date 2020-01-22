using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;

        //const int commonSpeed = 3;
        //const int planetSpeed = 1;
        //const int numOfPlanets = 1;
        //const int numOfStars = 1;
        //const int numOfAsteroids = 1;
        //const int numOfSmallStars = 50;
        //const int maxSize = 30;
        //const int minSize = 10;
        //const int planetSize = 600;


        /// <summary>Ширина окна</summary>
        public static int Width { get; set; }
        /// <summary>Высота окна</summary>
        public static int Height { get; set; }

        static SplashScreen()
        {
        }

        /// <summary>Метод создания объектов в окне</summary>
        public static void Load()
        {
            
        }

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
            //Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        /// <summary>Метод обработки события счёта таймера</summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Параметры события</param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            //Update();
        }

        /// <summary>Метод отрисовки объектов</summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Render();
        }

        /// <summary>Метод обновления объектов на форме</summary>
        public static void Update()
        {
           
        }


    }
}
