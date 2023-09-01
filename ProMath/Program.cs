using ProMath.Models;
using System;
using System.Collections.Generic;

namespace ProMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a shape: 1. Circle, 2. Triangle, 3. Square, 4. Rectangle");
            int choice = Convert.ToInt32(Console.ReadLine());

            Shape shape = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter radius: ");
                    double circleRadius = Convert.ToDouble(Console.ReadLine());
                    shape = ShapeFactory.CreateCircle(circleRadius);
                    break;
                case 2:
                    Console.Write("Enter side A: ");
                    double sideA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter side B: ");
                    double sideB = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter side C: ");
                    double sideC = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter base: ");
                    double baseValue = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter height: ");
                    double height = Convert.ToDouble(Console.ReadLine());
                    shape = ShapeFactory.CreateTriangle(sideA, sideB, sideC, baseValue, height);
                    string triangleType = shape.Name;
                    Console.WriteLine($"Triangle Type: {triangleType}");
                    break;
                case 3:
                    Console.Write("Enter side: ");
                    double squareSide = Convert.ToDouble(Console.ReadLine());
                    shape = ShapeFactory.CreateSquare(squareSide);
                    break;
                case 4:
                    Console.Write("Enter width: ");
                    double rectangleWidth = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter length: ");
                    double rectangleLength = Convert.ToDouble(Console.ReadLine());
                    shape = ShapeFactory.CreateRectangle(rectangleWidth, rectangleLength);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }


            Console.WriteLine($"Shape: {shape.Name}, Area: {shape.Area}, Perimeter: {shape.Perimeter}");

            List<Shape> shapes = new List<Shape> { shape };

            Console.WriteLine("Sorting by: 1. Area, 2. Perimeter");
            int sortChoice = Convert.ToInt32(Console.ReadLine());

            string sortCriteria = sortChoice == 1 ? "Area" : "Perimeter";
            shapes.Sort(new ShapeComparer(sortCriteria));


            ShapeSerializer.SerializeToJson(shapes, "shapes.json");

            List<Shape> deserializedShapes = ShapeSerializer.DeserializeFromJson("shapes.json");

            deserializedShapes.Sort(new ShapeComparer(sortCriteria));

            foreach (var deserializedShape in deserializedShapes)
            {
                ShapeCounter.IncrementCount(deserializedShape);
                if (("Scalene, Equilateral, Isosceles").Contains(deserializedShape.Name))
                {
                    string triangleType = deserializedShape.Name;
                    Console.WriteLine($"Shape: Triangle, Area: {deserializedShape.Area}, Perimeter: {deserializedShape.Perimeter}, Triangle Type: {triangleType}");
                }
                else
                {
                    Console.WriteLine($"Shape: {deserializedShape.Name}, Area: {deserializedShape.Area}, Perimeter: {deserializedShape.Perimeter}");
                }
            }

            Console.WriteLine($"Circle Count: {ShapeCounter.CircleCount}");
            Console.WriteLine($"Triangle Count: {ShapeCounter.TriangleCount}");
            Console.WriteLine($"Square Count: {ShapeCounter.SquareCount}");
            Console.WriteLine($"Rectangle Count: {ShapeCounter.RectangleCount}");
        }
    }
}
