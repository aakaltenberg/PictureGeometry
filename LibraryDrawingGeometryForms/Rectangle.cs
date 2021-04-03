using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibraryDrawingGeometryForms
{
    public class Rectangle : BaseFigure, IFigure
    {
        public override void Draw(Canvas canvas, MouseButtonEventHandler mouseDownEventHandler)
        {
            ClearShapes(mouseDownEventHandler);

            System.Windows.Shapes.Rectangle rectangle;
            rectangle = new System.Windows.Shapes.Rectangle
            {
                Width = Width,
                Height = Height,
            };
            rectangle.Margin = new Thickness((CenterX - rectangle.Width / 2), CenterY - rectangle.Height / 2, 0, 0);
            rectangle.Stroke = new SolidColorBrush(LineColor.ToColor());
            rectangle.StrokeThickness = LineThickness + (IsSelected ? 2 : 0);
            rectangle.MouseDown += mouseDownEventHandler;
            shapes.Add(rectangle);
            canvas.Children.Add(rectangle);
        }
    }
}
