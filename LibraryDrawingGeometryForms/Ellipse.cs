using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibraryDrawingGeometryForms
{
    public class Ellipse : BaseFigure
    {
        public override void Draw(Canvas canvas, MouseButtonEventHandler mouseDownEventHandler)
        {
            ClearShapes(mouseDownEventHandler);

            System.Windows.Shapes.Ellipse ellipse;
            ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = Width,
                Height = Height,
            };
            ellipse.Margin = new Thickness((CenterX - ellipse.Width / 2), CenterY - ellipse.Height / 2, 0, 0);
            ellipse.Stroke = new SolidColorBrush(LineColor.ToColor());
            ellipse.StrokeThickness = LineThickness + (IsSelected ? 2 : 0);
            ellipse.MouseDown += mouseDownEventHandler;
            shapes.Add(ellipse);
            canvas.Children.Add(ellipse);
        }
    }
}
