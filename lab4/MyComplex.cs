using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class MyComplex : IMyNumber<MyComplex>
    {
        double re, im;
        public double Real { get { return re; } }
        public double Imagionary { get { return im; } }

        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.re + that.re, this.im + that.im);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.re - that.re, this.im - that.im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            double newRe = this.re * that.re - this.im * that.im;
            double newIm = this.re * that.im + this.im * that.re;
            return new MyComplex(newRe, newIm);
        }

        public MyComplex Divide(MyComplex that)
        {
            double div = (Math.Pow(that.re, 2) + Math.Pow(that.im, 2));
            if (div == 0)
            {
                throw new System.DivideByZeroException("Cannot divide by zero.");
            }

            double newRe = this.re * that.re + this.im * that.im / div;
            double newIm = this.im * that.re - this.re * that.im / div;
            return new MyComplex(newRe, newIm);
        }

        public override string ToString()
        {
            if (im<0)
            {
                return $"{re}-{-im}i";
            }
            else
            {
                return $"{re}+{im}i";
            }
        }
    }
}
