using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;


namespace LibraryDrawingGeometryForms
{
    public abstract class BaseFigure : IFigure
    {
        protected List<Shape> shapes = new List<Shape>();
        public double Height { get; set; } = 0;
        public double Width { get; set; } = 0;
        public double LeftAngleX { get; set; } = 200;
        public double LeftAngleY { get; set; } = 200;
        public FigureColor LineColor { get; set; }
        public double LineThickness { get; set; } = 5;
        public bool IsSelected { get; set; }

        public abstract void Draw(Canvas canvas, MouseButtonEventHandler mouseDownEventHandler);
        public bool HasShape(Shape shape)
        {
            return shapes.Contains(shape); //возвращает true, если входящий объект, принадлежащий
                                           //классу Shape, содержится в листе shapes
        }

        protected void ClearShapes(MouseButtonEventHandler mouseDownEventHandler)
        {
            if (shapes.Any())
            {
                foreach (var shape in shapes)
                {
                    shape.MouseDown -= mouseDownEventHandler;
                }
                shapes.Clear();
            }
        }
    }
}
