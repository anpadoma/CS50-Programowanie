using System;
using System.Collections.Generic;

namespace Chapter06
{
    public class Shape
    {
        public Rect BoundingBox { get; set; }
    }

    public class Rect
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class RoundedRectangle : Shape
    {
        public double CornerRadius { get; set; }
    }

    public class BoxAreaComparer : IComparer<Shape>
    {
        public int Compare(Shape x, Shape y)
        {
            double xArea = x.BoundingBox.Width * x.BoundingBox.Height;
            double yArea = y.BoundingBox.Width * y.BoundingBox.Height;
            return Math.Sign(xArea - yArea);
        }
    }

    public class CornerSharpnessComparer : IComparer<RoundedRectangle>
    {
        public int Compare(RoundedRectangle x, RoundedRectangle y)
        {
            //Wierzchołki o mniejszym promieniu są ostrzejsze, a zatem
            //z pubnktu widzenia tego porównania mniejszy promień będzię "większy"
            //stąd odwrócenie kolejności argumentów w odejmowaniu.
            return Math.Sign(y.CornerRadius - x.CornerRadius);
        }
    }
}
