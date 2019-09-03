using HomeWork12;
using NUnit.Framework;

namespace Tests
{
    public class BinaryTest
    {
        [TestCase(new int[] { 3, 5, 1, 7, 8, 9, 6, 4, 5 }, 99, ExpectedResult = false)]
        public static bool BinarySearchTest(int[] arr, int search)
        {
            return BSearch.BinarySearch(arr, search);
        }

        [TestCase(new double[] { 3.1, 5.2, 1.3, 7.4, 8.6, 9.5, 6.8, 4.0, 5.3 }, 4.0, ExpectedResult = true)]
        public static bool BinarySearchTest(double[] arr, double search)
        {
            return BSearch.BinarySearch(arr, search);
        }

        [TestCase(new uint[] { 3, 5, 1, 7, 8, 9, 6, 4, 5 }, (uint)1, ExpectedResult = true)]
        public static bool BinarySearchTest(uint[] arr, uint search)
        {
            return BSearch.BinarySearch(arr, search);
        }

        [TestCase(new byte[] { 3, 5, 1, 7, 8, 9, 6, 4, 5 }, 19, ExpectedResult = false)]
        public static bool BinarySearchTest(byte[] arr, byte search)
        {
            return BSearch.BinarySearch(arr, search);
        }

        [TestCase(new long[] { 564, 4, 9, 8, 651, 8, 984, 65, 16, 198, 495, 1 }, 984, ExpectedResult = true)]
        public static bool BinarySearchTest(long[] arr, long search)
        {
            return BSearch.BinarySearch(arr, search);
        }
    }
}