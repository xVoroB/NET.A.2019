using NUnit.Framework;
using Poly;

namespace Tests
{
    public class Tests
    {
        [TestCase(new double[] { 4, 1, 21, 0, 5 }, ExpectedResult = "5*x^4 + 21*x^2 + 1*x^1 + 4")]
        [TestCase(new double[] { -44, -15, -6, 6, -5 }, ExpectedResult = "- 5*x^4 + 6*x^3 - 6*x^2 - 15*x^1 - 44")]
        [TestCase(new double[] { 0, 0, 6 }, ExpectedResult = "6*x^2")]
        public static string ToStringTest(double[] coeffs)
        {
            var p = new Polynomial(coeffs);
            return p.ToString();
        }

        [TestCase(new double[] { -44, -15, -6, 6, -5 }, new double[] { -44, -15, -6, 6, -5 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 3, 2, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2.001, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, -3 }, ExpectedResult = false)]
        public static bool EqualTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            var p1 = new Polynomial(firstCoeffs);
            var p2 = new Polynomial(secondCoeffs);
            return p1.Equals(p2);
        }

        [TestCase(new double[] { 3, 5, 7 }, new double[] { 1, 2, 3 }, ExpectedResult = new double[] { 4, 7, 10 })]
        [TestCase(new double[] { 3, 5, 7, 8 }, new double[] { 1, 2, 3 }, ExpectedResult = new double[] { 4, 7, 10, 8 })]
        public static double[] SumTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            var p1 = new Polynomial(firstCoeffs);
            var p2 = new Polynomial(secondCoeffs);
            var p3 = p1 + p2;
            return p3.GetCoeffs();
        }

        [TestCase(new double[] { 1.25, 2, 3.55 }, new double[] { 1.25, 2, 3.55 }, ExpectedResult = true)]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 0, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, int.MinValue }, new double[] { 0, int.MinValue }, ExpectedResult = true)]
        public static bool EqualOperatorTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            var p1 = new Polynomial(firstCoeffs);
            var p2 = new Polynomial(secondCoeffs);
            return p1 == p2;
        }

        [TestCase(new double[] { 1.25, 2, 3.55 }, new double[] { 1.25, 2, 3.55 }, ExpectedResult = false)]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 0, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, int.MinValue }, new double[] { 0, int.MinValue }, ExpectedResult = false)]
        public static bool NotEqualTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            var p1 = new Polynomial(firstCoeffs);
            var p2 = new Polynomial(secondCoeffs);
            return p1 != p2;
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 2, 3, 4 }, ExpectedResult = new double[] { 2, 7, 16, 17, 12 })]
        [TestCase(new double[] { 1, 2 }, new double[] { 1, 2, 3 }, ExpectedResult = new double[] { 1, 4, 7, 6 })]
        public static double[] MultiplierPP_Test(double[] firstCoeffs, double[] secondCoeffs)
        {
            var p1 = new Polynomial(firstCoeffs);
            var p2 = new Polynomial(secondCoeffs);
            var p3 = p1 * p2;
            return p3.GetCoeffs();
        }

        [TestCase(new double[] { 1, 2, 3 }, 6.0, ExpectedResult = new double[] { 6, 12, 18 })]
        [TestCase(new double[] { 0.0, 2.5, 100 }, 0.5, ExpectedResult = new double[] { 0, 1.25, 50 })]
        public static double[] MultiplierPN_Test(double[] firstCoeffs, double multiplier)
        {
            var p1 = new Polynomial(firstCoeffs);
            var p2 = p1 * multiplier;
            return p2.GetCoeffs();
        }

        [TestCase(new double[] { -2, 5, double.MinValue }, new double[] { -2.5, 7, -(double.MaxValue) }, ExpectedResult = new double[] { 0.5, -2, 0 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 2, 3, 4 }, ExpectedResult = new double[] { -1, -1, -1 })]
        public static double[] SubstractionTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            var p1 = new Polynomial(firstCoeffs);
            var p2 = new Polynomial(secondCoeffs);
            var p3 = p1 - p2;
            return p3.GetCoeffs();
        }

        
    }
}