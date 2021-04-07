using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomCalculator
{
    public static class PolynomExtensions
    {
        public static Polynom ToPolynom(this IEnumerable<int> arr) => new Polynom(arr);
    }
}
