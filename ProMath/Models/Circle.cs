using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMath.Models
{
    public class Circle : Shape
    {
        public Circle() { }
        public Circle(string name, double radius) 
        {
            Perimeter = Math.Round(2 * Math.PI * radius, 2);
            Area = Math.Round(Math.PI * radius * radius, 2);
            Name = name;
        } 
    }
}
