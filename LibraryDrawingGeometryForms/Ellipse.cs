using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryDrawingGeometryForms
{
    public class Ellipse : IFigure
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public FigureColor LineColor { get; set; }
        public double LineThickness { get; set; }

        public void Draw(Canvas canvas)
        { 
            System.Windows.Shapes.Ellipse ellipse;
            ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = Width,
                Height = Height,
            };
            ellipse.Margin = new Thickness((CenterX - ellipse.Width / 2), CenterY - ellipse.Height / 2, 0, 0);
            ellipse.Stroke = new SolidColorBrush(LineColor.ToColor());
            ellipse.StrokeThickness = LineThickness;
            canvas.Children.Add(ellipse);
        }
    }
}
