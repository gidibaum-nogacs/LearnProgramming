using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PolynomCalculator
{
    public partial class Form1 : Form
    {
        readonly PolynomService _PolynomService;
      
        

        public Form1()
        {
            var p = new PolynomService();
            _PolynomService = p;

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
       
            

            if (e.KeyChar == (char)Keys.Return)
            {
                



                var text = this.textBox1.Text;

                int[] numbers = _PolynomService.InputToArray(text);

                
                Polynom p = new Polynom(numbers);
               
                var res = p.ToString();

                Console.WriteLine(res);

                label5.Text = res;
            }           
        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            


        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = this.textBox1.Text;

            int[] numbers = _PolynomService.InputToArray(text);


            Polynom p = new Polynom(numbers);

            var res = p.ToString();

            Console.WriteLine(res);

            label5.Text = res;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var textA = this.textBox3.Text;
            var textB = this.textBox2.Text;
            int[] numbers0 = _PolynomService.InputToArray(textA);
            int[] numbers1 = _PolynomService.InputToArray(textB);
            Polynom p0 = new Polynom(numbers0);
            Polynom p1 = new Polynom(numbers1);

            var p = p0 - p1;

            Console.WriteLine(p.ToString());
            label4.Text = p.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var textA = this.textBox3.Text;
            var textB = this.textBox2.Text;
            int[] numbers0 = _PolynomService.InputToArray(textA);
            int[] numbers1 = _PolynomService.InputToArray(textB);
            Polynom p0 = new Polynom(numbers0);
            Polynom p1 = new Polynom(numbers1);

            var p = p0 + p1;

            Console.WriteLine(p.ToString());
            label4.Text = p.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var textA = this.textBox3.Text;
            var textB = this.textBox2.Text;
            int[] numbers0 = _PolynomService.InputToArray(textA);
            int[] numbers1 = _PolynomService.InputToArray(textB);
            Polynom p0 = new Polynom(numbers0);
            Polynom p1 = new Polynom(numbers1);

            var p = p0 * p1;

            Console.WriteLine(p.ToString());
            label4.Text = p.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string clear = "";
            textBox1.Text = clear;
            textBox2.Text = clear;
            textBox3.Text = clear;
            textBox4.Text = clear;
            label4.Text = clear;
            label5.Text = clear;
            label7.Text = clear;
            label8.Text = clear;
            textBox5.Text = clear;
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string polystring = textBox5.Text;
            label8.Text = _PolynomService.PolynomToArray(polystring);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                double variable = double.Parse(textBox4.Text);
                var text = this.textBox1.Text;
                int[] numbers = _PolynomService.InputToArray(text);
                //double variable = 4;

                //var numbers = new int[2] { 3, 2 };


                label7.Text = $"{_PolynomService.Evaluate(numbers, variable)}";
            } catch
            {
                label7.Text = "x must be a number";
            }
                
           





        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
