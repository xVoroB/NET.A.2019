using NUnit.Framework;
using System.Collections.Generic;

namespace NET.A._2019.Borovsky._02
{
    [TestFixture]
    class FilterDigit_Test
    {
        [TestCase]
        public void FilterDigit1()
        {
            FilterDigit fil = new FilterDigit();
            List<int> one = new List<int> { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            List<int> res = new List<int> { 7, 70, 17 };
            Assert.AreEqual(res, fil.FilDig(one));
        }

        [TestCase]
        public void FilterDigit2()
        {
            FilterDigit fil = new FilterDigit();
            List<int> one = new List<int> { 5, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            List<int> res = new List<int> { 5, 15 };
            Assert.AreEqual(res, fil.FilDig(one));
        }

        [TestCase]
        public void FilterDigit3()
        {
            FilterDigit fil = new FilterDigit();
            List<int> one = new List<int> { 6, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            List<int> res = new List<int> { 6, 68, 69 };
            Assert.AreEqual(res, fil.FilDig(one));
        }
    }
}
