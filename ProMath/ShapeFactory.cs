using ProMath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMath
{
    static class ShapeFactory
    {
        public static Circle CreateCircle(double radius)
        {
            return new Circle(AppConstants.CIRCLE, radius);
        }

        public static Triangle CreateTriangle(double sideA, double sideB, double sideC, double baseValue, double height)
        {
            string name = "";
            if (sideA == sideB && sideB == sideC)
                name = AppConstants.EQUILATERAL;
            else if (sideA == sideB || sideB == sideC || sideA == sideC)
                name =  AppConstants.ISOSCELES;
            else
                name = AppConstants.SCALENE;

            return new Triangle(name, sideA, sideB, sideC, baseValue, height);
        }

        public static Square CreateSquare(double side)
        {
            return new Square(AppConstants.SQUARE, side);
        }

        public static Rectangle CreateRectangle(double width, double length)
        {
            return new Rectangle(AppConstants.RECTANGLE, width, length);
        }

    }
}
