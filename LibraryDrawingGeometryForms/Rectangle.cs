using System;
namespace LibraryDrawingGeometryForms
{
    public class Rectangle : IFigure
    {
        public double Height {get ; set;}
        public double Width { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public string LineColor { get; set; }
        public int LineThickness { get; set; }
    }
}
