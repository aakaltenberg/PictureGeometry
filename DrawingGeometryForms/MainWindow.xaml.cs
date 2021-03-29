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

namespace DrawingGeometryForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ClickWidth(object sender, RoutedEventArgs e)
        {
            double width;
            if (!double.TryParse(inputedWidth.Text, out width))             // Является ли введенная ширина типом double
            {
                MessageBox.Show("Width is not number!");
                return;
            }
        }

        public void ClickHeight(object sender, RoutedEventArgs e)
        {
            double height;
            if (!double.TryParse(inputedHeight.Text, out height))
            {
                MessageBox.Show("Height is not number!");
                return;
            }
        }

        public void ClickCenterX(object sender, RoutedEventArgs e)
        {
            double centerX;
            if (!double.TryParse(inputedCenterX.Text, out centerX))
            {
                MessageBox.Show("CenterX is not number!");
                return;
            }
        }

        public void ClickCenterY(object sender, RoutedEventArgs e)
        {
            double centerY;
            if (!double.TryParse(inputedCenterY.Text, out centerY))
            {
                MessageBox.Show("CenterY is not number!");
                return;
            }
        }

        public void ClickLineColor(object sender, RoutedEventArgs e)
        {
            string lineColor = inputedLineColor.Text;
        }

        public void ClickLineThickness(object sender, RoutedEventArgs e)
        {
            int lineThickness;
            if (!int.TryParse(inputedLineThiсkness.Text, out lineThickness))
            {
                MessageBox.Show("lineTickness is not number");
                return;
            }
        }

        public void ClickNameFigure(object sender, RoutedEventArgs e)
        {
            string nameFigure = inputedNameFigure.Text;
        }
        public void ClickEnter(object sender, RoutedEventArgs e)
        {
            switch (inputedNameFigure)
            {
                case "rectangle":
                    //рисуем квадрат или прямоугольник
                    Rectangle rectangle;
                    rectangle = new System.Windows.Shapes.Rectangle();
                    rectangle.Width = double.Parse(inputedWidth.Text);
                    rectangle.Height = double.Parse(inputedHeight.Text);
                    rectangle.Margin = new Thickness((double.Parse(inputedCenterX.Text) - rectangle.Width / 2), (double.Parse(inputedCenterY.Text) - rectangle.Height / 2), 0, 0);
                    rectangle.Stroke = Brushes.Black;
                    rectangle.StrokeThickness = double.Parse(inputedLineThiсkness.Text);
                    canvas.Children.Add(rectangle);
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
                    BC.X1 = (double.Parse(inputedCenterX.Text) + (double.Parse(inputedHeight.Text) / Math.Sqrt(3)));
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
        }
    }
}