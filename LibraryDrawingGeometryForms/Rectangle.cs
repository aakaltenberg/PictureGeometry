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
                Width = Math.Abs(Width),
                Height = Math.Abs(Height),
            };
            rectangle.Margin = new Thickness(LeftAngleX, LeftAngleY, 0, 0);
            rectangle.Stroke = new SolidColorBrush(LineColor.ToColor());
            rectangle.StrokeThickness = LineThickness + (IsSelected ? 2 : 0);
            rectangle.MouseLeftButtonDown += mouseDownEventHandler;  // подписываем к событию
                                                                     // метод(обработчик событи€) через
                                                                     // делегат MouseButtonEventHandler
            shapes.Add(rectangle);  // при отрисовке фигуры закидываем в лист shapes объект rectangle
            canvas.Children.Add(rectangle);
        }
    }
}
