using LibraryDrawingGeometryForms;
using System;
using System.Windows.Media;

namespace LibraryDrawingGeometryForms
{
    public static class Extensions
    {
        public static Color ToColor(this FigureColor figure)
        {
            switch (figure)
            {
                case FigureColor.Black:
                    return new Color()
                    {
                        ScR = 0,
                        ScG = 0,
                        ScB = 0,
                        ScA = 1,
                    };
                case FigureColor.Blue:
                    return new Color()
                    {
                        ScR = 0,
                        ScG = 0,
                        ScB = 1,
                        ScA = 1,
                    };
                case FigureColor.Red:
                    return new Color()
                    {
                        ScR = 1,
                        ScG = 0,
                        ScB = 0,
                        ScA = 1,
                    };
                case FigureColor.Green:
                    const double V = 0.215860531;
                    return new Color()
                    {
                        ScR = 0,
                        ScG = (float)V,
                        ScB = 0,
                        ScA = 1,
                    };
                case FigureColor.Yellow:
                    return new Color()
                    {
                        ScR = 1,
                        ScG = 1,
                        ScB = 0,
                        ScA = 1,
                    };
                default:
                    throw new Exception();
            }
        }
    }
}