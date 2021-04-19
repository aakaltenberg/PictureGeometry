using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF = System.Windows.Shapes;


namespace LibraryDrawingGeometryForms
{
    public interface IFigure
    {
        double Height { get; set; }
        double Width { get; set; }
        double UpperLeftAngleX { get; set; }
        double UpperLeftAngleY { get; set; }
        FigureColor LineColor { get; set; }
        double LineThickness { get; set; }

        bool IsSelected { get; set; }

        bool HasShape(Shape shape);
        void Draw(Canvas canvas, MouseButtonEventHandler mouseDownEventHandler);
    }
}
