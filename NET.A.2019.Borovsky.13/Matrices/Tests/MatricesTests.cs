using NUnit.Framework;
using HomeWork13;

namespace Tests
{
    class MatricesTests
    {
        public class MatricesTest
        {
            [TestCaseSource("MatricesAddCases")]
            public void MatricesAddTest(SquareMatrix<int> argument1, SquareMatrix<int> argument2, int[][] expected)
            {
                Assert.AreEqual(expected, argument1 + argument2);
            }

            static object[] MatricesAddCases =
            {
                new object[] { new SquareMatrix<int>(new int[][] { new int[] { 1, 2, 3 },
                                                                    new int[] { 5, 6, 7 },
                                                                    new int[] { 9, 10, 11 } }),

                                new SymmetricMatrix<int>(new int[][] { new int[] { 1, 4, 9 },
                                                                        new int[] { 4, 6, 7 },
                                                                        new int[] { 9, 7, 11 } }),

                                    new int[][] { new int[] { 2, 6, 12 },
                                                    new int[] { 9, 12, 14 },
                                                    new int[] { 18, 17, 22 }}},

                new object[] { new DiagonalMatrix<int>(new int[][] { new int[] { 11, 0, 0 },
                                                                    new int[] { 0, 15, 0 },
                                                                    new int[] { 0, 0, 8 } }),

                                new SymmetricMatrix<int>(new int[][] { new int[] { 1, 4, 9 },
                                                                        new int[] { 4, 6, 7 },
                                                                        new int[] { 9, 7, 11 } }),

                                    new int[][] { new int[] { 12, 4, 9 },
                                                    new int[] { 4, 21, 7 },
                                                    new int[] { 9, 7, 19 }}}
};
        }
    }
}
