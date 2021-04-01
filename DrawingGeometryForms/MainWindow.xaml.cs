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

namespace DrawingGeometryForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IFigure> figures = new List<IFigure>();
        public List<string> AvailableColors => new List<string> { "Black", "Blue", "Red", "Green", "Yellow"};

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
            switch (inputedNameFigure.Text)
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
                    figure.Draw(canvas);
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
                    figure.Draw(canvas);
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
                    figure.Draw(canvas);
                    break;

            }
            figures.Add(figure);
        }
    }
}