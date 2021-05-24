using System;
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
        public double dx { get; set; } = 1;
        public double dy { get; set; } = 1;
        public double Height { get; set; } = 0;
        public double Width { get; set; } = 0;
        public double UpperLeftAngleX { get; set; } = 200;
        public double UpperLeftAngleY { get; set; } = 200;
        public FigureColor LineColor { get; set; }
        public double LineThickness { get; set; } = 5;
        public bool IsSelected { get; set; }
        public List<int> ShapeCircleX { get; set; } = new List<int>();
        public List<int> ShapeCircleY { get; set; } = new List<int>();

        public abstract void Draw(Canvas canvas, MouseButtonEventHandler mouseDownEventHandler, MouseButtonEventHandler mouseUpEventHandler);
        public bool HasShape(Shape shape)
        {
            return shapes.Contains(shape); //возвращает true, если входящий объект, принадлежащий
                                           //классу Shape, содержится в листе shapes
        }

        /// <summary>
        /// Метод, загоняющий координаты описанной вокруг фигуры окружности в два листа - для Х и Y отдельно
        /// </summary>
        public void RefreshShapeCircleXY()
        {
            ShapeCircleX.Clear();
            ShapeCircleY.Clear();
            int angle;
            for (angle = 0; angle < 360; angle++)
            {
                double radius = Math.Sqrt(Math.Pow(Height/2,2)+Math.Pow(Width/2,2));
                double centerX = (UpperLeftAngleX + Width) / 2;
                double centerY = (UpperLeftAngleY + Height) / 2;
                int shapeCircleX = (int)(centerX + radius * Math.Cos(angle));
                int shapeCircleY = (int)(centerY + radius * Math.Sin(angle));
                ShapeCircleX.Add(shapeCircleX);
                ShapeCircleY.Add(shapeCircleY);
            }
        }

        /// <summary>
        /// Очистка листа shapes
        /// </summary>
        /// <param name="mouseDownEventHandler"></param>
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
