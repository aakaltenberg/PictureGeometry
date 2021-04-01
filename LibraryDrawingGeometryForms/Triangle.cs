using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryDrawingGeometryForms
{
    public class Triangle : IFigure
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public FigureColor LineColor { get; set; }
        public double LineThickness { get; set; }
        public void Draw(Canvas canvas)
        {            
            System.Windows.Shapes.Line AB;
            AB = new System.Windows.Shapes.Line();
            AB.X1 = CenterX - Height / Math.Sqrt(3);
            AB.Y1 = CenterY - Height / 3;
            AB.X2 = CenterX + Height / Math.Sqrt(3);
            AB.Y2 = CenterY - Height / 3;
            AB.Stroke = new SolidColorBrush(LineColor.ToColor());
            AB.StrokeThickness = LineThickness;
            canvas.Children.Add(AB);

            System.Windows.Shapes.Line BC;
            BC = new System.Windows.Shapes.Line();
            BC.X1 = CenterX + Height / Math.Sqrt(3);
            BC.Y1 = CenterY - Height / 3;
            BC.X2 = CenterX;
            BC.Y2 = CenterY + 2 * Height / 3;
            BC.Stroke = new SolidColorBrush(LineColor.ToColor());
            BC.StrokeThickness = LineThickness;
            canvas.Children.Add(BC);

            System.Windows.Shapes.Line AC;
            AC = new System.Windows.Shapes.Line();
            AC.X1 = CenterX - Height / Math.Sqrt(3);
            AC.Y1 = CenterY - Height / 3;
            AC.X2 = CenterX;
            AC.Y2 = CenterY + 2 * Height / 3;
            AC.Stroke = new SolidColorBrush(LineColor.ToColor());
            AC.StrokeThickness = LineThickness;
            canvas.Children.Add(AC);
        }
    }
}
