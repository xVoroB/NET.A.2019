using NUnit.Framework;

namespace NET.A._2019.Borovsky._02
{
    [TestFixture]
    class FindNthRoot_Test
    {
        [TestCase]
        public void FindNthRoot1()
        {
            FindNthRoot fnr = new FindNthRoot();
            Assert.AreEqual(3.4025, fnr.NthRoot(456, 5, 0.0001));
        }

        [TestCase]
        public void FindNthRoot2()
        {
            FindNthRoot fnr = new FindNthRoot();
            Assert.AreEqual(0.6, fnr.NthRoot(0.0279936, 7, 0.0001));
        }

        [TestCase]
        public void FindNthRoot3()
        {
            FindNthRoot fnr = new FindNthRoot();
            Assert.AreEqual(0.545, fnr.NthRoot(0.004241979, 9, 0.00000001));
        }
    }
}
