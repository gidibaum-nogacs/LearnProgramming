using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomCalculator
{
    public class Polynom
    {
        public int[] Variables { get; set; }
        public Polynom(IEnumerable<int> variables)
        {
            Variables = variables.ToArray();
        }


        public static Polynom operator +(Polynom pa, Polynom pb)
        {
            var map = new Dictionary<int, int>();// map:= exp -> coef

            for (var i = 0; i < pa.Variables.Length; i++)
            {
                map[i] = pa.Variables[i];
            }

            for (var i = 0; i < pb.Variables.Length; i++)
            {
                if (map.TryGetValue(i, out var c))
                {
                    map[i] += pb.Variables[i];
                }
                else
                {
                    map[i] = pb.Variables[i];
                }
            }

            //return new Polynom(map.Values); //not sure on the ordering of the map

            return map
                .OrderBy(kv=>kv.Key) // order by exponent
                .Select(kv=>kv.Value)
                .ToPolynom();
        }

        public static Polynom operator *(Polynom pa, Polynom pb)
        {
            var dict = new Dictionary<int, int>();
            var maxExp = pa.Variables.Length + pb.Variables.Length - 1;

            for (int i = 0; i < maxExp; i++)            
            {
                dict[i] = 0;
            }

            for (var a = 0; a < pa.Variables.Length; a++)
            {
                for (var b = 0; b < pb.Variables.Length; b++)
                {
                    dict[a+b] += pa.Variables[a] * pb.Variables[b];
                }
            }

            return dict
                .OrderBy(kv => kv.Key) // order by exponent
                .Select(kv => kv.Value)
                .ToPolynom();
        }

        //public static Polynom operator *(Polynom pa, Polynom pb)
        //{
        //    var a = pa.Variables;
        //    var b = pb.Variables;

        //    var size = Math.Min(a.Length, b.Length);
        //    var mult = new int[size][];
        //    var g = new List<Polynom>();

        //    Console.WriteLine("multiplies works!");

        //    for (var x = 0; x < b.Length; x++)
        //    {
        //        var numbers = new List<int>();
        //        var num = b[x];
        //        if (num == 0)
        //        {
        //            continue;
        //        }
        //        for (var v = 0; v < x; v++)
        //        {
        //            numbers.Add(0);
        //        }
        //        for (var i = 0; i < a.Length; i++)
        //        {
        //            var newNum = num * a[i];
        //            numbers.Add(newNum);
        //        }

        //        var o = new Polynom(numbers.ToArray());
        //        g.Add(o);
        //    }

        //    var final = new Polynom(new int[2]);

        //    foreach (var o in g)
        //    {
        //        final += o;
        //    }
        //    // g.Select( a1 => final = final + a1);


        //    Console.WriteLine(final.ToString());


        //    return final;
        //}

        public void oldplus()
        {
            //    //public static Polynom operator +(Polynom pa, Polynom pb)
            //    //{
            //    //    var a = pa.Variables;
            //    //    var b = pb.Variables;

            //    //    var difference = Math.Max(a.Length, b.Length) - Math.Min(a.Length, b.Length);

            //    //    if (a.Length > b.Length)
            //    //    {
            //    //        Array.Resize(ref b, b.Length + difference);
            //    //    }
            //    //    else
            //    //    {
            //    //        Array.Resize(ref a, a.Length + difference);
            //    //    }

            //    //    var c = new List<int>();

            //    //    for (var i = 0; i < a.Length; i++)
            //    //    {
            //    //        c.Add(a[i] + b[i]);
            //    //    }

            //    //    foreach (var i in c)
            //    //    {
            //    //        Console.WriteLine(i);
            //    //    }

            //    //    return new Polynom(c);
            //    //}
        }

        public static Polynom operator -(Polynom pa, Polynom pb)
        {
            var a = pa.Variables;
            var b = pb.Variables;
            var difference = Math.Max(a.Length, b.Length) - Math.Min(a.Length, b.Length);

            if (a.Length > b.Length)
            {
                Array.Resize(ref b, b.Length + difference);
            }
            else
            {
                Array.Resize(ref a, a.Length + difference);
            }

            var c = new List<int>();

            for (var i = 0; i < a.Length; i++)
            {
                c.Add(a[i] - b[i]);
            }

            foreach (var i in c)
            {
                Console.WriteLine(i);
            }


        
            return new Polynom(c);
        }

        public override string ToString()
        {
            var fullPolynomial = "";

            var counter = 0;

            for (var i = 0; i < Variables.Length; i++)
            {
                counter ++;
                var power = Array.IndexOf(Variables , i) + 1;

                if (Variables[i] == 0)
                {
                    continue;
                }

                if (i == 0)
                {
                    fullPolynomial += $"{Variables[i]} ";
                    continue;
                }

                

                if (i == 1)
                {
                    if (!String.IsNullOrEmpty(fullPolynomial))
                    {
                        fullPolynomial += "+ ";
                    }               
                    fullPolynomial += $"{Variables[i]}x ";
                    continue;
                }
                //if (i == Variables.Length - 1)
                //{
                //    FullPolynom += $"{Variables[i]}x^{i + 1}";
                //    continue;
                //}
                if (!String.IsNullOrEmpty(fullPolynomial))
                {
                    fullPolynomial += " +";
                }
                fullPolynomial += $" { Variables[i] }x^{ i } ";
            }

            


            return fullPolynomial;

        }




        
    }
}
