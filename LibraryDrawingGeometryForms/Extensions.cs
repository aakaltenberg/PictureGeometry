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
                        R = 255,
                        G = 255,
                        B = 255,
                        A = 255,
                    };
                case FigureColor.Blue:
                    return new Color()
                    {
                        R = 0,
                        G = 181,
                        B = 204,
                        A = 1,
                    };
                case FigureColor.Red:
                    return new Color()
                    {
                        R = 240,
                        G = 52,
                        B = 52,
                        A = 1,
                    };
                case FigureColor.Green:
                    return new Color()
                    {
                        R = 11,
                        G = 156,
                        B = 49,
                        A = 1,
                    };
                case FigureColor.Yellow:
                    return new Color()
                    {
                        R = 255,
                        G = 255,
                        B = 0,
                        A = 1,
                    };
                default:
                    throw new Exception();
            }
        }
    }
}