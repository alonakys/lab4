using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace lab4
{
    class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger nominative, denominative;
        public BigInteger Nominative
        {
            get
            {
                return nominative;
            }
        }
        public BigInteger Denominative
        {
            get
            {
                return denominative;
            }
        }

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            if (denom < 0)
            {
                nom *= -1;
                denom *= -1;
            }
            nominative = nom;
            denominative = denom;
        }

        public MyFrac(int nom, int denom) : this(new BigInteger(nom), new BigInteger(denom))
        {
            SimplifyFrac();
        }
        private void SimplifyFrac()
        {
            BigInteger comdiv = BigInteger.GreatestCommonDivisor(nominative, denominative);
            nominative /= comdiv;
            denominative /= comdiv;
        }
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.nominative * that.denominative + that.nominative * this.denominative, this.denominative * that.denominative);
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.nominative * that.denominative - that.nominative * this.denominative, this.denominative * that.denominative);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.nominative * that.denominative, this.denominative * that.denominative);
        }

        public MyFrac Divide(MyFrac that)
        {
            BigInteger newDenominative = this.denominative * that.nominative;
            if (newDenominative == 0)
            {
                throw new System.DivideByZeroException("Cannot divide by zero.");
            }

            return new MyFrac(this.nominative * that.denominative, newDenominative);
        }

        public int CompareTo(MyFrac other)
        {
            decimal thisValue = (decimal)this.nominative / (decimal)this.denominative;
            decimal otherValue = (decimal)this.nominative / (decimal)this.denominative;

            return thisValue.CompareTo(otherValue);
        }
        public override string ToString()
        {
            return $"{nominative}/{denominative}";
        }
    }

    
}
