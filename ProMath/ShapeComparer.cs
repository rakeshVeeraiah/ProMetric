using ProMath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMath
{
    public class ShapeComparer : IComparer<Shape>
    {
        private readonly string _sortCriteria;

        public ShapeComparer(string sortCriteria)
        {
            _sortCriteria = sortCriteria;
        }

        public int Compare(Shape x, Shape y)
        {
            double valueX = _sortCriteria == "Area" ? x.Area : x.Perimeter;
            double valueY = _sortCriteria == "Area" ? y.Area : y.Perimeter;
            return valueX.CompareTo(valueY);
        }
    }
}
