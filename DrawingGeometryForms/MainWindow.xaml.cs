using LibraryDrawingGeometryForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using IFigure = LibraryDrawingGeometryForms.IFigure;
using Ellipse = LibraryDrawingGeometryForms.Ellipse;
using Rectangle = LibraryDrawingGeometryForms.Rectangle;
using Triangle = LibraryDrawingGeometryForms.Triangle;
using System.Globalization;

namespace DrawingGeometryForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double dx = 1;
        double dy = 1;
        private List<IFigure> figures = new List<IFigure>();

        public List<string> AvailableFigures => new List<string> { "rectangle", "ellipse", "triangle" }; //для списка figures
        public string SelectedFigureString { get; set; }

        public List<string> AvailableColors => new List<string> { "Black", "Blue", "Red", "Green", "Yellow" };  //для списка colors
        public string SelectedColorString { get; set; }
        public FigureColor SelectedColor
        {
            get
            {
                switch (SelectedColorString)
                {
                    case "Black":
                        return FigureColor.Black;
                    case "Red":
                        return FigureColor.Red;
                    case "Green":
                        return FigureColor.Green;
                    case "Yellow":
                        return FigureColor.Yellow;
                    case "Blue":
                        return FigureColor.Blue;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var figure = figures.Last();
            if (figure.UpperLeftAngleY + figure.Height >= canvas.Height)
            {
                dy = -dy;
            }
            if (figure.UpperLeftAngleX + figure.Width >= canvas.Width)
            {
                dx = -dx;
            }
            if (figure.UpperLeftAngleX <= 0)
            {
                dx = -dx;
            }
            if (figure.UpperLeftAngleY <= 0)
            {
                dy = -dy;
            }
            Random rnd = new Random();
            int rndMoving = rnd.Next(1, 3);
            switch (rndMoving)
            {
                case 1:
                    figure.UpperLeftAngleX += dx;
                    break;
                case 2:
                    figure.UpperLeftAngleY += dy;
                    break;
            }
            RefreshScene();
        }
        private void RefreshScene()
            // заново отрисовываем все фигуры
        {
            canvas.Children.Clear();
            foreach (var figure in figures)
            {
                figure.Draw(canvas, OnFigureMouseDown, DrawingFigureLeftButtonUp);
            }
        }
        private void ClickOnCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            // обработчик нажатия ЛКМ на канвас => рисует выбранную фигуру с дефолтными пропертями из BaseFigure
        {
            IFigure figure = null;
            switch (SelectedFigureString)
            {
                case "rectangle":
                    //рисуем квадрат или прямоугольник
                    figure = new Rectangle
                    {
                        UpperLeftAngleX = e.GetPosition(canvas).X,
                        UpperLeftAngleY = e.GetPosition(canvas).Y,
                        LineColor = SelectedColor,
                    };
                    break;

                case "ellipse":
                    // рисуем овал или круг
                    figure = new Ellipse
                    {
                        UpperLeftAngleX = e.GetPosition(canvas).X,
                        UpperLeftAngleY = e.GetPosition(canvas).Y,
                        LineColor = SelectedColor,
                    };
                    break;
                case "triangle":
                    // рисуем треугольник
                    figure = new Triangle
                    {
                        UpperLeftAngleX = e.GetPosition(canvas).X,
                        UpperLeftAngleY = e.GetPosition(canvas).Y,
                        LineColor = SelectedColor,
                    };
                    break;
            }
            figure.Draw(canvas, OnFigureMouseDown, DrawingFigureLeftButtonUp);
            figures.Add(figure);
            canvas.MouseMove += DrawingFigureMoveMouse;
            canvas.MouseLeftButtonUp += DrawingFigureLeftButtonUp;
        }
        private void DrawingFigureMoveMouse(object sender, MouseEventArgs e)
        {
            var figure = figures.Last();
            figure.Height = e.GetPosition(canvas).Y - figure.UpperLeftAngleY;    
            figure.Width = e.GetPosition(canvas).X - figure.UpperLeftAngleX;
            RefreshScene();
            e.Handled = true;
        }

        private void DrawingFigureLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas.MouseMove -= DrawingFigureMoveMouse;
            canvas.MouseMove -= OnSelectedFigureMouseMove;
            canvas.PreviewMouseLeftButtonUp -= DrawingFigureLeftButtonUp;
        }

        private void OnFigureMouseDown(object sender, MouseButtonEventArgs e)  // создание обработчика события
                                                                               // нажатия мышки на фигуру
        {
            var clickedShape = (Shape)sender;  // создаем переменную для временного хранения
                                               // выделенного объекта из базового класса Shape
                                               // видимо, просто ради удобочитаемого названия, явно прописываем тип объекта
            foreach (var figure in figures)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift))
                {
                    if (figure.HasShape(clickedShape)) // содержиться ли в листе shapes выделенный
                                                       // объект (может быть часть фигуры, например, линия)
                    {
                        figure.IsSelected = true;
                        figure.dx = (double)figure.UpperLeftAngleX - (double)e.GetPosition(canvas).X;
                        figure.dy = (double)figure.UpperLeftAngleY - (double)e.GetPosition(canvas).Y;
                    }
                }
                else
                {
                    figure.IsSelected = false;
                    if (figure.HasShape(clickedShape)) // содержиться ли в листе shapes выделенный
                                                       // объект (может быть часть фигуры, например, линия)
                    {
                        figure.IsSelected = true;
                        figure.dx = (double)figure.UpperLeftAngleX - (double)e.GetPosition(canvas).X;
                        figure.dy = (double)figure.UpperLeftAngleY - (double)e.GetPosition(canvas).Y;
                    }
                }
            }
            RefreshScene();
            canvas.MouseMove += OnSelectedFigureMouseMove;
            canvas.MouseLeftButtonUp += DrawingFigureLeftButtonUp;
            e.Handled = true; //говорит программе, что событие совершилось, дальше можно не идти по обработчикам
                              //объекты на канвасе идут слоями, children находятся
                              //выше по условной апликате и обрабатываются первыми обычно
                              //что-то вроде break
        }

        private void OnSelectedFigureMouseMove(object sender, MouseEventArgs e)
            // перемещение выбранной фигуры по типу преследования курсора мыши
        {
            foreach (var figure in figures.Where(x => x.IsSelected))
            {
                figure.UpperLeftAngleX = e.GetPosition(canvas).X + figure.dx;
                figure.UpperLeftAngleY = e.GetPosition(canvas).Y + figure.dy;

            }
            RefreshScene();
        }
        private void RightMouseOnCanvas(object sender, MouseButtonEventArgs e)
        {
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            if (figure == null)
            {
                return;
            }
            figure.IsSelected = false;

            RefreshScene();
        }
        private void ClickDeleteFigure(object sender, RoutedEventArgs e)
        {
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            figures.Remove(figure);
            RefreshScene();
        }

        private void StartBtn(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer.Start();
        }
        private void StopBtn(object sender, RoutedEventArgs e)
        {
        }
        
    }
}