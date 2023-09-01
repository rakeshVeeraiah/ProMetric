using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProMath.Models;
using System.Collections.Generic;
using System.IO;

namespace ProMath
{
    static class ShapeSerializer
    {
        public static void SerializeToJson(List<Shape> shapes, string filePath)
        {
            List<Shape> existingShapes = new List<Shape>();

            // If the file exists, read its content and deserialize it
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                existingShapes = JsonConvert.DeserializeObject<List<Shape>>(existingJson);
            }

            // Add the new shapes to the existing list
            existingShapes.AddRange(shapes);

            // Serialize the updated list and write it back to the file
            string json = JsonConvert.SerializeObject(existingShapes, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<Shape> DeserializeFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);

            List<Shape> shapes = new List<Shape>();

            foreach (JObject item in JArray.Parse(json))
            {
                var sms = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                Shape shape;
                switch (sms.Name.ToString())
                {
                    case AppConstants.CIRCLE:
                        shape = new Circle();
                        break;

                    case AppConstants.EQUILATERAL:
                    case AppConstants.ISOSCELES:
                    case AppConstants.SCALENE:
                        shape = new Triangle();
                        break;

                    case AppConstants.SQUARE:
                        shape = new Square();
                        break;

                    case AppConstants.RECTANGLE:
                        shape = new Rectangle();
                        break;
                    default:
                        throw new InvalidDataException("Unknown shape");
                }

                shape.Area = sms.Area;
                shape.Name = sms.Name;
                shape.Perimeter = sms.Perimeter;
                shapes.Add(shape);
            }
            return shapes;
        }
    }
}
