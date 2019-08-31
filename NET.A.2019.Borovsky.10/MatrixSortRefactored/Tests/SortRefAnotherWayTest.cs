using NUnit.Framework;
using Matrix;

namespace Tests
{
    public class SortRefAnotherWayTest
    {
        [TestCase(new int[] { 1, 2, 3, 5 }, new int[] { 4, 6, 8 }, new int[] { 20, 12, 15 }, new int[] { 10, 21, 13 }, ExpectedResult = new int[] { 20, 10, 4, 1 })]
        public static int[] ToLowSumTest(int[] subArr0, int[] subArr1, int[] subArr2, int[] subArr3)
        {
            int[][] jaggedArr = new int[4][];
            jaggedArr[0] = subArr0;
            jaggedArr[1] = subArr1;
            jaggedArr[2] = subArr2;
            jaggedArr[3] = subArr3;

            SortRefAnotherWay.SortToLowSum(jaggedArr);

            int[] result = new int[jaggedArr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = jaggedArr[i][0];
            }


            return result;
        }

        [TestCase(new int[] { 1, 2, 3, 5 }, new int[] { 4, 6, 8 }, new int[] { 20, 12, 15 }, new int[] { 10, 21, 13 }, ExpectedResult = new int[] { 1, 4, 10, 20 })]
        public static int[] ToHighSumTest(int[] subArr0, int[] subArr1, int[] subArr2, int[] subArr3)
        {
            int[][] jaggedArr = new int[4][];
            jaggedArr[0] = subArr0;
            jaggedArr[1] = subArr1;
            jaggedArr[2] = subArr2;
            jaggedArr[3] = subArr3;

            SortRefAnotherWay.SortToHighSum(jaggedArr);

            int[] result = new int[jaggedArr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = jaggedArr[i][0];
            }


            return result;
        }

        [TestCase(new int[] { 1, 2, 3, 5 }, new int[] { 4, 6, 8 }, new int[] { 20, 12, 15 }, new int[] { 10, 21, 13 }, ExpectedResult = new int[] { 1, 4, 20, 10 })]
        public static int[] ToHighMaxTest(int[] subArr0, int[] subArr1, int[] subArr2, int[] subArr3)
        {
            int[][] jaggedArr = new int[4][];
            jaggedArr[0] = subArr0;
            jaggedArr[1] = subArr1;
            jaggedArr[2] = subArr2;
            jaggedArr[3] = subArr3;

            SortRefAnotherWay.SortToHighMax(jaggedArr);

            int[] result = new int[jaggedArr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = jaggedArr[i][0];
            }


            return result;
        }

        [TestCase(new int[] { 1, 2, 3, 5 }, new int[] { 4, 6, 8 }, new int[] { 20, 12, 15 }, new int[] { 10, 21, 13 }, ExpectedResult = new int[] { 10, 20, 4, 1 })]
        public static int[] ToLowMaxTest(int[] subArr0, int[] subArr1, int[] subArr2, int[] subArr3)
        {
            int[][] jaggedArr = new int[4][];
            jaggedArr[0] = subArr0;
            jaggedArr[1] = subArr1;
            jaggedArr[2] = subArr2;
            jaggedArr[3] = subArr3;

            SortRefAnotherWay.SortToLowMax(jaggedArr);

            int[] result = new int[jaggedArr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = jaggedArr[i][0];
            }


            return result;
        }

        [TestCase(new int[] { 1, 2, 3, 5 }, new int[] { 4, 6, 8 }, new int[] { 20, 12, 15 }, new int[] { 10, 21, 13 }, ExpectedResult = new int[] { 1, 4, 10, 20 })]
        public static int[] ToHighMinTest(int[] subArr0, int[] subArr1, int[] subArr2, int[] subArr3)
        {
            int[][] jaggedArr = new int[4][];
            jaggedArr[0] = subArr0;
            jaggedArr[1] = subArr1;
            jaggedArr[2] = subArr2;
            jaggedArr[3] = subArr3;

            SortRefAnotherWay.SortToHighMin(jaggedArr);

            int[] result = new int[jaggedArr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = jaggedArr[i][0];
            }


            return result;
        }

        [TestCase(new int[] { 1, 2, 3, 5 }, new int[] { 4, 6, 8 }, new int[] { 20, 12, 15 }, new int[] { 10, 21, 13 }, ExpectedResult = new int[] { 20, 10, 4, 1 })]
        public static int[] ToLowMinTest(int[] subArr0, int[] subArr1, int[] subArr2, int[] subArr3)
        {
            int[][] jaggedArr = new int[4][];
            jaggedArr[0] = subArr0;
            jaggedArr[1] = subArr1;
            jaggedArr[2] = subArr2;
            jaggedArr[3] = subArr3;

            SortRefAnotherWay.SortToLowMin(jaggedArr);

            int[] result = new int[jaggedArr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = jaggedArr[i][0];
            }

            return result;
        }
    }
}
