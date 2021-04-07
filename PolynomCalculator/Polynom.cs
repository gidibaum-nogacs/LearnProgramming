using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomCalculator
{
    class Polynom
    {
        public int[] Variables { get; set; }

        public Polynom(int[] variables)
        {
            Variables = variables;
        }


        public static Polynom operator +(Polynom pa, Polynom pb)
        {

            var a = pa.Variables;
            var b = pb.Variables;
            int difference = Math.Max(a.Length, b.Length) - Math.Min(a.Length, b.Length);

            if (a.Length > b.Length)
            {
                Array.Resize(ref b, b.Length + difference);
            }
            else
            {
                Array.Resize(ref a, a.Length + difference);
            }



            List<int> c = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                c.Add(a[i] + b[i]);
            }

            foreach (int i in c)
            {
                Console.WriteLine(i);
            }

            return new Polynom(c.ToArray());
        }

        public static Polynom operator -(Polynom pa, Polynom pb)
        {
            var a = pa.Variables;
            var b = pb.Variables;
            int difference = Math.Max(a.Length, b.Length) - Math.Min(a.Length, b.Length);

            if (a.Length > b.Length)
            {
                Array.Resize(ref b, b.Length + difference);
            }
            else
            {
                Array.Resize(ref a, a.Length + difference);
            }

            List<int> c = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                c.Add(a[i] - b[i]);
            }

            foreach (int i in c)
            {
                Console.WriteLine(i);
            }

            return new Polynom(c.ToArray());
        }

        public static Polynom operator *(Polynom pa, Polynom pb)
        {
            int[] a = pa.Variables;
            int[] b = pb.Variables;

            int size = Math.Min(a.Length, b.Length);
            int[][] mult = new int[size][];
            List<Polynom> g = new List<Polynom>(); 

            Console.WriteLine("multiplies works!");

            for (int x = 0; x < b.Length; x++)
            {
                
                var numbers = new List<int>();
                var num = b[x];
                if (num == 0)
                {
                    continue;
                }
                for (int v = 0; v < x; v++)
                {
                    numbers.Add(0);
                }
                for (int i = 0; i < a.Length; i++)
                {
                  
                  var newNum =  num * a[i];
                    numbers.Add(newNum);
                }

                Polynom o = new Polynom(numbers.ToArray());
                g.Add(o);
            }

            Polynom final = new Polynom(new int[2]);

            foreach (Polynom o in g)
            {
                final += o;
            }
            // g.Select( a1 => final = final + a1);


            Console.WriteLine(final.ToString());

            
            return final;
        }



      


        public override string ToString()
        {

            string FullPolynom = "";

            int counter = 0;

            for (int i = 0; i < Variables.Length; i++)
            {
                counter ++;
                var power = Array.IndexOf(Variables , i) + 1;
                
                if (Variables[i] == 0)
                {
                    continue;
                }

                if (i == 0)
                {
                    FullPolynom += $"{Variables[i]} ";
                    continue;
                }
               
                if (i == 1)
                {
                    if (!String.IsNullOrEmpty(FullPolynom))
                    {
                        FullPolynom += "+ ";
                    }               
                    FullPolynom += $"{Variables[i]}x ";
                    continue;
                }
                //if (i == Variables.Length - 1)
                //{
                //    FullPolynom += $"{Variables[i]}x^{i + 1}";
                //    continue;
                //}
                if (!String.IsNullOrEmpty(FullPolynom))
                {
                    FullPolynom += " +";
                }
                FullPolynom += $" { Variables[i] }x^{ i } ";

            }
            return FullPolynom;

        }
    }
}
