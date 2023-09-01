using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMath.Models
{
    public class Triangle : Shape
    {
        public Triangle() { }
        public Triangle(string name, double sideA, double sideB, double sideC, double baseVal, double height)
        {
            Perimeter = Math.Round(sideA + sideB + sideC, 2);
            Area = Math.Round((baseVal * height) / 2, 2);
            Name = name;
        }
    }
}
