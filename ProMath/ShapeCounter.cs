using ProMath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMath
{
    static class ShapeCounter
    {
        public static int CircleCount { get; private set; }
        public static int TriangleCount { get; private set; }
        public static int SquareCount { get; private set; }
        public static int RectangleCount { get; private set; }

        public static void IncrementCount(Shape shape)
        {
            if (shape is Circle) CircleCount++;
            else if (shape is Triangle) TriangleCount++;
            else if (shape is Square) SquareCount++;
            else if (shape is Rectangle) RectangleCount++;
        }
    }
}
