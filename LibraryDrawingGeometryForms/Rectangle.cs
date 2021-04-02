using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryDrawingGeometryForms
{
    public class Rectangle : IFigure
    {
        public double Height { get; set; }
        public double Width { get; set; } 
        public double CenterX { get; set; } 
        public double CenterY { get; set; } 
        public FigureColor LineColor { get; set; }
        public double LineThickness { get; set; } 

        public void Draw(Canvas canvas)
        {

            System.Windows.Shapes.Rectangle rectangle;
            rectangle = new System.Windows.Shapes.Rectangle
            {
                Width = Width,
                Height = Height,
            };
            rectangle.Margin = new Thickness((CenterX - rectangle.Width / 2), CenterY - rectangle.Height / 2, 0, 0);
            rectangle.Stroke = new SolidColorBrush(LineColor.ToColor());
            rectangle.StrokeThickness = LineThickness;
            canvas.Children.Add(rectangle);
        }
    }
}
