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
        public override void Draw(Canvas canvas, MouseButtonEventHandler mouseDownEventHandler) //override позвол€ет переопределить метод,
                                                                                                //который определен в абстрактном классе
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
            rectangle.MouseLeftButtonDown += mouseDownEventHandler;  // подписываем к событию
                                                                     // метод(обработчик событи€) через
                                                                     // делегат MouseButtonEventHandler
            Point positionMouse = Mouse.GetPosition(relativeTo: canvas);
            shapes.Add(rectangle);  // при отрисовке фигуры закидываем в лист shapes объект rectangle
            canvas.Children.Add(rectangle);
        }
    }
}
