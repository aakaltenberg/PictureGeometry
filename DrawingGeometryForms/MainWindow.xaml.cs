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
        public string SelectedFigureString { get; set; }
        public string SelectedColorString { get; set; }
        int index { get; set; }

        /// <summary>
        /// Лист, содержащий фигуры, созданных на основе интерфейса IFigure
        /// </summary>
        private List<IFigure> figures = new List<IFigure>();
        
        /// <summary>
        /// Лист доступных фигур для скролящегося поля
        /// </summary>
        public List<string> AvailableFigures => new List<string> { "rectangle", "ellipse", "triangle" }; //для списка figures
        
        /// <summary>
        /// Лист доступных цветов для скролящегося поля
        /// </summary>
        public List<string> AvailableColors => new List<string> { "Black", "Blue", "Red", "Green", "Yellow" };  //для списка colors
        
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

        private void CheckCrash()
        {
            for (int i = 0; i < figures.Count; i++)
            {
                IFigure figure = figures[i];
                for (int j = i + 1; j < figures.Count -1; j++)
                {
                    IFigure figure2 = figures[j];
                    if (CheckCrash(figure, figure2))
                    {
                        continue;
                    }
                }
            }
        }

        private bool CheckCrash(IFigure figure1, IFigure figure2)
        {
            if (figure1 == figure2)
            {
                return false;
            }
            for (int i = 0; i < figure2.ShapeCircleX.Count; i++)
            {
                for (int j = 0; j < figure1.ShapeCircleX.Count; j++)
                {
                    if (figure2.ShapeCircleX[i] == figure1.ShapeCircleX[j])
                    {
                        if (figure2.ShapeCircleY[i] == figure1.ShapeCircleY[j])
                        {
                            figure1.dx = -figure1.dx;
                            figure2.dx = -figure2.dx;
                            figure1.dy = -figure1.dy;
                            figure2.dy = -figure2.dy;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Метод для смещение фигуы на 1 пиксель каждый тик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            CheckCrash();
            
            foreach (var figure in figures)
            {
                if (figure.UpperLeftAngleX + figure.Width == canvas.Width)
                {
                    figure.dx = -figure.dx;
                    figure.UpperLeftAngleX += figure.dx;
                }
                else if (figure.UpperLeftAngleY + figure.Height == canvas.Height)
                {
                    figure.dy = -figure.dy;
                    figure.UpperLeftAngleY += figure.dy;
                }
                else if (figure.UpperLeftAngleX == 0)
                {
                    figure.dx = -figure.dx;
                    figure.UpperLeftAngleX += figure.dx;
                }
                else if (figure.UpperLeftAngleY == 0)
                {
                    figure.dy = -figure.dy;
                    figure.UpperLeftAngleY += figure.dy;
                }
                
                figure.UpperLeftAngleX += figure.dx;
                figure.UpperLeftAngleY += figure.dy;
                RefreshScene();
                figure.RefreshShapeCircleXY();
            }
        }

        /// <summary>
        /// Стираем всё с канваса, заново отрисовываем
        /// </summary>
        private void RefreshScene()
        {
            canvas.Children.Clear();
            foreach (var figure in figures)
            {
                figure.Draw(canvas, OnFigureMouseDown, DrawingFigureLeftButtonUp);
            }
        }

        /// <summary>
        /// обработчик нажатия ЛКМ на канвас => рисует выбранную фигуры с дефолтными пропертями из BaseFigure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOnCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        /// <summary>
        /// изменение пропертей фигуры при зажатой мышке во время отрисовки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawingFigureMoveMouse(object sender, MouseEventArgs e)
        {
            var figure = figures.Last();
            figure.Height = e.GetPosition(canvas).Y - figure.UpperLeftAngleY;    
            figure.Width = e.GetPosition(canvas).X - figure.UpperLeftAngleX;
            RefreshScene();
            e.Handled = true;
        }

        /// <summary>
        /// Отработка поднятия ЛКМ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawingFigureLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas.MouseMove -= DrawingFigureMoveMouse;
            canvas.MouseMove -= OnSelectedFigureMouseMove;
            canvas.PreviewMouseLeftButtonUp -= DrawingFigureLeftButtonUp;
        }


        /// <summary>
        /// Обработка события опускания ЛКМ на фигуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Перемещение выбранной фигуры по типу преследования курсора мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectedFigureMouseMove(object sender, MouseEventArgs e)
        {
            foreach (var figure in figures.Where(x => x.IsSelected))
            {
                figure.UpperLeftAngleX = e.GetPosition(canvas).X + figure.dx;
                figure.UpperLeftAngleY = e.GetPosition(canvas).Y + figure.dy;

            }
            RefreshScene();
        }

        /// <summary>
        /// Снятие всех выделений при ПКМ на канвас
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Обработчик кнопки удаления фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickDeleteFigure(object sender, RoutedEventArgs e)
        {
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            figures.Remove(figure);
            RefreshScene();
        }

        public DispatcherTimer timer = new DispatcherTimer();

        /// <summary>
        /// Обработчик кнопки запуска самопроизвольного движения всех фигур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartBtn(object sender, RoutedEventArgs e)
        {
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer.Start();
        }

        /// <summary>
        /// Обработчик кнопки остановки движения фигур по канвасу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopBtn(object sender, RoutedEventArgs e)
        {
            timer.Tick -= timer_Tick;
            timer.Stop();
        }
    }
}