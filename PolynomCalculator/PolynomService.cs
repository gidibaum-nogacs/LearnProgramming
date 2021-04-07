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
                if (char.IsDigit(i))
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
    }
}
