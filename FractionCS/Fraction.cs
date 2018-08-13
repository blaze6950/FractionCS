using System;
using System.Numerics;

namespace FractionCS
{
    /*
     public static тип operator знак(параметры);
     
     */
    class Fraction
    {
        public int Numerator { get; set; }

        int _denominator = 1;
        public int Denominator
        {
            get { return _denominator; }
            set 
            {
                if (value == 0)
                    throw new DivideByZeroException();

                _denominator = value; 
            }          
        }

        public Fraction(){}

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException();
 
            Numerator = numerator;
            Denominator = denominator;
        }

        public void Optimization()
        {
            int ccd = (Int32)BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= ccd;
            Denominator /= ccd;
        }

        public static Fraction operator- (Fraction fr)
        {
            Fraction res = new Fraction();
            res.Numerator = -fr.Numerator;
            res.Denominator = fr.Denominator;

            return res;
        }

        public static Fraction operator* (Fraction op1, Fraction op2)
        {
            Fraction res = new Fraction();
            res.Numerator = op1.Numerator * op2.Numerator;
            res.Denominator = op1.Denominator * op2.Denominator;
            res.Optimization();
            return res;
        }

        public static Fraction operator *(Fraction op1, int op2)
        {
            Fraction res = new Fraction();
            res.Numerator = op1.Numerator * op2;
            res.Denominator = op1.Denominator;

            res.Optimization();
            return res;
        }

        public static Fraction operator *(int op1, Fraction op2)
        {
            Fraction res = new Fraction();
            res.Numerator = op1 * op2.Numerator;
            res.Denominator = op2.Denominator;

            res.Optimization();
            return res;
        }

        public static Fraction operator /(Fraction op1, Fraction op2)
        {
            Fraction res = new Fraction();
            res.Numerator = op1.Numerator * op2.Denominator;
            res.Denominator = op1.Denominator * op2.Numerator;
            res.Optimization();
            return res;
        }

        public static Fraction operator /(Fraction op1, int op2)
        {
            Fraction res = new Fraction();
            res.Numerator = op1.Numerator;
            res.Denominator = op1.Denominator * op2;

            res.Optimization();
            return res;
        }

        public static Fraction operator /(int op1, Fraction op2)
        {
            Fraction res = new Fraction();
            res.Numerator = op2.Numerator;
            res.Denominator = op1 * op2.Denominator;

            res.Optimization();
            return res;
        }

        public static bool operator >(Fraction op1, Fraction op2)
        {
            if (op1 == null || op2 == null)
            {
                return false;
            }
            return op1.Numerator > op2.Numerator && op1.Denominator > op2.Denominator;
        }

        public static bool operator <(Fraction op1, Fraction op2)
        {
            if (op1 == null || op2 == null)
            {
                return false;
            }
            return op1.Numerator < op2.Numerator && op1.Denominator < op2.Denominator;
        }

        public static bool operator==(Fraction op1, Fraction op2)
        {
            return op2 != null && (op1 != null && (op1.Numerator == op2.Numerator
                                                   && op1.Denominator == op2.Denominator));
        }

        public static bool operator <=(Fraction op1, Fraction op2)
        {
            if (op1 == null || op2 == null)
            {
                return false;
            }
            return op1.Numerator == op2.Numerator && op1.Denominator == op2.Denominator || op1.Numerator < op2.Numerator && op1.Denominator < op2.Denominator;
        }

        public static bool operator >=(Fraction op1, Fraction op2)
        {
            if (op1 == null || op2 == null)
            {
                return false;
            }
            return op1.Numerator == op2.Numerator && op1.Denominator == op2.Denominator || op1.Numerator > op2.Numerator && op1.Denominator > op2.Denominator;
        }

        public static bool operator !=(Fraction op1, Fraction op2)
        {
            return op2 != null && (op1 != null && (op1.Numerator != op2.Numerator
                                                   || op1.Denominator != op2.Denominator));
        }

        public static Fraction operator++ (Fraction op)
        {
            Fraction res = new Fraction();
            res.Numerator = op.Numerator + op.Denominator;
            res.Denominator = op.Denominator;

            res.Optimization();
            return res;
        }

        public static Fraction operator --(Fraction op)
        {
            Fraction res = new Fraction();
            res.Numerator = op.Numerator - op.Denominator;
            res.Denominator = op.Denominator;

            res.Optimization();
            return res;
        }

        public static bool operator true(Fraction f)
        {
            return f.Numerator != 0;
        }

        public static bool operator false(Fraction f)
        {
            return f.Numerator == 0;
        }


        //public static explicit | implicit operator type_dest(type_src name)
        public static explicit operator int (Fraction f)
        {
            return f.Numerator / f.Denominator;
        }

        public static implicit operator Fraction(int num)
        {
            return new Fraction(num, 1);
        }

        public override string ToString()
        {
            return String.Format("{0} / {1}", Numerator, Denominator);
        }

        public override bool Equals(object obj)
        {
            Fraction fr = obj as Fraction;
            if (obj == null || fr == null )
                return false;


            return Numerator == fr.Numerator
                && Denominator == fr.Denominator;
        }

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => Numerator ^ Denominator;
    }
}
