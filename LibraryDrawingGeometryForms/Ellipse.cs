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
                Width = Math.Abs(Width),
                Height = Math.Abs(Height),
            };
            ellipse.Margin = new Thickness(LeftAngleX, LeftAngleY, 0, 0);
            ellipse.Stroke = new SolidColorBrush(LineColor.ToColor());
            ellipse.StrokeThickness = LineThickness + (IsSelected ? 2 : 0);
            ellipse.MouseLeftButtonDown += mouseDownEventHandler;
            shapes.Add(ellipse); // при отрисовке фигуры в лист шейп закидываем объект эллипс
            canvas.Children.Add(ellipse);
        }
    }
}
