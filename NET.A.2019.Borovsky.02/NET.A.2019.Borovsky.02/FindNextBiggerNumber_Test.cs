using NUnit.Framework;

namespace NET.A._2019.Borovsky._02
{
    [TestFixture]
    class FindNextBiggerNumber_Test
    {
        [TestCase]
        public void FindNextBiggerNumber1()
        {
            FindNextBiggerNumber fnbn = new FindNextBiggerNumber();
            Assert.AreEqual(21, fnbn.FNBN(12));
        }

        [TestCase]
        public void FindNextBiggerNumber2()
        {
            FindNextBiggerNumber fnbn = new FindNextBiggerNumber();
            Assert.AreEqual(1241233, fnbn.FNBN(1234321));
        }

        [TestCase]
        public void FindNextBiggerNumber3()
        {
            FindNextBiggerNumber fnbn = new FindNextBiggerNumber();
            Assert.AreEqual(3462345, fnbn.FNBN(3456432));
        }
    }
}
