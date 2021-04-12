using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomCalculator
{
    class PolynomService
    {
      

        public int[] InputToArray(string input)
        {
            int counter = 0;
            string previousDigit = "";
            var numbers = new List<int>();

            foreach (char i in input)
            {
                counter++;
                if (char.IsDigit(i) || i == '-')
                {
                    previousDigit += i;
                }
         
                if (counter == input.Length || Char.IsWhiteSpace(i))
                {
                    try
                    {
                        if (String.IsNullOrEmpty(previousDigit))
                        {
                            continue;
                        }
                        var num = int.Parse(previousDigit);
                        numbers.Add(num);
                        previousDigit = "";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("you did that wrong");
                    }       
                }    
            }

            Console.WriteLine(numbers);
            return numbers.ToArray();

          

            
        }

        string pnom = " 2x + 3x^2 + 4x^4 + 1";

        public Polynom StringToPolynom(string pnom)
        {
            int length = pnom.Length;

            var text = pnom.Trim('+');
            string word = "";
            List<string> list = new List<string>();
            // 
            foreach(char c in pnom)
            {
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }
                if (c == '+')
                {
                    list.Add(word);
                    word = "";
                }
                word += c;

            }
            foreach(string i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(text.ToString());

            Console.WriteLine("trees");


            int power = pnom.IndexOf("^");

            for (int i = 0; i < pnom.Length; i++)
            {

            }

            List<int> powers = new List<int>();

            
           


            Console.WriteLine(powers);

            int[] order = new int[] { };


            Polynom rek = new Polynom(new int[0]);

            return rek;
        }

        public double Evaluate(int[] numbers, double variable)
        {     
            double sum = 0;
            sum += numbers[0] + (numbers[1] * variable);
            for (var i = 2; i < numbers.Length; i++)
            {
                sum += ( numbers[i] * Math.Pow(variable, i));
            }
            return sum;
        }


     

        public string PolynomToArray(string polystring)
        {
            var plusIndex = polystring.IndexOf('+');
            string[] split = polystring.Split('+');
            var split2 = new double[split.Length];
            var exponent = new string[split.Length];
            int coefficientIndex = 0;
            var powerIndex = 0;
            var final = "";

            foreach(string c in split)
            {
                if (!c.Contains('^') && !c.Contains('x'))
                {
                    exponent[0] = c;
                } else if(!c.Contains('^') && c.Contains('x'))
                {
                    exponent[1] = c;
                }
                else
                {
                    powerIndex = c.IndexOf('^') + 1;
                    string result = c.Substring(powerIndex);
                    exponent[int.Parse(result)] = c;                    
                }                
            }

            for (int a = 1; a < exponent.Length; a++)
            {                
                coefficientIndex = exponent[a].IndexOf('x');
                exponent[a] = exponent[a].Remove(coefficientIndex);
                Console.WriteLine($"this is exponent with out x {exponent[a]}");
            }

            foreach (string i in exponent)
            {
                final += i;
                Console.WriteLine($"this is after parsing {i}");
            }



            return final;
        }
    }
}
