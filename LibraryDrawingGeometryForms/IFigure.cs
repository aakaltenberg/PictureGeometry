using System;
using System.Collections.Generic;
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
using WPF = System.Windows.Shapes;


namespace LibraryDrawingGeometryForms
{
    public interface IFigure
    {
        double Height { get; set; }
        double Width { get; set; }
        double CenterX { get; set; }
        double CenterY { get; set; }
        string LineColor { get; set; }
        int LineThickness { get; set; }
    }
}
