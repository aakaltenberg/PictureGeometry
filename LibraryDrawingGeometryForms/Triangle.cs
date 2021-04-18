using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibraryDrawingGeometryForms
{
    public class Triangle : BaseFigure
    {
        public override void Draw(Canvas canvas, MouseButtonEventHandler mouseDownEventHandler)
        {
            ClearShapes(mouseDownEventHandler);

            var selectedThickness = IsSelected ? 2 : 0;

            System.Windows.Shapes.Line lineAB;
            lineAB = new System.Windows.Shapes.Line();
            lineAB.X1 = LeftAngleX - Height / Math.Sqrt(3);
            lineAB.Y1 = LeftAngleY - Height / 3;
            lineAB.X2 = LeftAngleX + Height / Math.Sqrt(3);
            lineAB.Y2 = LeftAngleY - Height / 3;
            lineAB.Stroke = new SolidColorBrush(LineColor.ToColor());
            lineAB.StrokeThickness = LineThickness + selectedThickness;
            lineAB.MouseLeftButtonDown += mouseDownEventHandler;
            shapes.Add(lineAB);
            canvas.Children.Add(lineAB);

            System.Windows.Shapes.Line lineBC;
            lineBC = new System.Windows.Shapes.Line();
            lineBC.X1 = LeftAngleX + Height / Math.Sqrt(3);
            lineBC.Y1 = LeftAngleY - Height / 3;
            lineBC.X2 = LeftAngleX;
            lineBC.Y2 = LeftAngleY + 2 * Height / 3;
            lineBC.Stroke = new SolidColorBrush(LineColor.ToColor());
            lineBC.StrokeThickness = LineThickness + selectedThickness;
            lineBC.MouseLeftButtonDown += mouseDownEventHandler;
            shapes.Add(lineBC);
            canvas.Children.Add(lineBC);

            System.Windows.Shapes.Line lineAC;
            lineAC = new System.Windows.Shapes.Line();
            lineAC.X1 = LeftAngleX - Height / Math.Sqrt(3);
            lineAC.Y1 = LeftAngleY - Height / 3;
            lineAC.X2 = LeftAngleX;
            lineAC.Y2 = LeftAngleY + 2 * Height / 3;
            lineAC.Stroke = new SolidColorBrush(LineColor.ToColor());
            lineAC.StrokeThickness = LineThickness+ selectedThickness;
            lineAC.MouseLeftButtonDown += mouseDownEventHandler;
            shapes.Add(lineAC); // при отрисовке фигуры закидываем в лист шэйп три объекта - (lineAB, lineBC, lineAC)
            canvas.Children.Add(lineAC);
        }
    }
}
