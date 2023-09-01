using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMath.Models
{
    public class Rectangle : Shape
    {
        public Rectangle() { }
        public Rectangle(string name, double width, double length)
        {
            Name = name;
            Area = Math.Round(width * length, 2);
            Perimeter = Math.Round(2 * (width + length), 2);
        }
    }
}
