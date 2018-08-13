using System;
using System.Text;

namespace FractionCS
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Fraction fr1 = new Fraction(1, 2);
            Console.WriteLine("{0} / {1}" , fr1.Numerator, fr1.Denominator);

            try
            {
                Fraction fr2 = new Fraction(2, 0);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Fraction fr3 = -fr1;
            Console.WriteLine("{0} / {1}", fr3.Numerator, fr3.Denominator);

            fr3.Numerator = 1;
            fr3.Denominator = 3;

            Fraction fr4 = fr1 * fr3;
            Console.WriteLine("{0} / {1}", fr4.Numerator, fr4.Denominator);

            fr4 = fr1 * 3;
            Console.WriteLine("{0} / {1}", fr4.Numerator, fr4.Denominator);

            fr4 = 3 * fr3;
            Console.WriteLine("{0} / {1}", fr4.Numerator, fr4.Denominator);

            fr3 *= 3;
            Console.WriteLine("f3 = {0} / {1}", fr3.Numerator, fr3.Denominator);

            if(fr4 != fr3)
            {
                Console.WriteLine("fr4 != fr3");
            }

            Console.WriteLine("Operator ++");
            Console.WriteLine("fr1 = {0} / {1}", fr1.Numerator, fr1.Denominator);
            fr4 = fr1++;
            Console.WriteLine("fr1 = {0} / {1}", fr1.Numerator, fr1.Denominator);
            Console.WriteLine("fr4 = {0} / {1}", fr4.Numerator, fr4.Denominator);

            if(fr4)
            {
                Console.WriteLine("fr4 is true");
            }
            else 
            {
                Console.WriteLine("fr4 is false");
            }

            int a = (int)fr4;
            Console.WriteLine("fr4 to int => {0}", a);

            Fraction fr5 = 5;
            Console.WriteLine("fr5 = {0}", fr5); //fr5.ToString();
            Console.WriteLine(fr5.ToString());
        
        }
    }
}
