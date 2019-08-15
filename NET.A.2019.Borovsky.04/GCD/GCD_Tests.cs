using NUnit.Framework;
using GCD;

namespace Tests
{
    public class GCD_Tests
    {
        [TestCase(116298, 461952, 461934, -54, 117288, ExpectedResult = 18)]
        [TestCase(461934, 54, 116298, 461952, 0, ExpectedResult = 0)]
        [TestCase(461952, ExpectedResult = 461952)]
        public int GCD_EuclideanTest(params int[] a)
        {
            return GCD_Calculations.Euclidean(a);
        }

        [TestCase(116298, 461952, 461934, -54, 117288, ExpectedResult = 18)]
        [TestCase(461934, 54, 116298, 461952, 0, ExpectedResult = 0)]
        [TestCase(461952, ExpectedResult = 461952)]
        public int GCD_BinaryTest(params int[] a)
        {
            return GCD_Calculations.Binary(a);
        }
    }
}