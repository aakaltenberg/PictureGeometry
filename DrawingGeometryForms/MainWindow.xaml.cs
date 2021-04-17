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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
        public void ClickEnter(object sender, RoutedEventArgs e)
        {
            IFigure figure = null;
            switch (SelectedFigureString)
            {
                case "rectangle":
                    //рисуем квадрат или прямоугольник
                    figure = new Rectangle
                    {
                        LineColor = SelectedColor,
                        Width = double.Parse(inputedWidth.Text),
                        Height = double.Parse(inputedHeight.Text),
                        LineThickness = double.Parse(inputedLineThiсkness.Text),
                        CenterX = double.Parse(inputedCenterX.Text),
                        CenterY = double.Parse(inputedCenterY.Text)
                    };
                    break;

                case "ellipse":
                    // рисуем овал или круг
                    figure = new Ellipse
                    {
                        LineColor = SelectedColor,
                        Width = double.Parse(inputedWidth.Text),
                        Height = double.Parse(inputedHeight.Text),
                        LineThickness = double.Parse(inputedLineThiсkness.Text),
                        CenterX = double.Parse(inputedCenterX.Text),
                        CenterY = double.Parse(inputedCenterY.Text)
                    };
                    break;
                case "triangle":
                    // рисуем треугольник
                    figure = new Triangle
                    {
                        CenterX = double.Parse(inputedCenterX.Text),
                        CenterY = double.Parse(inputedCenterY.Text),
                        Height = double.Parse(inputedHeight.Text),
                        LineColor = SelectedColor,
                        LineThickness = double.Parse(inputedLineThiсkness.Text),
                    };
                    break;
            }
            figure.Draw(canvas, OnFigureMouseDown);
            figures.Add(figure);
        }
        private void RefreshScene()
            // заново отрисовываем все фигуры
        {
            canvas.Children.Clear();
            foreach (var figure in figures)
            {
                figure.Draw(canvas, OnFigureMouseDown);
            }
        }
        
        private void OnFigureMouseDown(object sender, MouseButtonEventArgs e)  // создание обработчика события
                                                                               // нажатия мышки на фигуру
        {
            var clickedShape = (Shape)sender;  // создаем переменную для временного хранения
                                               // выделенного объекта из базового класса Shape
                                               // видимо, просто ради удобочитаемого названия, явно прописываем тип объекта
            foreach (var figure in figures)
            {
                figure.IsSelected = false;
                if (figure.HasShape(clickedShape)) // содержиться ли в листе shapes выделенный
                                                   // объект (может быть часть фигуры, например, линия)
                {
                    figure.IsSelected = true;
                }
            }
            RefreshScene();
            canvas.MouseMove += OnSelectedFigureMouseMove;
            canvas.MouseLeftButtonUp += OnSelectedFigureMouseUp;
            e.Handled = true;
        }

        private void OnSelectedFigureMouseUp(object sender, MouseButtonEventArgs e)
        {
            canvas.MouseMove -= OnSelectedFigureMouseMove;
            canvas.MouseLeftButtonUp -= OnSelectedFigureMouseUp;
        }

        private void OnSelectedFigureMouseMove(object sender, MouseEventArgs e)
        {
            foreach (var figure in figures.Where(x => x.IsSelected))
            {
                figure.CenterX = e.GetPosition(canvas).X;
                figure.CenterY = e.GetPosition(canvas).Y;

            }
            RefreshScene();
        }

        private void ClickUp(object sender, RoutedEventArgs e)
        {
            var dy = 15;
            canvas.Children.Clear();
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            if (figure == null)
            {
                return;
            }
            figure.CenterY -= dy;
            figure.Draw(canvas, OnFigureMouseDown);
            RefreshScene();
        }


        private void ClickDown(object sender, RoutedEventArgs e)
        {
            var dy = 15;
            canvas.Children.Clear();
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            if (figure == null)
            {
                return;
            }
            figure.CenterY += dy;
            figure.Draw(canvas, OnFigureMouseDown);
            RefreshScene();
        }

        private void ClickLeft(object sender, RoutedEventArgs e)
        {
            var dx = 15;
            canvas.Children.Clear();
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            if (figure == null)
            {
                return;
            }
            figure.CenterX -= dx;
            figure.Draw(canvas, OnFigureMouseDown);
            RefreshScene();
        }

        private void ClickRight(object sender, RoutedEventArgs e)
        {
            var dx = 15;
            canvas.Children.Clear();
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            if (figure == null)
            {
                return;
            }
            figure.CenterX += dx;
            figure.Draw(canvas, OnFigureMouseDown);
            RefreshScene();
        }
        private void leftMouseOnCanvas(object sender, MouseButtonEventArgs e)
        {
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            if (figure == null)
            {
                return;
            }
            figure.IsSelected = false;

            RefreshScene();
        }
        private void clickDeleteFigure(object sender, RoutedEventArgs e)
        {
            var figure = figures.FirstOrDefault(x => x.IsSelected);
            figures.Remove(figure);
            RefreshScene();
        }
    }
}