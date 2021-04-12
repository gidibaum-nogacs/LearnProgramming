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
            string[] split = polystring.Split('+');
            var exponent = new string[split.Length];
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
                    int powerIndex = c.IndexOf('^') + 1;
                    string result = c.Substring(powerIndex);
                    exponent[int.Parse(result)] = c;
                }                
            }

            for (int a = 1; a < exponent.Length; a++)
            {
                int coefficientIndex = exponent[a].IndexOf('x');
                exponent[a] = exponent[a].Remove(coefficientIndex);
                Console.WriteLine($"exponent with out x {exponent[a]}");
            }

            foreach (string i in exponent)
            {
                final += i;
                Console.WriteLine($"this is after parsing {i}");
            }

            return final;
        }

        //1 + 2x  + 3x^2  + 4x^3  + 5x^4  + 6x^5  + 7x^6 

        public void PolynomToArrayUsingDictionary(string polystring)
        {
            var stray = polystring.Split('+');
            var powerindex = 0;
            double coefficient = 0;
            var exponentDict = new Dictionary<int, double>();


            foreach(string i in stray)
            {
                if(!i.Contains('^') && !i.Contains('x'))
                {
                    powerindex = 0;
                }

                else if (!i.Contains('^') && i.Contains('x'))
                {
                    powerindex = 1;
                }

                else if (i.Contains('^'))
                {
                    powerindex = i.IndexOf('^') + 1;
                    coefficient = double.Parse(i.Substring(0,(powerindex-1)));
                    exponentDict.Add(powerindex, coefficient);
                }
            }


            string pattern = @"\d";
            // Create a Regex  
            Regex rg = new Regex(pattern);

            // Long string  
            string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";
            // Get all matches  
            MatchCollection matchedAuthors = rg.Matches(authors);

        }
    }
}
