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
using Rectangle = LibraryDrawingGeometryForms.Rectangle;

namespace DrawingGeometryForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IFigure> figures = new List<IFigure>();

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
                    Ellipse ellipse;
                    ellipse = new System.Windows.Shapes.Ellipse();
                    ellipse.Width = double.Parse(inputedWidth.Text);
                    ellipse.Height = double.Parse(inputedHeight.Text);
                    ellipse.Margin = new Thickness((double.Parse(inputedCenterX.Text) - ellipse.Width / 2), (double.Parse(inputedCenterY.Text) - ellipse.Height / 2), 0, 0);
                    ellipse.Stroke = Brushes.Black;
                    ellipse.StrokeThickness = double.Parse(inputedLineThiсkness.Text);
                    canvas.Children.Add(ellipse);
                    break;
                case "triangle":
                    // рисуем треугольник
                    Line AB;
                    AB = new Line();
                    AB.X1 = (double.Parse(inputedCenterX.Text) - (double.Parse(inputedHeight.Text) / Math.Sqrt(3)));
                    AB.Y1 = (double.Parse(inputedCenterY.Text) - (double.Parse(inputedHeight.Text) / 3));
                    AB.X2 = (double.Parse(inputedCenterX.Text) + (double.Parse(inputedHeight.Text) / Math.Sqrt(3)));
                    AB.Y2 = (double.Parse(inputedCenterY.Text) - (double.Parse(inputedHeight.Text) / 3));
                    AB.Stroke = Brushes.Black;
                    AB.StrokeThickness = double.Parse(inputedLineThiсkness.Text);
                    canvas.Children.Add(AB);

                    Line BC;
                    BC = new Line();
                    BC.X1 = double.Parse(inputedCenterX.Text) + (double.Parse(inputedHeight.Text) / Math.Sqrt(3));
                    BC.Y1 = (double.Parse(inputedCenterY.Text) - (double.Parse(inputedHeight.Text) / 3));
                    BC.X2 = double.Parse(inputedCenterX.Text);
                    BC.Y2 = (double.Parse(inputedCenterY.Text) + (2 * double.Parse(inputedHeight.Text) / 3));
                    BC.Stroke = Brushes.Black;
                    BC.StrokeThickness = double.Parse(inputedLineThiсkness.Text);
                    canvas.Children.Add(BC);

                    Line AC;
                    AC = new Line();
                    AC.X1 = (double.Parse(inputedCenterX.Text) - (double.Parse(inputedHeight.Text) / Math.Sqrt(3)));
                    AC.Y1 = (double.Parse(inputedCenterY.Text) - (double.Parse(inputedHeight.Text) / 3));
                    AC.X2 = double.Parse(inputedCenterX.Text);
                    AC.Y2 = (double.Parse(inputedCenterY.Text) + (2 * double.Parse(inputedHeight.Text) / 3));
                    AC.Stroke = Brushes.Black;
                    AC.StrokeThickness = double.Parse(inputedLineThiсkness.Text);
                    canvas.Children.Add(AC);
                    break;
            }
            figures.Add(figure);
        }
    }
}