using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMath.Models
{
    public class Square : Shape
    {
        public Square() { }
        public Square(string name, double side)
        {
            Name = name;
            Area = Math.Round(side * side, 2);
            Perimeter = Math.Round(4 * side, 2);
        }
    }
}
