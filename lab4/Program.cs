using System;
using System.Collections.Generic;

namespace lab4
{
    class Program
    {
        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b)^2=a^2-2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);
            Console.WriteLine("(a-b)^2 = " + aMinusB.Multiply(aMinusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Subtract(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2-2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a-b)^2=a^2-2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }
        static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b)=(a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");
            T aSubtractB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aSubtractB);
            Console.WriteLine(" = = = ");

            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);

            wholeRightPart = wholeRightPart.Subtract(curr);
            Console.WriteLine("a^2-b^2 = " + wholeRightPart);
            curr = a.Add(b);
            Console.WriteLine("a+b = " + curr);

            wholeRightPart = wholeRightPart.Divide(curr);
            Console.WriteLine("(a^2-b^2)/(a+b) = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a-b)=(a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");
        }
        static void Main(string[] args)
        {
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            TestSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
            TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

            MyFrac[] fracs = { new MyFrac(1, 3), new MyFrac(1, 2), new MyFrac(1, 4), new MyFrac(4, 5), new MyFrac(7, 1), new MyFrac(0, 5), new MyFrac(15, 5) };
            Array.Sort(fracs);

            Console.WriteLine("\nSorted fractions:");
            foreach (var fraction in fracs)
            {
                Console.WriteLine(fraction);
            }

        }
    }
}
